using SL.BLL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls.UC
{
    public partial class UC_Filterable<T> : UserControl
    {
        protected Dictionary<object, Func<T, bool>> filters = new Dictionary<object, Func<T, bool>>();
        protected Dictionary<object, Func<T, bool>> filters_applied = new Dictionary<object, Func<T, bool>>();
        protected List<T> list = new List<T>();
        protected List<T> filtered_list = null;
        protected Func<T, dynamic> datasource_configuration = null;
        public UC_Filterable()
        {
            InitializeComponent();
        }

        private void UC_Filterable_ClientSizeChanged(object sender, EventArgs e)
        {
        }
        void SetupAll(bool justResize = false)
        {
            if (!justResize) this.BackColor = UI_Config.BackColor_Tab;
            SetupFlowFiltros(justResize);
        }
        void SetupFlowFiltros(bool justResize = false)
        {
            flow_Filtros.Size = new Size(this.ClientSize.Width - 20, 100);
            flow_Filtros.Location = new Point(0, 0);

            if (!justResize)
            {
                flow_Filtros.Font = UI_Config.Font_Default_Primary;
                flow_Filtros.ForeColor = UI_Config.ForeColor_Flow;
            }

            foreach (var control in flow_Filtros.Controls.Cast<Control>())
            {
                if (!(control is Panel))
                {
                    control.Size = new Size(
                    Convert.ToInt32(flow_Filtros.Width / flow_Filtros.ColumnCount - 5),
                    Convert.ToInt32(flow_Filtros.Height / flow_Filtros.RowCount - 5));
                    if (!justResize) SetupFlowControl(control);
                }
            }
        }
        protected void SetupFlowControl(Control control)
        {
            if (control is Label)
            {
                (control as Label).TextAlign = ContentAlignment.MiddleRight;
                (control as Label).Anchor = AnchorStyles.Right;
            }
            else if (control is ComboBox)
            {
                (control as ComboBox).SelectedIndex = -1;
                (control as ComboBox).SelectedIndex = -1;
            }
            else if (control is Button)
            {
            }
            else
            {
                //control.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        protected void Set_FilterButtonsVisibility()
        {
            int filterControls_count = flow_Filtros.Controls.Cast<Control>().Count(x => x != null);

            if (filterControls_count <= 2)
            {
                but_AplicarFiltros.Hide();
                but_ResetearFiltros.Hide();
            }
        }
        protected void SetFilter(object sender, Func<T, bool> filter)
        {
            if (!filters.ContainsKey(sender))
                filters.Add(sender, filter);
            else
                filters[sender] = filter;
        }
        protected void RemoveFilter(object sender)
        {
            if (filters.ContainsKey(sender))
                filters.Remove(sender);
        }
        protected virtual void RefreshList()
        {
            //TIENE QUE SER IMPLEMENTADO AL SER HEREDADO
            ApplyFilters();
            RefreshGrids();
            RefreshCharts();
        }
        protected virtual void RefreshListWithoutCharts()
        {
            //TIENE QUE SER IMPLEMENTADO AL SER HEREDADO
            ApplyFilters();
            RefreshGrids();
        }
        void ApplyFilters()
        {
            filtered_list = list.ToList();

            foreach (var filter in filters_applied)
                filtered_list = filtered_list.Where(filter.Value).ToList();
        }
        protected void ConfirmFilters()
        {
            filters_applied.Clear();

            foreach (var filter in filters)
                filters_applied[filter.Key] = filter.Value;

            ApplyFilters();
        }
        void ResetFilters()
        {
            foreach (var control in flow_Filtros.Controls.Cast<Control>())
            {
                if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                    (control as ComboBox).SelectedIndex = -1;
                }
                else if (control is TextBox)
                    control.Text = default;
                else if (control is CheckBox)
                    (control as CheckBox).Checked = false;
            }

            filters.Clear();

            SetDefaultValues();

            ConfirmFilters();
        }
        void RefreshGrids()
        {
            //Actualizo todos los grids existentes
            //Mejor práctica: lista de elementos a los que asignar el datasource, trabajada desde clases hijas
            var grids = Controls.Cast<Control>().Where(x => x is DataGridView).Cast<DataGridView>().ToList();
            grids.ForEach(x =>
            {
                x.DataSource = null;

                if (datasource_configuration == null) x.DataSource = filtered_list;
                else x.DataSource = filtered_list.Select(datasource_configuration).ToList();

                x.ClearSelection();

                x.SetupLanguageForDataGridView();
            });
        }
        protected virtual void SetDefaultValues()
        {
            //PARA REIMPLEMENTAR
        }
        protected virtual void RefreshCharts()
        {
            //SOLO PARA REIMPLEMENTACION
        }
        private void But_AplicarFiltros_Click(object sender, EventArgs e)
        {
            ConfirmFilters();
            RefreshGrids();
            RefreshCharts();
        }
        protected virtual void But_ResetearFiltros_Click(object sender, EventArgs e)
        {
            ResetFilters();
            RefreshGrids();
            RefreshCharts();
        }
        private void flow_Filtros_ControlAdded(object sender, ControlEventArgs e)
        {
            SetupFlowControl(e.Control);
        }
        private void ABMGrid_SizeChanged(object sender, EventArgs e)
        {
            SetupAll(true);
        }
        private void UC_ABMGrid_Load(object sender, EventArgs e)
        {
            SetupAll();
        }
        private void UC_Filterable_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;

            Set_FilterButtonsVisibility();
            RefreshList();
        }
    }
}
