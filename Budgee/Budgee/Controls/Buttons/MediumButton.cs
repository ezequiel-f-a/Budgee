namespace UI.Controls.Buttons
{
    public class MediumButton : DefaultButton
    {
        public MediumButton()
        {
            ForeColor = UI_Config.ForeColor_MediumButton;
            BackColor = UI_Config.BackColor_MediumButton;
            FlatAppearance.MouseOverBackColor = UI_Config.BackColor_MediumButton_Hover;
            FlatAppearance.MouseDownBackColor = UI_Config.BackColor_MediumButton_Click;
        }
    }
}
