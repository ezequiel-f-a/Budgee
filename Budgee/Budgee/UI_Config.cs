using System.Drawing;

namespace UI
{
    static class UI_Config
    {
        #region Fonts
        public static Font Font_Default_Primary { get { return new Font("Segoe UI", 12, FontStyle.Bold); } }
        public static Font Font_Default_Secondary { get { return new Font("Segoe Print", Font_Default_Primary.Size, Font_Default_Primary.Style); } }
        #endregion
        #region Colors
        #region ForeColor
        public static Color ForeColor_StripMenu { get { return Color.FromArgb(244, 150, 96); } }
        public static Color ForeColor_Flow { get { return ForeColor_LightButton; } }
        public static Color ForeColor_LightButton { get { return Color.FromArgb(156, 61, 8); } }
        public static Color ForeColor_MediumButton { get { return ForeColor_LightButton; } }
        public static Color ForeColor_DarkButton { get { return BackColor_LightButton; } }
        public static Color ForeColor_DarkLabel { get { return ForeColor_LightButton; } }
        #endregion
        #region BackColor
        public static Color BackColor_LightBackground { get { return Color.FromArgb(242, 138, 79); } }
        public static Color BackColor_MediumBackground { get { return Color.FromArgb(228, 120, 58/*219, 108, 45*/); } }
        public static Color BackColor_DarkBackground { get { return Color.FromArgb(180, 79, 20); } }
        public static Color BackColor_StripMenu { get { return Color.FromArgb(155, 57, 0); } }
        public static Color BackColor_SideMenu { get { return BackColor_MediumBackground; } }
        public static Color BackColor_Tab { get { return BackColor_SideMenu; } }
        public static Color BackColor_Grid { get { return BackColor_DarkBackground; } }
        public static Color BackColor_LightButton { get { return BackColor_LightBackground; } }
        public static Color BackColor_LightButton_Hover { get { return Color.FromArgb(244, 150, 96); } }
        public static Color BackColor_LightButton_Click { get { return Color.FromArgb(255, 172, 125); } }
        public static Color BackColor_MediumButton { get { return BackColor_SideMenu; } }
        public static Color BackColor_MediumButton_Hover { get { return BackColor_LightButton; } }
        public static Color BackColor_MediumButton_Click { get { return BackColor_LightButton_Hover; } }
        public static Color BackColor_DarkButton { get { return ForeColor_LightButton; } }
        public static Color BackColor_DarkButton_Hover { get { return Color.FromArgb(187, 75, 13); } }
        public static Color BackColor_DarkButton_Click { get { return Color.FromArgb(214, 92, 25); } }
        #endregion
        #endregion
    }
}
