using Domain;
using Enums;
using SL.Domain;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_EstablecerVariable : Form
    {
        char[] allowedSymbols = new char[] { '_', ' ' };
        List<string> variables_internas = new List<string>() { "Pi", "e" };
        IEnumerable<string> Name_Not_In = new List<string>();
        int? combo_tipoVariable_prev_selectedIndex;

        Transaccion transaccion;
        Planificacion planificacion;
        PlantillaTransaccion plantillaTransaccion;
        Cuenta cuenta;
        Caracteristica categoria;
        Caracteristica etiqueta;
        Lapso lapso;
        DateTime? fecha;

        ToolTip tip = new ToolTip() { AutoPopDelay = 9999 };
        public Variable ReturnedObject { get; private set; }
        public Variable ReferenceObject { get; set; }
        public Guid? ExceptObject { get; set; }

        public f_EstablecerVariable(bool pedirNombreVariable = true)
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_MediumBackground;
            SetupAll();
            SetupNombreVariable(pedirNombreVariable);
        }
        public f_EstablecerVariable(IEnumerable<string> name_not_in, bool pedirNombreVariable = true)
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_MediumBackground;
            Name_Not_In = name_not_in;
            SetupAll();
            /*Pegar a enum de tipo_variable_especificacion*/ //new string[] { "Transacción", "Planificación", "Plantilla", "Cuenta", "Categoría", "Etiqueta" }
        }
        protected void SetFields(Variable referenceObject)
        {
            txt_Nombre.Text = referenceObject.Nombre_Variable;

            transaccion = referenceObject.Transaccion;
            planificacion = referenceObject.Planificacion;
            plantillaTransaccion = referenceObject.PlantillaTransaccion;
            cuenta = referenceObject.Cuenta;
            categoria = referenceObject.Categoria;
            etiqueta = referenceObject.Etiqueta;
            lapso = referenceObject.Lapso;
            fecha = referenceObject.Fecha;

            combo_TipoVariable.SelectedIndexChanged -= combo_TipoVariable_SelectedIndexChanged;
            combo_TipoVariable.SelectedIndex = referenceObject.Tipo_Variable.Index();
            combo_TipoVariable.SelectedIndexChanged += combo_TipoVariable_SelectedIndexChanged;

            RefreshDetalle(referenceObject);
        }
        protected void SetupReturnedObject()
        {
            Tipo_Variable tipo_Variable = EnumHelper.GetEnumFromIndex<Tipo_Variable>(combo_TipoVariable.SelectedIndex);

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Nombre_Variable = txt_Nombre.Text;
                ReturnedObject.Tipo_Variable = tipo_Variable;
                ReturnedObject.Transaccion = transaccion;
                ReturnedObject.Planificacion = planificacion;
                ReturnedObject.PlantillaTransaccion = plantillaTransaccion;
                ReturnedObject.Cuenta = cuenta;
                ReturnedObject.Categoria = categoria;
                ReturnedObject.Etiqueta = etiqueta;
                ReturnedObject.Lapso = lapso;
                ReturnedObject.Fecha = fecha;
            }
            else
            {
                ReturnedObject = new Variable(
                    Guid.NewGuid(), 
                    txt_Nombre.Text, 
                    tipo_Variable, 
                    transaccion, 
                    planificacion, 
                    plantillaTransaccion, 
                    cuenta, 
                    categoria, 
                    etiqueta, 
                    lapso, 
                    fecha, 
                    AppData.CurrentUser);
            }
        }
        void RefreshDetalle()
        {
            if (combo_TipoVariable.SelectedIndex == -1)
            {
                lbl_Detalle.Text = "...";
            }
            else
            {
                Tipo_Variable tipo_Variable = EnumHelper.GetEnumFromIndex<Tipo_Variable>(combo_TipoVariable.SelectedIndex);
                var variable = new Variable(Guid.NewGuid(), txt_Nombre.Text, tipo_Variable, transaccion, planificacion, plantillaTransaccion, cuenta, categoria, etiqueta, lapso, fecha, AppData.CurrentUser);
                RefreshDetalle(variable);
            }
        }
        void RefreshDetalle(Variable variable) 
        {
            lbl_Detalle.Text = BLL.Services.VariableService.Current.GetDescription(variable);
        }
        void SetupAll()
        {
            combo_TipoVariable.SelectedIndexChanged -= combo_TipoVariable_SelectedIndexChanged;
            combo_TipoVariable.DataSource = new Tipo_Variable().GetDescriptions().Translate().ToList();
            combo_TipoVariable.SelectedIndex = -1;
            combo_TipoVariable.SelectedIndexChanged += combo_TipoVariable_SelectedIndexChanged;
        }
        void SetupNombreVariable(bool pedir)
        {
            if (!pedir)
            {
                Controls.Remove(lbl_Nombre);
                Controls.Remove(txt_Nombre);

                foreach (var control in Controls.Cast<Control>().Where(x=> x != but_Establecer && x != but_Cancelar))
                {
                    control.Location = new System.Drawing.Point(
                        control.Location.X,
                        control.Location.Y - lbl_Nombre.Height - txt_Nombre.Height);
                }

                this.Size = new System.Drawing.Size(
                    this.Size.Width,
                    this.Size.Height - lbl_Nombre.Height - txt_Nombre.Height);
            }
        }
        bool EntryIsValid(string entry)
        {
            bool permitido = true;

            int LetterCount = 0;

            foreach (char character in (txt_Nombre.Text + entry))
            {
                if (char.IsLetter(character))
                    LetterCount++;

                else if (char.IsSymbol(character) && !allowedSymbols.Contains(character))
                    permitido = false;
            }

            if (LetterCount == 0) permitido = false;

            return permitido;
        }
        void LimpiarAtributosDetalle()
        {
            transaccion = null;
            planificacion = null;
            plantillaTransaccion = null;
            cuenta = null;
            categoria = null;
            etiqueta = null;
            lapso = null;
            fecha = null;
        }
        private void but_Establecer_Click(object sender, EventArgs e)
        {
            if (!UIManager.Check_FilledFields(Controls.Cast<Control>()))
            {
                MessageBox.Show("Hay campos que no fueron completados.".Translate());
                return;
            }
            else if (Controls.Contains(txt_Nombre) && !EntryIsValid(txt_Nombre.Text))
            {
                tip.Show("Sólo se permiten letras, espacios o guiones bajos.\nEl nombre de variable debe poseer al menos una letra.".Translate(), txt_Nombre, 3000);
                return;
            }
            else if (Controls.Contains(txt_Nombre) && variables_internas.Contains(txt_Nombre.Text))
            {
                tip.Show("Las variables 'Pi' y 'e' están reservadas por el sistema.".Translate(), txt_Nombre, 3000);
                return;
            }
            else if (Controls.Contains(txt_Nombre) && Name_Not_In.Contains(txt_Nombre.Text))
            {
                if(ReferenceObject == null || ReferenceObject.Nombre_Variable != txt_Nombre.Text)
                {
                    tip.Show("El nombre de la variable están ya se encuentra en uso.".Translate(), txt_Nombre, 3000);
                    return;
                }
            }

            SetupReturnedObject();

            ReferenceObject = null;
            DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReturnedObject = default;
            ReferenceObject = default;
            DialogResult = DialogResult.Cancel;
        }
        private void txt_Descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8) return;

            if (!char.IsLetterOrDigit(e.KeyChar) && !allowedSymbols.Contains(e.KeyChar))
            {
                e.Handled = true;
                tip.Show("Sólo se permiten letras, espacios o guiones bajos.\nEl nombre de variable debe poseer al menos una letra.".Translate(), txt_Nombre, 2000);
            }
        }
        private void combo_TipoVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_TipoVariable.SelectedIndex == -1) return;

            Tipo_Variable selected = (Tipo_Variable)combo_TipoVariable.SelectedIndex;

            bool cancelDialog = false;

            if (selected == Tipo_Variable.Monto)
            {
                var establecerDetalle = new f_EstablecerVariableDetalle1();

                establecerDetalle.ExceptObject = this.ExceptObject;

                if (establecerDetalle.ShowDialog() == DialogResult.OK)
                {
                    LimpiarAtributosDetalle();

                    dynamic returned = establecerDetalle.ReturnedObject;

                    if (returned is Transaccion) transaccion = returned;
                    else if (returned is Planificacion) planificacion = returned;
                    if (returned is PlantillaTransaccion) plantillaTransaccion = returned;
                }
                else cancelDialog = true;
            }
            else if (selected == Tipo_Variable.Balance || selected == Tipo_Variable.Balance_Potencial)
            {
                var establecerDetalle = new f_EstablecerVariableDetalle3();

                if (establecerDetalle.ShowDialog() == DialogResult.OK)
                {
                    LimpiarAtributosDetalle();

                    (cuenta, categoria, etiqueta, fecha) = establecerDetalle.ReturnedObject;
                }
                else cancelDialog = true;
            }
            else
            {
                var establecerDetalle = new f_EstablecerVariableDetalle2();

                if (establecerDetalle.ShowDialog() == DialogResult.OK)
                {
                    LimpiarAtributosDetalle();

                    (cuenta, categoria, etiqueta, lapso) = establecerDetalle.ReturnedObject;
                }
                else cancelDialog = true;
            }

            combo_TipoVariable.SelectedIndexChanged -= combo_TipoVariable_SelectedIndexChanged;
            if (cancelDialog && combo_tipoVariable_prev_selectedIndex != null) 
                combo_TipoVariable.SelectedIndex = (int)combo_tipoVariable_prev_selectedIndex;
            else if (cancelDialog && combo_tipoVariable_prev_selectedIndex == null)
                combo_TipoVariable.SelectedIndex = -1;
            combo_TipoVariable.SelectedIndexChanged += combo_TipoVariable_SelectedIndexChanged;

            combo_tipoVariable_prev_selectedIndex = combo_TipoVariable.SelectedIndex;

            RefreshDetalle();
        }
        private void f_EstablecerVariable_Shown(object sender, EventArgs e)
        {
            if (ReferenceObject != null)
                new Thread(() => { SetFields(ReferenceObject); }).Start();
        }

        private void f_EstablecerVariable_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
