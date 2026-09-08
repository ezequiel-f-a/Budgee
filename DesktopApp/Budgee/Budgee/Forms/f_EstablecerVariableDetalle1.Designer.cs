
namespace UI.Forms
{
    partial class f_EstablecerVariableDetalle1
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
            this.lbl_Detalle = new UI.Controls.Labels.DarkLabel();
            this.combo_EnFuncionDe = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_EnFuncionDe = new UI.Controls.Labels.DarkLabel();
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Establecer = new UI.Controls.Buttons.DarkButton();
            this.SuspendLayout();
            // 
            // lbl_Detalle
            // 
            this.lbl_Detalle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Detalle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Detalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Detalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Detalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Detalle.Location = new System.Drawing.Point(12, 79);
            this.lbl_Detalle.Name = "lbl_Detalle";
            this.lbl_Detalle.Size = new System.Drawing.Size(312, 45);
            this.lbl_Detalle.TabIndex = 72;
            this.lbl_Detalle.Text = "...";
            this.lbl_Detalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_EnFuncionDe
            // 
            this.combo_EnFuncionDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_EnFuncionDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_EnFuncionDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_EnFuncionDe.FormattingEnabled = true;
            this.combo_EnFuncionDe.Location = new System.Drawing.Point(41, 39);
            this.combo_EnFuncionDe.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_EnFuncionDe.Name = "combo_EnFuncionDe";
            this.combo_EnFuncionDe.Size = new System.Drawing.Size(254, 29);
            this.combo_EnFuncionDe.TabIndex = 71;
            this.combo_EnFuncionDe.SelectedIndexChanged += new System.EventHandler(this.combo_EnFuncionDe_SelectedIndexChanged);
            // 
            // lbl_EnFuncionDe
            // 
            this.lbl_EnFuncionDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_EnFuncionDe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_EnFuncionDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_EnFuncionDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_EnFuncionDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_EnFuncionDe.Location = new System.Drawing.Point(58, 7);
            this.lbl_EnFuncionDe.Name = "lbl_EnFuncionDe";
            this.lbl_EnFuncionDe.Size = new System.Drawing.Size(220, 30);
            this.lbl_EnFuncionDe.TabIndex = 70;
            this.lbl_EnFuncionDe.Text = "En Función de:";
            this.lbl_EnFuncionDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Cancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Cancelar.Location = new System.Drawing.Point(178, 140);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(114, 28);
            this.but_Cancelar.TabIndex = 74;
            this.but_Cancelar.Text = "Cancelar";
            this.but_Cancelar.UseVisualStyleBackColor = false;
            this.but_Cancelar.Click += new System.EventHandler(this.but_Cancelar_Click);
            // 
            // but_Establecer
            // 
            this.but_Establecer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Establecer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Establecer.FlatAppearance.BorderSize = 0;
            this.but_Establecer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Establecer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Establecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Establecer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Establecer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Establecer.Location = new System.Drawing.Point(44, 140);
            this.but_Establecer.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Establecer.Name = "but_Establecer";
            this.but_Establecer.Size = new System.Drawing.Size(114, 28);
            this.but_Establecer.TabIndex = 73;
            this.but_Establecer.Text = "Establecer";
            this.but_Establecer.UseVisualStyleBackColor = false;
            this.but_Establecer.Click += new System.EventHandler(this.but_Establecer_Click);
            // 
            // f_EstablecerVariableDetalle1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 190);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Establecer);
            this.Controls.Add(this.lbl_Detalle);
            this.Controls.Add(this.combo_EnFuncionDe);
            this.Controls.Add(this.lbl_EnFuncionDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_EstablecerVariableDetalle1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable en Función de...";
            this.Load += new System.EventHandler(this.f_EstablecerVariableDetalle1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Labels.DarkLabel lbl_Detalle;
        private Controls.ComboBoxs.DefaultComboBox combo_EnFuncionDe;
        private Controls.Labels.DarkLabel lbl_EnFuncionDe;
        private Controls.Buttons.DarkButton but_Cancelar;
        private Controls.Buttons.DarkButton but_Establecer;
    }
}