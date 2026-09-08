
namespace UI.Forms.Talonarios
{
    partial class Talonario_Usuario
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
            this.txt_Username = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Username = new UI.Controls.Labels.DarkLabel();
            this.txt_Password = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Password = new UI.Controls.Labels.DarkLabel();
            this.check_ShowPassword = new UI.Controls.Labels.DarkCheckbox();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(81, 224);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(222, 224);
            // 
            // txt_Username
            // 
            this.txt_Username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Username.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Username.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Username.Location = new System.Drawing.Point(41, 55);
            this.txt_Username.MaxLength = 50;
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(342, 29);
            this.txt_Username.TabIndex = 60;
            // 
            // lbl_Username
            // 
            this.lbl_Username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Username.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Username.Location = new System.Drawing.Point(41, 23);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(342, 29);
            this.lbl_Username.TabIndex = 59;
            this.lbl_Username.Text = "Nombre de Usuario:";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Password.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Password.Location = new System.Drawing.Point(41, 128);
            this.txt_Password.MaxLength = 50;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(342, 29);
            this.txt_Password.TabIndex = 62;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // lbl_Password
            // 
            this.lbl_Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Password.Location = new System.Drawing.Point(41, 96);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(342, 29);
            this.lbl_Password.TabIndex = 61;
            this.lbl_Password.Text = "Contraseña:";
            this.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_ShowPassword
            // 
            this.check_ShowPassword.AutoSize = true;
            this.check_ShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.check_ShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_ShowPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_ShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_ShowPassword.Location = new System.Drawing.Point(130, 174);
            this.check_ShowPassword.Name = "check_ShowPassword";
            this.check_ShowPassword.Size = new System.Drawing.Size(164, 25);
            this.check_ShowPassword.TabIndex = 63;
            this.check_ShowPassword.Text = "Mostrar Contraseña";
            this.check_ShowPassword.UseVisualStyleBackColor = false;
            this.check_ShowPassword.CheckedChanged += new System.EventHandler(this.check_ShowPassword_CheckedChanged);
            // 
            // Talonario_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 275);
            this.Controls.Add(this.check_ShowPassword);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.lbl_Username);
            this.Name = "Talonario_Usuario";
            this.Text = "Talonario_Usuarios";
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.lbl_Username, 0);
            this.Controls.SetChildIndex(this.txt_Username, 0);
            this.Controls.SetChildIndex(this.lbl_Password, 0);
            this.Controls.SetChildIndex(this.txt_Password, 0);
            this.Controls.SetChildIndex(this.check_ShowPassword, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxs.DefaultTextBox txt_Username;
        private Controls.Labels.DarkLabel lbl_Username;
        private Controls.TextBoxs.DefaultTextBox txt_Password;
        private Controls.Labels.DarkLabel lbl_Password;
        private Controls.Labels.DarkCheckbox check_ShowPassword;
    }
}