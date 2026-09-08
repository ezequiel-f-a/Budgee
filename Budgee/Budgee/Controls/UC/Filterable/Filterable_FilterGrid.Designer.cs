
namespace UI.Controls.UC.Filterable
{
    partial class Filterable_FilterGrid<T>
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
            this.grid_Main = new global::UI.Controls.Grids.DefaultDataGridView();
            this.flow_Buttons = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Main)).BeginInit();
            this.flow_Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_ABM
            // 
            this.grid_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Main.Location = new System.Drawing.Point(15, 100);
            this.grid_Main.Name = "grid_ABM";
            this.grid_Main.RowHeadersVisible = false;
            this.grid_Main.Size = new System.Drawing.Size(599, 225);
            this.grid_Main.TabIndex = 0;
            this.grid_Main.RowsAdded += Grid_ABM_RowsAdded;
            this.grid_Main.RowsRemoved += Grid_ABM_RowsRemoved;
            // 
            // flow_Buttons
            // 
            this.flow_Buttons.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flow_Buttons.BackColor = System.Drawing.Color.Transparent;
            this.flow_Buttons.ColumnCount = 6;
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flow_Buttons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.flow_Buttons.Location = new System.Drawing.Point(15, 329);
            this.flow_Buttons.Name = "flow_Buttons";
            this.flow_Buttons.RowCount = 1;
            this.flow_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flow_Buttons.Size = new System.Drawing.Size(599, 42);
            this.flow_Buttons.TabIndex = 4;
            this.flow_Buttons.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flow_Buttons_ControlAdded);
            // 
            // UC_FilterGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flow_Filtros);
            this.Controls.Add(this.flow_Buttons);
            this.Controls.Add(this.grid_Main);
            this.Name = "UC_FilterGrid";
            this.Size = new System.Drawing.Size(630, 383);
            this.Load += new System.EventHandler(this.UC_ABMGrid_Load);
            this.SizeChanged += new System.EventHandler(this.ABMGrid_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Main)).EndInit();
            this.flow_Filtros.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        

        #endregion
        protected System.Windows.Forms.TableLayoutPanel flow_Buttons;
        protected global::UI.Controls.Grids.DefaultDataGridView grid_Main;
    }
}
