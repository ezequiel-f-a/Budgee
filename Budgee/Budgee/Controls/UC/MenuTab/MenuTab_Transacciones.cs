using SL.Services;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls.UC.MenuTab
{
    public partial class MenuTab_Transacciones : UC_MenuTab
    {
        public MenuTab_Transacciones()
        {
            InitializeComponent();
            Title = "Transacciones".Translate();
            SetupAll();
        }
        void SetupAll()
        {
            SetupTabs();
        }
        void SetupTabs()
        {
            tabs_Transacciones.Appearance = TabAppearance.Normal;
            tabs_Transacciones.Font = UI_Config.Font_Default_Primary;
            tabs_Transacciones.TabPages.Cast<TabPage>().ToList().ForEach(x =>
            {
                x.BackColor = UI_Config.BackColor_LightButton;
                x.ForeColor = UI_Config.ForeColor_LightButton;
            });
        }
    }
}
