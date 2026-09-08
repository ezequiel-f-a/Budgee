using System.Windows.Forms;

namespace UI.Controls.Labels
{
    public class DefaultLabel : Label
    {
        public DefaultLabel()
        {
            BackColor = System.Drawing.Color.Transparent;
            AutoSize = false;
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            FlatStyle = FlatStyle.Flat;
            Font = UI_Config.Font_Default_Primary;
        }
    }
}
