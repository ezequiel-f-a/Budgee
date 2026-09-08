using System.Drawing;
using System.Windows.Forms;

namespace UI.Controls.Labels
{
    class DefaultCheckbox : CheckBox
    {
        public DefaultCheckbox()
        {
            BackColor = System.Drawing.Color.Transparent;
            AutoSize = false;
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            FlatStyle = FlatStyle.Flat;
            Font = new Font(UI_Config.Font_Default_Primary.FontFamily, 12, FontStyle.Regular);
        }
    }
}
