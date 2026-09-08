
namespace UI.Forms
{
    partial class f_SeleccionarElem<T>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.but_Cancelar = new UI.Controls.Buttons.DarkButton();
            this.but_Seleccionar = new UI.Controls.Buttons.DarkButton();
            this.but_Crear = new UI.Controls.Buttons.DarkButton();
            this.but_VerDetalles = new UI.Controls.Buttons.DarkButton();
            this.grid_Seleccionar = new UI.Controls.Grids.DefaultDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Seleccionar)).BeginInit();
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
            this.but_Cancelar.Location = new System.Drawing.Point(205, 345);
            this.but_Cancelar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Cancelar.Name = "but_Cancelar";
            this.but_Cancelar.Size = new System.Drawing.Size(127, 33);
            this.but_Cancelar.TabIndex = 4;
            this.but_Cancelar.Text = "Cancelar";
            this.but_Cancelar.UseVisualStyleBackColor = false;
            this.but_Cancelar.Click += new System.EventHandler(this.but_Cancelar_Click);
            // 
            // but_Seleccionar
            // 
            this.but_Seleccionar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Seleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Seleccionar.FlatAppearance.BorderSize = 0;
            this.but_Seleccionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Seleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Seleccionar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Seleccionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Seleccionar.Location = new System.Drawing.Point(58, 345);
            this.but_Seleccionar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Seleccionar.Name = "but_Seleccionar";
            this.but_Seleccionar.Size = new System.Drawing.Size(127, 33);
            this.but_Seleccionar.TabIndex = 3;
            this.but_Seleccionar.Text = "Seleccionar";
            this.but_Seleccionar.UseVisualStyleBackColor = false;
            this.but_Seleccionar.Click += new System.EventHandler(this.but_Seleccionar_Click);
            // 
            // but_Crear
            // 
            this.but_Crear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Crear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Crear.FlatAppearance.BorderSize = 0;
            this.but_Crear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Crear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Crear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Crear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Crear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Crear.Location = new System.Drawing.Point(253, 277);
            this.but_Crear.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Crear.Name = "but_Crear";
            this.but_Crear.Size = new System.Drawing.Size(127, 33);
            this.but_Crear.TabIndex = 2;
            this.but_Crear.Text = "Crear...";
            this.but_Crear.UseVisualStyleBackColor = false;
            this.but_Crear.Click += new System.EventHandler(this.but_Crear_Click);
            // 
            // but_VerDetalles
            // 
            this.but_VerDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_VerDetalles.FlatAppearance.BorderSize = 0;
            this.but_VerDetalles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_VerDetalles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_VerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_VerDetalles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_VerDetalles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_VerDetalles.Location = new System.Drawing.Point(12, 277);
            this.but_VerDetalles.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_VerDetalles.Name = "but_VerDetalles";
            this.but_VerDetalles.Size = new System.Drawing.Size(127, 33);
            this.but_VerDetalles.TabIndex = 1;
            this.but_VerDetalles.Text = "Ver Detalles";
            this.but_VerDetalles.UseVisualStyleBackColor = false;
            this.but_VerDetalles.Click += new System.EventHandler(this.but_VerDetalles_Click);
            // 
            // grid_Seleccionar
            // 
            this.grid_Seleccionar.AllowUserToAddRows = false;
            this.grid_Seleccionar.AllowUserToDeleteRows = false;
            this.grid_Seleccionar.AllowUserToResizeRows = false;
            this.grid_Seleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))));
            this.grid_Seleccionar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Seleccionar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Seleccionar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Seleccionar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Seleccionar.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Seleccionar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Seleccionar.Location = new System.Drawing.Point(12, 12);
            this.grid_Seleccionar.MultiSelect = false;
            this.grid_Seleccionar.Name = "grid_Seleccionar";
            this.grid_Seleccionar.ReadOnly = true;
            this.grid_Seleccionar.RowHeadersVisible = false;
            this.grid_Seleccionar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Seleccionar.Size = new System.Drawing.Size(368, 252);
            this.grid_Seleccionar.TabIndex = 0;
            // 
            // f_SeleccionarElem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 394);
            this.Controls.Add(this.but_Cancelar);
            this.Controls.Add(this.but_Seleccionar);
            this.Controls.Add(this.but_Crear);
            this.Controls.Add(this.but_VerDetalles);
            this.Controls.Add(this.grid_Seleccionar);
            this.MaximizeBox = false;
            this.Name = "f_SeleccionarElem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_SeleccionarElemento";
            this.Load += new System.EventHandler(this.f_SeleccionarElem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Seleccionar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.Buttons.DarkButton but_Crear;
        protected Controls.Buttons.DarkButton but_Seleccionar;
        protected Controls.Buttons.DarkButton but_Cancelar;
        protected Controls.Grids.DefaultDataGridView grid_Seleccionar;
        protected Controls.Buttons.DarkButton but_VerDetalles;
    }
}