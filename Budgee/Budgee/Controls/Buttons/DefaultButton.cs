using System.Windows.Forms;

namespace UI.Controls.Buttons
{
    public class DefaultButton : Button
    {
        public DefaultButton()
        {
            Margin = new Padding(10, 10, 10, 0);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = UI_Config.Font_Default_Primary;
        }
    }
}
