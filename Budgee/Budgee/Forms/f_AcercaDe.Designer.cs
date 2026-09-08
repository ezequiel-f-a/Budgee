
namespace UI.Forms
{
    partial class f_AcercaDe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_AcercaDe));
            this.but_Aceptar = new UI.Controls.Buttons.DarkButton();
            this.lbl_Copyright = new UI.Controls.Labels.DarkLabel();
            this.lbl_Description = new UI.Controls.Labels.DarkLabel();
            this.lbl_Title = new UI.Controls.Labels.DarkLabel();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Aceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Aceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Aceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Aceptar.Location = new System.Drawing.Point(218, 330);
            this.but_Aceptar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Aceptar.Name = "but_Aceptar";
            this.but_Aceptar.Size = new System.Drawing.Size(234, 33);
            this.but_Aceptar.TabIndex = 3;
            this.but_Aceptar.Text = "Aceptar";
            this.but_Aceptar.UseVisualStyleBackColor = false;
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // lbl_Copyright
            // 
            this.lbl_Copyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Copyright.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Copyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Copyright.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Copyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Copyright.Location = new System.Drawing.Point(1, 253);
            this.lbl_Copyright.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Copyright.Name = "lbl_Copyright";
            this.lbl_Copyright.Size = new System.Drawing.Size(666, 62);
            this.lbl_Copyright.TabIndex = 2;
            this.lbl_Copyright.Text = "Copyright Ⓒ 2021 Ezequiel Francisco Amorosino - Todos los derechos reservados.";
            this.lbl_Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Description
            // 
            this.lbl_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Description.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Description.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Description.Location = new System.Drawing.Point(14, 91);
            this.lbl_Description.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(642, 168);
            this.lbl_Description.TabIndex = 1;
            this.lbl_Description.Text = resources.GetString("lbl_Description.Text");
            this.lbl_Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe Print", 32F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Title.Location = new System.Drawing.Point(3, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(664, 77);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Budgee";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f_AcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 382);
            this.Controls.Add(this.but_Aceptar);
            this.Controls.Add(this.lbl_Copyright);
            this.Controls.Add(this.lbl_Description);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_AcercaDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerca de Budgee";
            this.Load += new System.EventHandler(this.f_AcercaDe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Labels.DarkLabel lbl_Title;
        private Controls.Labels.DarkLabel lbl_Description;
        private Controls.Labels.DarkLabel lbl_Copyright;
        private Controls.Buttons.DarkButton but_Aceptar;
    }
}