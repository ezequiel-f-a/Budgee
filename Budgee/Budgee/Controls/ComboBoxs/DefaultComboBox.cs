using System.Windows.Forms;

namespace UI.Controls.ComboBoxs
{
    public class DefaultComboBox : ComboBox
    {
        public DefaultComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            Font = UI_Config.Font_Default_Primary;
            Margin = new Padding(10, 10, 10, 0);
        }
    }
}
