using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Controls.TextBoxs
{
    public class DefaultTextBox : TextBox
    {
        Color _DisabledColor = UI_Config.BackColor_MediumBackground;
        public Color DisabledColor
        {
            get { return _DisabledColor; }
            set
            {
                _DisabledColor = value;
                SetupDisabledColor();
            }
        }
        public DefaultTextBox()
        {
            Font = UI_Config.Font_Default_Primary;

            BorderStyle = BorderStyle.FixedSingle;
            ReadOnlyChanged += DefaultTextBox_ReadOnlyChanged;
            EnabledChanged += DefaultTextBox_EnabledChanged;
            SetupDisabledColor();
        }
        void SetupDisabledColor()
        {
            if (ReadOnly || !Enabled)
                BackColor = DisabledColor;
            else
                BackColor = SystemColors.Window;
        }
        private void DefaultTextBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            SetupDisabledColor();
        }
        private void DefaultTextBox_EnabledChanged(object sender, EventArgs e)
        {
            SetupDisabledColor();
        }
    }
}
