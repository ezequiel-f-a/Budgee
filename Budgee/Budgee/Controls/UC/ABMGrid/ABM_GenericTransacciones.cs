using Domain;
using Enums;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.UC.FilterGrid;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_GenericTransacciones<T> : FilterGrid_ABMGrid<T> where T : GenericTransaccion
    {
        protected Label lbl_Descripcion, lbl_Etiqueta, lbl_Categoria, lbl_TipoOperacion;
        protected TextBox txt_Descripcion;
        protected ComboBox combo_Etiqueta, combo_Categoria, combo_TipoOperacion;
        protected List<Caracteristica> CategoriasDisponibles = new List<Caracteristica>();
        protected List<Caracteristica> EtiquetasDisponibles = new List<Caracteristica>();
        public ABM_GenericTransacciones()
        {
            InitializeComponent();
            SetupAll();
        }
        void SetupAll()
        {
            AddFiltros();
        }
        void AddFiltros()
        {
            lbl_Descripcion = new Label() { Text = "Descripción:" };
            txt_Descripcion = new TextBox();
            txt_Descripcion.TextChanged += txt_Descripcion_TextChanged;

            lbl_Etiqueta = new Label() { Text = "Etiqueta:" };
            combo_Etiqueta = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Etiqueta.SelectedIndexChanged += Combo_Etiqueta_SelectedIndexChanged;
            combo_Etiqueta.DropDown += Combo_etiqueta_DropDown;

            lbl_Categoria = new Label() { Text = "Categoría:" };
            combo_Categoria = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Categoria.SelectedIndexChanged += Combo_Categoria_SelectedIndexChanged;
            combo_Categoria.DropDown += Combo_categoria_DropDown;

            lbl_TipoOperacion = new Label() { Text = "Tipo Operación:" };
            combo_TipoOperacion = new ComboBox()
            {
                DataSource = new Tipo_Operacion().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_TipoOperacion.SelectedIndexChanged += Combo_tipoOperacion_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Etiqueta, 0, 1);
            flow_Filtros.Controls.Add(combo_Etiqueta, 1, 1);
            flow_Filtros.Controls.Add(lbl_Categoria, 2, 1);
            flow_Filtros.Controls.Add(combo_Categoria, 3, 1);
            flow_Filtros.Controls.Add(lbl_TipoOperacion, 4, 1);
            flow_Filtros.Controls.Add(combo_TipoOperacion, 5, 1);
            flow_Filtros.Controls.Add(lbl_Descripcion, 0, 0);
            flow_Filtros.Controls.Add(txt_Descripcion, 1, 0);
        }
        protected override void RefreshList()
        {
            CategoriasDisponibles = BLL.Services.CaracteristicaService.Current.GetAll(x => list.Select(y => y.Categoria?.ID_Caracteristica).Contains(x.ID_Caracteristica)).ToList();
            EtiquetasDisponibles = BLL.Services.CaracteristicaService.Current.GetAll(x => list.Select(y => y.Etiquetas.Select(z => z.ID_Caracteristica)).SelectMany(y => y).Contains(x.ID_Caracteristica)).ToList();
            base.RefreshList();
        }
        private void Combo_categoria_DropDown(object sender, EventArgs e)
        {
            combo_Categoria.SelectedIndexChanged -= Combo_Categoria_SelectedIndexChanged;
            int index = combo_Categoria.SelectedIndex;
            int count = combo_Categoria.Items.Count;
            combo_Categoria.DataSource = null;
            combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Categoria.Items.Count == count) combo_Categoria.SelectedIndex = index;
            combo_Categoria.SelectedIndexChanged += Combo_Categoria_SelectedIndexChanged;
        }
        private void Combo_etiqueta_DropDown(object sender, EventArgs e)
        {
            combo_Etiqueta.SelectedIndexChanged -= Combo_Etiqueta_SelectedIndexChanged;
            int index = combo_Etiqueta.SelectedIndex;
            int count = combo_Etiqueta.Items.Count;
            combo_Etiqueta.DataSource = null;
            combo_Etiqueta.DataSource = EtiquetasDisponibles.Select(x => x.Nombre).ToList();
            combo_Etiqueta.SelectedIndex = -1;
            if (combo_Etiqueta.Items.Count == count) combo_Etiqueta.SelectedIndex = index;
            combo_Etiqueta.SelectedIndexChanged += Combo_Etiqueta_SelectedIndexChanged;
        }
        private void Combo_tipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_TipoOperacion.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex);

            SetFilter(combo_TipoOperacion, x =>
            x.TipoOperacion == enumValue);
        }
        private void Combo_Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Categoria.SelectedIndex == -1) return;

            var id = CategoriasDisponibles[combo_Categoria.SelectedIndex].ID_Caracteristica;

            SetFilter(combo_Categoria, x =>
            x.Categoria?.ID_Caracteristica == id);
        }
        private void Combo_Etiqueta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Etiqueta.SelectedIndex == -1) return;

            var id = EtiquetasDisponibles[combo_Etiqueta.SelectedIndex].ID_Caracteristica;

            SetFilter(combo_Etiqueta, x =>
            x.Etiquetas.Select(y => y.ID_Caracteristica).Contains(id));
        }
        private void txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Descripcion.Text))
            {
                RemoveFilter(txt_Descripcion);
                return;
            }

            var txt = txt_Descripcion.Text.Normalize().ToLower();

            SetFilter(txt_Descripcion, x =>
            x.Descripcion.Normalize().ToLower().Contains(txt));
        }
    }
}
