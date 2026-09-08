using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.TextBoxs;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Planificaciones : ABM_GenericTransacciones<Planificacion>
    {
        protected Label lbl_cuenta, lbl_Frecuencia, lbl_Estado;
        protected TextBox txt_Frecuencia;
        protected ComboBox combo_Cuenta, combo_Frecuencia, combo_Estado;
        protected List<Cuenta> CuentasDisponibles = new List<Cuenta>();
        protected Button but_Habilitar, but_Deshabilitar;
        string[] enumHabilitado = new string[] { "Habilitado", "Deshabilitado" }.Translate();
        public ABM_Planificaciones()
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                FrecuenciaInicio = (x.FrecuenciaInicio == null) ? null : SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(x.FrecuenciaInicio),
                x.Cuenta,
                x.Categoria,
                Etiquetas = String.Join(", ", x.Etiquetas),
                TipoOperacion = (x.TipoOperacion != null) ? ((Tipo_Operacion)x.TipoOperacion).GetDescription().Translate() : null,
                MontoExpresion = $"{x.MontoExpresion} {x.Cuenta.Divisa.GetDescription().Translate()}",
                x.Habilitado
            };

            servicio = BLL.Services.PlanificacionService.Current;
            talonario = new Talonario_Planificacion();
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
            lbl_cuenta = new Label() { Text = "Cuenta:" };
            combo_Cuenta = new ComboBox()
            {
                //DataSource = /*Pegar a BLL de cuentas*/ new string[] { "Cuenta 1", "Cuenta 2" },
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;
            combo_Cuenta.DropDown += Combo_cuenta_DropDown;

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
                DataSource = enumHabilitado,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Estado.SelectedIndexChanged += Combo_Estado_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_cuenta, 4, 0);
            flow_Filtros.Controls.Add(combo_Cuenta, 5, 0);
            flow_Filtros.Controls.Add(lbl_Frecuencia, 0, 2);
            flow_Filtros.Controls.Add(txt_Frecuencia, 1, 2);
            flow_Filtros.Controls.Add(combo_Frecuencia, 2, 2);
            flow_Filtros.Controls.Add(lbl_Estado, 2, 0);
            flow_Filtros.Controls.Add(combo_Estado, 3, 0);
        }
        void SetupButtons()
        {
            var but_Habilitar = new DarkButton() { Text = "Habilitar", Anchor = AnchorStyles.Left };
            but_Habilitar.Click += But_Habilitar_Click;

            var but_Deshabilitar = new DarkButton() { Text = "Deshabilitar", Anchor = AnchorStyles.Left };
            but_Deshabilitar.Click += But_Deshabilitar_Click;

            flow_Buttons.Controls.Add(but_Habilitar, 3, 0);
            flow_Buttons.Controls.Add(but_Deshabilitar, 4, 0);
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Cuenta.Habilitada == true && x.Cuenta.Estado == true && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderBy(x => x.Descripcion).ToList();
                CuentasDisponibles = BLL.Services.CuentaService.Current.GetAll(x => list.Select(y => y.Cuenta.ID_Cuenta).Contains(x.ID_Cuenta)).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void But_Deshabilitar_Click(object sender, EventArgs e)
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

            BLL.Services.PlanificacionService.Current.Update(elem);

            RefreshList();

            if (temp_count == grid_Main.Rows.Count)
            {
                grid_Main.CurrentCell = grid_Main.Rows[temp_row_index].Cells[0];
                grid_Main.Rows[temp_row_index].Selected = true;
            }
        }
        private void But_Habilitar_Click(object sender, EventArgs e)
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

            BLL.Services.PlanificacionService.Current.Update(elem);

            RefreshList();

            if (temp_count == grid_Main.Rows.Count)
            {
                grid_Main.CurrentCell = grid_Main.Rows[temp_row_index].Cells[0];
                grid_Main.Rows[temp_row_index].Selected = true;
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
        private void Combo_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Cuenta.SelectedIndex == -1) return;

            var id = CuentasDisponibles[combo_Cuenta.SelectedIndex].ID_Cuenta;

            SetFilter(combo_Cuenta, x =>
            x.Cuenta.ID_Cuenta == id);
        }
        private void Combo_cuenta_DropDown(object sender, EventArgs e)
        {
            combo_Cuenta.SelectedIndexChanged -= Combo_Cuenta_SelectedIndexChanged;
            int index = combo_Cuenta.SelectedIndex;
            int count = combo_Cuenta.Items.Count;
            combo_Cuenta.DataSource = null;
            combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
            if (combo_Cuenta.Items.Count == count) combo_Cuenta.SelectedIndex = index;
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;
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
    }
}
