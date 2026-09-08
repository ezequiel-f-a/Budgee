using Domain;
using Enums;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_Talonario<T> : Form
    {
        protected object flag_thread = new object();
        protected bool _ViewOnly = false;
        public T ReferenceObject { get; set; }
        public T ReturnedObject { get; protected set; }
        public bool ViewOnly { get { return _ViewOnly; } set { SetupViewOnly(value); } }
        protected List<Cuenta> CuentasDisponibles => BLL.Services.CuentaService.Current.GetAll(x => x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true && x.Habilitada == true).ToList();
        protected List<Caracteristica> CategoriasDisponibles => BLL.Services.CaracteristicaService.Current.GetAll(x => x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true && x.Tipo_Caracteristica == Tipo_Caracteristica.Categoria).ToList();
        private Dictionary<Control, bool> DefaultEnabledState = new Dictionary<Control, bool>();
        private Dictionary<TextBox, (bool Enabled, bool ReadOnly)> DefaultTextBoxesState = new Dictionary<TextBox, (bool Enabled, bool ReadOnly)>();
        public f_Talonario()
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_MediumBackground;
        }
        void ClearSelections()
        {
            Controls.Cast<Control>().Where(x => x is DataGridView).ToList().ForEach(x => (x as DataGridView).ClearSelection());
            Controls.Cast<Control>().Where(x => x is ListBox).ToList().ForEach(x => (x as ListBox).ClearSelected());
        }
        void SetupViewOnly(bool viewOnly)
        {
            if (viewOnly && !_ViewOnly)
            {
                Func<Control, bool> filterEnabled = (x => x is Button || x is ComboBox || x is CheckBox || x is DataGridView || x is ListBox || x is DateTimePicker);

                DefaultEnabledState.Clear();

                Controls.Cast<Control>().Where(filterEnabled).ToList()
                    .ForEach(x => DefaultEnabledState.Add(x, x.Enabled));

                Controls.Cast<Control>().Where(filterEnabled).ToList()
                    .ForEach(x => x.Enabled = false);


                DefaultTextBoxesState.Clear();

                Controls.Cast<Control>().Where(x => x is TextBox).Cast<TextBox>().ToList()
                    .ForEach(x => { DefaultTextBoxesState.Add(x, (x.Enabled, x.ReadOnly)); });

                Controls.Cast<Control>().Where(x => x is TextBox).Cast<TextBox>().ToList()
                    .ForEach(x => { x.Enabled = true; x.ReadOnly = true; });
            }
            else if (!viewOnly && _ViewOnly)
            {
                if (DefaultEnabledState.Count > 0)
                {
                    foreach (var control in DefaultEnabledState)
                        control.Key.Enabled = control.Value;

                    foreach (var textbox in DefaultTextBoxesState)
                    {
                        textbox.Key.Enabled = textbox.Value.Enabled;
                        textbox.Key.ReadOnly = textbox.Value.ReadOnly;
                    }
                }
            }

            but_Aceptar.Visible = !viewOnly;
            but_Cancelar.Visible = !viewOnly;

            if (viewOnly && !_ViewOnly)
                this.ClientSize = new System.Drawing.Size(ClientSize.Width, ClientSize.Height - but_Aceptar.Size.Height);

            else if (!viewOnly && _ViewOnly)
                this.ClientSize = new System.Drawing.Size(ClientSize.Width, ClientSize.Height + but_Aceptar.Size.Height);

            _ViewOnly = viewOnly;
        }
        protected void ClearFields()
        {
            foreach (var control in Controls.Cast<Control>())
            {
                if (control is TextBox)
                    control.Text = "";
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                    (control as ComboBox).SelectedIndex = -1;
                }
                else if (control is DataGridView)
                {
                    if ((control as DataGridView).DataSource == null)
                        (control as DataGridView).Rows.Clear();
                    else
                        (control as DataGridView).DataSource = null;
                }
                else if (control is ListBox)
                {
                    (control as ListBox).Items.Clear();
                }
            }
        }
        protected bool CheckCamposCompletados()
        {
            bool empty_fields = false;
            foreach (var control in Controls.Cast<Control>().Where(x => x.Enabled == true))
            {
                if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text)) empty_fields = true;

                else if (control is ComboBox && (control as ComboBox).SelectedIndex == -1) empty_fields = true;
            }

            if (empty_fields) MessageBox.Show("Hay campos que no fueron completados.".Translate());

            return !empty_fields;
        }
        protected virtual void SetFields(T referenceObject)
        {
            //NO DEBE TENER CODIGO, ESO SOLO PARA REIMPLEMENTAR
        }
        protected virtual void SetupReturnedObject()
        {
            //NO DEBE TENER CODIGO, ESO SOLO PARA REIMPLEMENTAR
        }
        protected virtual void ClearCustomAttributes()
        {
            //ES SOLO PARA HEREDAR
        }
        private void but_Aceptar_Click(object sender, EventArgs e)
        {
            //Si hago esto, las verificaciones de los que hereden este form no se van a poder hacer
            //this.DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReturnedObject = default;
            ClearCustomAttributes();
            DialogResult = DialogResult.Cancel;
        }
        private void f_Talonario_Shown(object sender, EventArgs e)
        {
            ClearFields();

            if (ReferenceObject != null)
                new Thread(() => { SetupViewOnly(ViewOnly); SetFields(ReferenceObject); }).Start();
            else
                new Thread(() => { SetupViewOnly(ViewOnly); }).Start();

            new Thread(ClearSelections).Start();
        }
        private void f_Talonario_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReferenceObject = default;
            ClearCustomAttributes();
        }

        private void f_Talonario_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
