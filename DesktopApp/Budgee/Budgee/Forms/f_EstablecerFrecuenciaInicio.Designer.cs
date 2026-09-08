
namespace UI.Forms
{
    partial class f_EstablecerFrecuenciaInicio
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
            this.panel_FrecuenciaBorder = new System.Windows.Forms.Panel();
            this.panel_Frecuencia = new System.Windows.Forms.Panel();
            this.lbl_FrecuenciaMagnitud = new UI.Controls.Labels.DarkLabel();
            this.txt_FrecuenciaValor = new UI.Controls.TextBoxs.IntegerBox();
            this.lbl_FrecuenciaValor = new UI.Controls.Labels.DarkLabel();
            this.combo_FrecuenciaMagnitud = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.panel_InicioBorder = new System.Windows.Forms.Panel();
            this.panel_Inicio = new System.Windows.Forms.Panel();
            this.txt_Año = new UI.Controls.TextBoxs.IntegerBox();
            this.lbl_Horario = new UI.Controls.Labels.DarkLabel();
            this.date_Horario = new System.Windows.Forms.DateTimePicker();
            this.lbl_Dia = new UI.Controls.Labels.DarkLabel();
            this.combo_Dia = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Mes = new UI.Controls.Labels.DarkLabel();
            this.combo_Mes = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Año = new UI.Controls.Labels.DarkLabel();
            this.lbl_Inicio = new UI.Controls.Labels.DarkLabel();
            this.check_Frecuencia = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_Frecuencia = new UI.Controls.Labels.DarkLabel();
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Establecer = new UI.Controls.Buttons.DarkButton();
            this.panel_FrecuenciaBorder.SuspendLayout();
            this.panel_Frecuencia.SuspendLayout();
            this.panel_InicioBorder.SuspendLayout();
            this.panel_Inicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_FrecuenciaBorder
            // 
            this.panel_FrecuenciaBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_FrecuenciaBorder.Controls.Add(this.panel_Frecuencia);
            this.panel_FrecuenciaBorder.Location = new System.Drawing.Point(12, 45);
            this.panel_FrecuenciaBorder.Name = "panel_FrecuenciaBorder";
            this.panel_FrecuenciaBorder.Padding = new System.Windows.Forms.Padding(5);
            this.panel_FrecuenciaBorder.Size = new System.Drawing.Size(315, 97);
            this.panel_FrecuenciaBorder.TabIndex = 21;
            // 
            // panel_Frecuencia
            // 
            this.panel_Frecuencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Frecuencia.Controls.Add(this.lbl_FrecuenciaMagnitud);
            this.panel_Frecuencia.Controls.Add(this.txt_FrecuenciaValor);
            this.panel_Frecuencia.Controls.Add(this.lbl_FrecuenciaValor);
            this.panel_Frecuencia.Controls.Add(this.combo_FrecuenciaMagnitud);
            this.panel_Frecuencia.Location = new System.Drawing.Point(7, 8);
            this.panel_Frecuencia.Name = "panel_Frecuencia";
            this.panel_Frecuencia.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Frecuencia.Size = new System.Drawing.Size(301, 81);
            this.panel_Frecuencia.TabIndex = 18;
            // 
            // lbl_FrecuenciaMagnitud
            // 
            this.lbl_FrecuenciaMagnitud.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FrecuenciaMagnitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FrecuenciaMagnitud.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FrecuenciaMagnitud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FrecuenciaMagnitud.Location = new System.Drawing.Point(107, 11);
            this.lbl_FrecuenciaMagnitud.Name = "lbl_FrecuenciaMagnitud";
            this.lbl_FrecuenciaMagnitud.Size = new System.Drawing.Size(156, 20);
            this.lbl_FrecuenciaMagnitud.TabIndex = 26;
            this.lbl_FrecuenciaMagnitud.Text = "Magnitud:";
            this.lbl_FrecuenciaMagnitud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_FrecuenciaValor
            // 
            this.txt_FrecuenciaValor.AllowText = false;
            this.txt_FrecuenciaValor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_FrecuenciaValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FrecuenciaValor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_FrecuenciaValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_FrecuenciaValor.Location = new System.Drawing.Point(37, 37);
            this.txt_FrecuenciaValor.MaxLength = 4;
            this.txt_FrecuenciaValor.Name = "txt_FrecuenciaValor";
            this.txt_FrecuenciaValor.Size = new System.Drawing.Size(57, 29);
            this.txt_FrecuenciaValor.TabIndex = 25;
            // 
            // lbl_FrecuenciaValor
            // 
            this.lbl_FrecuenciaValor.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FrecuenciaValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FrecuenciaValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FrecuenciaValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FrecuenciaValor.Location = new System.Drawing.Point(37, 11);
            this.lbl_FrecuenciaValor.Name = "lbl_FrecuenciaValor";
            this.lbl_FrecuenciaValor.Size = new System.Drawing.Size(57, 20);
            this.lbl_FrecuenciaValor.TabIndex = 24;
            this.lbl_FrecuenciaValor.Text = "Valor:";
            this.lbl_FrecuenciaValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_FrecuenciaMagnitud
            // 
            this.combo_FrecuenciaMagnitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_FrecuenciaMagnitud.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_FrecuenciaMagnitud.FormattingEnabled = true;
            this.combo_FrecuenciaMagnitud.Location = new System.Drawing.Point(107, 37);
            this.combo_FrecuenciaMagnitud.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_FrecuenciaMagnitud.Name = "combo_FrecuenciaMagnitud";
            this.combo_FrecuenciaMagnitud.Size = new System.Drawing.Size(156, 29);
            this.combo_FrecuenciaMagnitud.TabIndex = 0;
            this.combo_FrecuenciaMagnitud.SelectedIndexChanged += new System.EventHandler(this.combo_FrecuenciaMagnitud_SelectedIndexChanged);
            // 
            // panel_InicioBorder
            // 
            this.panel_InicioBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_InicioBorder.Controls.Add(this.panel_Inicio);
            this.panel_InicioBorder.Enabled = false;
            this.panel_InicioBorder.Location = new System.Drawing.Point(12, 184);
            this.panel_InicioBorder.Name = "panel_InicioBorder";
            this.panel_InicioBorder.Padding = new System.Windows.Forms.Padding(5);
            this.panel_InicioBorder.Size = new System.Drawing.Size(315, 272);
            this.panel_InicioBorder.TabIndex = 22;
            // 
            // panel_Inicio
            // 
            this.panel_Inicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Inicio.Controls.Add(this.txt_Año);
            this.panel_Inicio.Controls.Add(this.lbl_Horario);
            this.panel_Inicio.Controls.Add(this.date_Horario);
            this.panel_Inicio.Controls.Add(this.lbl_Dia);
            this.panel_Inicio.Controls.Add(this.combo_Dia);
            this.panel_Inicio.Controls.Add(this.lbl_Mes);
            this.panel_Inicio.Controls.Add(this.combo_Mes);
            this.panel_Inicio.Controls.Add(this.lbl_Año);
            this.panel_Inicio.Location = new System.Drawing.Point(7, 8);
            this.panel_Inicio.Name = "panel_Inicio";
            this.panel_Inicio.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Inicio.Size = new System.Drawing.Size(301, 257);
            this.panel_Inicio.TabIndex = 18;
            // 
            // txt_Año
            // 
            this.txt_Año.AllowText = false;
            this.txt_Año.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Año.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Año.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Año.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Año.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Año.Location = new System.Drawing.Point(113, 36);
            this.txt_Año.MaxLength = 4;
            this.txt_Año.Name = "txt_Año";
            this.txt_Año.Size = new System.Drawing.Size(75, 29);
            this.txt_Año.TabIndex = 33;
            // 
            // lbl_Horario
            // 
            this.lbl_Horario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Horario.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Horario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Horario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Horario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Horario.Location = new System.Drawing.Point(55, 190);
            this.lbl_Horario.Name = "lbl_Horario";
            this.lbl_Horario.Size = new System.Drawing.Size(190, 23);
            this.lbl_Horario.TabIndex = 32;
            this.lbl_Horario.Text = "Horario:";
            this.lbl_Horario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date_Horario
            // 
            this.date_Horario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.date_Horario.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.date_Horario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_Horario.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.date_Horario.Location = new System.Drawing.Point(104, 219);
            this.date_Horario.Name = "date_Horario";
            this.date_Horario.ShowUpDown = true;
            this.date_Horario.Size = new System.Drawing.Size(92, 26);
            this.date_Horario.TabIndex = 31;
            // 
            // lbl_Dia
            // 
            this.lbl_Dia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Dia.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Dia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Dia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Dia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Dia.Location = new System.Drawing.Point(72, 129);
            this.lbl_Dia.Name = "lbl_Dia";
            this.lbl_Dia.Size = new System.Drawing.Size(156, 19);
            this.lbl_Dia.TabIndex = 30;
            this.lbl_Dia.Text = "Día:";
            this.lbl_Dia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Dia
            // 
            this.combo_Dia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Dia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Dia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Dia.FormattingEnabled = true;
            this.combo_Dia.Location = new System.Drawing.Point(72, 153);
            this.combo_Dia.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Dia.Name = "combo_Dia";
            this.combo_Dia.Size = new System.Drawing.Size(156, 29);
            this.combo_Dia.TabIndex = 29;
            // 
            // lbl_Mes
            // 
            this.lbl_Mes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Mes.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Mes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Mes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Mes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Mes.Location = new System.Drawing.Point(72, 70);
            this.lbl_Mes.Name = "lbl_Mes";
            this.lbl_Mes.Size = new System.Drawing.Size(156, 19);
            this.lbl_Mes.TabIndex = 28;
            this.lbl_Mes.Text = "Mes:";
            this.lbl_Mes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Mes
            // 
            this.combo_Mes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Mes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Mes.FormattingEnabled = true;
            this.combo_Mes.Location = new System.Drawing.Point(72, 94);
            this.combo_Mes.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Mes.Name = "combo_Mes";
            this.combo_Mes.Size = new System.Drawing.Size(156, 29);
            this.combo_Mes.TabIndex = 27;
            // 
            // lbl_Año
            // 
            this.lbl_Año.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Año.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Año.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Año.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Año.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Año.Location = new System.Drawing.Point(72, 12);
            this.lbl_Año.Name = "lbl_Año";
            this.lbl_Año.Size = new System.Drawing.Size(156, 20);
            this.lbl_Año.TabIndex = 26;
            this.lbl_Año.Text = "Año:";
            this.lbl_Año.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Inicio
            // 
            this.lbl_Inicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Inicio.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Inicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Inicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Inicio.Location = new System.Drawing.Point(3, 154);
            this.lbl_Inicio.Name = "lbl_Inicio";
            this.lbl_Inicio.Size = new System.Drawing.Size(335, 20);
            this.lbl_Inicio.TabIndex = 24;
            this.lbl_Inicio.Text = "Inicio:";
            this.lbl_Inicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_Frecuencia
            // 
            this.check_Frecuencia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Frecuencia.AutoSize = true;
            this.check_Frecuencia.BackColor = System.Drawing.Color.Transparent;
            this.check_Frecuencia.Checked = true;
            this.check_Frecuencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Frecuencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Frecuencia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_Frecuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Frecuencia.Location = new System.Drawing.Point(103, 21);
            this.check_Frecuencia.Name = "check_Frecuencia";
            this.check_Frecuencia.Size = new System.Drawing.Size(12, 11);
            this.check_Frecuencia.TabIndex = 23;
            this.check_Frecuencia.UseVisualStyleBackColor = false;
            this.check_Frecuencia.CheckedChanged += new System.EventHandler(this.check_Frecuencia_CheckedChanged);
            // 
            // lbl_Frecuencia
            // 
            this.lbl_Frecuencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Frecuencia.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Frecuencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Frecuencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Frecuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Frecuencia.Location = new System.Drawing.Point(-1, 14);
            this.lbl_Frecuencia.Name = "lbl_Frecuencia";
            this.lbl_Frecuencia.Size = new System.Drawing.Size(339, 20);
            this.lbl_Frecuencia.TabIndex = 22;
            this.lbl_Frecuencia.Text = "Frecuencia:";
            this.lbl_Frecuencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.but_Cancelar.Location = new System.Drawing.Point(179, 469);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(114, 28);
            this.but_Cancelar.TabIndex = 3;
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
            this.but_Establecer.Location = new System.Drawing.Point(45, 469);
            this.but_Establecer.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Establecer.Name = "but_Establecer";
            this.but_Establecer.Size = new System.Drawing.Size(114, 28);
            this.but_Establecer.TabIndex = 2;
            this.but_Establecer.Text = "Establecer";
            this.but_Establecer.UseVisualStyleBackColor = false;
            this.but_Establecer.Click += new System.EventHandler(this.but_Establecer_Click);
            // 
            // f_EstablecerFrecuenciaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 512);
            this.Controls.Add(this.lbl_Inicio);
            this.Controls.Add(this.panel_InicioBorder);
            this.Controls.Add(this.check_Frecuencia);
            this.Controls.Add(this.lbl_Frecuencia);
            this.Controls.Add(this.panel_FrecuenciaBorder);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Establecer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_EstablecerFrecuenciaInicio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Establecer Frecuencia e Inicio";
            this.Load += new System.EventHandler(this.f_EstablecerFrecuenciaInicio_Load);
            this.Shown += new System.EventHandler(this.f_EstablecerFrecuenciaInicio_Shown);
            this.SizeChanged += new System.EventHandler(this.f_EstablecerFrecuenciaInicio_SizeChanged);
            this.panel_FrecuenciaBorder.ResumeLayout(false);
            this.panel_Frecuencia.ResumeLayout(false);
            this.panel_Frecuencia.PerformLayout();
            this.panel_InicioBorder.ResumeLayout(false);
            this.panel_Inicio.ResumeLayout(false);
            this.panel_Inicio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Buttons.DarkButton but_Cancelar;
        private Controls.Buttons.DarkButton but_Establecer;
        private System.Windows.Forms.Panel panel_FrecuenciaBorder;
        private System.Windows.Forms.Panel panel_Frecuencia;
        private Controls.Labels.DarkLabel lbl_Frecuencia;
        private Controls.Labels.DarkCheckbox check_Frecuencia;
        private Controls.Labels.DarkLabel lbl_FrecuenciaValor;
        private Controls.ComboBoxs.DefaultComboBox combo_FrecuenciaMagnitud;
        private Controls.Labels.DarkLabel lbl_FrecuenciaMagnitud;
        private Controls.TextBoxs.IntegerBox txt_FrecuenciaValor;
        private System.Windows.Forms.Panel panel_InicioBorder;
        private System.Windows.Forms.Panel panel_Inicio;
        private Controls.Labels.DarkLabel lbl_Dia;
        private Controls.ComboBoxs.DefaultComboBox combo_Dia;
        private Controls.Labels.DarkLabel lbl_Mes;
        private Controls.ComboBoxs.DefaultComboBox combo_Mes;
        private Controls.Labels.DarkLabel lbl_Año;
        private Controls.Labels.DarkLabel lbl_Inicio;
        private Controls.Labels.DarkLabel lbl_Horario;
        private System.Windows.Forms.DateTimePicker date_Horario;
        private Controls.TextBoxs.IntegerBox txt_Año;
    }
}