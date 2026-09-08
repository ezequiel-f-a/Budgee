namespace UI.Controls.Buttons
{
    public class LightButton : DefaultButton
    {
        public LightButton()
        {
            ForeColor = UI_Config.ForeColor_LightButton;
            BackColor = UI_Config.BackColor_LightButton;
            FlatAppearance.MouseOverBackColor = UI_Config.BackColor_LightButton_Hover;
            FlatAppearance.MouseDownBackColor = UI_Config.BackColor_LightButton_Click;
        }
    }
}
