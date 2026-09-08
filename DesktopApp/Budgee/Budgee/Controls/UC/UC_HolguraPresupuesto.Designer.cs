
namespace UI.Controls.UC
{
    partial class UC_HolguraPresupuesto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_PresupuestoTitle = new System.Windows.Forms.Label();
            this.lbl_DetalleTitle = new System.Windows.Forms.Label();
            this.panel_Presupuesto = new System.Windows.Forms.Panel();
            this.chartBar_Presupuesto = new LiveCharts.WinForms.CartesianChart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_DetalleValue = new System.Windows.Forms.Label();
            this.lbl_PresupuestoValue = new System.Windows.Forms.Label();
            this.but_Exportar = new UI.Controls.Buttons.DarkButton();
            this.grid_Presupuestos = new UI.Controls.Grids.DefaultDataGridView();
            this.panel_Presupuesto.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Presupuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_PresupuestoTitle
            // 
            this.lbl_PresupuestoTitle.AutoSize = true;
            this.lbl_PresupuestoTitle.Location = new System.Drawing.Point(21, 39);
            this.lbl_PresupuestoTitle.Name = "lbl_PresupuestoTitle";
            this.lbl_PresupuestoTitle.Size = new System.Drawing.Size(137, 13);
            this.lbl_PresupuestoTitle.TabIndex = 1;
            this.lbl_PresupuestoTitle.Text = "Presupuesto Seleccionado:";
            // 
            // lbl_DetalleTitle
            // 
            this.lbl_DetalleTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DetalleTitle.AutoSize = true;
            this.lbl_DetalleTitle.Location = new System.Drawing.Point(21, 8);
            this.lbl_DetalleTitle.Name = "lbl_DetalleTitle";
            this.lbl_DetalleTitle.Size = new System.Drawing.Size(43, 13);
            this.lbl_DetalleTitle.TabIndex = 2;
            this.lbl_DetalleTitle.Text = "Detalle:";
            // 
            // panel_Presupuesto
            // 
            this.panel_Presupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Presupuesto.Controls.Add(this.chartBar_Presupuesto);
            this.panel_Presupuesto.Location = new System.Drawing.Point(376, 0);
            this.panel_Presupuesto.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel_Presupuesto.Name = "panel_Presupuesto";
            this.panel_Presupuesto.Size = new System.Drawing.Size(223, 291);
            this.panel_Presupuesto.TabIndex = 4;
            // 
            // chartBar_Presupuesto
            // 
            this.chartBar_Presupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartBar_Presupuesto.Location = new System.Drawing.Point(8, 10);
            this.chartBar_Presupuesto.Margin = new System.Windows.Forms.Padding(10);
            this.chartBar_Presupuesto.Name = "chartBar_Presupuesto";
            this.chartBar_Presupuesto.Size = new System.Drawing.Size(205, 271);
            this.chartBar_Presupuesto.TabIndex = 0;
            this.chartBar_Presupuesto.Text = "cartesianChart1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.93656F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.06344F));
            this.tableLayoutPanel1.Controls.Add(this.panel_Presupuesto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grid_Presupuestos, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 291);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbl_DetalleValue
            // 
            this.lbl_DetalleValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DetalleValue.AutoSize = true;
            this.lbl_DetalleValue.Location = new System.Drawing.Point(21, 23);
            this.lbl_DetalleValue.Name = "lbl_DetalleValue";
            this.lbl_DetalleValue.Size = new System.Drawing.Size(27, 13);
            this.lbl_DetalleValue.TabIndex = 6;
            this.lbl_DetalleValue.Text = "N/A";
            // 
            // lbl_PresupuestoValue
            // 
            this.lbl_PresupuestoValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PresupuestoValue.AutoSize = true;
            this.lbl_PresupuestoValue.Location = new System.Drawing.Point(21, 53);
            this.lbl_PresupuestoValue.Name = "lbl_PresupuestoValue";
            this.lbl_PresupuestoValue.Size = new System.Drawing.Size(27, 13);
            this.lbl_PresupuestoValue.TabIndex = 7;
            this.lbl_PresupuestoValue.Text = "N/A";
            // 
            // but_Exportar
            // 
            this.but_Exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Exportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Exportar.FlatAppearance.BorderSize = 0;
            this.but_Exportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Exportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Exportar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Exportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Exportar.Location = new System.Drawing.Point(526, 45);
            this.but_Exportar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Exportar.Name = "but_Exportar";
            this.but_Exportar.Size = new System.Drawing.Size(89, 17);
            this.but_Exportar.TabIndex = 3;
            this.but_Exportar.Text = "Exportar...";
            this.but_Exportar.UseVisualStyleBackColor = false;
            this.but_Exportar.Click += new System.EventHandler(this.but_Exportar_Click);
            // 
            // grid_Presupuestos
            // 
            this.grid_Presupuestos.AllowUserToAddRows = false;
            this.grid_Presupuestos.AllowUserToDeleteRows = false;
            this.grid_Presupuestos.AllowUserToResizeRows = false;
            this.grid_Presupuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_Presupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Presupuestos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Presupuestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Presupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Presupuestos.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Presupuestos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Presupuestos.Location = new System.Drawing.Point(0, 0);
            this.grid_Presupuestos.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.grid_Presupuestos.MultiSelect = false;
            this.grid_Presupuestos.Name = "grid_Presupuestos";
            this.grid_Presupuestos.ReadOnly = true;
            this.grid_Presupuestos.RowHeadersVisible = false;
            this.grid_Presupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Presupuestos.Size = new System.Drawing.Size(366, 291);
            this.grid_Presupuestos.TabIndex = 0;
            this.grid_Presupuestos.SelectionChanged += new System.EventHandler(this.grid_Presupuestos_SelectionChanged);
            // 
            // UC_HolguraPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_PresupuestoValue);
            this.Controls.Add(this.lbl_DetalleValue);
            this.Controls.Add(this.but_Exportar);
            this.Controls.Add(this.lbl_DetalleTitle);
            this.Controls.Add(this.lbl_PresupuestoTitle);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_HolguraPresupuesto";
            this.Size = new System.Drawing.Size(630, 383);
            this.SizeChanged += new System.EventHandler(this.UC_Overview_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.UC_Overview_VisibleChanged);
            this.panel_Presupuesto.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Presupuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Grids.DefaultDataGridView grid_Presupuestos;
        private System.Windows.Forms.Label lbl_PresupuestoTitle;
        private System.Windows.Forms.Label lbl_DetalleTitle;
        private Buttons.DarkButton but_Exportar;
        private System.Windows.Forms.Panel panel_Presupuesto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_DetalleValue;
        private System.Windows.Forms.Label lbl_PresupuestoValue;
        private LiveCharts.WinForms.CartesianChart chartBar_Presupuesto;
    }
}
