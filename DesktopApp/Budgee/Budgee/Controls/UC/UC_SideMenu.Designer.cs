
namespace UI.Controls.UC
{
    partial class UC_SideMenu
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
            this.flow_Menu = new System.Windows.Forms.FlowLayoutPanel();
            this.but_SwitchMinimize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flow_Menu
            // 
            this.flow_Menu.Location = new System.Drawing.Point(3, 3);
            this.flow_Menu.Name = "flow_Menu";
            this.flow_Menu.Size = new System.Drawing.Size(166, 446);
            this.flow_Menu.TabIndex = 0;
            // 
            // but_SwitchMinimize
            // 
            this.but_SwitchMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.but_SwitchMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(125)))), ((int)(((byte)(28)))));
            this.but_SwitchMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(125)))), ((int)(((byte)(28)))));
            this.but_SwitchMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SwitchMinimize.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_SwitchMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.but_SwitchMinimize.Location = new System.Drawing.Point(175, 0);
            this.but_SwitchMinimize.Name = "but_SwitchMinimize";
            this.but_SwitchMinimize.Size = new System.Drawing.Size(39, 452);
            this.but_SwitchMinimize.TabIndex = 1;
            this.but_SwitchMinimize.Text = "<";
            this.but_SwitchMinimize.UseVisualStyleBackColor = false;
            this.but_SwitchMinimize.Click += new System.EventHandler(this.but_SwitchMinimize_Click);
            // 
            // UC_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.but_SwitchMinimize);
            this.Controls.Add(this.flow_Menu);
            this.Name = "UC_Menu";
            this.Size = new System.Drawing.Size(214, 452);
            this.SizeChanged += new System.EventHandler(this.UC_SideMenu_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow_Menu;
        private System.Windows.Forms.Button but_SwitchMinimize;
    }
}
