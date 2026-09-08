using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using UI.Forms.Talonarios;

namespace UI.Forms.SeleccionarElems
{
    public partial class SeleccionarElem_Etiqueta : f_SeleccionarElem<Caracteristica>
    {
        public SeleccionarElem_Etiqueta(IEnumerable<Caracteristica> not_in = null) : base(not_in, tieneVerDetalle: false)
        {
            datasource_configuration = x => new
            {
                Nombre = x.Nombre,
                Color = (x.Color == null) ? null : ((ColorBasico)((Color)x.Color).ToColorBasico()).GetDescription().Translate()
            };

            InitializeComponent();
            this.Text = "Seleccionar Etiqueta";
            talonario = new Talonario_Etiqueta();
            servicio = BLL.Services.CaracteristicaService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Tipo_Caracteristica == Enums.Tipo_Caracteristica.Etiqueta && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_Caracteristica).Contains(x.ID_Caracteristica)).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
