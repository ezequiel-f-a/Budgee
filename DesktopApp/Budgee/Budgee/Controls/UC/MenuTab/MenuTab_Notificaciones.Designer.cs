
namespace UI.Controls.UC.MenuTab
{
    partial class MenuTab_Notificaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs_Notificaciones = new System.Windows.Forms.TabControl();
            this.tab_Nuevas = new System.Windows.Forms.TabPage();
            this.tab_Vistas = new System.Windows.Forms.TabPage();
            this.filterGrid_Notificaciones_Nuevas = new UI.Controls.UC.FilterGrid.FilterGrid_NotifNuevas();
            this.filterGrid_Notificaciones_Vistas = new UI.Controls.UC.FilterGrid.FilterGrid_NotifVistas();
            this.panel_Window.SuspendLayout();
            this.panel_ControlArea.SuspendLayout();
            this.tabs_Notificaciones.SuspendLayout();
            this.tab_Nuevas.SuspendLayout();
            this.tab_Vistas.SuspendLayout();
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
            this.lbl_Title.Size = new System.Drawing.Size(750, 90);
            // 
            // panel_Window
            // 
            this.panel_Window.Size = new System.Drawing.Size(750, 400);
            // 
            // panel_ControlArea
            // 
            this.panel_ControlArea.Controls.Add(this.tabs_Notificaciones);
            this.panel_ControlArea.Size = new System.Drawing.Size(700, 285);
            // 
            // tabs_Notificaciones
            // 
            this.tabs_Notificaciones.Controls.Add(this.tab_Nuevas);
            this.tabs_Notificaciones.Controls.Add(this.tab_Vistas);
            this.tabs_Notificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_Notificaciones.ItemSize = new System.Drawing.Size(65, 30);
            this.tabs_Notificaciones.Location = new System.Drawing.Point(0, 0);
            this.tabs_Notificaciones.Name = "tabs_Notificaciones";
            this.tabs_Notificaciones.SelectedIndex = 0;
            this.tabs_Notificaciones.Size = new System.Drawing.Size(700, 285);
            this.tabs_Notificaciones.TabIndex = 0;
            // 
            // tab_Nuevas
            // 
            this.tab_Nuevas.Controls.Add(this.filterGrid_Notificaciones_Nuevas);
            this.tab_Nuevas.Location = new System.Drawing.Point(4, 22);
            this.tab_Nuevas.Name = "tab_Nuevas";
            this.tab_Nuevas.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Nuevas.Size = new System.Drawing.Size(692, 259);
            this.tab_Nuevas.TabIndex = 0;
            this.tab_Nuevas.Text = "    Nuevas    ";
            this.tab_Nuevas.UseVisualStyleBackColor = true;
            // 
            // tab_Vistas
            // 
            this.tab_Vistas.Controls.Add(this.filterGrid_Notificaciones_Vistas);
            this.tab_Vistas.Location = new System.Drawing.Point(4, 22);
            this.tab_Vistas.Name = "tab_Vistas";
            this.tab_Vistas.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Vistas.Size = new System.Drawing.Size(692, 259);
            this.tab_Vistas.TabIndex = 1;
            this.tab_Vistas.Text = "    Vistas    ";
            this.tab_Vistas.UseVisualStyleBackColor = true;
            // 
            // filterGrid_Notificaciones_Nuevas
            // 
            this.filterGrid_Notificaciones_Nuevas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.filterGrid_Notificaciones_Nuevas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterGrid_Notificaciones_Nuevas.Location = new System.Drawing.Point(3, 3);
            this.filterGrid_Notificaciones_Nuevas.Name = "filterGrid_Notificaciones_Nuevas";
            this.filterGrid_Notificaciones_Nuevas.Size = new System.Drawing.Size(686, 253);
            this.filterGrid_Notificaciones_Nuevas.TabIndex = 0;
            // 
            // filterGrid_Notificaciones_Vistas
            // 
            this.filterGrid_Notificaciones_Vistas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.filterGrid_Notificaciones_Vistas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterGrid_Notificaciones_Vistas.Location = new System.Drawing.Point(3, 3);
            this.filterGrid_Notificaciones_Vistas.Name = "filterGrid_Notificaciones_Vistas";
            this.filterGrid_Notificaciones_Vistas.Size = new System.Drawing.Size(686, 253);
            this.filterGrid_Notificaciones_Vistas.TabIndex = 0;
            // 
            // MenuTab_Notificaciones2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MenuTab_Notificaciones2";
            this.Size = new System.Drawing.Size(800, 450);
            this.panel_Window.ResumeLayout(false);
            this.panel_ControlArea.ResumeLayout(false);
            this.tabs_Notificaciones.ResumeLayout(false);
            this.tab_Nuevas.ResumeLayout(false);
            this.tab_Vistas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs_Notificaciones;
        private System.Windows.Forms.TabPage tab_Nuevas;
        private System.Windows.Forms.TabPage tab_Vistas;
        private FilterGrid.FilterGrid_NotifNuevas filterGrid_Notificaciones_Nuevas;
        private FilterGrid.FilterGrid_NotifVistas filterGrid_Notificaciones_Vistas;
    }
}