
namespace UI.Forms
{
    partial class f_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Login));
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.check_MantenerSesionIniciada = new UI.Controls.Labels.DarkCheckbox();
            this.check_ShowPassword = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_Password = new UI.Controls.Labels.DarkLabel();
            this.lbl_Username = new UI.Controls.Labels.DarkLabel();
            this.but_CrearUsuario = new UI.Controls.Buttons.DarkButton();
            this.but_IniciarSesion = new UI.Controls.Buttons.DarkButton();
            this.SuspendLayout();
            // 
            // txt_Username
            // 
            this.txt_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_Username.Location = new System.Drawing.Point(52, 39);
            this.txt_Username.MaxLength = 50;
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(278, 26);
            this.txt_Username.TabIndex = 1;
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_Password.Location = new System.Drawing.Point(52, 102);
            this.txt_Password.MaxLength = 50;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(278, 26);
            this.txt_Password.TabIndex = 2;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // check_MantenerSesionIniciada
            // 
            this.check_MantenerSesionIniciada.AutoSize = true;
            this.check_MantenerSesionIniciada.BackColor = System.Drawing.Color.Transparent;
            this.check_MantenerSesionIniciada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_MantenerSesionIniciada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_MantenerSesionIniciada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_MantenerSesionIniciada.Location = new System.Drawing.Point(52, 176);
            this.check_MantenerSesionIniciada.Name = "check_MantenerSesionIniciada";
            this.check_MantenerSesionIniciada.Size = new System.Drawing.Size(200, 25);
            this.check_MantenerSesionIniciada.TabIndex = 7;
            this.check_MantenerSesionIniciada.Text = "Mantener Sesión Iniciada";
            this.check_MantenerSesionIniciada.UseVisualStyleBackColor = false;
            // 
            // check_ShowPassword
            // 
            this.check_ShowPassword.AutoSize = true;
            this.check_ShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.check_ShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_ShowPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_ShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_ShowPassword.Location = new System.Drawing.Point(52, 145);
            this.check_ShowPassword.Name = "check_ShowPassword";
            this.check_ShowPassword.Size = new System.Drawing.Size(164, 25);
            this.check_ShowPassword.TabIndex = 6;
            this.check_ShowPassword.Text = "Mostrar Contraseña";
            this.check_ShowPassword.UseVisualStyleBackColor = false;
            this.check_ShowPassword.CheckedChanged += new System.EventHandler(this.check_ShowPassword_CheckedChanged);
            // 
            // lbl_Password
            // 
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Password.Location = new System.Drawing.Point(52, 76);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(278, 23);
            this.lbl_Password.TabIndex = 5;
            this.lbl_Password.Text = "Contraseña:";
            this.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Username
            // 
            this.lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Username.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Username.Location = new System.Drawing.Point(52, 13);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(278, 23);
            this.lbl_Username.TabIndex = 4;
            this.lbl_Username.Text = "Usuario:";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_CrearUsuario
            // 
            this.but_CrearUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_CrearUsuario.FlatAppearance.BorderSize = 0;
            this.but_CrearUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_CrearUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_CrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CrearUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_CrearUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_CrearUsuario.Location = new System.Drawing.Point(201, 217);
            this.but_CrearUsuario.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_CrearUsuario.Name = "but_CrearUsuario";
            this.but_CrearUsuario.Size = new System.Drawing.Size(129, 35);
            this.but_CrearUsuario.TabIndex = 4;
            this.but_CrearUsuario.Text = "Crear Usuario";
            this.but_CrearUsuario.UseVisualStyleBackColor = false;
            this.but_CrearUsuario.Click += new System.EventHandler(this.but_CrearUsuario_Click);
            // 
            // but_IniciarSesion
            // 
            this.but_IniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_IniciarSesion.FlatAppearance.BorderSize = 0;
            this.but_IniciarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_IniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_IniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_IniciarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_IniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_IniciarSesion.Location = new System.Drawing.Point(52, 217);
            this.but_IniciarSesion.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_IniciarSesion.Name = "but_IniciarSesion";
            this.but_IniciarSesion.Size = new System.Drawing.Size(129, 35);
            this.but_IniciarSesion.TabIndex = 3;
            this.but_IniciarSesion.Text = "Iniciar Sesión";
            this.but_IniciarSesion.UseVisualStyleBackColor = false;
            this.but_IniciarSesion.Click += new System.EventHandler(this.but_IniciarSesion_Click);
            // 
            // f_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 282);
            this.Controls.Add(this.check_MantenerSesionIniciada);
            this.Controls.Add(this.check_ShowPassword);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.but_CrearUsuario);
            this.Controls.Add(this.but_IniciarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.VisibleChanged += new System.EventHandler(this.f_Login_VisibleChanged);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.f_Login_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Buttons.DarkButton but_IniciarSesion;
        private Controls.Buttons.DarkButton but_CrearUsuario;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private Controls.Labels.DarkLabel lbl_Username;
        private Controls.Labels.DarkLabel lbl_Password;
        private Controls.Labels.DarkCheckbox check_ShowPassword;
        private Controls.Labels.DarkCheckbox check_MantenerSesionIniciada;
    }
}