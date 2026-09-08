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
    public partial class ABM_Presupuestos : FilterGrid_ABMGrid<Presupuesto>
    {
        protected Label lbl_Descripcion, lbl_Estado, lbl_Lapso, lbl_CuandoChequear, lbl_Supervisa1, lbl_Supervisa2;
        protected TextBox txt_Descripcion, txt_Lapso;
        protected ComboBox combo_Lapso, combo_Estado, combo_CuandoChequear, combo_Supervisa1, combo_Supervisa2;

        protected Button but_Habilitar, but_Deshabilitar;
        public ABM_Presupuestos()
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                VariableSupervisada = BLL.Services.VariableService.Current.GetDescription(x.VariableSupervisada),
                OperadorRelacional = x.OperadorRelacional.GetDescription().Translate(),
                CondicionExpresion = BLL.Services.ExpresionService.Current.GetDescription(x.CondicionExpresion),
                LapsoPresupuesto = (x.LapsoPresupuesto == null) ? null : SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(x.LapsoPresupuesto),
                CuandoChequear = x.CuandoChequear.GetDescription().Translate(),
                x.Habilitado
            };

            servicio = BLL.Services.PresupuestoService.Current;
            talonario = new Talonario_Presupuesto();

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

            lbl_Estado = new Label() { Text = "Estado:" };
            combo_Estado = new ComboBox()
            {
                DataSource = new string[] { "Habilitado", "Deshabilitado" }.Translate(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Estado.SelectedIndexChanged += Combo_Estado_SelectedIndexChanged;

            lbl_Lapso = new Label() { Text = "Lapso:" };
            txt_Lapso = new IntegerBox();
            combo_Lapso = new ComboBox()
            {
                DataSource = new FrecuenciaSimplificada().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            txt_Lapso.TextChanged += Txt_Lapso_TextChanged;
            combo_Lapso.SelectedIndexChanged += Combo_Lapso_SelectedIndexChanged;

            lbl_CuandoChequear = new Label() { Text = "Cuando Cheq.:" };
            combo_CuandoChequear = new ComboBox()
            {
                DataSource = new Cuando_Chequear().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_CuandoChequear.SelectedIndexChanged += Combo_CuandoChequear_SelectedIndexChanged;

            lbl_Supervisa1 = new Label() { Text = "Supervisa:" };
            combo_Supervisa1 = new ComboBox()
            {
                DataSource = new Tipo_Variable().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownWidth = 200
            };
            combo_Supervisa1.SelectedIndexChanged += Combo_Supervisa1_SelectedIndexChanged;

            lbl_Supervisa2 = new Label() { Text = "De:" };
            combo_Supervisa2 = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = false
            };
            combo_Supervisa2.Items.AddRange(new Variable_Target().GetDescriptions().Translate().ToArray());
            combo_Supervisa2.SelectedIndexChanged += Combo_Supervisa2_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Descripcion, 0, 0);
            flow_Filtros.Controls.Add(txt_Descripcion, 1, 0);
            flow_Filtros.Controls.Add(lbl_Estado, 2, 0);
            flow_Filtros.Controls.Add(combo_Estado, 3, 0);
            flow_Filtros.Controls.Add(lbl_CuandoChequear, 0, 1);
            flow_Filtros.Controls.Add(combo_CuandoChequear, 1, 1);
            flow_Filtros.Controls.Add(lbl_Supervisa1, 2, 1);
            flow_Filtros.Controls.Add(combo_Supervisa1, 3, 1);
            flow_Filtros.Controls.Add(lbl_Supervisa2, 4, 1);
            flow_Filtros.Controls.Add(combo_Supervisa2, 5, 1);
            flow_Filtros.Controls.Add(lbl_Lapso, 0, 2);
            flow_Filtros.Controls.Add(txt_Lapso, 1, 2);
            flow_Filtros.Controls.Add(combo_Lapso, 1, 2);
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
        void SetupComboSupervisa2()
        {
            //Me traigo todo por si filtre anteriormente
            combo_Supervisa2.Items.Clear();
            combo_Supervisa2.Items.AddRange(new Variable_Target().GetDescriptions().Translate().ToArray());

            var selectedSupervisa1 = (Tipo_Variable)combo_Supervisa1.SelectedIndex;

            if (selectedSupervisa1 == Tipo_Variable.Monto)
            {
                combo_Supervisa2.Items.Remove(Variable_Target.Cuenta.GetDescription().Translate());
                combo_Supervisa2.Items.Remove(Variable_Target.Categoria.GetDescription().Translate());
                combo_Supervisa2.Items.Remove(Variable_Target.Etiqueta.GetDescription().Translate());
            }
            else
            {
                combo_Supervisa2.Items.Remove(Variable_Target.Transaccion.GetDescription().Translate());
                combo_Supervisa2.Items.Remove(Variable_Target.Planificacion.GetDescription().Translate());
                combo_Supervisa2.Items.Remove(Variable_Target.Plantilla.GetDescription().Translate());
            }

            combo_Supervisa2.Enabled = true;
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
            x.Habilitado == habilitado);
        }
        private void Combo_Lapso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Lapso.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<Frecuencia>(combo_Lapso.SelectedIndex);

            SetFilter(combo_Lapso, x =>
            x.LapsoPresupuesto.FrecuenciaMagnitud == enumValue);
        }
        private void Combo_CuandoChequear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_CuandoChequear.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<Cuando_Chequear>(combo_CuandoChequear.SelectedIndex);

            SetFilter(combo_CuandoChequear, x =>
            x.CuandoChequear == enumValue);
        }
        private void Combo_Supervisa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supervisa1.SelectedIndex == -1)
            {
                combo_Supervisa2.Enabled = false;
                return;
            }

            SetupComboSupervisa2();

            var enumValue = EnumHelper.GetEnumFromIndex<Tipo_Variable>(combo_Supervisa1.SelectedIndex);

            if(enumValue == Tipo_Variable.Monto)
                    SetFilter(combo_Supervisa1, x => x.VariableSupervisada.Transaccion != null || x.VariableSupervisada.Planificacion != null || x.VariableSupervisada.PlantillaTransaccion != null);
            else
                    SetFilter(combo_Supervisa1, x => x.VariableSupervisada.Transaccion == null && x.VariableSupervisada.Planificacion == null && x.VariableSupervisada.PlantillaTransaccion == null);
        }
        private void Combo_Supervisa2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supervisa2.SelectedIndex == -1) return;

            int varTargetIndex = combo_Supervisa2.SelectedIndex;

            if (EnumHelper.GetEnumFromIndex<Tipo_Variable>(combo_Supervisa1.SelectedIndex) != Tipo_Variable.Monto)
                varTargetIndex += 3;

            var enumValue = EnumHelper.GetEnumFromIndex<Variable_Target>(varTargetIndex);

            switch (enumValue)
            {
                case Variable_Target.Transaccion:
                    SetFilter(combo_Supervisa2, x => x.VariableSupervisada.Transaccion != null);
                    break;
                case Variable_Target.Planificacion:
                    SetFilter(combo_Supervisa2, x => x.VariableSupervisada.Planificacion != null);
                    break;
                case Variable_Target.Plantilla:
                    SetFilter(combo_Supervisa2, x => x.VariableSupervisada.PlantillaTransaccion != null);
                    break;
                case Variable_Target.Cuenta:
                    SetFilter(combo_Supervisa2, x => x.VariableSupervisada.Cuenta != null);
                    break;
                case Variable_Target.Categoria:
                    SetFilter(combo_Supervisa2, x => x.VariableSupervisada.Categoria != null);
                    break;
                case Variable_Target.Etiqueta:
                    SetFilter(combo_Supervisa2, x => x.VariableSupervisada.Etiqueta != null);
                    break;
                default:
                    break;
            }
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
        private void Txt_Lapso_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Lapso.Text))
            {
                RemoveFilter(txt_Lapso);
                return;
            }

            var frecValor = Convert.ToInt32(txt_Lapso.Text);

            SetFilter(txt_Lapso, x =>
            x.LapsoPresupuesto.FrecuenciaValor == frecValor);
        }
    }
}
