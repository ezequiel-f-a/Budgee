
namespace UI.Forms.Talonarios
{
    partial class Talonario_Cuenta
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
            this.txt_Nombre = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Nombre = new UI.Controls.Labels.DarkLabel();
            this.combo_Divisa = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Divisa = new UI.Controls.Labels.DarkLabel();
            this.check_AdmiteFondosNegativos = new UI.Controls.Labels.DarkCheckbox();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(60, 224);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(201, 224);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Nombre.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nombre.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Nombre.Location = new System.Drawing.Point(19, 46);
            this.txt_Nombre.MaxLength = 50;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(342, 29);
            this.txt_Nombre.TabIndex = 50;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Nombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Nombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Nombre.Location = new System.Drawing.Point(19, 14);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(342, 29);
            this.lbl_Nombre.TabIndex = 49;
            this.lbl_Nombre.Text = "Nombre:";
            this.lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Divisa
            // 
            this.combo_Divisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Divisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Divisa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Divisa.FormattingEnabled = true;
            this.combo_Divisa.Location = new System.Drawing.Point(84, 118);
            this.combo_Divisa.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Divisa.Name = "combo_Divisa";
            this.combo_Divisa.Size = new System.Drawing.Size(216, 29);
            this.combo_Divisa.TabIndex = 52;
            // 
            // lbl_Divisa
            // 
            this.lbl_Divisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Divisa.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Divisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Divisa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Divisa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Divisa.Location = new System.Drawing.Point(80, 86);
            this.lbl_Divisa.Name = "lbl_Divisa";
            this.lbl_Divisa.Size = new System.Drawing.Size(220, 30);
            this.lbl_Divisa.TabIndex = 51;
            this.lbl_Divisa.Text = "Divisa:";
            this.lbl_Divisa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_AdmiteFondosNegativos
            // 
            this.check_AdmiteFondosNegativos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_AdmiteFondosNegativos.AutoSize = true;
            this.check_AdmiteFondosNegativos.BackColor = System.Drawing.Color.Transparent;
            this.check_AdmiteFondosNegativos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_AdmiteFondosNegativos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_AdmiteFondosNegativos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_AdmiteFondosNegativos.Location = new System.Drawing.Point(79, 170);
            this.check_AdmiteFondosNegativos.Name = "check_AdmiteFondosNegativos";
            this.check_AdmiteFondosNegativos.Size = new System.Drawing.Size(223, 25);
            this.check_AdmiteFondosNegativos.TabIndex = 55;
            this.check_AdmiteFondosNegativos.Text = "Admite Fondos Negativos";
            this.check_AdmiteFondosNegativos.UseVisualStyleBackColor = false;
            // 
            // Talonario_Cuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 275);
            this.Controls.Add(this.check_AdmiteFondosNegativos);
            this.Controls.Add(this.combo_Divisa);
            this.Controls.Add(this.lbl_Divisa);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.lbl_Nombre);
            this.Name = "Talonario_Cuenta";
            this.Text = "Talonario_Cuentas";
            this.Shown += new System.EventHandler(this.Talonario_Cuenta_Shown);
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.lbl_Nombre, 0);
            this.Controls.SetChildIndex(this.txt_Nombre, 0);
            this.Controls.SetChildIndex(this.lbl_Divisa, 0);
            this.Controls.SetChildIndex(this.combo_Divisa, 0);
            this.Controls.SetChildIndex(this.check_AdmiteFondosNegativos, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxs.DefaultTextBox txt_Nombre;
        private Controls.Labels.DarkLabel lbl_Nombre;
        private Controls.ComboBoxs.DefaultComboBox combo_Divisa;
        private Controls.Labels.DarkLabel lbl_Divisa;
        private Controls.Labels.DarkCheckbox check_AdmiteFondosNegativos;
    }
}