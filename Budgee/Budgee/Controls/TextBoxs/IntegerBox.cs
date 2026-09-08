using SL.Services;
using System;
using System.Windows.Forms;

namespace UI.Controls.TextBoxs
{
    public class IntegerBox : DefaultTextBox
    {
        ToolTip tip = new ToolTip() { AutoPopDelay = 9999 };
        bool _AllowText = false;
        public bool AllowText { get => _AllowText; set => _AllowText = value; }

        public IntegerBox()
        {
            KeyPress += NumericBox_KeyPress;
            TextChanged += IntegerBox_TextChanged;
        }

        private void IntegerBox_TextChanged(object sender, EventArgs e)
        {
            if (AllowText) return;

            if (!Int32.TryParse(Text, out _))
            {
                tip.Show("Sólo se aceptan números enteros.".Translate(), this, 1000);
                Text = "";
            }
        }

        private void NumericBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AllowText) return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                tip.Show("Sólo se aceptan números enteros.".Translate(), this, 1000);
            }
        }
    }
}
