
namespace UI.Controls.UC
{
    partial class UC_Overview
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
            this.grid_Overview = new UI.Controls.Grids.DefaultDataGridView();
            this.lbl_BalanceGlobal = new System.Windows.Forms.Label();
            this.lbl_BalanceGlobalPotencial = new System.Windows.Forms.Label();
            this.but_Exportar = new UI.Controls.Buttons.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Overview)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_Overview
            // 
            this.grid_Overview.AllowUserToAddRows = false;
            this.grid_Overview.AllowUserToDeleteRows = false;
            this.grid_Overview.AllowUserToResizeRows = false;
            this.grid_Overview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_Overview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Overview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Overview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Overview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Overview.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Overview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Overview.Location = new System.Drawing.Point(15, 76);
            this.grid_Overview.MultiSelect = false;
            this.grid_Overview.Name = "grid_Overview";
            this.grid_Overview.ReadOnly = true;
            this.grid_Overview.RowHeadersVisible = false;
            this.grid_Overview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Overview.Size = new System.Drawing.Size(599, 289);
            this.grid_Overview.TabIndex = 0;
            // 
            // lbl_BalanceGlobal
            // 
            this.lbl_BalanceGlobal.AutoSize = true;
            this.lbl_BalanceGlobal.Location = new System.Drawing.Point(21, 18);
            this.lbl_BalanceGlobal.Name = "lbl_BalanceGlobal";
            this.lbl_BalanceGlobal.Size = new System.Drawing.Size(94, 13);
            this.lbl_BalanceGlobal.TabIndex = 1;
            this.lbl_BalanceGlobal.Text = "Balance Global: ...";
            // 
            // lbl_BalanceGlobalPotencial
            // 
            this.lbl_BalanceGlobalPotencial.AutoSize = true;
            this.lbl_BalanceGlobalPotencial.Location = new System.Drawing.Point(21, 43);
            this.lbl_BalanceGlobalPotencial.Name = "lbl_BalanceGlobalPotencial";
            this.lbl_BalanceGlobalPotencial.Size = new System.Drawing.Size(141, 13);
            this.lbl_BalanceGlobalPotencial.TabIndex = 2;
            this.lbl_BalanceGlobalPotencial.Text = "Balance Global Potencial: ...";
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
            // UC_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.but_Exportar);
            this.Controls.Add(this.lbl_BalanceGlobalPotencial);
            this.Controls.Add(this.lbl_BalanceGlobal);
            this.Controls.Add(this.grid_Overview);
            this.Name = "UC_Overview";
            this.Size = new System.Drawing.Size(630, 383);
            this.SizeChanged += new System.EventHandler(this.UC_Overview_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.UC_Overview_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Overview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Grids.DefaultDataGridView grid_Overview;
        private System.Windows.Forms.Label lbl_BalanceGlobal;
        private System.Windows.Forms.Label lbl_BalanceGlobalPotencial;
        private Buttons.DarkButton but_Exportar;
    }
}
