using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Etiquetas : ABM_Caracteristicas
    {
        public ABM_Etiquetas()
        {
            InitializeComponent();
            talonario = new Talonario_Etiqueta();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Tipo_Caracteristica == Tipo_Caracteristica.Etiqueta && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderBy(x => x.Nombre).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
