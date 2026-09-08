namespace UI.Controls.Buttons
{
    public class DarkButton : DefaultButton
    {
        public DarkButton()
        {
            ForeColor = UI_Config.ForeColor_DarkButton;
            BackColor = UI_Config.BackColor_DarkButton;
            FlatAppearance.MouseOverBackColor = UI_Config.BackColor_DarkButton_Hover;
            FlatAppearance.MouseDownBackColor = UI_Config.BackColor_DarkButton_Click;
        }
    }
}
