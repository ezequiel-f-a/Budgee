
namespace UI.Forms
{
    partial class f_EstablecerLapso
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
            this.date_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.date_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Establecer = new UI.Controls.Buttons.DarkButton();
            this.combo_Lapso = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Lapso = new UI.Controls.Labels.DarkLabel();
            this.lbl_FechaDesde = new UI.Controls.Labels.DarkLabel();
            this.lbl_FechaHasta = new UI.Controls.Labels.DarkLabel();
            this.SuspendLayout();
            // 
            // date_FechaDesde
            // 
            this.date_FechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.date_FechaDesde.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.date_FechaDesde.Enabled = false;
            this.date_FechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_FechaDesde.Location = new System.Drawing.Point(23, 129);
            this.date_FechaDesde.Name = "date_FechaDesde";
            this.date_FechaDesde.Size = new System.Drawing.Size(190, 26);
            this.date_FechaDesde.TabIndex = 2;
            // 
            // date_FechaHasta
            // 
            this.date_FechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.date_FechaHasta.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.date_FechaHasta.Enabled = false;
            this.date_FechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_FechaHasta.Location = new System.Drawing.Point(233, 129);
            this.date_FechaHasta.Name = "date_FechaHasta";
            this.date_FechaHasta.Size = new System.Drawing.Size(190, 26);
            this.date_FechaHasta.TabIndex = 3;
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
            this.but_Cancelar.Location = new System.Drawing.Point(233, 183);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(114, 28);
            this.but_Cancelar.TabIndex = 1;
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
            this.but_Establecer.Location = new System.Drawing.Point(99, 183);
            this.but_Establecer.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Establecer.Name = "but_Establecer";
            this.but_Establecer.Size = new System.Drawing.Size(114, 28);
            this.but_Establecer.TabIndex = 0;
            this.but_Establecer.Text = "Establecer";
            this.but_Establecer.UseVisualStyleBackColor = false;
            this.but_Establecer.Click += new System.EventHandler(this.but_Establecer_Click);
            // 
            // combo_Lapso
            // 
            this.combo_Lapso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Lapso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Lapso.FormattingEnabled = true;
            this.combo_Lapso.Location = new System.Drawing.Point(133, 48);
            this.combo_Lapso.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Lapso.Name = "combo_Lapso";
            this.combo_Lapso.Size = new System.Drawing.Size(181, 29);
            this.combo_Lapso.TabIndex = 4;
            this.combo_Lapso.SelectedIndexChanged += new System.EventHandler(this.combo_Lapso_SelectedIndexChanged);
            // 
            // lbl_Lapso
            // 
            this.lbl_Lapso.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Lapso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Lapso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Lapso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Lapso.Location = new System.Drawing.Point(12, 17);
            this.lbl_Lapso.Name = "lbl_Lapso";
            this.lbl_Lapso.Size = new System.Drawing.Size(423, 23);
            this.lbl_Lapso.TabIndex = 5;
            this.lbl_Lapso.Text = "Lapso:";
            this.lbl_Lapso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_FechaDesde
            // 
            this.lbl_FechaDesde.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FechaDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FechaDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FechaDesde.Location = new System.Drawing.Point(23, 103);
            this.lbl_FechaDesde.Name = "lbl_FechaDesde";
            this.lbl_FechaDesde.Size = new System.Drawing.Size(190, 23);
            this.lbl_FechaDesde.TabIndex = 6;
            this.lbl_FechaDesde.Text = "Fecha Desde:";
            this.lbl_FechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_FechaHasta
            // 
            this.lbl_FechaHasta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FechaHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FechaHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FechaHasta.Location = new System.Drawing.Point(233, 103);
            this.lbl_FechaHasta.Name = "lbl_FechaHasta";
            this.lbl_FechaHasta.Size = new System.Drawing.Size(190, 23);
            this.lbl_FechaHasta.TabIndex = 7;
            this.lbl_FechaHasta.Text = "Fecha Hasta:";
            this.lbl_FechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f_EstablecerLapso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 229);
            this.Controls.Add(this.lbl_FechaHasta);
            this.Controls.Add(this.lbl_FechaDesde);
            this.Controls.Add(this.lbl_Lapso);
            this.Controls.Add(this.combo_Lapso);
            this.Controls.Add(this.date_FechaHasta);
            this.Controls.Add(this.date_FechaDesde);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Establecer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_EstablecerLapso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Establecer Lapso";
            this.Load += new System.EventHandler(this.f_EstablecerLapso_Load);
            this.Shown += new System.EventHandler(this.f_EstablecerLapso_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Buttons.DarkButton but_Establecer;
        private Controls.Buttons.DarkButton but_Cancelar;
        private System.Windows.Forms.DateTimePicker date_FechaDesde;
        private System.Windows.Forms.DateTimePicker date_FechaHasta;
        private Controls.ComboBoxs.DefaultComboBox combo_Lapso;
        private Controls.Labels.DarkLabel lbl_Lapso;
        private Controls.Labels.DarkLabel lbl_FechaDesde;
        private Controls.Labels.DarkLabel lbl_FechaHasta;
    }
}