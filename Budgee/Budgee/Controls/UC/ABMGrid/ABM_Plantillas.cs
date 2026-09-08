using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows;
using UI.Controls.UC.ABMGrids;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrid
{
    public partial class ABM_Plantillas : ABM_GenericTransacciones<PlantillaTransaccion>
    {
        public ABM_Plantillas()
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                x.Categoria,
                Etiquetas = String.Join(", ", x.Etiquetas),
                TipoOperacion = (x.TipoOperacion != null) ? ((Tipo_Operacion)x.TipoOperacion).GetDescription().Translate() : null,
                MontoExpresion = x.MontoExpresion
            };

            servicio = BLL.Services.PlantillaTransaccionService.Current;
            talonario = new Talonario_Plantilla();
            InitializeComponent();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderBy(x => x.Descripcion).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
