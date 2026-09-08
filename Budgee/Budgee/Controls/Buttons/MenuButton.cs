using System;
using System.Drawing;
using UI.Controls.UC;
using UI.Forms;

namespace UI.Controls.Buttons
{
    public class MenuButton : DarkButton
    {
        UC_MenuTab Tab;
        f_Main TabContainer;
        public MenuButton(UC_MenuTab tab)
        {
            Tab = tab;
            Text = tab.Title;
            Size = new Size(Size.Width, Size.Height * 2);
            this.Click += ShowTab;
        }
        void ShowTab(object sender, EventArgs e)
        {
            TabContainer = f_Main.Current;
            TabContainer.SetTab(Tab);
        }
    }
}
