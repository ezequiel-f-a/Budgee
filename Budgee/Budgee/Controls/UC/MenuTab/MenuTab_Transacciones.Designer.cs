
using UI.Controls.UC;
using UI.Controls.UC.ABMGrids;

namespace UI.Controls.UC.MenuTab
{
    partial class MenuTab_Transacciones
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
            this.tabs_Transacciones = new System.Windows.Forms.TabControl();
            this.tab_Pendientes = new System.Windows.Forms.TabPage();
            this.abm_pendientes = new global::UI.Controls.UC.ABMGrids.ABM_TransaccionesPendientes();
            this.tab_Concretadas = new System.Windows.Forms.TabPage();
            this.abm_concretadas = new global::UI.Controls.UC.ABMGrids.ABM_TransaccionesConcretadas();
            this.panel_Window.SuspendLayout();
            this.panel_ControlArea.SuspendLayout();
            this.tabs_Transacciones.SuspendLayout();
            this.tab_Pendientes.SuspendLayout();
            this.tab_Concretadas.SuspendLayout();
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
            this.panel_ControlArea.Controls.Add(this.tabs_Transacciones);
            this.panel_ControlArea.Size = new System.Drawing.Size(601, 336);
            // 
            // tabs_Transacciones
            // 
            this.tabs_Transacciones.Controls.Add(this.tab_Pendientes);
            this.tabs_Transacciones.Controls.Add(this.tab_Concretadas);
            this.tabs_Transacciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_Transacciones.ItemSize = new System.Drawing.Size(65, 30);
            this.tabs_Transacciones.Location = new System.Drawing.Point(0, 0);
            this.tabs_Transacciones.Name = "tabs_Transacciones";
            this.tabs_Transacciones.SelectedIndex = 0;
            this.tabs_Transacciones.Size = new System.Drawing.Size(601, 336);
            this.tabs_Transacciones.TabIndex = 0;
            // 
            // tab_Pendientes
            // 
            this.tab_Pendientes.Controls.Add(this.abm_pendientes);
            this.tab_Pendientes.Location = new System.Drawing.Point(4, 34);
            this.tab_Pendientes.Name = "tab_Pendientes";
            this.tab_Pendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Pendientes.Size = new System.Drawing.Size(593, 298);
            this.tab_Pendientes.TabIndex = 0;
            this.tab_Pendientes.Text = "    Pendientes    ";
            this.tab_Pendientes.UseVisualStyleBackColor = true;
            // 
            // abm_pendientes
            // 
            this.abm_pendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(108)))), ((int)(((byte)(45)))));
            this.abm_pendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abm_pendientes.Location = new System.Drawing.Point(3, 3);
            this.abm_pendientes.Name = "abm_pendientes";
            this.abm_pendientes.Size = new System.Drawing.Size(587, 292);
            this.abm_pendientes.TabIndex = 0;
            // 
            // tab_Concretadas
            // 
            this.tab_Concretadas.Controls.Add(this.abm_concretadas);
            this.tab_Concretadas.Location = new System.Drawing.Point(4, 34);
            this.tab_Concretadas.Name = "tab_Concretadas";
            this.tab_Concretadas.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Concretadas.Size = new System.Drawing.Size(593, 298);
            this.tab_Concretadas.TabIndex = 1;
            this.tab_Concretadas.Text = "    Concretadas    ";
            this.tab_Concretadas.UseVisualStyleBackColor = true;
            // 
            // abm_concretadas
            // 
            this.abm_concretadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(108)))), ((int)(((byte)(45)))));
            this.abm_concretadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abm_concretadas.Location = new System.Drawing.Point(3, 3);
            this.abm_concretadas.Name = "abm_concretadas";
            this.abm_concretadas.Size = new System.Drawing.Size(587, 292);
            this.abm_concretadas.TabIndex = 0;
            // 
            // MenuTab_Transacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            this.Name = "MenuTab_Transacciones";
            this.Size = new System.Drawing.Size(701, 501);
            this.panel_Window.ResumeLayout(false);
            this.panel_ControlArea.ResumeLayout(false);
            this.tabs_Transacciones.ResumeLayout(false);
            this.tab_Pendientes.ResumeLayout(false);
            this.tab_Concretadas.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabs_Transacciones;
        private System.Windows.Forms.TabPage tab_Pendientes;
        private System.Windows.Forms.TabPage tab_Concretadas;
        private ABM_TransaccionesPendientes abm_pendientes;
        private ABM_TransaccionesConcretadas abm_concretadas;
    }
}
