
namespace UI.Controls.UC.FilterChart
{
    partial class FilterChart_Distribucion
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
            this.chart_Distribucion = new LiveCharts.WinForms.PieChart();
            this.panel_Chart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Chart
            // 
            this.panel_Chart.Controls.Add(this.chart_Distribucion);
            // 
            // chart_IngresoEgreso
            // 
            this.chart_Distribucion.Location = new System.Drawing.Point(15, 15);
            this.chart_Distribucion.Margin = new System.Windows.Forms.Padding(15);
            this.chart_Distribucion.Name = "chart_Distribucion";
            this.chart_Distribucion.Size = new System.Drawing.Size(568, 216);
            this.chart_Distribucion.TabIndex = 0;
            this.chart_Distribucion.Text = "chart_Distribucion";
            // 
            // FilterChart_Distribucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilterChart_Distribucion";
            this.Load += new System.EventHandler(FilterChart_Distribucion_Load);
            this.VisibleChanged += new System.EventHandler(FilterChart_Distribucion_VisibleChanged);
            this.panel_Chart.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private LiveCharts.WinForms.PieChart chart_Distribucion;
    }
}
