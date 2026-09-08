
using UI.Controls.UC;
using UI.Controls.UC.ABMGrids;

namespace UI.Controls.UC.MenuTab
{
    partial class MenuTab_Estadisticas
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
            this.tabs_Estadisticas = new System.Windows.Forms.TabControl();
            this.tab_Overview = new System.Windows.Forms.TabPage();
            this.tab_IngresoEgreso = new System.Windows.Forms.TabPage();
            this.tab_PatrimonioNeto = new System.Windows.Forms.TabPage();
            this.tab_Distribucion = new System.Windows.Forms.TabPage();
            this.tab_HolguraPresupuesto = new System.Windows.Forms.TabPage();
            this.panel_Window.SuspendLayout();
            this.panel_ControlArea.SuspendLayout();
            this.tabs_Estadisticas.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_CloseTab
            // 
            this.but_CloseTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_CloseTab.FlatAppearance.BorderSize = 0;
            this.but_CloseTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_CloseTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            // 
            // lbl_Title
            // 
            this.lbl_Title.Size = new System.Drawing.Size(651, 90);
            // 
            // panel_Window
            // 
            this.panel_Window.Size = new System.Drawing.Size(651, 451);
            // 
            // panel_ControlArea
            // 
            this.panel_ControlArea.Controls.Add(this.tabs_Estadisticas);
            this.panel_ControlArea.Size = new System.Drawing.Size(601, 336);
            // 
            // tabs_Estadisticas
            // 
            this.tabs_Estadisticas.Controls.Add(this.tab_Overview);
            this.tabs_Estadisticas.Controls.Add(this.tab_IngresoEgreso);
            this.tabs_Estadisticas.Controls.Add(this.tab_PatrimonioNeto);
            this.tabs_Estadisticas.Controls.Add(this.tab_Distribucion);
            this.tabs_Estadisticas.Controls.Add(this.tab_HolguraPresupuesto);
            this.tabs_Estadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_Estadisticas.ItemSize = new System.Drawing.Size(119, 30);
            this.tabs_Estadisticas.Location = new System.Drawing.Point(0, 0);
            this.tabs_Estadisticas.Name = "tabs_Estadisticas";
            this.tabs_Estadisticas.SelectedIndex = 0;
            this.tabs_Estadisticas.Size = new System.Drawing.Size(601, 336);
            this.tabs_Estadisticas.TabIndex = 0;
            // 
            // tab_Overview
            // 
            this.tab_Overview.Location = new System.Drawing.Point(4, 34);
            this.tab_Overview.Name = "tab_Overview";
            this.tab_Overview.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Overview.Size = new System.Drawing.Size(593, 298);
            this.tab_Overview.TabIndex = 0;
            this.tab_Overview.Text = "    Overview    ";
            this.tab_Overview.UseVisualStyleBackColor = true;
            // 
            // tab_IngresoEgreso
            // 
            this.tab_IngresoEgreso.Location = new System.Drawing.Point(4, 34);
            this.tab_IngresoEgreso.Name = "tab_IngresoEgreso";
            this.tab_IngresoEgreso.Padding = new System.Windows.Forms.Padding(3);
            this.tab_IngresoEgreso.Size = new System.Drawing.Size(593, 298);
            this.tab_IngresoEgreso.TabIndex = 1;
            this.tab_IngresoEgreso.Text = "    Ingresos / Egresos    ";
            this.tab_IngresoEgreso.UseVisualStyleBackColor = true;
            // 
            // tab_PatrimonioNeto
            // 
            this.tab_PatrimonioNeto.Location = new System.Drawing.Point(4, 34);
            this.tab_PatrimonioNeto.Name = "tab_PatrimonioNeto";
            this.tab_PatrimonioNeto.Padding = new System.Windows.Forms.Padding(3);
            this.tab_PatrimonioNeto.Size = new System.Drawing.Size(593, 298);
            this.tab_PatrimonioNeto.TabIndex = 2;
            this.tab_PatrimonioNeto.Text = "    Patrimonio Neto    ";
            this.tab_PatrimonioNeto.UseVisualStyleBackColor = true;
            // 
            // tab_Distribucion
            // 
            this.tab_Distribucion.Location = new System.Drawing.Point(4, 34);
            this.tab_Distribucion.Name = "tab_Distribucion";
            this.tab_Distribucion.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Distribucion.Size = new System.Drawing.Size(593, 298);
            this.tab_Distribucion.TabIndex = 3;
            this.tab_Distribucion.Text = "    Distribución    ";
            this.tab_Distribucion.UseVisualStyleBackColor = true;
            // 
            // tab_HolguraPresupuesto
            // 
            this.tab_HolguraPresupuesto.Location = new System.Drawing.Point(4, 34);
            this.tab_HolguraPresupuesto.Name = "tab_HolguraPresupuesto";
            this.tab_HolguraPresupuesto.Padding = new System.Windows.Forms.Padding(3);
            this.tab_HolguraPresupuesto.Size = new System.Drawing.Size(593, 298);
            this.tab_HolguraPresupuesto.TabIndex = 4;
            this.tab_HolguraPresupuesto.Text = "    Holgura de Presupuesto    ";
            this.tab_HolguraPresupuesto.UseVisualStyleBackColor = true;
            // 
            // MenuTab_Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            this.Name = "MenuTab_Estadisticas";
            this.Size = new System.Drawing.Size(701, 501);
            this.panel_Window.ResumeLayout(false);
            this.panel_ControlArea.ResumeLayout(false);
            this.tabs_Estadisticas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs_Estadisticas;
        private System.Windows.Forms.TabPage tab_Overview;
        private System.Windows.Forms.TabPage tab_IngresoEgreso;
        private System.Windows.Forms.TabPage tab_PatrimonioNeto;
        private System.Windows.Forms.TabPage tab_Distribucion;
        private System.Windows.Forms.TabPage tab_HolguraPresupuesto;
    }
}
