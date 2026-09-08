
using UI.Controls.Buttons;

namespace UI.Forms
{
    partial class f_Talonario<T>
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
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Aceptar = new UI.Controls.Buttons.DarkButton();
            this.SuspendLayout();
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Cancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Cancelar.Location = new System.Drawing.Point(271, 38);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(121, 37);
            this.but_Cancelar.TabIndex = 1;
            this.but_Cancelar.Text = "Cancelar";
            this.but_Cancelar.UseVisualStyleBackColor = true;
            this.but_Cancelar.Click += new System.EventHandler(this.but_Cancelar_Click);
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Aceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Aceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Aceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Aceptar.Location = new System.Drawing.Point(130, 38);
            this.but_Aceptar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Aceptar.Name = "but_Aceptar";
            this.but_Aceptar.Size = new System.Drawing.Size(121, 37);
            this.but_Aceptar.TabIndex = 0;
            this.but_Aceptar.Text = "Aceptar";
            this.but_Aceptar.UseVisualStyleBackColor = true;
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // f_Talonario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 89);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_Talonario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "f_Talonario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f_Talonario_FormClosed);
            this.Load += new System.EventHandler(this.f_Talonario_Load);
            this.Shown += new System.EventHandler(this.f_Talonario_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        protected DarkButton but_Aceptar;
        protected DarkButton but_Cancelar;
    }
}