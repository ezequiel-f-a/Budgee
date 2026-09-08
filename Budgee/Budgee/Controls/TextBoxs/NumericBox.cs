using SL.Services;
using System;
using System.Windows.Forms;

namespace UI.Controls.TextBoxs
{
    public class NumericBox : DefaultTextBox
    {
        ToolTip tip = new ToolTip() { AutoPopDelay = 9999 };
        bool _AllowText = false;
        public bool AllowText { get => _AllowText; set => _AllowText = value; }
        public NumericBox()
        {
            KeyPress += NumericBox_KeyPress;
            TextChanged += NumericBox_TextChanged;
        }

        private void NumericBox_TextChanged(object sender, EventArgs e)
        {
            if (AllowText) return;

            if (!Double.TryParse(Text, out _))
            {
                tip.Show("Sólo se aceptan números.".Translate(), this, 1000);
                Text = "";
            }
        }

        private void NumericBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AllowText) return;

            if (e.KeyChar == ',')
                e.KeyChar = '.';

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                tip.Show("Sólo se aceptan números.".Translate(), this, 1000);
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                tip.Show("El número ya tiene punto decimal.".Translate(), this, 1000);
            }
        }
    }
}
