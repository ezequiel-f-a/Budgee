using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Controls.UC
{
    public partial class UC_SideMenu : UserControl
    {
        List<Button> menuButtons = new List<Button>();
        Size MaximizedSize;
        bool IsMinimized = false;
        public UC_SideMenu(List<Button> buttons)
        {
            InitializeComponent();

            menuButtons = buttons;

            SetupAll();
        }
        void SetupAll()
        {
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            this.BackColor = UI_Config.BackColor_SideMenu;

            SetupSwitchMinimize();
            SetupFlow();
        }
        void SetupSwitchMinimize()
        {
            but_SwitchMinimize.BackColor = UI_Config.BackColor_MediumButton;
            but_SwitchMinimize.ForeColor = UI_Config.ForeColor_MediumButton;
            but_SwitchMinimize.FlatAppearance.BorderSize = 5;
            but_SwitchMinimize.FlatAppearance.BorderColor = UI_Config.BackColor_DarkBackground;
            but_SwitchMinimize.FlatAppearance.MouseOverBackColor = UI_Config.BackColor_MediumButton_Hover;
            but_SwitchMinimize.FlatAppearance.MouseDownBackColor = UI_Config.BackColor_MediumButton_Click;
        }
        void SetupFlow()
        {
            flow_Menu.Size = new Size(this.Size.Width - but_SwitchMinimize.Size.Width, this.ClientSize.Height);
            flow_Menu.Location = new Point(0, 0);
            flow_Menu.Controls.Clear();
            menuButtons.ForEach(x => x.Size = new Size(flow_Menu.ClientSize.Width - x.Margin.Horizontal, x.Size.Height));
            flow_Menu.Controls.AddRange(menuButtons.ToArray());
        }
        void Minimize()
        {
            MaximizedSize = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.ClientSize = new Size(this.ClientSize.Width - flow_Menu.Size.Width, this.ClientSize.Height);
            but_SwitchMinimize.Text = ">";
            IsMinimized = true;
        }
        void Maximize()
        {
            this.ClientSize = new Size(MaximizedSize.Width, MaximizedSize.Height);
            but_SwitchMinimize.Text = "<";
            IsMinimized = false;
        }
        private void UC_SideMenu_SizeChanged(object sender, EventArgs e)
        {
            SetupFlow();
        }
        private void but_SwitchMinimize_Click(object sender, EventArgs e)
        {
            if (MaximizedSize != null)
                MaximizedSize = new Size(MaximizedSize.Width, this.ClientSize.Height);

            if (IsMinimized)
                Maximize();
            else
                Minimize();
        }
    }
}
