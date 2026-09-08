using SL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.UC.MenuTab
{
    public partial class MenuTab_Notificaciones : UC_MenuTab
    {
        public MenuTab_Notificaciones()
        {
            InitializeComponent();
            Title = "Notificaciones".Translate();
            SetupAll();
        }
        void SetupAll()
        {
            SetupTabs();
        }
        void SetupTabs()
        {
            tabs_Notificaciones.Appearance = TabAppearance.Normal;
            tabs_Notificaciones.Font = UI_Config.Font_Default_Primary;
            tabs_Notificaciones.TabPages.Cast<TabPage>().ToList().ForEach(x =>
            {
                x.BackColor = UI_Config.BackColor_LightButton;
                x.ForeColor = UI_Config.ForeColor_LightButton;
            });
        }
    }
}
