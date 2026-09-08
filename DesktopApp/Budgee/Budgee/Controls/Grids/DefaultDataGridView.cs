using System.Drawing;
using System.Windows.Forms;

namespace UI.Controls.Grids
{
    public class DefaultDataGridView : DataGridView
    {
        public DefaultDataGridView()
        {
            Font = UI_Config.Font_Default_Primary;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { Font = this.Font };
            DefaultCellStyle = new DataGridViewCellStyle() { Font = new Font(this.Font.FontFamily, 10) };
            ForeColor = Color.Black;
            BackgroundColor = UI_Config.BackColor_Grid;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToResizeRows = false;
            MultiSelect = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ReadOnly = true;
        }
        public DefaultDataGridView(bool allow_abm)
        {
            Font = UI_Config.Font_Default_Primary;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { Font = this.Font };
            DefaultCellStyle = new DataGridViewCellStyle() { Font = new Font(this.Font.FontFamily, 10) };
            BackgroundColor = UI_Config.BackColor_Grid;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToResizeRows = false;
            MultiSelect = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AllowUserToAddRows = allow_abm;
            AllowUserToDeleteRows = allow_abm;
            ReadOnly = !allow_abm;
        }
    }
}
