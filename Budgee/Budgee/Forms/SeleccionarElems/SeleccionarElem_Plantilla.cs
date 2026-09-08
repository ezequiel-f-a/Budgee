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
    public partial class SeleccionarElem_Plantilla : f_SeleccionarElem<PlantillaTransaccion>
    {
        private Guid? ExceptObject { get; set; }
        public SeleccionarElem_Plantilla(IEnumerable<PlantillaTransaccion> not_in = null, Guid? except = null) : base(not_in)
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                x.Categoria,
                Etiquetas = String.Join(", ", x.Etiquetas),
                x.TipoOperacion,
                MontoExpresion = x.MontoExpresion
            };

            ExceptObject = except;

            InitializeComponent();
            this.Text = "Seleccionar Plantilla";
            talonario = new Talonario_Plantilla();
            servicio = BLL.Services.PlantillaTransaccionService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_PlantillaTransaccion).Contains(x.ID_PlantillaTransaccion)).ToList();
                if (ExceptObject != null) list = list.Where(x => x.ID_PlantillaTransaccion != (Guid)ExceptObject).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
