
namespace UI.Controls.UC
{
    partial class UC_MenuTab
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
            this.panel_Window = new System.Windows.Forms.Panel();
            this.panel_ControlArea = new System.Windows.Forms.Panel();
            this.but_CloseTab = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panel_Window.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Window
            // 
            this.panel_Window.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel_Window.Controls.Add(this.panel_ControlArea);
            this.panel_Window.Controls.Add(this.but_CloseTab);
            this.panel_Window.Controls.Add(this.lbl_Title);
            this.panel_Window.Location = new System.Drawing.Point(15, 14);
            this.panel_Window.Name = "panel_Window";
            this.panel_Window.Size = new System.Drawing.Size(643, 431);
            this.panel_Window.TabIndex = 2;
            // 
            // panel_ControlArea
            // 
            this.panel_ControlArea.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel_ControlArea.Location = new System.Drawing.Point(15, 57);
            this.panel_ControlArea.Name = "panel_ControlArea";
            this.panel_ControlArea.Size = new System.Drawing.Size(611, 357);
            this.panel_ControlArea.TabIndex = 3;
            // 
            // but_CloseTab
            // 
            this.but_CloseTab.Location = new System.Drawing.Point(6, 6);
            this.but_CloseTab.Name = "but_CloseTab";
            this.but_CloseTab.Size = new System.Drawing.Size(30, 30);
            this.but_CloseTab.TabIndex = 0;
            this.but_CloseTab.Text = "X";
            this.but_CloseTab.UseVisualStyleBackColor = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(643, 45);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Título";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_MenuTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Window);
            this.Name = "UC_MenuTab";
            this.Size = new System.Drawing.Size(684, 464);
            this.Load += new System.EventHandler(this.UC_MenuTab_Load);
            this.SizeChanged += new System.EventHandler(this.SizeChangedSetup);
            this.VisibleChanged += new System.EventHandler(this.UC_MenuTab_VisibleChanged);
            this.panel_Window.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Button but_CloseTab;
        protected System.Windows.Forms.Label lbl_Title;
        protected System.Windows.Forms.Panel panel_Window;
        protected System.Windows.Forms.Panel panel_ControlArea;
    }
}
