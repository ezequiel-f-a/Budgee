
namespace UI.Forms.Talonarios
{
    partial class Talonario_Caracteristica
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
            this.combo_Color = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Color = new UI.Controls.Labels.DarkLabel();
            this.txt_Nombre = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Nombre = new UI.Controls.Labels.DarkLabel();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(59, 169);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(200, 169);
            // 
            // combo_Color
            // 
            this.combo_Color.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Color.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Color.FormattingEnabled = true;
            this.combo_Color.Location = new System.Drawing.Point(84, 110);
            this.combo_Color.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Color.Name = "combo_Color";
            this.combo_Color.Size = new System.Drawing.Size(216, 29);
            this.combo_Color.TabIndex = 64;
            // 
            // lbl_Color
            // 
            this.lbl_Color.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Color.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Color.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Color.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Color.Location = new System.Drawing.Point(80, 78);
            this.lbl_Color.Name = "lbl_Color";
            this.lbl_Color.Size = new System.Drawing.Size(220, 30);
            this.lbl_Color.TabIndex = 63;
            this.lbl_Color.Text = "Color:";
            this.lbl_Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Nombre.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nombre.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Nombre.Location = new System.Drawing.Point(19, 38);
            this.txt_Nombre.MaxLength = 50;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(342, 29);
            this.txt_Nombre.TabIndex = 62;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Nombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Nombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Nombre.Location = new System.Drawing.Point(19, 6);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(342, 29);
            this.lbl_Nombre.TabIndex = 61;
            this.lbl_Nombre.Text = "Nombre:";
            this.lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Talonario_Caracteristica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 226);
            this.Controls.Add(this.combo_Color);
            this.Controls.Add(this.lbl_Color);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.lbl_Nombre);
            this.Name = "Talonario_Caracteristica";
            this.Text = "Talonario_Caracteristica";
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.lbl_Nombre, 0);
            this.Controls.SetChildIndex(this.txt_Nombre, 0);
            this.Controls.SetChildIndex(this.lbl_Color, 0);
            this.Controls.SetChildIndex(this.combo_Color, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.Labels.DarkLabel lbl_Color;
        private Controls.Labels.DarkLabel lbl_Nombre;
        protected Controls.ComboBoxs.DefaultComboBox combo_Color;
        protected Controls.TextBoxs.DefaultTextBox txt_Nombre;
    }
}