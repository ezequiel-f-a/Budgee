
namespace UI.Forms
{
    partial class f_EstablecerVariableDetalle2
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
            this.panel_EnFuncionDeBorder = new System.Windows.Forms.Panel();
            this.panel_EnFuncionDe = new System.Windows.Forms.Panel();
            this.check_Etiqueta = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_Etiqueta = new UI.Controls.Labels.DarkLabel();
            this.combo_Etiqueta = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.check_Categoria = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_Categoría = new UI.Controls.Labels.DarkLabel();
            this.combo_Categoria = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.check_Cuenta = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_Cuenta = new UI.Controls.Labels.DarkLabel();
            this.combo_Cuenta = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_LapsoDetalle = new UI.Controls.Labels.DarkLabel();
            this.but_EstablecerLapso = new UI.Controls.Buttons.DarkButton();
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Establecer = new UI.Controls.Buttons.DarkButton();
            this.lbl_EnFuncionDe = new UI.Controls.Labels.DarkLabel();
            this.panel_EnFuncionDeBorder.SuspendLayout();
            this.panel_EnFuncionDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_EnFuncionDeBorder
            // 
            this.panel_EnFuncionDeBorder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_EnFuncionDeBorder.Controls.Add(this.panel_EnFuncionDe);
            this.panel_EnFuncionDeBorder.Location = new System.Drawing.Point(12, 47);
            this.panel_EnFuncionDeBorder.Name = "panel_EnFuncionDeBorder";
            this.panel_EnFuncionDeBorder.Padding = new System.Windows.Forms.Padding(5);
            this.panel_EnFuncionDeBorder.Size = new System.Drawing.Size(406, 259);
            this.panel_EnFuncionDeBorder.TabIndex = 75;
            // 
            // panel_EnFuncionDe
            // 
            this.panel_EnFuncionDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_EnFuncionDe.Controls.Add(this.check_Etiqueta);
            this.panel_EnFuncionDe.Controls.Add(this.lbl_Etiqueta);
            this.panel_EnFuncionDe.Controls.Add(this.combo_Etiqueta);
            this.panel_EnFuncionDe.Controls.Add(this.check_Categoria);
            this.panel_EnFuncionDe.Controls.Add(this.lbl_Categoría);
            this.panel_EnFuncionDe.Controls.Add(this.combo_Categoria);
            this.panel_EnFuncionDe.Controls.Add(this.check_Cuenta);
            this.panel_EnFuncionDe.Controls.Add(this.lbl_Cuenta);
            this.panel_EnFuncionDe.Controls.Add(this.combo_Cuenta);
            this.panel_EnFuncionDe.Location = new System.Drawing.Point(7, 8);
            this.panel_EnFuncionDe.Name = "panel_EnFuncionDe";
            this.panel_EnFuncionDe.Padding = new System.Windows.Forms.Padding(5);
            this.panel_EnFuncionDe.Size = new System.Drawing.Size(391, 243);
            this.panel_EnFuncionDe.TabIndex = 18;
            // 
            // check_Etiqueta
            // 
            this.check_Etiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Etiqueta.AutoSize = true;
            this.check_Etiqueta.BackColor = System.Drawing.Color.Transparent;
            this.check_Etiqueta.Checked = true;
            this.check_Etiqueta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Etiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Etiqueta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_Etiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Etiqueta.Location = new System.Drawing.Point(142, 167);
            this.check_Etiqueta.Name = "check_Etiqueta";
            this.check_Etiqueta.Size = new System.Drawing.Size(12, 11);
            this.check_Etiqueta.TabIndex = 83;
            this.check_Etiqueta.UseVisualStyleBackColor = false;
            this.check_Etiqueta.CheckedChanged += new System.EventHandler(this.check_Etiqueta_CheckedChanged);
            // 
            // lbl_Etiqueta
            // 
            this.lbl_Etiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Etiqueta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Etiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Etiqueta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Etiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Etiqueta.Location = new System.Drawing.Point(95, 156);
            this.lbl_Etiqueta.Name = "lbl_Etiqueta";
            this.lbl_Etiqueta.Size = new System.Drawing.Size(200, 30);
            this.lbl_Etiqueta.TabIndex = 82;
            this.lbl_Etiqueta.Text = "Etiqueta:";
            this.lbl_Etiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Etiqueta
            // 
            this.combo_Etiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Etiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Etiqueta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Etiqueta.FormattingEnabled = true;
            this.combo_Etiqueta.Location = new System.Drawing.Point(20, 187);
            this.combo_Etiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Etiqueta.Name = "combo_Etiqueta";
            this.combo_Etiqueta.Size = new System.Drawing.Size(351, 29);
            this.combo_Etiqueta.TabIndex = 81;
            this.combo_Etiqueta.DropDown += new System.EventHandler(this.combo_Etiqueta_DropDown);
            // 
            // check_Categoria
            // 
            this.check_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Categoria.AutoSize = true;
            this.check_Categoria.BackColor = System.Drawing.Color.Transparent;
            this.check_Categoria.Checked = true;
            this.check_Categoria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_Categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Categoria.Location = new System.Drawing.Point(136, 94);
            this.check_Categoria.Name = "check_Categoria";
            this.check_Categoria.Size = new System.Drawing.Size(12, 11);
            this.check_Categoria.TabIndex = 80;
            this.check_Categoria.UseVisualStyleBackColor = false;
            this.check_Categoria.CheckedChanged += new System.EventHandler(this.check_Categoria_CheckedChanged);
            // 
            // lbl_Categoría
            // 
            this.lbl_Categoría.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Categoría.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Categoría.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Categoría.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Categoría.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Categoría.Location = new System.Drawing.Point(95, 83);
            this.lbl_Categoría.Name = "lbl_Categoría";
            this.lbl_Categoría.Size = new System.Drawing.Size(200, 30);
            this.lbl_Categoría.TabIndex = 79;
            this.lbl_Categoría.Text = "Categoría:";
            this.lbl_Categoría.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Categoria
            // 
            this.combo_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Categoria.FormattingEnabled = true;
            this.combo_Categoria.Location = new System.Drawing.Point(20, 114);
            this.combo_Categoria.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Categoria.Name = "combo_Categoria";
            this.combo_Categoria.Size = new System.Drawing.Size(351, 29);
            this.combo_Categoria.TabIndex = 78;
            this.combo_Categoria.DropDown += new System.EventHandler(this.combo_Categoria_DropDown);
            // 
            // check_Cuenta
            // 
            this.check_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Cuenta.AutoSize = true;
            this.check_Cuenta.BackColor = System.Drawing.Color.Transparent;
            this.check_Cuenta.Checked = true;
            this.check_Cuenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_Cuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Cuenta.Location = new System.Drawing.Point(145, 22);
            this.check_Cuenta.Name = "check_Cuenta";
            this.check_Cuenta.Size = new System.Drawing.Size(12, 11);
            this.check_Cuenta.TabIndex = 77;
            this.check_Cuenta.UseVisualStyleBackColor = false;
            this.check_Cuenta.CheckedChanged += new System.EventHandler(this.check_Cuenta_CheckedChanged);
            // 
            // lbl_Cuenta
            // 
            this.lbl_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Cuenta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Cuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Cuenta.Location = new System.Drawing.Point(95, 11);
            this.lbl_Cuenta.Name = "lbl_Cuenta";
            this.lbl_Cuenta.Size = new System.Drawing.Size(200, 30);
            this.lbl_Cuenta.TabIndex = 76;
            this.lbl_Cuenta.Text = "Cuenta:";
            this.lbl_Cuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Cuenta
            // 
            this.combo_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Cuenta.FormattingEnabled = true;
            this.combo_Cuenta.Location = new System.Drawing.Point(20, 42);
            this.combo_Cuenta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Cuenta.Name = "combo_Cuenta";
            this.combo_Cuenta.Size = new System.Drawing.Size(351, 29);
            this.combo_Cuenta.TabIndex = 71;
            this.combo_Cuenta.DropDown += new System.EventHandler(this.combo_Cuenta_DropDown);
            // 
            // lbl_LapsoDetalle
            // 
            this.lbl_LapsoDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_LapsoDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LapsoDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_LapsoDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_LapsoDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_LapsoDetalle.Location = new System.Drawing.Point(12, 367);
            this.lbl_LapsoDetalle.Name = "lbl_LapsoDetalle";
            this.lbl_LapsoDetalle.Size = new System.Drawing.Size(406, 41);
            this.lbl_LapsoDetalle.TabIndex = 86;
            this.lbl_LapsoDetalle.Text = "...";
            this.lbl_LapsoDetalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // but_EstablecerLapso
            // 
            this.but_EstablecerLapso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_EstablecerLapso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_EstablecerLapso.FlatAppearance.BorderSize = 0;
            this.but_EstablecerLapso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_EstablecerLapso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_EstablecerLapso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_EstablecerLapso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_EstablecerLapso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_EstablecerLapso.Location = new System.Drawing.Point(124, 325);
            this.but_EstablecerLapso.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_EstablecerLapso.Name = "but_EstablecerLapso";
            this.but_EstablecerLapso.Size = new System.Drawing.Size(182, 28);
            this.but_EstablecerLapso.TabIndex = 76;
            this.but_EstablecerLapso.Text = "Establecer Lapso...";
            this.but_EstablecerLapso.UseVisualStyleBackColor = false;
            this.but_EstablecerLapso.Click += new System.EventHandler(this.but_EstablecerLapso_Click);
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
            this.but_Cancelar.Location = new System.Drawing.Point(225, 418);
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
            this.but_Establecer.Location = new System.Drawing.Point(91, 418);
            this.but_Establecer.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Establecer.Name = "but_Establecer";
            this.but_Establecer.Size = new System.Drawing.Size(114, 28);
            this.but_Establecer.TabIndex = 73;
            this.but_Establecer.Text = "Establecer";
            this.but_Establecer.UseVisualStyleBackColor = false;
            this.but_Establecer.Click += new System.EventHandler(this.but_Establecer_Click);
            // 
            // lbl_EnFuncionDe
            // 
            this.lbl_EnFuncionDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_EnFuncionDe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_EnFuncionDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_EnFuncionDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_EnFuncionDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_EnFuncionDe.Location = new System.Drawing.Point(105, 7);
            this.lbl_EnFuncionDe.Name = "lbl_EnFuncionDe";
            this.lbl_EnFuncionDe.Size = new System.Drawing.Size(220, 30);
            this.lbl_EnFuncionDe.TabIndex = 70;
            this.lbl_EnFuncionDe.Text = "En Función de:";
            this.lbl_EnFuncionDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f_EstablecerVariableDetalle2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 468);
            this.Controls.Add(this.lbl_LapsoDetalle);
            this.Controls.Add(this.but_EstablecerLapso);
            this.Controls.Add(this.panel_EnFuncionDeBorder);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Establecer);
            this.Controls.Add(this.lbl_EnFuncionDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_EstablecerVariableDetalle2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable en Función de...";
            this.Load += new System.EventHandler(this.f_EstablecerVariableDetalle2_Load);
            this.panel_EnFuncionDeBorder.ResumeLayout(false);
            this.panel_EnFuncionDe.ResumeLayout(false);
            this.panel_EnFuncionDe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.ComboBoxs.DefaultComboBox combo_Cuenta;
        private Controls.Labels.DarkLabel lbl_EnFuncionDe;
        private Controls.Buttons.DarkButton but_Cancelar;
        private Controls.Buttons.DarkButton but_Establecer;
        private System.Windows.Forms.Panel panel_EnFuncionDeBorder;
        private System.Windows.Forms.Panel panel_EnFuncionDe;
        private Controls.Labels.DarkLabel lbl_Cuenta;
        private Controls.Labels.DarkCheckbox check_Cuenta;
        private Controls.Labels.DarkCheckbox check_Categoria;
        private Controls.Labels.DarkLabel lbl_Categoría;
        private Controls.ComboBoxs.DefaultComboBox combo_Categoria;
        private Controls.Labels.DarkCheckbox check_Etiqueta;
        private Controls.Labels.DarkLabel lbl_Etiqueta;
        private Controls.ComboBoxs.DefaultComboBox combo_Etiqueta;
        private Controls.Buttons.DarkButton but_EstablecerLapso;
        private Controls.Labels.DarkLabel lbl_LapsoDetalle;
    }
}