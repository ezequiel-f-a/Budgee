
namespace UI.Controls.UC.FilterChart
{
    partial class FilterChart_PatrimonioNeto
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
            this.chart_PatrimonioNeto = new LiveCharts.WinForms.CartesianChart();
            this.panel_Chart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Chart
            // 
            this.panel_Chart.Controls.Add(this.chart_PatrimonioNeto);
            // 
            // 
            // chart_IngresoEgreso
            // 
            this.chart_PatrimonioNeto.Location = new System.Drawing.Point(15, 15);
            this.chart_PatrimonioNeto.Margin = new System.Windows.Forms.Padding(15);
            this.chart_PatrimonioNeto.Name = "chart_IngresoEgreso";
            this.chart_PatrimonioNeto.Size = new System.Drawing.Size(568, 216);
            this.chart_PatrimonioNeto.TabIndex = 0;
            this.chart_PatrimonioNeto.Text = "chart_IngresoEgreso";
            // 
            // FilterChart_PatrimonioNeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //components = new System.ComponentModel.Container();
            this.Name = "FilterChart_PatrimonioNeto";
            this.Load += new System.EventHandler(FilterChart_PatrimonioNeto_Load);
            this.VisibleChanged += new System.EventHandler(FilterChart_PatrimonioNeto_VisibleChanged);
            this.panel_Chart.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private LiveCharts.WinForms.CartesianChart chart_PatrimonioNeto;
    }
}
