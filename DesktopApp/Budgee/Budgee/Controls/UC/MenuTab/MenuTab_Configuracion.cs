using SL.Services;
using System.Windows.Forms;

namespace UI.Controls.UC.MenuTab
{
    public partial class MenuTab_Configuracion : UC_MenuTab
    {
        public MenuTab_Configuracion()
        {
            InitializeComponent();
            Title = "Configuración".Translate();
            this.panel_ControlArea.Controls.Add(new UC_Configuracion() { Dock = DockStyle.Fill });
        }
    }
}
