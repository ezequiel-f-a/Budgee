using SL.BLL.Contracts;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls.UC.Filterable
{
    public partial class Filterable_FilterGrid<T> : UC_Filterable<T>
    {
        private readonly bool _HasButtons = true;
        protected IGenericBusinessLogic<T> servicio;

        public bool HasButtons { get => _HasButtons; }

        public Filterable_FilterGrid(bool hasButtons)
        {
            InitializeComponent();
            _HasButtons = hasButtons;
        }
        void SetupAll(bool justResize = false)
        {
            SetupFlowButtons(justResize);
            SetupGrid(justResize);
        }
        void SetupFlowButtons(bool justResize = false)
        {
            if (!HasButtons)
            {
                this.Controls.Remove(flow_Buttons);
                return;
            }

            flow_Buttons.Size = new Size(this.ClientSize.Width - 20, 50);
            flow_Buttons.Location = new Point(10, this.ClientSize.Height - flow_Buttons.Height);

            if (!justResize)
            {
                flow_Buttons.Font = UI_Config.Font_Default_Primary;
            }

            foreach (var control in flow_Buttons.Controls.Cast<Control>())
            {
                if (!(control is Panel))
                {
                    control.Size = new Size(
                    Convert.ToInt32(flow_Buttons.Width / flow_Buttons.ColumnCount - 5),
                    Convert.ToInt32(flow_Buttons.Height / flow_Buttons.RowCount - 20));
                    if (!justResize) SetupFlowControl(control);
                }
            }
        }
        void SetupGrid(bool justResize)
        {
            int margin = 15;

            int width = this.ClientSize.Width - margin * 2;
            int height = (HasButtons) ?
                this.ClientSize.Height - flow_Filtros.Height - flow_Buttons.Height - 10 :
                this.ClientSize.Height - flow_Filtros.Height - margin - 10;

            int x = margin;
            int y = flow_Filtros.Height + 10;

            grid_Main.Size = new Size(width, height);
            grid_Main.Location = new Point(x, y);

            if (!justResize)
            {
                grid_Main.Font = new Font(UI_Config.Font_Default_Primary.FontFamily, 8);
                grid_Main.BackgroundColor = UI_Config.BackColor_DarkBackground;
            }
        }
        private void flow_Buttons_ControlAdded(object sender, ControlEventArgs e)
        {
            SetupFlowButtons();
        }
        private void ABMGrid_SizeChanged(object sender, EventArgs e)
        {
            SetupAll(true);
        }
        private void Grid_ABM_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            grid_Main.ClearSelection();
        }
        private void Grid_ABM_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e)
        {
            grid_Main.ClearSelection();
        }
        private void UC_ABMGrid_Load(object sender, EventArgs e)
        {
            SetupAll();
        }
    }
}
