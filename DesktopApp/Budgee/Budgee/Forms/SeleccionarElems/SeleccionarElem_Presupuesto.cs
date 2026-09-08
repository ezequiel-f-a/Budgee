using Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using UI.Forms.Talonarios;

namespace UI.Forms.SeleccionarElems
{
    public partial class SeleccionarElem_Presupuesto : f_SeleccionarElem<Presupuesto>
    {
        public SeleccionarElem_Presupuesto(IEnumerable<Presupuesto> not_in = null) : base(not_in)
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                VariableSupervisada = BLL.Services.VariableService.Current.GetDescription(x.VariableSupervisada),
                OperadorRelacional = x.OperadorRelacional.GetDescription().Translate(),
                x.CondicionExpresion,
                LapsoPresupuesto = (x.LapsoPresupuesto == null) ? null : SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(x.LapsoPresupuesto),
                CuandoChequear = x.CuandoChequear.GetDescription().Translate(),
                x.Habilitado
            };

            InitializeComponent();
            this.Text = "Seleccionar Presupuesto";
            talonario = new Talonario_Presupuesto();
            servicio = BLL.Services.PresupuestoService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Habilitado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_Presupuesto).Contains(x.ID_Presupuesto)).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
