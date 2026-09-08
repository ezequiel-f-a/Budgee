
namespace UI.Controls.UC
{
    partial class UC_Filterable<T>
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
            this.flow_Filtros = new System.Windows.Forms.TableLayoutPanel();
            this.but_AplicarFiltros = new UI.Controls.Buttons.DarkButton();
            this.but_ResetearFiltros = new UI.Controls.Buttons.DarkButton();
            this.flow_Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow_Filtros
            // 
            this.flow_Filtros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flow_Filtros.BackColor = System.Drawing.Color.Transparent;
            this.flow_Filtros.ColumnCount = 6;
            this.flow_Filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.flow_Filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.flow_Filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.flow_Filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.flow_Filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.flow_Filtros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.flow_Filtros.Controls.Add(this.but_AplicarFiltros, 4, 2);
            this.flow_Filtros.Controls.Add(this.but_ResetearFiltros, 5, 2);
            this.flow_Filtros.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.flow_Filtros.Location = new System.Drawing.Point(15, 3);
            this.flow_Filtros.Name = "flow_Filtros";
            this.flow_Filtros.RowCount = 3;
            this.flow_Filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_Filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_Filtros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_Filtros.Size = new System.Drawing.Size(599, 91);
            this.flow_Filtros.TabIndex = 5;
            this.flow_Filtros.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flow_Filtros_ControlAdded);
            // 
            // but_AplicarFiltros
            // 
            this.but_AplicarFiltros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_AplicarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_AplicarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_AplicarFiltros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_AplicarFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_AplicarFiltros.Location = new System.Drawing.Point(401, 68);
            this.but_AplicarFiltros.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.but_AplicarFiltros.Name = "but_AplicarFiltros";
            this.but_AplicarFiltros.Size = new System.Drawing.Size(89, 23);
            this.but_AplicarFiltros.TabIndex = 6;
            this.but_AplicarFiltros.Text = "Aplicar Filtros";
            this.but_AplicarFiltros.UseVisualStyleBackColor = true;
            this.but_AplicarFiltros.Click += new System.EventHandler(this.But_AplicarFiltros_Click);
            // 
            // but_ResetearFiltros
            // 
            this.but_ResetearFiltros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_ResetearFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_ResetearFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ResetearFiltros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_ResetearFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_ResetearFiltros.Location = new System.Drawing.Point(500, 68);
            this.but_ResetearFiltros.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.but_ResetearFiltros.Name = "but_ResetearFiltros";
            this.but_ResetearFiltros.Size = new System.Drawing.Size(94, 23);
            this.but_ResetearFiltros.TabIndex = 2;
            this.but_ResetearFiltros.Text = "Resetear Filtros";
            this.but_ResetearFiltros.UseVisualStyleBackColor = true;
            this.but_ResetearFiltros.Click += new System.EventHandler(this.But_ResetearFiltros_Click);
            // 
            // UC_Filterable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flow_Filtros);
            this.Name = "UC_Filterable";
            this.Size = new System.Drawing.Size(630, 383);
            this.Load += new System.EventHandler(this.UC_ABMGrid_Load);
            this.SizeChanged += new System.EventHandler(this.ABMGrid_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.UC_Filterable_VisibleChanged);
            this.flow_Filtros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.TableLayoutPanel flow_Filtros;
        protected Buttons.DarkButton but_ResetearFiltros;
        protected Buttons.DarkButton but_AplicarFiltros;
    }
}
