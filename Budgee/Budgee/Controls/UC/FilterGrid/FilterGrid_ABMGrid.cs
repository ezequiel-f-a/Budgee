using SL.Services;
using SL.Services.Extensions;
using System;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.UC.Filterable;
using UI.Forms;

namespace UI.Controls.UC.FilterGrid
{
    public partial class FilterGrid_ABMGrid<T> : Filterable_FilterGrid<T>
    {
        protected Button but_Agregar, but_Eliminar, but_Modificar, but_VerDetalles;
        protected f_Talonario<T> talonario;
        public FilterGrid_ABMGrid() : base(true)
        {
            InitializeComponent();
            SetupAll();
        }
        void SetupAll()
        {
            but_Agregar = new DarkButton() { Text = "Agregar", Anchor = AnchorStyles.Left };
            but_Agregar.Click += but_Agregar_Click;

            but_Eliminar = new DarkButton() { Text = "Eliminar", Anchor = AnchorStyles.Left };
            but_Eliminar.Click += but_Eliminar_Click;

            but_Modificar = new DarkButton() { Text = "Modificar", Anchor = AnchorStyles.Left };
            but_Modificar.Click += but_Modificar_Click;

            but_VerDetalles = new DarkButton() { Text = "Ver Detalles", Anchor = AnchorStyles.Right };
            but_VerDetalles.Click += but_VerDetalles_Click;

            flow_Buttons.Controls.Add(but_Agregar, 0, 0);
            flow_Buttons.Controls.Add(but_Eliminar, 1, 0);
            flow_Buttons.Controls.Add(but_Modificar, 2, 0);
            flow_Buttons.Controls.Add(but_VerDetalles, 5, 0);
        }
        private void but_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (talonario.ShowDialog() == DialogResult.OK)
                {
                    servicio.Add(talonario.ReturnedObject);
                    RefreshList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Main.SelectedRows.Count == 0) return;

                var dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el elemento seleccionado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel);

                if (dialogResult != DialogResult.OK) return;

                (filtered_list[grid_Main.CurrentRow.Index] as dynamic).Estado = false;

                try
                {
                    servicio.Update(filtered_list[grid_Main.CurrentRow.Index]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetFullMessage());
                }

                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Main.SelectedRows.Count == 0) return;

                int temp_row_index = grid_Main.CurrentCell.RowIndex;
                int temp_count = grid_Main.Rows.Count;

                talonario.ReferenceObject = filtered_list[grid_Main.CurrentCell.RowIndex];

                if (talonario.ShowDialog() == DialogResult.OK)
                {
                    servicio.Update(talonario.ReturnedObject);
                    RefreshList();
                }

                talonario.ReferenceObject = default;

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
        private void but_VerDetalles_Click(object sender, EventArgs e)
        {
            if (grid_Main.SelectedRows.Count == 0) return;

            int temp_row_index = grid_Main.CurrentCell.RowIndex;
            int temp_count = grid_Main.Rows.Count;

            talonario.ReferenceObject = filtered_list[grid_Main.CurrentCell.RowIndex];
            talonario.ViewOnly = true;

            talonario.ShowDialog();

            talonario.ViewOnly = false;

            if (temp_count == grid_Main.Rows.Count)
            {
                grid_Main.CurrentCell = grid_Main.Rows[temp_row_index].Cells[0];
                grid_Main.Rows[temp_row_index].Selected = true;
            }
        }
    }
}
