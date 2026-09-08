using BLL.Services;
using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_EstablecerExpresion : Form
    {
        ToolTip tip = new ToolTip() { AutoPopDelay = 9999 };
        List<Variable> variables = new List<Variable>();
        Dictionary<string, object> variables_internas = new Dictionary<string, object>()
        {{ "Pi", Math.PI },{ "e", Math.E }};
        char[] allowedSymbols = new char[] { '+', '-', '*', '/', '^', '.', '(', ')' };

        public Expresion ReturnedObject { get; private set; }
        public Expresion ReferenceObject { get; set; }
        public Guid? ExceptObject { get; set; }
        public f_EstablecerExpresion()
        {
            InitializeComponent();
            SetupAll();
        }
        protected void SetFields(Expresion referenceObject)
        {
            txt_Expresion.Text = referenceObject.Definicion;
            variables = referenceObject.Variables.ToList();

            RefreshGridVariables();
        }
        protected void SetupReturnedObject()
        {
            string definicion = txt_Expresion.Text;

            Tipo_Expresion tipo_Expresion = (txt_Expresion.Text.All(char.IsDigit)) ? Tipo_Expresion.Fija : Tipo_Expresion.Calculada;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Definicion = definicion;
                ReturnedObject.Tipo_Expresion = tipo_Expresion;
                ReturnedObject.Variables = variables.ToList();
            }
            else
            {
                ReturnedObject = new Expresion(
                    Guid.NewGuid(),
                    definicion,
                    variables.ToList(),
                    tipo_Expresion,
                    AppData.CurrentUser);
            }
        }
        void SetupAll()
        {
            BackColor = UI_Config.BackColor_MediumBackground;
            panel_ButtonsBorder.BackColor = UI_Config.BackColor_DarkBackground;
            panel_Buttons.BackColor = UI_Config.BackColor_MediumBackground;
            lbl_PreviewResultado.Text = $"{"Preview Resultado".Translate()}: N/A";
            ResizePanel(panel_ButtonsBorder, panel_Buttons);
        }
        void ResizePanel(Panel border, Panel inside)
        {
            inside.Size = new Size(border.Width - 4, border.Height - 4);
            inside.Location = new Point(2, 2);
        }
        void RefreshGridVariables()
        {
            grid_Variables.DataSource = null;
            grid_Variables.DataSource = variables.Select(x => new { Nombre = x.Nombre_Variable, Detalles = VariableService.Current.GetDescription(x)}).ToList();
            grid_Variables.SetupLanguageForDataGridView();
            grid_Variables.ClearSelection();
        }
        void AddToExpresion(string text)
        {
            int selectionStart = txt_Expresion.SelectionStart;

            if (!(selectionStart == 0 && txt_Expresion.SelectionLength == 0))
            {
                string selectedText = txt_Expresion.SelectedText;

                txt_Expresion.Text = txt_Expresion.Text.Remove(
                    selectionStart, selectedText.Length);

                FixDeletedVariables(selectedText, selectionStart);
            }

            int newSelectedIndex = txt_Expresion.SelectionStart + text.Length;
            txt_Expresion.SelectedText = text;
            FocusExpresion(newSelectedIndex);
        }
        void FocusExpresion(int? index = null)
        {
            txt_Expresion.Focus();
            txt_Expresion.SelectionLength = 0;
            txt_Expresion.SelectionStart = (index != null) ? (int)index : txt_Expresion.Text.Length;
        }
        void FixDeletedVariables(string text_deleted, int start_index)
        {
            //Ahora a borrar lo de atras del texto original

            //Hay que setear esto en el delete before text para trabajar con esto despues
            int new_start_index = start_index;
            int CountCorcheteRBeforeText = 0;

            //Primero busco y borro antes del texto borrado
            for (int i = start_index - 1; i >= 0; i--)
            {
                if (txt_Expresion.Text[i] == ']') CountCorcheteRBeforeText++;

                if (txt_Expresion.Text[i] == '[' && CountCorcheteRBeforeText < 1)
                {
                    new_start_index = i;
                    txt_Expresion.Text = txt_Expresion.Text.Remove(
                        i,
                        start_index - i);
                    break;
                }
            }

            //Ahora busco y borro despues del texto borrado
            int CountCorcheteLAfterText = 0;

            for (int i = new_start_index; i < txt_Expresion.Text.Length; i++)
            {
                if (txt_Expresion.Text[i] == '[') CountCorcheteLAfterText++;
                if (txt_Expresion.Text[i] == ']' && CountCorcheteLAfterText < 1)
                {
                    txt_Expresion.Text = txt_Expresion.Text.Remove(
                        new_start_index,
                        i - new_start_index + 1);
                    break;
                }
            }

            //Ahora focuseamos
            FocusExpresion(new_start_index);
        }
        Dictionary<string, object> GetVariablesDictionary()
        {
            var dic = new Dictionary<string, object>();
            variables.ForEach(x => dic.Add(x.Nombre_Variable, Convert.ToDouble(VariableService.Current.GetValue(x))));

            foreach (var interna in variables_internas)
                dic.Add(interna.Key, interna.Value);

            return dic;
        }
        private void but_Establecer_Click(object sender, EventArgs e)
        {
            var variables = GetVariablesDictionary();

            if (string.IsNullOrEmpty(txt_Expresion.Text))
            {
                MessageBox.Show("Falta ingresar la expresión.".Translate());
                return;
            }
            else if (!CalculatorService.ValidateExpression(txt_Expresion.Text, variables))
            {
                MessageBox.Show("La expresión es inválida.".Translate());
                return;
            }

            SetupReturnedObject();

            variables.Clear();
            ReferenceObject = null;
            ExceptObject = null;
            DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            variables.Clear();
            ReturnedObject = default;
            ReferenceObject = default;
            ExceptObject = null;
            DialogResult = DialogResult.Cancel;
        }
        private void but_AgregarVariable_Click(object sender, EventArgs e)
        {
            var talonario_variable = new f_EstablecerVariable(variables.Select(x=>x.Nombre_Variable));

            talonario_variable.ExceptObject = this.ExceptObject;

            if (talonario_variable.ShowDialog() == DialogResult.OK)
            {
                variables.Add(talonario_variable.ReturnedObject);
            }

            RefreshGridVariables();
        }
        private void but_EliminarVariable_Click(object sender, EventArgs e)
        {
            if (grid_Variables.SelectedRows.Count == 0) return;

            var dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el elemento seleccionado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel);

            if (dialogResult != DialogResult.OK) return;

            var variable = variables[grid_Variables.CurrentRow.Index];
            variables.Remove(variable);
            txt_Expresion.Text = txt_Expresion.Text.Replace($"[{variable.Nombre_Variable}]","");

            RefreshGridVariables();
        }
        private void but_ModificarVariable_Click(object sender, EventArgs e)
        {
            var talonario_variable = new f_EstablecerVariable(variables.Select(x => x.Nombre_Variable));

            talonario_variable.ExceptObject = this.ExceptObject;

            var variable = variables[grid_Variables.CurrentRow.Index];

            string old_name = variable.Nombre_Variable;

            talonario_variable.ReferenceObject = variable;

            if (talonario_variable.ShowDialog() == DialogResult.OK)
            {
                variables[grid_Variables.CurrentRow.Index] = talonario_variable.ReturnedObject;
                RefreshGridVariables();
                txt_Expresion.Text = txt_Expresion.Text.Replace($"[{old_name}]", $"[{variable.Nombre_Variable}]");
            }
        }
        private void but_InsertarVariable_Click(object sender, EventArgs e)
        {
            if (grid_Variables.SelectedRows.Count == 0) return;

            var variable = variables[grid_Variables.CurrentRow.Index];
            AddToExpresion($"[{variable.Nombre_Variable}]");
        }
        private void txt_Expresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evitar CTRL+V
            if (e.KeyChar == 22)
            {
                e.Handled = true;
                tip.Show("No está permitido pegar textos.".Translate(), txt_Expresion, 1000);
            }

            //Reemplazar símbolos

            if (e.KeyChar == 'x')
                e.KeyChar = '*';

            if (e.KeyChar == ',')
                e.KeyChar = '.';

            //Permitir simbolos matemáticos

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !allowedSymbols.Contains(e.KeyChar))
            {
                e.Handled = true;
                tip.Show("Entrada no válida.".Translate(), txt_Expresion, 1000);
            }
        }
        private void txt_Expresion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                int startIndex = default;
                string selectedText = default;

                if (e.KeyCode == Keys.Delete)
                {
                    if (txt_Expresion.SelectionStart == txt_Expresion.Text.Length) return;

                    startIndex = txt_Expresion.SelectionStart;

                    selectedText = (txt_Expresion.SelectedText.Length == 0) ?
                        txt_Expresion.Text[startIndex].ToString() : txt_Expresion.SelectedText;
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if (txt_Expresion.SelectionStart == 0 && txt_Expresion.SelectedText.Length == 0) return;

                    startIndex = (txt_Expresion.SelectedText.Length == 0) ?
                        txt_Expresion.SelectionStart - 1 : txt_Expresion.SelectionStart;

                    selectedText = (txt_Expresion.SelectedText.Length == 0) ?
                        txt_Expresion.Text[startIndex].ToString() : txt_Expresion.SelectedText;
                }

                txt_Expresion.Text = txt_Expresion.Text.Remove(startIndex, selectedText.Length);

                FixDeletedVariables(selectedText, startIndex);
            }
        }
        private void but_Clear_Click(object sender, EventArgs e)
        {
            txt_Expresion.Text = "";
        }
        private void but_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Expresion.Text.Length == 0) return;
            if (txt_Expresion.SelectionStart == 0 && txt_Expresion.SelectionLength == 0) return;

            int selectedCount = txt_Expresion.SelectedText.Length;

            int selectedIndex = (selectedCount == 0) ?
                txt_Expresion.SelectionStart - 1 :
                txt_Expresion.SelectionStart;

            string selectedText = (selectedCount == 0) ?
                txt_Expresion.Text[selectedIndex].ToString() :
                txt_Expresion.SelectedText;

            txt_Expresion.Text = txt_Expresion.Text.Remove(selectedIndex,
                (selectedCount == 0) ? 1 : selectedCount);

            FixDeletedVariables(selectedText, selectedIndex);

            if (!txt_Expresion.Focused)
                FocusExpresion(selectedIndex);
        }
        private void but_0_Click(object sender, EventArgs e)
        {
            AddToExpresion("0");
        }
        private void but_1_Click(object sender, EventArgs e)
        {
            AddToExpresion("1");
        }
        private void but_2_Click(object sender, EventArgs e)
        {
            AddToExpresion("2");
        }
        private void but_3_Click(object sender, EventArgs e)
        {
            AddToExpresion("3");
        }
        private void but_4_Click(object sender, EventArgs e)
        {
            AddToExpresion("4");
        }
        private void but_5_Click(object sender, EventArgs e)
        {
            AddToExpresion("5");
        }
        private void but_6_Click(object sender, EventArgs e)
        {
            AddToExpresion("6");
        }
        private void but_7_Click(object sender, EventArgs e)
        {
            AddToExpresion("7");
        }
        private void but_8_Click(object sender, EventArgs e)
        {
            AddToExpresion("8");
        }
        private void but_9_Click(object sender, EventArgs e)
        {
            AddToExpresion("9");
        }
        private void but_ParentesisL_Click(object sender, EventArgs e)
        {
            AddToExpresion("(");
        }
        private void but_ParenesisR_Click(object sender, EventArgs e)
        {
            AddToExpresion(")");
        }
        private void but_Coma_Click(object sender, EventArgs e)
        {
            AddToExpresion(".");
        }
        private void but_Igual_Click(object sender, EventArgs e)
        {
            var variables = GetVariablesDictionary();

            lbl_PreviewResultado.Text = $"{"Preview Resultado".Translate()}: ";

            if (string.IsNullOrEmpty(txt_Expresion.Text))
            {
                lbl_PreviewResultado.Text += "N/A";
            }
            else if (CalculatorService.ValidateExpression(txt_Expresion.Text, variables))
            {
                try
                {
                    lbl_PreviewResultado.Text += CalculatorService.SolveExpression(txt_Expresion.Text, variables);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetFullMessage());
                }
            }
            else
            {
                lbl_PreviewResultado.Text += "N/A";
                MessageBox.Show("La expresión es inválida.".Translate());
            }
        }
        private void but_Suma_Click(object sender, EventArgs e)
        {
            AddToExpresion("+");
        }
        private void but_Resta_Click(object sender, EventArgs e)
        {
            AddToExpresion("-");
        }
        private void but_Multiplicacion_Click(object sender, EventArgs e)
        {
            AddToExpresion("*");
        }
        private void but_Division_Click(object sender, EventArgs e)
        {
            AddToExpresion("/");
        }
        private void but_Potencia_Click(object sender, EventArgs e)
        {
            AddToExpresion("Pow(x,n)");
        }
        private void but_Raiz_Click(object sender, EventArgs e)
        {
            AddToExpresion("Pow(x,1/n)");
        }
        private void but_PotenciaCuadrada_Click(object sender, EventArgs e)
        {
            AddToExpresion("Pow(x,2)");
        }
        private void but_RaizCuadrada_Click(object sender, EventArgs e)
        {
            AddToExpresion("Sqrt(x)");
        }
        private void but_Log_Click(object sender, EventArgs e)
        {
            AddToExpresion("Log(x,y)");
        }
        private void but_Ln_Click(object sender, EventArgs e)
        {
            AddToExpresion("Log(x,[e])");
        }
        private void but_Sin_Click(object sender, EventArgs e)
        {
            AddToExpresion("Sin(x)");
        }
        private void but_Cos_Click(object sender, EventArgs e)
        {
            AddToExpresion("Cos(x)");
        }
        private void but_Tan_Click(object sender, EventArgs e)
        {
            AddToExpresion("Tan(x)");
        }
        private void but_ASin_Click(object sender, EventArgs e)
        {
            AddToExpresion("Asin(x)");
        }
        private void but_ACos_Click(object sender, EventArgs e)
        {
            AddToExpresion("Acos(x)");
        }
        private void but_ATan_Click(object sender, EventArgs e)
        {
            AddToExpresion("Atan(x)");
        }
        private void but_Modulo_Click(object sender, EventArgs e)
        {
            AddToExpresion("Abs(x)");
        }
        private void but_Pi_Click(object sender, EventArgs e)
        {
            AddToExpresion("[Pi]");
        }
        private void but_e_Click(object sender, EventArgs e)
        {
            AddToExpresion("[e]");
        }
        private void f_EstablecerExpresion_Shown(object sender, EventArgs e)
        {
            if (ReferenceObject != null)
                new Thread(() => { SetFields(ReferenceObject); }).Start();
        }

        private void f_EstablecerExpresion_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
