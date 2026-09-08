using Enums;
using SL.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.UC.FilterChart;

namespace UI.Controls.UC.MenuTab
{
    public partial class MenuTab_Estadisticas : UC_MenuTab
    {
        Tipo_Estadistica[] tabs_index = new Tipo_Estadistica[5]
        {
            Tipo_Estadistica.Overview,
            Tipo_Estadistica.IngresoEgreso,
            Tipo_Estadistica.PatrimonioNeto,
            Tipo_Estadistica.Distribucion,
            Tipo_Estadistica.Presupuesto
        };
        public Tipo_Estadistica CurrentTab 
        {
            get { return tabs_index[tabs_Estadisticas.SelectedIndex]; }
            set { tabs_Estadisticas.SelectedIndex = tabs_index.ToList().IndexOf(value); }
        }
        public MenuTab_Estadisticas()
        {
            InitializeComponent();
            Title = "Estadísticas".Translate();
            SetupAll();
        }
        void SetupAll()
        {
            SetupTabs();
        }
        void SetupTabs()
        {
            tabs_Estadisticas.Appearance = TabAppearance.Normal;
            tabs_Estadisticas.Font = UI_Config.Font_Default_Primary;
            tabs_Estadisticas.TabPages.Cast<TabPage>().ToList().ForEach(x =>
            {
                x.BackColor = UI_Config.BackColor_LightButton;
                x.ForeColor = UI_Config.ForeColor_LightButton;
            });

            tab_Overview.Controls.Add(new UC_Overview() { Dock = DockStyle.Fill });
            tab_IngresoEgreso.Controls.Add(new FilterChart_IngresoEgreso() { Dock = DockStyle.Fill });
            tab_PatrimonioNeto.Controls.Add(new FilterChart_PatrimonioNeto() { Dock = DockStyle.Fill });
            tab_Distribucion.Controls.Add(new FilterChart_Distribucion() { Dock = DockStyle.Fill });
            tab_HolguraPresupuesto.Controls.Add(new UC_HolguraPresupuesto() { Dock = DockStyle.Fill });
        }
    }
}
