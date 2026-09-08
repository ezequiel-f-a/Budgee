using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_TransaccionesConcretadas : ABM_Transacciones
    {
        public ABM_TransaccionesConcretadas()
        {
            talonario = new Talonario_Transaccion(true);
            InitializeComponent();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Concretada == true && x.Cuenta.Habilitada == true && x.Cuenta.Estado == true && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderByDescending(x => x.Fecha).ThenBy(x => x.Descripcion).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
