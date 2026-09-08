using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.UC.FilterGrid;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Cuentas : FilterGrid_ABMGrid<Cuenta>
    {
        protected Label lbl_Nombre, lbl_Divisa, lbl_Estado;
        protected TextBox txt_Nombre;
        protected ComboBox combo_Divisa, combo_Estado;
        protected Button but_Habilitar, but_Deshabilitar;
        string[] enumHabilitado = new string[] { "Habilitada", "Deshabilitada" }.Translate();
        public ABM_Cuentas()
        {
            servicio = BLL.Services.CuentaService.Current;
            talonario = new Talonario_Cuenta();

            InitializeComponent();
            SetupAll();
        }

        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderBy(x => x.Nombre).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
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

            lbl_Divisa = new Label() { Text = "Divisa:" };
            combo_Divisa = new ComboBox()
            {
                DataSource = new Divisa().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Divisa.SelectedIndexChanged += Combo_Divisa_SelectedIndexChanged;

            lbl_Estado = new Label() { Text = "Estado:" };
            combo_Estado = new ComboBox()
            {
                DataSource = enumHabilitado,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Estado.SelectedIndexChanged += Combo_Estado_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Nombre, 0, 1);
            flow_Filtros.Controls.Add(txt_Nombre, 1, 1);
            flow_Filtros.Controls.Add(lbl_Divisa, 2, 1);
            flow_Filtros.Controls.Add(combo_Divisa, 3, 1);
            flow_Filtros.Controls.Add(lbl_Estado, 4, 1);
            flow_Filtros.Controls.Add(combo_Estado, 5, 1);
        }
        void SetupButtons()
        {
            but_Habilitar = new DarkButton() { Text = "Habilitar", Anchor = AnchorStyles.Left };
            but_Habilitar.Click += But_Habilitar_Click;

            but_Deshabilitar = new DarkButton() { Text = "Deshabilitar", Anchor = AnchorStyles.Left };
            but_Deshabilitar.Click += But_Deshabilitar_Click;

            flow_Buttons.Controls.Add(but_Habilitar, 3, 0);
            flow_Buttons.Controls.Add(but_Deshabilitar, 4, 0);
        }
        private void But_Deshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Main.SelectedCells.Count == 0)
                {
                    MessageBox.Show("No se seleccionó ningún elemento.".Translate());
                    return;
                }

                var elem = filtered_list[grid_Main.CurrentRow.Index];

                int temp_row_index = grid_Main.CurrentCell.RowIndex;
                int temp_count = grid_Main.Rows.Count;

                if (elem.Habilitada == false)
                {
                    MessageBox.Show("El elemento ya se encuentra deshabilitado.".Translate());
                    return;
                }

                if (MessageBox.Show("¿Está seguro que desea deshabilitar el elemento seleccionado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                elem.Habilitada = false;

                servicio.Update(elem);

                RefreshList();

                if (temp_count == grid_Main.Rows.Count)
                {
                    grid_Main.CurrentCell = grid_Main.Rows[temp_row_index].Cells[0];
                    grid_Main.Rows[temp_row_index].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void But_Habilitar_Click(object sender, EventArgs e)
        {
            try
            {

                var elem = filtered_list[grid_Main.CurrentRow.Index];

                int temp_row_index = grid_Main.CurrentCell.RowIndex;
                int temp_count = grid_Main.Rows.Count;

                if (elem.Habilitada == true)
                {
                    MessageBox.Show("El elemento ya se encuentra habilitado.".Translate());
                    return;
                }

                if (MessageBox.Show("¿Está seguro que desea habilitar la cuenta seleccionada?\nEsto habilitará todas las planificaciones ligadas a esta.".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                elem.Habilitada = true;

                servicio.Update(elem);

                RefreshList();

                if (temp_count == grid_Main.Rows.Count)
                {
                    grid_Main.CurrentCell = grid_Main.Rows[temp_row_index].Cells[0];
                    grid_Main.Rows[temp_row_index].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
            if (grid_Main.SelectedCells.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningún elemento.".Translate());
                return;
            }
        }
        private void Combo_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Estado.SelectedIndex == -1) return;

            bool habilitado = true;

            if (combo_Estado.SelectedIndex == 0) habilitado = true;
            if (combo_Estado.SelectedIndex == 1) habilitado = false;

            SetFilter(combo_Estado, x =>
            x.Habilitada == habilitado);
        }
        private void Combo_Divisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Divisa.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<Divisa>(combo_Divisa.SelectedIndex);

            SetFilter(combo_Divisa, x =>
            x.Divisa == enumValue);
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
