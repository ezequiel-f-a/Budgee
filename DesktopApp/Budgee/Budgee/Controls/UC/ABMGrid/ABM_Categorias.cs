using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Categorias : ABM_Caracteristicas
    {
        public ABM_Categorias()
        {
            InitializeComponent();
            talonario = new Talonario_Categoria();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Tipo_Caracteristica == Tipo_Caracteristica.Categoria && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderBy(x => x.Nombre).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
