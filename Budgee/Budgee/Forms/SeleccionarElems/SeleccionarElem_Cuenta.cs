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
    public partial class SeleccionarElem_Cuenta : f_SeleccionarElem<Cuenta>
    {
        public SeleccionarElem_Cuenta(IEnumerable<Cuenta> not_in = null) : base(not_in)
        {
            InitializeComponent();
            this.Text = "Seleccionar Cuenta";
            talonario = new Talonario_Cuenta();
            servicio = BLL.Services.CuentaService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Habilitada == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_Cuenta).Contains(x.ID_Cuenta)).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
