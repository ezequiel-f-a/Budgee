
namespace UI.Controls.UC.MenuTab
{
    partial class MenuTab_Planificacion
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
            this.abM_Planificaciones1 = new global::UI.Controls.UC.ABMGrids.ABM_Planificaciones();
            this.panel_Window.SuspendLayout();
            this.panel_ControlArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_CloseTab
            // 
            this.but_CloseTab.FlatAppearance.BorderSize = 0;
            this.but_CloseTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_CloseTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            // 
            // lbl_Title
            // 
            this.lbl_Title.Size = new System.Drawing.Size(564, 90);
            // 
            // panel_Window
            // 
            this.panel_Window.Size = new System.Drawing.Size(564, 401);
            // 
            // panel_ControlArea
            // 
            this.panel_ControlArea.Controls.Add(this.abM_Planificaciones1);
            this.panel_ControlArea.Size = new System.Drawing.Size(514, 286);
            // 
            // abM_Planificaciones1
            // 
            this.abM_Planificaciones1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(108)))), ((int)(((byte)(45)))));
            this.abM_Planificaciones1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abM_Planificaciones1.Location = new System.Drawing.Point(0, 0);
            this.abM_Planificaciones1.Name = "abM_Planificaciones1";
            this.abM_Planificaciones1.Size = new System.Drawing.Size(514, 286);
            this.abM_Planificaciones1.TabIndex = 0;
            // 
            // MenuTab_Planificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            this.Name = "MenuTab_Planificacion";
            this.Size = new System.Drawing.Size(614, 451);
            this.panel_Window.ResumeLayout(false);
            this.panel_ControlArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ABMGrids.ABM_Planificaciones abM_Planificaciones1;
    }
}
