
namespace UI.Forms.Talonarios
{
    partial class Talonario_Presupuesto
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
            this.txt_Descripcion = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Descripcion = new UI.Controls.Labels.DarkLabel();
            this.but_LapsoPresupuesto = new UI.Controls.Buttons.DarkButton();
            this.txt_LapsoPresupuesto = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_LapsoPresupuesto = new UI.Controls.Labels.DarkLabel();
            this.but_Supervisa = new UI.Controls.Buttons.DarkButton();
            this.txt_Supervisa = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Supervisa = new UI.Controls.Labels.DarkLabel();
            this.but_ValorCondición = new UI.Controls.Buttons.DarkButton();
            this.txt_ValorCondicion = new UI.Controls.TextBoxs.NumericBox();
            this.lbl_ValorCondición = new UI.Controls.Labels.DarkLabel();
            this.combo_CuandoChequear = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_CuandoChequear = new UI.Controls.Labels.DarkLabel();
            this.combo_OperadorRelacional = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.check_AlarmaWindows = new UI.Controls.Labels.DarkCheckbox();
            this.check_NotificacionWindows = new UI.Controls.Labels.DarkCheckbox();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(189, 491);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(330, 491);
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Descripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Descripcion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Descripcion.Location = new System.Drawing.Point(149, 48);
            this.txt_Descripcion.MaxLength = 150;
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(342, 29);
            this.txt_Descripcion.TabIndex = 48;
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Descripcion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Descripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Descripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Descripcion.Location = new System.Drawing.Point(149, 16);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(342, 29);
            this.lbl_Descripcion.TabIndex = 47;
            this.lbl_Descripcion.Text = "Descripción:";
            this.lbl_Descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_LapsoPresupuesto
            // 
            this.but_LapsoPresupuesto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_LapsoPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_LapsoPresupuesto.Enabled = false;
            this.but_LapsoPresupuesto.FlatAppearance.BorderSize = 0;
            this.but_LapsoPresupuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_LapsoPresupuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_LapsoPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_LapsoPresupuesto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_LapsoPresupuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_LapsoPresupuesto.Location = new System.Drawing.Point(577, 118);
            this.but_LapsoPresupuesto.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_LapsoPresupuesto.Name = "but_LapsoPresupuesto";
            this.but_LapsoPresupuesto.Size = new System.Drawing.Size(32, 29);
            this.but_LapsoPresupuesto.TabIndex = 52;
            this.but_LapsoPresupuesto.Text = "...";
            this.but_LapsoPresupuesto.UseVisualStyleBackColor = false;
            this.but_LapsoPresupuesto.Click += new System.EventHandler(this.but_LapsoPresupuesto_Click);
            // 
            // txt_LapsoPresupuesto
            // 
            this.txt_LapsoPresupuesto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_LapsoPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_LapsoPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LapsoPresupuesto.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_LapsoPresupuesto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_LapsoPresupuesto.Location = new System.Drawing.Point(261, 118);
            this.txt_LapsoPresupuesto.Name = "txt_LapsoPresupuesto";
            this.txt_LapsoPresupuesto.ReadOnly = true;
            this.txt_LapsoPresupuesto.Size = new System.Drawing.Size(317, 29);
            this.txt_LapsoPresupuesto.TabIndex = 51;
            // 
            // lbl_LapsoPresupuesto
            // 
            this.lbl_LapsoPresupuesto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_LapsoPresupuesto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LapsoPresupuesto.Enabled = false;
            this.lbl_LapsoPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_LapsoPresupuesto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_LapsoPresupuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_LapsoPresupuesto.Location = new System.Drawing.Point(261, 87);
            this.lbl_LapsoPresupuesto.Name = "lbl_LapsoPresupuesto";
            this.lbl_LapsoPresupuesto.Size = new System.Drawing.Size(348, 29);
            this.lbl_LapsoPresupuesto.TabIndex = 50;
            this.lbl_LapsoPresupuesto.Text = "Lapso de Presupuesto:";
            this.lbl_LapsoPresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_Supervisa
            // 
            this.but_Supervisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_Supervisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Supervisa.FlatAppearance.BorderSize = 0;
            this.but_Supervisa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Supervisa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Supervisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Supervisa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Supervisa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Supervisa.Location = new System.Drawing.Point(478, 199);
            this.but_Supervisa.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Supervisa.Name = "but_Supervisa";
            this.but_Supervisa.Size = new System.Drawing.Size(32, 29);
            this.but_Supervisa.TabIndex = 55;
            this.but_Supervisa.Text = "...";
            this.but_Supervisa.UseVisualStyleBackColor = false;
            this.but_Supervisa.Click += new System.EventHandler(this.but_Supervisa_Click);
            // 
            // txt_Supervisa
            // 
            this.txt_Supervisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Supervisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Supervisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Supervisa.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Supervisa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Supervisa.Location = new System.Drawing.Point(130, 199);
            this.txt_Supervisa.Name = "txt_Supervisa";
            this.txt_Supervisa.ReadOnly = true;
            this.txt_Supervisa.Size = new System.Drawing.Size(349, 29);
            this.txt_Supervisa.TabIndex = 54;
            // 
            // lbl_Supervisa
            // 
            this.lbl_Supervisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Supervisa.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Supervisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Supervisa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Supervisa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Supervisa.Location = new System.Drawing.Point(130, 167);
            this.lbl_Supervisa.Name = "lbl_Supervisa";
            this.lbl_Supervisa.Size = new System.Drawing.Size(380, 29);
            this.lbl_Supervisa.TabIndex = 53;
            this.lbl_Supervisa.Text = "Supervisa:";
            this.lbl_Supervisa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_ValorCondición
            // 
            this.but_ValorCondición.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_ValorCondición.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_ValorCondición.FlatAppearance.BorderSize = 0;
            this.but_ValorCondición.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_ValorCondición.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_ValorCondición.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ValorCondición.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_ValorCondición.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_ValorCondición.Location = new System.Drawing.Point(478, 330);
            this.but_ValorCondición.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_ValorCondición.Name = "but_ValorCondición";
            this.but_ValorCondición.Size = new System.Drawing.Size(32, 29);
            this.but_ValorCondición.TabIndex = 58;
            this.but_ValorCondición.Text = "...";
            this.but_ValorCondición.UseVisualStyleBackColor = false;
            this.but_ValorCondición.Click += new System.EventHandler(this.but_ValorCondición_Click);
            // 
            // txt_ValorCondicion
            // 
            this.txt_ValorCondicion.AllowText = false;
            this.txt_ValorCondicion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_ValorCondicion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ValorCondicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ValorCondicion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_ValorCondicion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_ValorCondicion.Location = new System.Drawing.Point(130, 330);
            this.txt_ValorCondicion.MaxLength = 10;
            this.txt_ValorCondicion.Name = "txt_ValorCondicion";
            this.txt_ValorCondicion.Size = new System.Drawing.Size(349, 29);
            this.txt_ValorCondicion.TabIndex = 57;
            // 
            // lbl_ValorCondición
            // 
            this.lbl_ValorCondición.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_ValorCondición.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ValorCondición.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ValorCondición.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_ValorCondición.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_ValorCondición.Location = new System.Drawing.Point(130, 298);
            this.lbl_ValorCondición.Name = "lbl_ValorCondición";
            this.lbl_ValorCondición.Size = new System.Drawing.Size(380, 29);
            this.lbl_ValorCondición.TabIndex = 56;
            this.lbl_ValorCondición.Text = "Valor de Condición:";
            this.lbl_ValorCondición.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_CuandoChequear
            // 
            this.combo_CuandoChequear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_CuandoChequear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_CuandoChequear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_CuandoChequear.FormattingEnabled = true;
            this.combo_CuandoChequear.Location = new System.Drawing.Point(32, 118);
            this.combo_CuandoChequear.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_CuandoChequear.Name = "combo_CuandoChequear";
            this.combo_CuandoChequear.Size = new System.Drawing.Size(216, 29);
            this.combo_CuandoChequear.TabIndex = 61;
            this.combo_CuandoChequear.SelectedIndexChanged += new System.EventHandler(this.combo_CuandoChequear_SelectedIndexChanged);
            // 
            // lbl_CuandoChequear
            // 
            this.lbl_CuandoChequear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_CuandoChequear.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CuandoChequear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_CuandoChequear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_CuandoChequear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_CuandoChequear.Location = new System.Drawing.Point(32, 86);
            this.lbl_CuandoChequear.Name = "lbl_CuandoChequear";
            this.lbl_CuandoChequear.Size = new System.Drawing.Size(216, 30);
            this.lbl_CuandoChequear.TabIndex = 60;
            this.lbl_CuandoChequear.Text = "Cuando Chequear:";
            this.lbl_CuandoChequear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_OperadorRelacional
            // 
            this.combo_OperadorRelacional.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_OperadorRelacional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_OperadorRelacional.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_OperadorRelacional.FormattingEnabled = true;
            this.combo_OperadorRelacional.Location = new System.Drawing.Point(218, 253);
            this.combo_OperadorRelacional.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_OperadorRelacional.Name = "combo_OperadorRelacional";
            this.combo_OperadorRelacional.Size = new System.Drawing.Size(205, 29);
            this.combo_OperadorRelacional.TabIndex = 63;
            // 
            // check_AlarmaWindows
            // 
            this.check_AlarmaWindows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_AlarmaWindows.AutoSize = true;
            this.check_AlarmaWindows.BackColor = System.Drawing.Color.Transparent;
            this.check_AlarmaWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_AlarmaWindows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_AlarmaWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_AlarmaWindows.Location = new System.Drawing.Point(32, 430);
            this.check_AlarmaWindows.Name = "check_AlarmaWindows";
            this.check_AlarmaWindows.Size = new System.Drawing.Size(261, 25);
            this.check_AlarmaWindows.TabIndex = 65;
            this.check_AlarmaWindows.Text = "Establecer Alarma de Windows";
            this.check_AlarmaWindows.UseVisualStyleBackColor = false;
            // 
            // check_NotificacionWindows
            // 
            this.check_NotificacionWindows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_NotificacionWindows.AutoSize = true;
            this.check_NotificacionWindows.BackColor = System.Drawing.Color.Transparent;
            this.check_NotificacionWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_NotificacionWindows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_NotificacionWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_NotificacionWindows.Location = new System.Drawing.Point(32, 392);
            this.check_NotificacionWindows.Name = "check_NotificacionWindows";
            this.check_NotificacionWindows.Size = new System.Drawing.Size(301, 25);
            this.check_NotificacionWindows.TabIndex = 64;
            this.check_NotificacionWindows.Text = "Establecer Notificación de Windows";
            this.check_NotificacionWindows.UseVisualStyleBackColor = false;
            // 
            // Talonario_Presupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 542);
            this.Controls.Add(this.check_AlarmaWindows);
            this.Controls.Add(this.check_NotificacionWindows);
            this.Controls.Add(this.combo_OperadorRelacional);
            this.Controls.Add(this.combo_CuandoChequear);
            this.Controls.Add(this.lbl_CuandoChequear);
            this.Controls.Add(this.but_ValorCondición);
            this.Controls.Add(this.txt_ValorCondicion);
            this.Controls.Add(this.lbl_ValorCondición);
            this.Controls.Add(this.but_Supervisa);
            this.Controls.Add(this.txt_Supervisa);
            this.Controls.Add(this.lbl_Supervisa);
            this.Controls.Add(this.but_LapsoPresupuesto);
            this.Controls.Add(this.txt_LapsoPresupuesto);
            this.Controls.Add(this.lbl_LapsoPresupuesto);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.lbl_Descripcion);
            this.Name = "Talonario_Presupuesto";
            this.Text = "Talonario_Presupuestos";
            this.Shown += new System.EventHandler(this.Talonario_Presupuesto_Shown);
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.lbl_Descripcion, 0);
            this.Controls.SetChildIndex(this.txt_Descripcion, 0);
            this.Controls.SetChildIndex(this.lbl_LapsoPresupuesto, 0);
            this.Controls.SetChildIndex(this.txt_LapsoPresupuesto, 0);
            this.Controls.SetChildIndex(this.but_LapsoPresupuesto, 0);
            this.Controls.SetChildIndex(this.lbl_Supervisa, 0);
            this.Controls.SetChildIndex(this.txt_Supervisa, 0);
            this.Controls.SetChildIndex(this.but_Supervisa, 0);
            this.Controls.SetChildIndex(this.lbl_ValorCondición, 0);
            this.Controls.SetChildIndex(this.txt_ValorCondicion, 0);
            this.Controls.SetChildIndex(this.but_ValorCondición, 0);
            this.Controls.SetChildIndex(this.lbl_CuandoChequear, 0);
            this.Controls.SetChildIndex(this.combo_CuandoChequear, 0);
            this.Controls.SetChildIndex(this.combo_OperadorRelacional, 0);
            this.Controls.SetChildIndex(this.check_NotificacionWindows, 0);
            this.Controls.SetChildIndex(this.check_AlarmaWindows, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxs.DefaultTextBox txt_Descripcion;
        private Controls.Labels.DarkLabel lbl_Descripcion;
        private Controls.Buttons.DarkButton but_LapsoPresupuesto;
        private Controls.TextBoxs.DefaultTextBox txt_LapsoPresupuesto;
        private Controls.Labels.DarkLabel lbl_LapsoPresupuesto;
        private Controls.Buttons.DarkButton but_Supervisa;
        private Controls.TextBoxs.DefaultTextBox txt_Supervisa;
        private Controls.Labels.DarkLabel lbl_Supervisa;
        private Controls.Buttons.DarkButton but_ValorCondición;
        private Controls.Labels.DarkLabel lbl_ValorCondición;
        private Controls.ComboBoxs.DefaultComboBox combo_CuandoChequear;
        private Controls.Labels.DarkLabel lbl_CuandoChequear;
        private Controls.ComboBoxs.DefaultComboBox combo_OperadorRelacional;
        private Controls.Labels.DarkCheckbox check_AlarmaWindows;
        private Controls.Labels.DarkCheckbox check_NotificacionWindows;
        private Controls.TextBoxs.NumericBox txt_ValorCondicion;
    }
}