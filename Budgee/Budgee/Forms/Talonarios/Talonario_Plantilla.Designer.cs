
namespace UI.Forms.Talonarios
{
    partial class Talonario_Plantilla
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
            this.txt_DescripcionPlantilla = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_DescripcionPlantilla = new UI.Controls.Labels.DarkLabel();
            this.but_Monto = new UI.Controls.Buttons.DarkButton();
            this.txt_Monto = new UI.Controls.TextBoxs.NumericBox();
            this.grid_Etiquetas = new UI.Controls.Grids.DefaultDataGridView();
            this.lbl_Etiquetas = new UI.Controls.Labels.DarkLabel();
            this.but_RemoverEtiqueta = new UI.Controls.Buttons.DarkButton();
            this.but_AgregarEtiqueta = new UI.Controls.Buttons.DarkButton();
            this.lbl_Monto = new UI.Controls.Labels.DarkLabel();
            this.combo_TipoOperacion = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_TipoOperacion = new UI.Controls.Labels.DarkLabel();
            this.combo_Categoria = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Categoria = new UI.Controls.Labels.DarkLabel();
            this.txt_DescripcionTransaccion = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_DescripcionTransaccion = new UI.Controls.Labels.DarkLabel();
            this.check_Categoria = new UI.Controls.Labels.DarkCheckbox();
            this.check_DescripcionTransaccion = new UI.Controls.Labels.DarkCheckbox();
            this.check_TipoOperacion = new UI.Controls.Labels.DarkCheckbox();
            this.check_Monto = new UI.Controls.Labels.DarkCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Etiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(157, 381);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(298, 381);
            // 
            // txt_DescripcionPlantilla
            // 
            this.txt_DescripcionPlantilla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_DescripcionPlantilla.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescripcionPlantilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescripcionPlantilla.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_DescripcionPlantilla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_DescripcionPlantilla.Location = new System.Drawing.Point(117, 44);
            this.txt_DescripcionPlantilla.MaxLength = 150;
            this.txt_DescripcionPlantilla.Name = "txt_DescripcionPlantilla";
            this.txt_DescripcionPlantilla.Size = new System.Drawing.Size(342, 29);
            this.txt_DescripcionPlantilla.TabIndex = 68;
            // 
            // lbl_DescripcionPlantilla
            // 
            this.lbl_DescripcionPlantilla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_DescripcionPlantilla.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DescripcionPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_DescripcionPlantilla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_DescripcionPlantilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_DescripcionPlantilla.Location = new System.Drawing.Point(117, 12);
            this.lbl_DescripcionPlantilla.Name = "lbl_DescripcionPlantilla";
            this.lbl_DescripcionPlantilla.Size = new System.Drawing.Size(342, 29);
            this.lbl_DescripcionPlantilla.TabIndex = 67;
            this.lbl_DescripcionPlantilla.Text = "Descripción Plantilla:";
            this.lbl_DescripcionPlantilla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_Monto
            // 
            this.but_Monto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_Monto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Monto.Enabled = false;
            this.but_Monto.FlatAppearance.BorderSize = 0;
            this.but_Monto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Monto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Monto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Monto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Monto.Location = new System.Drawing.Point(248, 328);
            this.but_Monto.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Monto.Name = "but_Monto";
            this.but_Monto.Size = new System.Drawing.Size(32, 29);
            this.but_Monto.TabIndex = 66;
            this.but_Monto.Text = "...";
            this.but_Monto.UseVisualStyleBackColor = false;
            this.but_Monto.Click += new System.EventHandler(this.but_Monto_Click);
            // 
            // txt_Monto
            // 
            this.txt_Monto.AllowText = false;
            this.txt_Monto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Monto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Monto.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Monto.Enabled = false;
            this.txt_Monto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Monto.Location = new System.Drawing.Point(19, 328);
            this.txt_Monto.MaxLength = 10;
            this.txt_Monto.Name = "txt_Monto";
            this.txt_Monto.Size = new System.Drawing.Size(229, 29);
            this.txt_Monto.TabIndex = 65;
            // 
            // grid_Etiquetas
            // 
            this.grid_Etiquetas.AllowUserToAddRows = false;
            this.grid_Etiquetas.AllowUserToDeleteRows = false;
            this.grid_Etiquetas.AllowUserToResizeRows = false;
            this.grid_Etiquetas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grid_Etiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Etiquetas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Etiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Etiquetas.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Etiquetas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Etiquetas.Location = new System.Drawing.Point(300, 185);
            this.grid_Etiquetas.MultiSelect = false;
            this.grid_Etiquetas.Name = "grid_Etiquetas";
            this.grid_Etiquetas.ReadOnly = true;
            this.grid_Etiquetas.RowHeadersVisible = false;
            this.grid_Etiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Etiquetas.Size = new System.Drawing.Size(265, 131);
            this.grid_Etiquetas.TabIndex = 64;
            // 
            // lbl_Etiquetas
            // 
            this.lbl_Etiquetas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Etiquetas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Etiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Etiquetas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Etiquetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Etiquetas.Location = new System.Drawing.Point(300, 153);
            this.lbl_Etiquetas.Name = "lbl_Etiquetas";
            this.lbl_Etiquetas.Size = new System.Drawing.Size(265, 30);
            this.lbl_Etiquetas.TabIndex = 63;
            this.lbl_Etiquetas.Text = "Etiquetas:";
            this.lbl_Etiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_RemoverEtiqueta
            // 
            this.but_RemoverEtiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_RemoverEtiqueta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_RemoverEtiqueta.FlatAppearance.BorderSize = 0;
            this.but_RemoverEtiqueta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_RemoverEtiqueta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_RemoverEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_RemoverEtiqueta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_RemoverEtiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_RemoverEtiqueta.Location = new System.Drawing.Point(441, 328);
            this.but_RemoverEtiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_RemoverEtiqueta.Name = "but_RemoverEtiqueta";
            this.but_RemoverEtiqueta.Size = new System.Drawing.Size(124, 29);
            this.but_RemoverEtiqueta.TabIndex = 62;
            this.but_RemoverEtiqueta.Text = "Remover";
            this.but_RemoverEtiqueta.UseVisualStyleBackColor = false;
            this.but_RemoverEtiqueta.Click += new System.EventHandler(this.but_RemoverEtiqueta_Click);
            // 
            // but_AgregarEtiqueta
            // 
            this.but_AgregarEtiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_AgregarEtiqueta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_AgregarEtiqueta.FlatAppearance.BorderSize = 0;
            this.but_AgregarEtiqueta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_AgregarEtiqueta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_AgregarEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_AgregarEtiqueta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_AgregarEtiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_AgregarEtiqueta.Location = new System.Drawing.Point(298, 328);
            this.but_AgregarEtiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_AgregarEtiqueta.Name = "but_AgregarEtiqueta";
            this.but_AgregarEtiqueta.Size = new System.Drawing.Size(124, 29);
            this.but_AgregarEtiqueta.TabIndex = 61;
            this.but_AgregarEtiqueta.Text = "Agregar";
            this.but_AgregarEtiqueta.UseVisualStyleBackColor = false;
            this.but_AgregarEtiqueta.Click += new System.EventHandler(this.but_AgregarEtiqueta_Click);
            // 
            // lbl_Monto
            // 
            this.lbl_Monto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Monto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Monto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Monto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Monto.Location = new System.Drawing.Point(19, 296);
            this.lbl_Monto.Name = "lbl_Monto";
            this.lbl_Monto.Size = new System.Drawing.Size(261, 29);
            this.lbl_Monto.TabIndex = 60;
            this.lbl_Monto.Text = "Monto:";
            this.lbl_Monto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_TipoOperacion
            // 
            this.combo_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_TipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_TipoOperacion.FormattingEnabled = true;
            this.combo_TipoOperacion.Location = new System.Drawing.Point(19, 256);
            this.combo_TipoOperacion.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_TipoOperacion.Name = "combo_TipoOperacion";
            this.combo_TipoOperacion.Size = new System.Drawing.Size(261, 29);
            this.combo_TipoOperacion.TabIndex = 57;
            this.combo_TipoOperacion.SelectedIndexChanged += new System.EventHandler(this.combo_TipoOperacion_SelectedIndexChanged);
            // 
            // lbl_TipoOperacion
            // 
            this.lbl_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_TipoOperacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_TipoOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_TipoOperacion.Location = new System.Drawing.Point(19, 224);
            this.lbl_TipoOperacion.Name = "lbl_TipoOperacion";
            this.lbl_TipoOperacion.Size = new System.Drawing.Size(261, 29);
            this.lbl_TipoOperacion.TabIndex = 56;
            this.lbl_TipoOperacion.Text = "Tipo Operación:";
            this.lbl_TipoOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Categoria
            // 
            this.combo_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Categoria.FormattingEnabled = true;
            this.combo_Categoria.Location = new System.Drawing.Point(19, 185);
            this.combo_Categoria.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Categoria.Name = "combo_Categoria";
            this.combo_Categoria.Size = new System.Drawing.Size(261, 29);
            this.combo_Categoria.TabIndex = 55;
            this.combo_Categoria.DropDown += new System.EventHandler(this.combo_Categoria_DropDown);
            // 
            // lbl_Categoria
            // 
            this.lbl_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Categoria.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Categoria.Location = new System.Drawing.Point(19, 153);
            this.lbl_Categoria.Name = "lbl_Categoria";
            this.lbl_Categoria.Size = new System.Drawing.Size(261, 30);
            this.lbl_Categoria.TabIndex = 54;
            this.lbl_Categoria.Text = "Categoría:";
            this.lbl_Categoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_DescripcionTransaccion
            // 
            this.txt_DescripcionTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_DescripcionTransaccion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescripcionTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescripcionTransaccion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_DescripcionTransaccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_DescripcionTransaccion.Location = new System.Drawing.Point(119, 114);
            this.txt_DescripcionTransaccion.MaxLength = 150;
            this.txt_DescripcionTransaccion.Name = "txt_DescripcionTransaccion";
            this.txt_DescripcionTransaccion.Size = new System.Drawing.Size(342, 29);
            this.txt_DescripcionTransaccion.TabIndex = 51;
            // 
            // lbl_DescripcionTransaccion
            // 
            this.lbl_DescripcionTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_DescripcionTransaccion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DescripcionTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_DescripcionTransaccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_DescripcionTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_DescripcionTransaccion.Location = new System.Drawing.Point(117, 82);
            this.lbl_DescripcionTransaccion.Name = "lbl_DescripcionTransaccion";
            this.lbl_DescripcionTransaccion.Size = new System.Drawing.Size(342, 29);
            this.lbl_DescripcionTransaccion.TabIndex = 50;
            this.lbl_DescripcionTransaccion.Text = "Descripción de Transacción:";
            this.lbl_DescripcionTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.check_Categoria.Location = new System.Drawing.Point(89, 163);
            this.check_Categoria.Name = "check_Categoria";
            this.check_Categoria.Size = new System.Drawing.Size(12, 11);
            this.check_Categoria.TabIndex = 69;
            this.check_Categoria.UseVisualStyleBackColor = false;
            this.check_Categoria.CheckedChanged += new System.EventHandler(this.check_Categoria_CheckedChanged);
            // 
            // check_DescripcionTransaccion
            // 
            this.check_DescripcionTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_DescripcionTransaccion.AutoSize = true;
            this.check_DescripcionTransaccion.BackColor = System.Drawing.Color.Transparent;
            this.check_DescripcionTransaccion.Checked = true;
            this.check_DescripcionTransaccion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_DescripcionTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_DescripcionTransaccion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_DescripcionTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_DescripcionTransaccion.Location = new System.Drawing.Point(161, 93);
            this.check_DescripcionTransaccion.Name = "check_DescripcionTransaccion";
            this.check_DescripcionTransaccion.Size = new System.Drawing.Size(12, 11);
            this.check_DescripcionTransaccion.TabIndex = 70;
            this.check_DescripcionTransaccion.UseVisualStyleBackColor = false;
            this.check_DescripcionTransaccion.CheckedChanged += new System.EventHandler(this.check_DescripcionTransaccion_CheckedChanged);
            // 
            // check_TipoOperacion
            // 
            this.check_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_TipoOperacion.AutoSize = true;
            this.check_TipoOperacion.BackColor = System.Drawing.Color.Transparent;
            this.check_TipoOperacion.Checked = true;
            this.check_TipoOperacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_TipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_TipoOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_TipoOperacion.Location = new System.Drawing.Point(68, 233);
            this.check_TipoOperacion.Name = "check_TipoOperacion";
            this.check_TipoOperacion.Size = new System.Drawing.Size(12, 11);
            this.check_TipoOperacion.TabIndex = 71;
            this.check_TipoOperacion.UseVisualStyleBackColor = false;
            this.check_TipoOperacion.CheckedChanged += new System.EventHandler(this.check_TipoOperacion_CheckedChanged);
            // 
            // check_Monto
            // 
            this.check_Monto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Monto.AutoSize = true;
            this.check_Monto.BackColor = System.Drawing.Color.Transparent;
            this.check_Monto.Checked = true;
            this.check_Monto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Monto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Monto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_Monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Monto.Location = new System.Drawing.Point(101, 305);
            this.check_Monto.Name = "check_Monto";
            this.check_Monto.Size = new System.Drawing.Size(12, 11);
            this.check_Monto.TabIndex = 73;
            this.check_Monto.UseVisualStyleBackColor = false;
            this.check_Monto.CheckedChanged += new System.EventHandler(this.check_Monto_CheckedChanged);
            // 
            // Talonario_Plantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 427);
            this.Controls.Add(this.check_Monto);
            this.Controls.Add(this.check_TipoOperacion);
            this.Controls.Add(this.check_DescripcionTransaccion);
            this.Controls.Add(this.check_Categoria);
            this.Controls.Add(this.txt_DescripcionPlantilla);
            this.Controls.Add(this.lbl_DescripcionPlantilla);
            this.Controls.Add(this.but_Monto);
            this.Controls.Add(this.txt_Monto);
            this.Controls.Add(this.grid_Etiquetas);
            this.Controls.Add(this.lbl_Etiquetas);
            this.Controls.Add(this.but_RemoverEtiqueta);
            this.Controls.Add(this.but_AgregarEtiqueta);
            this.Controls.Add(this.lbl_Monto);
            this.Controls.Add(this.combo_TipoOperacion);
            this.Controls.Add(this.lbl_TipoOperacion);
            this.Controls.Add(this.combo_Categoria);
            this.Controls.Add(this.lbl_Categoria);
            this.Controls.Add(this.txt_DescripcionTransaccion);
            this.Controls.Add(this.lbl_DescripcionTransaccion);
            this.Name = "Talonario_Plantilla";
            this.Text = "Talonario_Plantillas";
            this.Shown += new System.EventHandler(this.Talonario_Plantilla_Shown);
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.lbl_DescripcionTransaccion, 0);
            this.Controls.SetChildIndex(this.txt_DescripcionTransaccion, 0);
            this.Controls.SetChildIndex(this.lbl_Categoria, 0);
            this.Controls.SetChildIndex(this.combo_Categoria, 0);
            this.Controls.SetChildIndex(this.lbl_TipoOperacion, 0);
            this.Controls.SetChildIndex(this.combo_TipoOperacion, 0);
            this.Controls.SetChildIndex(this.lbl_Monto, 0);
            this.Controls.SetChildIndex(this.but_AgregarEtiqueta, 0);
            this.Controls.SetChildIndex(this.but_RemoverEtiqueta, 0);
            this.Controls.SetChildIndex(this.lbl_Etiquetas, 0);
            this.Controls.SetChildIndex(this.grid_Etiquetas, 0);
            this.Controls.SetChildIndex(this.txt_Monto, 0);
            this.Controls.SetChildIndex(this.but_Monto, 0);
            this.Controls.SetChildIndex(this.lbl_DescripcionPlantilla, 0);
            this.Controls.SetChildIndex(this.txt_DescripcionPlantilla, 0);
            this.Controls.SetChildIndex(this.check_Categoria, 0);
            this.Controls.SetChildIndex(this.check_DescripcionTransaccion, 0);
            this.Controls.SetChildIndex(this.check_TipoOperacion, 0);
            this.Controls.SetChildIndex(this.check_Monto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Etiquetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.TextBoxs.DefaultTextBox txt_DescripcionPlantilla;
        private Controls.Labels.DarkLabel lbl_DescripcionPlantilla;
        private Controls.Buttons.DarkButton but_Monto;
        private Controls.Grids.DefaultDataGridView grid_Etiquetas;
        private Controls.Labels.DarkLabel lbl_Etiquetas;
        private Controls.Buttons.DarkButton but_RemoverEtiqueta;
        private Controls.Buttons.DarkButton but_AgregarEtiqueta;
        private Controls.Labels.DarkLabel lbl_Monto;
        private Controls.ComboBoxs.DefaultComboBox combo_TipoOperacion;
        private Controls.Labels.DarkLabel lbl_TipoOperacion;
        private Controls.ComboBoxs.DefaultComboBox combo_Categoria;
        private Controls.Labels.DarkLabel lbl_Categoria;
        private Controls.TextBoxs.DefaultTextBox txt_DescripcionTransaccion;
        private Controls.Labels.DarkLabel lbl_DescripcionTransaccion;
        private Controls.TextBoxs.NumericBox txt_Monto;
        private Controls.Labels.DarkCheckbox check_Categoria;
        private Controls.Labels.DarkCheckbox check_DescripcionTransaccion;
        private Controls.Labels.DarkCheckbox check_TipoOperacion;
        private Controls.Labels.DarkCheckbox check_Monto;
    }
}