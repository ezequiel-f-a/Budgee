using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.TextBoxs;
using UI.Controls.UC.FilterGrid;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Recordatorios : FilterGrid_ABMGrid<Recordatorio>
    {
        protected Label lbl_Descripcion, lbl_Frecuencia, lbl_Estado;
        protected TextBox txt_Descripcion, txt_Frecuencia;
        protected ComboBox combo_Frecuencia, combo_Estado;

        protected Button but_Habilitar, but_Deshabilitar;
        public ABM_Recordatorios()
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                FrecuenciaInicio = (x.FrecuenciaInicio == null) ? null : SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(x.FrecuenciaInicio),
                //x.AlarmaWindows,
                //x.NotificacionWindows,
                x.QuitarAlConcluir,
                x.Habilitado
            };

            servicio = BLL.Services.RecordatorioService.Current;
            talonario = new Talonario_Recordatorio();

            InitializeComponent();
            SetupAll();
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
        void SetupAll()
        {
            SetupFiltros();
            SetupButtons();
        }
        void SetupFiltros()
        {
            lbl_Descripcion = new Label() { Text = "Descripción:" };
            txt_Descripcion = new TextBox();
            txt_Descripcion.TextChanged += Txt_Descripcion_TextChanged;

            lbl_Frecuencia = new Label() { Text = "Frecuencia:" };
            txt_Frecuencia = new IntegerBox();
            combo_Frecuencia = new ComboBox()
            {
                DataSource = new FrecuenciaSimplificada().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            txt_Frecuencia.TextChanged += Txt_Frecuencia_TextChanged;
            combo_Frecuencia.SelectedIndexChanged += Combo_Frecuencia_SelectedIndexChanged;

            lbl_Estado = new Label() { Text = "Estado:" };
            combo_Estado = new ComboBox()
            {
                DataSource = new string[] { "Habilitado", "Deshabilitado" }.Translate(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Estado.SelectedIndexChanged += Combo_Estado_SelectedIndexChanged;

            //lbl_PlanificacionLigada = new Label() { Text = "Planificación Ligada:" };
            //combo_PlanificacionLigada = new ComboBox()
            //{
            //    DataSource = /*Hacer select distinct de planificaciones ligadas*/ new string[] { "Planificación 1", "Planificación 2" },
            //    DropDownStyle = ComboBoxStyle.DropDownList
            //};
            //combo_PlanificacionLigada.SelectedIndexChanged += Combo_PlanificacionLigada_SelectedIndexChanged; ;

            flow_Filtros.Controls.Add(lbl_Descripcion, 0, 0);
            flow_Filtros.Controls.Add(txt_Descripcion, 1, 0);
            flow_Filtros.Controls.Add(lbl_Estado, 2, 0);
            flow_Filtros.Controls.Add(combo_Estado, 3, 0);
            //flow_Filtros.Controls.Add(lbl_PlanificacionLigada, 4, 0);
            //flow_Filtros.Controls.Add(combo_PlanificacionLigada, 5, 0);
            flow_Filtros.Controls.Add(lbl_Frecuencia, 0, 1);
            flow_Filtros.Controls.Add(txt_Frecuencia, 1, 1);
            flow_Filtros.Controls.Add(combo_Frecuencia, 2, 1);
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

                if (elem.Habilitado == false)
                {
                    MessageBox.Show("El elemento ya se encuentra deshabilitado.".Translate());
                    return;
                }

                if (MessageBox.Show("¿Está seguro que desea deshabilitar el elemento seleccionado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                elem.Habilitado = false;

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
                if (grid_Main.SelectedCells.Count == 0)
                {
                    MessageBox.Show("No se seleccionó ningún elemento.".Translate());
                    return;
                }

                var elem = filtered_list[grid_Main.CurrentRow.Index];

                int temp_row_index = grid_Main.CurrentCell.RowIndex;
                int temp_count = grid_Main.Rows.Count;

                if (elem.Habilitado == true)
                {
                    MessageBox.Show("El elemento ya se encuentra habilitado.".Translate());
                    return;
                }

                if (MessageBox.Show("¿Está seguro que desea habilitar el elemento seleccionado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                elem.Habilitado = true;

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
        private void Combo_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Estado.SelectedIndex == -1) return;

            bool habilitado = true;

            if (combo_Estado.SelectedIndex == 0) habilitado = true;
            if (combo_Estado.SelectedIndex == 1) habilitado = false;

            SetFilter(combo_Estado, x =>
            x.Habilitado == habilitado);
        }
        private void Combo_Frecuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Frecuencia.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<Frecuencia>(combo_Frecuencia.SelectedIndex);

            SetFilter(combo_Frecuencia, x =>
            x.FrecuenciaInicio.FrecuenciaMagnitud == enumValue);
        }
        private void Txt_Frecuencia_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Frecuencia.Text))
            {
                RemoveFilter(txt_Frecuencia);
                return;
            }

            var frecValor = Convert.ToInt32(txt_Frecuencia.Text);

            SetFilter(txt_Frecuencia, x =>
            x.FrecuenciaInicio.FrecuenciaValor == frecValor);
        }
        private void Txt_Descripcion_TextChanged(object sender, EventArgs e)
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
