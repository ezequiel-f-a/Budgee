using Enums;
using SL.Domain;
using SL.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_EstablecerFrecuenciaInicio : Form
    {
        protected bool _ViewOnly = false;
        public FrecuenciaInicio ReferenceObject { get; set; }
        public FrecuenciaInicio ReturnedObject { get; protected set; }
        public bool ViewOnly { get { return _ViewOnly; } set { SetupViewOnly(value); } }
        public f_EstablecerFrecuenciaInicio(bool frecuenciaObligatoria = false)
        {
            InitializeComponent();

            check_Frecuencia.Visible = !frecuenciaObligatoria;
        }
        void SetupAll()
        {
            this.BackColor = UI_Config.BackColor_MediumBackground;
            panel_FrecuenciaBorder.BackColor = UI_Config.BackColor_DarkBackground;
            panel_Frecuencia.BackColor = UI_Config.BackColor_MediumBackground;
            panel_InicioBorder.BackColor = UI_Config.BackColor_DarkBackground;
            panel_Inicio.BackColor = UI_Config.BackColor_MediumBackground;
            ResizePanel(panel_FrecuenciaBorder, panel_Frecuencia);
            ResizePanel(panel_InicioBorder, panel_Inicio);

            combo_FrecuenciaMagnitud.DataSource = new FrecuenciaSimplificada().GetDescriptions().Translate().ToList();
            combo_FrecuenciaMagnitud.SelectedIndex = -1;

            combo_Mes.DataSource = new Mes().GetDescriptions().Translate().ToList();
            combo_Mes.SelectedIndex = -1;

            combo_Dia.DataSource = new Dia_del_Mes().GetDescriptions().Translate().ToList();
            combo_Dia.SelectedIndex = -1;

            txt_Año.Text = DateTime.Now.Year.ToString();
            date_Horario.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0);
        }
        void SetFields(FrecuenciaInicio referenceObject)
        {
            txt_FrecuenciaValor.Text = referenceObject.FrecuenciaValor.ToString();

            if (referenceObject.FrecuenciaMagnitud != null)
                combo_FrecuenciaMagnitud.SelectedIndex = ((Frecuencia)referenceObject.FrecuenciaMagnitud).Index();
            else
                check_Frecuencia.Checked = false;

            txt_Año.Text = referenceObject.Año.ToString();

            if (referenceObject.Mes != null)
                combo_Mes.SelectedIndex = (int)referenceObject.Mes - 1;

            if (referenceObject.DiaDelMes != null)
                combo_Dia.SelectedIndex = ((Dia_del_Mes)referenceObject.DiaDelMes).Index();

            if (referenceObject.DiaDeLaSemana != null)
                combo_Dia.SelectedIndex = ((Dia_de_la_Semana)referenceObject.DiaDeLaSemana).Index();

            var horario = referenceObject.Horario;
            var now = DateTime.Now;
            date_Horario.Value = new DateTime(now.Year, now.Month, now.Day, horario.Hours, horario.Minutes, horario.Seconds);
        }
        void SetupReturnedObject()
        {
            int? frecValor = null;

            if (!string.IsNullOrEmpty(txt_FrecuenciaValor.Text))
                frecValor = Convert.ToInt32(txt_FrecuenciaValor.Text);

            Frecuencia? frecMagnitud = null;
            if (combo_FrecuenciaMagnitud.SelectedIndex != -1)
                frecMagnitud = EnumHelper.GetEnumFromIndex<Frecuencia>(combo_FrecuenciaMagnitud.SelectedIndex);

            int? año = null;
            if (!string.IsNullOrEmpty(txt_Año.Text)) año = Convert.ToInt32(txt_Año.Text);

            int? mes = null;
            if (combo_Mes.SelectedIndex != -1) mes = combo_Mes.SelectedIndex + 1;

            Dia_del_Mes? diaDelMes = null;
            if (combo_Dia.Items.Count == Enum.GetNames(typeof(Dia_del_Mes)).Count() && combo_Dia.SelectedIndex != -1)
                diaDelMes = EnumHelper.GetEnumFromIndex<Dia_del_Mes>(combo_Dia.SelectedIndex);

            Dia_de_la_Semana? diaDeLaSemana = null;
            if (combo_Dia.Items.Count == Enum.GetNames(typeof(Dia_de_la_Semana)).Count() && combo_Dia.SelectedIndex != -1)
                diaDeLaSemana = EnumHelper.GetEnumFromIndex<Dia_de_la_Semana>(combo_Dia.SelectedIndex);

            TimeSpan horario = date_Horario.Value.TimeOfDay;

            if (!txt_FrecuenciaValor.Enabled) frecValor = null;
            if (!combo_FrecuenciaMagnitud.Enabled) frecMagnitud = null;
            if (!txt_Año.Enabled) año = null;
            if (!combo_Mes.Enabled) mes = null;
            if (!combo_Dia.Enabled) { diaDelMes = null; diaDeLaSemana = null; }

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.FrecuenciaValor = frecValor;
                ReturnedObject.FrecuenciaMagnitud = frecMagnitud;
                ReturnedObject.Año = año;
                ReturnedObject.Mes = mes;
                ReturnedObject.DiaDelMes = diaDelMes;
                ReturnedObject.DiaDeLaSemana = diaDeLaSemana;
                ReturnedObject.Horario = horario;
                ReturnedObject.FechaUltimoProceso = null; //Ya que la frecuencia pudo haber cambiado, reestablecemos fecha ult. proc.
            }
            else
            {
                ReturnedObject = new FrecuenciaInicio(
                    Guid.NewGuid(),
                    frecMagnitud,
                    frecValor,
                    año,
                    mes,
                    diaDelMes,
                    diaDeLaSemana,
                    horario,
                    null,
                    AppData.CurrentUser.ID_Usuario);
            }
        }
        void CleanFields()
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
                    (control as DataGridView).Rows.Clear();
                }
                else if (control is ListBox)
                {
                    (control as ListBox).Items.Clear();
                }
            }
        }
        void SetupFrecuenciaInicio()
        {
            panel_FrecuenciaBorder.Enabled = check_Frecuencia.Checked;
            panel_InicioBorder.Enabled = !check_Frecuencia.Checked;
            SetupInicio();
        }
        void SetupInicio()
        {
            lbl_Año.Enabled = true;
            txt_Año.Enabled = true;
            lbl_Mes.Enabled = true;
            combo_Mes.Enabled = true;
            lbl_Dia.Enabled = true;
            combo_Dia.Enabled = true;

            if (combo_FrecuenciaMagnitud.Enabled)
            {
                if (combo_FrecuenciaMagnitud.SelectedIndex == -1) panel_InicioBorder.Enabled = false;
                else
                {
                    panel_InicioBorder.Enabled = true;

                    int temp_combo_dia_count = combo_Dia.Items.Count;
                    int temp_combo_dia_index = combo_Dia.SelectedIndex;

                    var selectedValue = EnumHelper.GetEnumFromIndex<Frecuencia>(combo_FrecuenciaMagnitud.SelectedIndex);

                    lbl_Año.Enabled = false;
                    txt_Año.Enabled = false;

                    if (selectedValue == Frecuencia.Años)
                    {
                        combo_Dia.DataSource = new Dia_del_Mes().GetDescriptions().Translate().ToList();
                        combo_Dia.SelectedIndex = -1;
                    }
                    if (selectedValue == Frecuencia.Meses)
                    {
                        lbl_Mes.Enabled = false;
                        combo_Mes.Enabled = false;
                        combo_Dia.DataSource = new Dia_del_Mes().GetDescriptions().Translate().ToList();
                        combo_Dia.SelectedIndex = -1;
                    }
                    if (selectedValue == Frecuencia.Semanas)
                    {
                        lbl_Mes.Enabled = false;
                        combo_Mes.Enabled = false;
                        combo_Dia.DataSource = new Dia_de_la_Semana().GetDescriptions().Translate().ToList();
                        combo_Dia.SelectedIndex = -1;
                    }
                    if (selectedValue == Frecuencia.Dias)
                    {
                        lbl_Mes.Enabled = false;
                        combo_Mes.Enabled = false;
                        lbl_Dia.Enabled = false;
                        combo_Dia.Enabled = false;
                    }

                    if (combo_Dia.Items.Count == temp_combo_dia_count) combo_Dia.SelectedIndex = temp_combo_dia_index;
                }
            }
        }
        void ResizePanel(Panel border, Panel inside)
        {
            inside.Size = new Size(border.Width - 4, border.Height - 4);
            inside.Location = new Point(2, 2);
        }
        void SetupViewOnly(bool value)
        {
            _ViewOnly = value;
            foreach (var control in Controls.Cast<Control>())
            {
                if (control is Button || control is ComboBox || control is TextBox)
                    control.Enabled = !value;
            }
        }
        private void but_Establecer_Click(object sender, EventArgs e)
        {
            bool emptyfields = false;

            if (txt_FrecuenciaValor.Enabled && string.IsNullOrEmpty(txt_FrecuenciaValor.Text))
                emptyfields = true;

            if (combo_FrecuenciaMagnitud.Enabled && combo_FrecuenciaMagnitud.SelectedIndex == -1)
                emptyfields = true;

            if (txt_Año.Enabled && string.IsNullOrEmpty(txt_Año.Text))
                emptyfields = true;

            if (combo_Mes.Enabled && combo_Mes.SelectedIndex == -1)
                emptyfields = true;

            if (combo_Dia.Enabled && combo_Dia.SelectedIndex == -1)
                emptyfields = true;

            if (emptyfields)
            {
                MessageBox.Show("Hay campos que no fueron completados.".Translate());
                return;
            }

            if (!string.IsNullOrEmpty(txt_Año.Text) && Convert.ToInt32(txt_Año.Text) < 1753)
            {
                MessageBox.Show("La fecha ingresada es demasiado antigua.".Translate());
                return;
            }

            SetupReturnedObject();

            ReferenceObject = null;
            this.DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReturnedObject = null;
            ReferenceObject = null;
            this.DialogResult = DialogResult.Cancel;
        }
        private void f_EstablecerFrecuenciaInicio_SizeChanged(object sender, EventArgs e)
        {
            ResizePanel(panel_FrecuenciaBorder, panel_Frecuencia);
            ResizePanel(panel_InicioBorder, panel_Inicio);
        }
        private void check_Frecuencia_CheckedChanged(object sender, EventArgs e)
        {
            SetupFrecuenciaInicio();
        }
        private void combo_FrecuenciaMagnitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupFrecuenciaInicio();
        }
        private void f_EstablecerFrecuenciaInicio_Load(object sender, EventArgs e)
        {
            SetupAll();
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
        private void f_EstablecerFrecuenciaInicio_Shown(object sender, EventArgs e)
        {
            CleanFields();

            if (ReferenceObject != null)
                new Thread(() => { SetFields(ReferenceObject); SetupFrecuenciaInicio(); }).Start();
        }
    }
}
