using SL.Services;
using System.Windows.Forms;

namespace UI.Controls.UC.MenuTab
{
    public partial class MenuTab_Familias : UC_MenuTab
    {
        public MenuTab_Familias()
        {
            InitializeComponent();
            Title = "Perfiles".Translate();
            panel_ControlArea.Controls.Add(new UC_AdministracionFamilias() { Dock = DockStyle.Fill });
        }
    }
}
