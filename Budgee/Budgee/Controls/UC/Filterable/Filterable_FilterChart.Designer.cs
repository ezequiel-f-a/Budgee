
namespace UI.Controls.UC.Filterable
{
    partial class Filterable_FilterChart<U, T>
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
            this.panel_Chart = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_Chart
            // 
            this.panel_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Chart.Location = new System.Drawing.Point(15, 117);
            this.panel_Chart.Name = "panel_Chart";
            this.panel_Chart.Size = new System.Drawing.Size(598, 246);
            this.panel_Chart.TabIndex = 6;
            // 
            // Filterable_FilterChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Chart);
            this.Name = "Filterable_FilterChart";
            this.SizeChanged += new System.EventHandler(this.Filterable_FilterChart_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.Filterable_FilterChart_VisibleChanged);
            this.Load += new System.EventHandler(this.Filterable_FilterChart_Load);
            this.Controls.SetChildIndex(this.panel_Chart, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel_Chart;
    }
}
