using Domain;
using Enums;
using SL.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.UC.FilterGrid;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Caracteristicas : FilterGrid_ABMGrid<Caracteristica>
    {
        protected Label lbl_Nombre, lbl_Color;
        protected TextBox txt_Nombre;
        protected ComboBox combo_Color;

        protected Button but_Habilitar, but_Deshabilitar;
        public ABM_Caracteristicas()
        {
            datasource_configuration = x => new 
            { 
                Nombre = x.Nombre, 
                Color = (x.Color == null) ? null : ((ColorBasico)((Color)x.Color).ToColorBasico()).GetDescription().Translate()
            };

            servicio = BLL.Services.CaracteristicaService.Current;
            InitializeComponent();
            SetupAll();
        }
        void SetupAll()
        {
            SetupFiltros();
            SetupButtons();
        }
        void SetupFiltros()
        {
            lbl_Nombre = new Label() { Text = "Nombre:" };
            txt_Nombre = new TextBox();
            txt_Nombre.TextChanged += Txt_Nombre_TextChanged;

            lbl_Color = new Label() { Text = "Color:" };
            combo_Color = new ComboBox()
            {
                DataSource = new ColorBasico().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Color.SelectedIndexChanged += Combo_Color_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Nombre, 0, 1);
            flow_Filtros.Controls.Add(txt_Nombre, 1, 1);
            flow_Filtros.Controls.Add(lbl_Color, 0, 2);
            flow_Filtros.Controls.Add(combo_Color, 1, 2);
        }
        void SetupButtons()
        {
            /*but_Habilitar = new DarkButton() { Text = "Habilitar", Anchor = AnchorStyles.Left };
            but_Habilitar.Click += But_Habilitar_Click;

            but_Deshabilitar = new DarkButton() { Text = "Deshabilitar", Anchor = AnchorStyles.Left };
            but_Deshabilitar.Click += But_Deshabilitar_Click;

            flow_Buttons.Controls.Add(but_Habilitar, 3, 0);
            flow_Buttons.Controls.Add(but_Deshabilitar, 4, 0);*/
        }
        private void Combo_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Color.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<ColorBasico>(combo_Color.SelectedIndex);

            SetFilter(combo_Color, x =>
            x.Color != null &&
            ((Color)x.Color).ToColorBasico() == enumValue);
        }
        private void Txt_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Nombre.Text))
            {
                RemoveFilter(txt_Nombre);
                return;
            }

            var txt = txt_Nombre.Text.Normalize().ToLower();

            SetFilter(txt_Nombre, x =>
            x.Nombre.Normalize().ToLower().Contains(txt));
        }
    }
}
