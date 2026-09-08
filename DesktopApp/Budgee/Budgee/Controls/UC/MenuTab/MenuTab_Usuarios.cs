using SL.Services;
using System.Windows.Forms;

namespace UI.Controls.UC.MenuTab
{
    public partial class MenuTab_Usuarios : UC_MenuTab
    {
        public MenuTab_Usuarios()
        {
            InitializeComponent();
            Title = "Usuarios".Translate();
            panel_ControlArea.Controls.Add(new UC_AdministracionUsuarios() { Dock = DockStyle.Fill });
        }
    }
}
