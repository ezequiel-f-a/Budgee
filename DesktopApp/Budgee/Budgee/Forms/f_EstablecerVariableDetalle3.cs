using Domain;
using Enums;
using SL.Domain;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_EstablecerVariableDetalle3 : Form
    {
        List<Cuenta> CuentasDisponibles => BLL.Services.CuentaService.Current.GetAll(x => x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true && x.Habilitada == true).ToList();
        List<Caracteristica> CategoriasDisponibles => BLL.Services.CaracteristicaService.Current.GetAll(x => x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true && x.Tipo_Caracteristica == Tipo_Caracteristica.Categoria).ToList();
        List<Caracteristica> EtiquetasDisponibles => BLL.Services.CaracteristicaService.Current.GetAll(x => x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true && x.Tipo_Caracteristica == Tipo_Caracteristica.Etiqueta).ToList();

        public (Cuenta, Caracteristica, Caracteristica, DateTime?) ReturnedObject { get; private set; }
        public f_EstablecerVariableDetalle3()
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_MediumBackground;
            SetupAll();
        }
        protected void SetupReturnedObject()
        {
            Cuenta cuenta = null;
            if (combo_Cuenta.Enabled) cuenta = CuentasDisponibles[combo_Cuenta.SelectedIndex];

            Caracteristica categoria = null;
            if (combo_Categoria.Enabled) categoria = CategoriasDisponibles[combo_Categoria.SelectedIndex];

            Caracteristica etiqueta = null;
            if (combo_Etiqueta.Enabled) etiqueta = EtiquetasDisponibles[combo_Etiqueta.SelectedIndex];

            DateTime? fecha = null;
            if (date_Fecha.Enabled) fecha = date_Fecha.Value;

            ReturnedObject = (cuenta, categoria, etiqueta, fecha);
        }
        void SetupAll()
        {
            panel_EnFuncionDeBorder.BackColor = UI_Config.BackColor_DarkBackground;
            panel_EnFuncionDe.BackColor = UI_Config.BackColor_MediumBackground;
            ResizePanel(panel_EnFuncionDeBorder, panel_EnFuncionDe);
        }
        void ResizePanel(Panel border, Panel inside)
        {
            inside.Size = new Size(border.Width - 4, border.Height - 4);
            inside.Location = new Point(2, 2);
        }
        private void check_Cuenta_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Cuenta.Enabled = check_Cuenta.Checked;
            combo_Cuenta.Enabled = check_Cuenta.Checked;
        }
        private void check_Categoria_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Categoría.Enabled = check_Categoria.Checked;
            combo_Categoria.Enabled = check_Categoria.Checked;
        }
        private void check_Etiqueta_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Etiqueta.Enabled = check_Etiqueta.Checked;
            combo_Etiqueta.Enabled = check_Etiqueta.Checked;
        }
        private void check_BalanceActual_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Fecha.Enabled = !check_BalanceActual.Checked;
            date_Fecha.Enabled = !check_BalanceActual.Checked;
        }
        private void combo_Cuenta_DropDown(object sender, EventArgs e)
        {
            int index = combo_Cuenta.SelectedIndex;
            int count = combo_Cuenta.Items.Count;
            combo_Cuenta.DataSource = null;
            combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
            if (combo_Cuenta.Items.Count == count) combo_Cuenta.SelectedIndex = index;
        }
        private void combo_Categoria_DropDown(object sender, EventArgs e)
        {
            int index = combo_Categoria.SelectedIndex;
            int count = combo_Categoria.Items.Count;
            combo_Categoria.DataSource = null;
            combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Categoria.Items.Count == count) combo_Categoria.SelectedIndex = index;
        }
        private void combo_Etiqueta_DropDown(object sender, EventArgs e)
        {
            int index = combo_Etiqueta.SelectedIndex;
            int count = combo_Etiqueta.Items.Count;
            combo_Etiqueta.DataSource = null;
            combo_Etiqueta.DataSource = EtiquetasDisponibles.Select(x => x.Nombre).ToList();
            combo_Etiqueta.SelectedIndex = -1;
            if (combo_Etiqueta.Items.Count == count) combo_Etiqueta.SelectedIndex = index;
        }
        private void but_Establecer_Click(object sender, EventArgs e)
        {
            bool camposIncompletos = false;
            if (combo_Cuenta.SelectedIndex == -1 && check_Cuenta.Checked) camposIncompletos = true;
            if (combo_Categoria.SelectedIndex == -1 && check_Categoria.Checked) camposIncompletos = true;
            if (combo_Etiqueta.SelectedIndex == -1 && check_Etiqueta.Checked) camposIncompletos = true;
            if (camposIncompletos)
            {
                MessageBox.Show("Hay campos que no fueron completados.".Translate());
                return;
            }

            SetupReturnedObject();

            this.DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReturnedObject = default;

            this.DialogResult = DialogResult.Cancel;
        }

        private void f_EstablecerVariableDetalle3_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
