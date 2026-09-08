
namespace UI.Forms
{
    partial class f_CambiarPassword
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
            this.txt_PasswordNew = new System.Windows.Forms.TextBox();
            this.lbl_PasswordNew = new UI.Controls.Labels.DarkLabel();
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Confirmar = new UI.Controls.Buttons.DarkButton();
            this.lbl_PasswordOld = new UI.Controls.Labels.DarkLabel();
            this.txt_PasswordOld = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_PasswordNew
            // 
            this.txt_PasswordNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_PasswordNew.Location = new System.Drawing.Point(34, 101);
            this.txt_PasswordNew.MaxLength = 50;
            this.txt_PasswordNew.Name = "txt_PasswordNew";
            this.txt_PasswordNew.Size = new System.Drawing.Size(278, 26);
            this.txt_PasswordNew.TabIndex = 2;
            this.txt_PasswordNew.UseSystemPasswordChar = true;
            // 
            // lbl_PasswordNew
            // 
            this.lbl_PasswordNew.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PasswordNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_PasswordNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_PasswordNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_PasswordNew.Location = new System.Drawing.Point(34, 75);
            this.lbl_PasswordNew.Name = "lbl_PasswordNew";
            this.lbl_PasswordNew.Size = new System.Drawing.Size(278, 23);
            this.lbl_PasswordNew.TabIndex = 9;
            this.lbl_PasswordNew.Text = "Nueva Contraseña:";
            this.lbl_PasswordNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Cancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Cancelar.Location = new System.Drawing.Point(183, 145);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(129, 35);
            this.but_Cancelar.TabIndex = 8;
            this.but_Cancelar.Text = "Cancelar";
            this.but_Cancelar.UseVisualStyleBackColor = false;
            this.but_Cancelar.Click += new System.EventHandler(this.but_Cancelar_Click);
            // 
            // but_Confirmar
            // 
            this.but_Confirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Confirmar.FlatAppearance.BorderSize = 0;
            this.but_Confirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Confirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Confirmar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Confirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Confirmar.Location = new System.Drawing.Point(34, 145);
            this.but_Confirmar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Confirmar.Name = "but_Confirmar";
            this.but_Confirmar.Size = new System.Drawing.Size(129, 35);
            this.but_Confirmar.TabIndex = 7;
            this.but_Confirmar.Text = "Confirmar";
            this.but_Confirmar.UseVisualStyleBackColor = false;
            this.but_Confirmar.Click += new System.EventHandler(this.but_Confirmar_Click);
            // 
            // lbl_PasswordOld
            // 
            this.lbl_PasswordOld.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PasswordOld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_PasswordOld.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_PasswordOld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_PasswordOld.Location = new System.Drawing.Point(34, 11);
            this.lbl_PasswordOld.Name = "lbl_PasswordOld";
            this.lbl_PasswordOld.Size = new System.Drawing.Size(278, 23);
            this.lbl_PasswordOld.TabIndex = 11;
            this.lbl_PasswordOld.Text = "Confirmar Contraseña Actual:";
            this.lbl_PasswordOld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PasswordOld
            // 
            this.txt_PasswordOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_PasswordOld.Location = new System.Drawing.Point(34, 37);
            this.txt_PasswordOld.MaxLength = 50;
            this.txt_PasswordOld.Name = "txt_PasswordOld";
            this.txt_PasswordOld.Size = new System.Drawing.Size(278, 26);
            this.txt_PasswordOld.TabIndex = 1;
            this.txt_PasswordOld.UseSystemPasswordChar = true;
            // 
            // f_CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 204);
            this.Controls.Add(this.lbl_PasswordOld);
            this.Controls.Add(this.txt_PasswordOld);
            this.Controls.Add(this.lbl_PasswordNew);
            this.Controls.Add(this.txt_PasswordNew);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Confirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_CambiarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Contraseña";
            this.Load += new System.EventHandler(this.f_CambiarPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Labels.DarkLabel lbl_PasswordNew;
        private System.Windows.Forms.TextBox txt_PasswordNew;
        private Controls.Buttons.DarkButton but_Cancelar;
        private Controls.Buttons.DarkButton but_Confirmar;
        private Controls.Labels.DarkLabel lbl_PasswordOld;
        private System.Windows.Forms.TextBox txt_PasswordOld;
    }
}