using SL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UI.Forms;

namespace UI.Controls.UC
{
    public partial class UC_MenuTab : UserControl
    {
        public string Title { get { return lbl_Title.Text; } protected set { lbl_Title.Text = value; } }
        public UC_MenuTab()
        {
            InitializeComponent();
            SetupAll();
            this.lbl_Title.Text = "DEBUG";
            f_Main.Current.ResizeEnd += ContainerSizeChangedSetup;
        }
        void SetupAll()
        {
            this.BackColor = UI_Config.BackColor_DarkBackground;
            SetupPanelWindow();
            SetupTitle();
            SetupButtonCloseTab();
            SetupPanelControlArea();
        }
        void SetupPanelWindow()
        {
            panel_Window.BackColor = UI_Config.BackColor_Tab;
            panel_Window.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            panel_Window.Size = new Size(this.ClientSize.Width - 50, this.ClientSize.Height - 50);
            panel_Window.Location = new Point(25, 25);
        }
        void SetupTitle()
        {
            lbl_Title.Font = new Font(UI_Config.Font_Default_Secondary.FontFamily, 40, FontStyle.Bold);
            lbl_Title.Size = new Size(panel_Window.Width, 90);
            lbl_Title.TextAlign = ContentAlignment.BottomCenter;
            lbl_Title.Dock = DockStyle.Top;
            lbl_Title.BackColor = Color.Transparent;
            lbl_Title.ForeColor = UI_Config.ForeColor_LightButton;
            lbl_Title.FlatStyle = FlatStyle.Flat;
            lbl_Title.Margin = new Padding(0);
            lbl_Title.BringToFront();
            panel_Window.SendToBack();
        }
        void SetupButtonCloseTab()
        {
            var locationX = lbl_Title.Size.Height - but_CloseTab.Size.Height * 2;
            var locationY = lbl_Title.Size.Height - but_CloseTab.Size.Height * 2;
            but_CloseTab.Font = new Font("Arial", 12, FontStyle.Bold);
            but_CloseTab.Size = new Size(30, 30);
            but_CloseTab.Location = new Point(locationX, locationY);
            but_CloseTab.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            but_CloseTab.BackColor = UI_Config.BackColor_DarkButton;
            but_CloseTab.ForeColor = UI_Config.ForeColor_DarkButton;
            but_CloseTab.FlatStyle = FlatStyle.Flat;
            but_CloseTab.Margin = new Padding(0);
            but_CloseTab.FlatAppearance.BorderSize = 0;
            //but_CloseTab.FlatAppearance.BorderColor = UI_Config.BackColor_DarkButton;
            but_CloseTab.FlatAppearance.MouseOverBackColor = UI_Config.BackColor_DarkButton_Hover;
            but_CloseTab.FlatAppearance.MouseDownBackColor = UI_Config.BackColor_DarkButton_Click;
            but_CloseTab.BringToFront();
            but_CloseTab.Click += but_CloseTab_Click;

        }
        void SetupPanelControlArea()
        {
            int margin = 25;
            int width = panel_Window.ClientSize.Width - margin * 2;
            int height = panel_Window.ClientSize.Height - lbl_Title.ClientSize.Height - margin;

            panel_ControlArea.BackColor = panel_Window.BackColor;
            panel_ControlArea.Anchor = panel_Window.Anchor;
            panel_ControlArea.Size = new Size(width, height);
            panel_ControlArea.Location = new Point(
                 panel_Window.ClientSize.Width - width - margin,
                panel_Window.ClientSize.Height - height - margin);
        }
        private void but_CloseTab_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            f_Main.Current.Controls.Remove(this);
        }
        private void SizeChangedSetup(object sender, EventArgs e)
        {
            SetupAll();
        }
        private void ContainerSizeChangedSetup(object sender, EventArgs e)
        {
            if (f_Main.Current.Controls.Cast<Control>().Where(x => x == this).Count() > 0)
            {
                f_Main.Current.SetTab(this);
                SetupAll();
            }
        }
        private void UC_MenuTab_VisibleChanged(object sender, EventArgs e)
        {
        }
        private void UC_MenuTab_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
