
namespace UI.Forms
{
    partial class f_EstablecerVariable
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
            this.but_Establecer = new UI.Controls.Buttons.DarkButton();
            this.lbl_Detalle = new UI.Controls.Labels.DarkLabel();
            this.combo_TipoVariable = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_TipoVariable = new UI.Controls.Labels.DarkLabel();
            this.txt_Nombre = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Nombre = new UI.Controls.Labels.DarkLabel();
            this.darkLabel1 = new UI.Controls.Labels.DarkLabel();
            this.SuspendLayout();
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
            this.but_Cancelar.Location = new System.Drawing.Point(232, 283);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(114, 28);
            this.but_Cancelar.TabIndex = 71;
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
            this.but_Establecer.Location = new System.Drawing.Point(98, 283);
            this.but_Establecer.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Establecer.Name = "but_Establecer";
            this.but_Establecer.Size = new System.Drawing.Size(114, 28);
            this.but_Establecer.TabIndex = 70;
            this.but_Establecer.Text = "Establecer";
            this.but_Establecer.UseVisualStyleBackColor = false;
            this.but_Establecer.Click += new System.EventHandler(this.but_Establecer_Click);
            // 
            // lbl_Detalle
            // 
            this.lbl_Detalle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Detalle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Detalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Detalle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Detalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Detalle.Location = new System.Drawing.Point(23, 187);
            this.lbl_Detalle.Name = "lbl_Detalle";
            this.lbl_Detalle.Size = new System.Drawing.Size(398, 79);
            this.lbl_Detalle.TabIndex = 69;
            this.lbl_Detalle.Text = "...";
            this.lbl_Detalle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // combo_TipoVariable
            // 
            this.combo_TipoVariable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_TipoVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_TipoVariable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_TipoVariable.FormattingEnabled = true;
            this.combo_TipoVariable.Location = new System.Drawing.Point(68, 109);
            this.combo_TipoVariable.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_TipoVariable.Name = "combo_TipoVariable";
            this.combo_TipoVariable.Size = new System.Drawing.Size(309, 29);
            this.combo_TipoVariable.TabIndex = 68;
            this.combo_TipoVariable.SelectedIndexChanged += new System.EventHandler(this.combo_TipoVariable_SelectedIndexChanged);
            // 
            // lbl_TipoVariable
            // 
            this.lbl_TipoVariable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_TipoVariable.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TipoVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TipoVariable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_TipoVariable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_TipoVariable.Location = new System.Drawing.Point(112, 77);
            this.lbl_TipoVariable.Name = "lbl_TipoVariable";
            this.lbl_TipoVariable.Size = new System.Drawing.Size(220, 30);
            this.lbl_TipoVariable.TabIndex = 67;
            this.lbl_TipoVariable.Text = "Tipo de Variable:";
            this.lbl_TipoVariable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Nombre.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nombre.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Nombre.Location = new System.Drawing.Point(68, 37);
            this.txt_Nombre.MaxLength = 50;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(309, 29);
            this.txt_Nombre.TabIndex = 66;
            this.txt_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Descripcion_KeyPress);
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Nombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Nombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Nombre.Location = new System.Drawing.Point(114, 5);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(216, 29);
            this.lbl_Nombre.TabIndex = 65;
            this.lbl_Nombre.Text = "Nombre de Variable:";
            this.lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkLabel1
            // 
            this.darkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.darkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.darkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.darkLabel1.Location = new System.Drawing.Point(112, 153);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(220, 30);
            this.darkLabel1.TabIndex = 72;
            this.darkLabel1.Text = "Detalle:";
            this.darkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f_EstablecerVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 331);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Establecer);
            this.Controls.Add(this.lbl_Detalle);
            this.Controls.Add(this.combo_TipoVariable);
            this.Controls.Add(this.lbl_TipoVariable);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.lbl_Nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "f_EstablecerVariable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Establecer Variable";
            this.Load += new System.EventHandler(this.f_EstablecerVariable_Load);
            this.Shown += new System.EventHandler(this.f_EstablecerVariable_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ComboBoxs.DefaultComboBox combo_TipoVariable;
        private Controls.Labels.DarkLabel lbl_TipoVariable;
        private Controls.TextBoxs.DefaultTextBox txt_Nombre;
        private Controls.Labels.DarkLabel lbl_Nombre;
        private Controls.Labels.DarkLabel lbl_Detalle;
        private Controls.Buttons.DarkButton but_Cancelar;
        private Controls.Buttons.DarkButton but_Establecer;
        private Controls.Labels.DarkLabel darkLabel1;
    }
}