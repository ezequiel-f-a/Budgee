
namespace UI.Forms.Talonarios
{
    partial class Talonario_Planificacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.combo_Cuenta = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Cuenta = new UI.Controls.Labels.DarkLabel();
            this.txt_DescripcionTransaccion = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_DescripcionTransaccion = new UI.Controls.Labels.DarkLabel();
            this.but_GuardarComoPlantilla = new UI.Controls.Buttons.DarkButton();
            this.but_CargarDesdePlantilla = new UI.Controls.Buttons.DarkButton();
            this.txt_DescripcionPlanificacion = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_DescripcionPlanificacion = new UI.Controls.Labels.DarkLabel();
            this.but_FrecuenciaInicio = new UI.Controls.Buttons.DarkButton();
            this.txt_FrecuenciaInicio = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_FrecuenciaInicio = new UI.Controls.Labels.DarkLabel();
            this.check_GenerarRecordatorio = new UI.Controls.Labels.DarkCheckbox();
            this.check_Categoria = new UI.Controls.Labels.DarkCheckbox();
            this.check_QuitarAlConcluir = new UI.Controls.Labels.DarkCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Etiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(157, 574);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(298, 574);
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
            this.but_Monto.Location = new System.Drawing.Point(246, 386);
            this.but_Monto.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Monto.Name = "but_Monto";
            this.but_Monto.Size = new System.Drawing.Size(32, 29);
            this.but_Monto.TabIndex = 42;
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
            this.txt_Monto.Location = new System.Drawing.Point(18, 386);
            this.txt_Monto.MaxLength = 10;
            this.txt_Monto.Name = "txt_Monto";
            this.txt_Monto.Size = new System.Drawing.Size(228, 29);
            this.txt_Monto.TabIndex = 41;
            // 
            // grid_Etiquetas
            // 
            this.grid_Etiquetas.AllowUserToAddRows = false;
            this.grid_Etiquetas.AllowUserToDeleteRows = false;
            this.grid_Etiquetas.AllowUserToResizeRows = false;
            this.grid_Etiquetas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grid_Etiquetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Etiquetas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(79)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Etiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_Etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Etiquetas.DefaultCellStyle = dataGridViewCellStyle4;
            this.grid_Etiquetas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grid_Etiquetas.Location = new System.Drawing.Point(298, 315);
            this.grid_Etiquetas.MultiSelect = false;
            this.grid_Etiquetas.Name = "grid_Etiquetas";
            this.grid_Etiquetas.ReadOnly = true;
            this.grid_Etiquetas.RowHeadersVisible = false;
            this.grid_Etiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Etiquetas.Size = new System.Drawing.Size(260, 129);
            this.grid_Etiquetas.TabIndex = 40;
            // 
            // lbl_Etiquetas
            // 
            this.lbl_Etiquetas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Etiquetas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Etiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Etiquetas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Etiquetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Etiquetas.Location = new System.Drawing.Point(294, 283);
            this.lbl_Etiquetas.Name = "lbl_Etiquetas";
            this.lbl_Etiquetas.Size = new System.Drawing.Size(264, 30);
            this.lbl_Etiquetas.TabIndex = 39;
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
            this.but_RemoverEtiqueta.Location = new System.Drawing.Point(434, 457);
            this.but_RemoverEtiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_RemoverEtiqueta.Name = "but_RemoverEtiqueta";
            this.but_RemoverEtiqueta.Size = new System.Drawing.Size(124, 29);
            this.but_RemoverEtiqueta.TabIndex = 38;
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
            this.but_AgregarEtiqueta.Location = new System.Drawing.Point(298, 457);
            this.but_AgregarEtiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_AgregarEtiqueta.Name = "but_AgregarEtiqueta";
            this.but_AgregarEtiqueta.Size = new System.Drawing.Size(124, 29);
            this.but_AgregarEtiqueta.TabIndex = 37;
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
            this.lbl_Monto.Location = new System.Drawing.Point(18, 354);
            this.lbl_Monto.Name = "lbl_Monto";
            this.lbl_Monto.Size = new System.Drawing.Size(260, 29);
            this.lbl_Monto.TabIndex = 36;
            this.lbl_Monto.Text = "Monto:";
            this.lbl_Monto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_TipoOperacion
            // 
            this.combo_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_TipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_TipoOperacion.FormattingEnabled = true;
            this.combo_TipoOperacion.Location = new System.Drawing.Point(18, 315);
            this.combo_TipoOperacion.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_TipoOperacion.Name = "combo_TipoOperacion";
            this.combo_TipoOperacion.Size = new System.Drawing.Size(260, 29);
            this.combo_TipoOperacion.TabIndex = 33;
            this.combo_TipoOperacion.SelectedIndexChanged += new System.EventHandler(this.combo_TipoOperacion_SelectedIndexChanged);
            // 
            // lbl_TipoOperacion
            // 
            this.lbl_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_TipoOperacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_TipoOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_TipoOperacion.Location = new System.Drawing.Point(18, 283);
            this.lbl_TipoOperacion.Name = "lbl_TipoOperacion";
            this.lbl_TipoOperacion.Size = new System.Drawing.Size(260, 29);
            this.lbl_TipoOperacion.TabIndex = 32;
            this.lbl_TipoOperacion.Text = "Tipo Operación:";
            this.lbl_TipoOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Categoria
            // 
            this.combo_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Categoria.FormattingEnabled = true;
            this.combo_Categoria.Location = new System.Drawing.Point(298, 243);
            this.combo_Categoria.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Categoria.Name = "combo_Categoria";
            this.combo_Categoria.Size = new System.Drawing.Size(260, 29);
            this.combo_Categoria.TabIndex = 31;
            this.combo_Categoria.DropDown += new System.EventHandler(this.combo_Categoria_DropDown);
            // 
            // lbl_Categoria
            // 
            this.lbl_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Categoria.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Categoria.Location = new System.Drawing.Point(298, 211);
            this.lbl_Categoria.Name = "lbl_Categoria";
            this.lbl_Categoria.Size = new System.Drawing.Size(260, 30);
            this.lbl_Categoria.TabIndex = 30;
            this.lbl_Categoria.Text = "Categoría:";
            this.lbl_Categoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Cuenta
            // 
            this.combo_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Cuenta.FormattingEnabled = true;
            this.combo_Cuenta.Location = new System.Drawing.Point(18, 243);
            this.combo_Cuenta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Cuenta.Name = "combo_Cuenta";
            this.combo_Cuenta.Size = new System.Drawing.Size(260, 29);
            this.combo_Cuenta.TabIndex = 29;
            this.combo_Cuenta.DropDown += new System.EventHandler(this.combo_Cuenta_DropDown);
            // 
            // lbl_Cuenta
            // 
            this.lbl_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Cuenta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Cuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Cuenta.Location = new System.Drawing.Point(18, 211);
            this.lbl_Cuenta.Name = "lbl_Cuenta";
            this.lbl_Cuenta.Size = new System.Drawing.Size(260, 29);
            this.lbl_Cuenta.TabIndex = 28;
            this.lbl_Cuenta.Text = "Cuenta:";
            this.lbl_Cuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_DescripcionTransaccion
            // 
            this.txt_DescripcionTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_DescripcionTransaccion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescripcionTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescripcionTransaccion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_DescripcionTransaccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_DescripcionTransaccion.Location = new System.Drawing.Point(117, 172);
            this.txt_DescripcionTransaccion.MaxLength = 150;
            this.txt_DescripcionTransaccion.Name = "txt_DescripcionTransaccion";
            this.txt_DescripcionTransaccion.Size = new System.Drawing.Size(342, 29);
            this.txt_DescripcionTransaccion.TabIndex = 27;
            // 
            // lbl_DescripcionTransaccion
            // 
            this.lbl_DescripcionTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_DescripcionTransaccion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DescripcionTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_DescripcionTransaccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_DescripcionTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_DescripcionTransaccion.Location = new System.Drawing.Point(117, 140);
            this.lbl_DescripcionTransaccion.Name = "lbl_DescripcionTransaccion";
            this.lbl_DescripcionTransaccion.Size = new System.Drawing.Size(342, 29);
            this.lbl_DescripcionTransaccion.TabIndex = 26;
            this.lbl_DescripcionTransaccion.Text = "Descripción de Transacción Planificada:";
            this.lbl_DescripcionTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_GuardarComoPlantilla
            // 
            this.but_GuardarComoPlantilla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_GuardarComoPlantilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_GuardarComoPlantilla.FlatAppearance.BorderSize = 0;
            this.but_GuardarComoPlantilla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_GuardarComoPlantilla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_GuardarComoPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_GuardarComoPlantilla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_GuardarComoPlantilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_GuardarComoPlantilla.Location = new System.Drawing.Point(298, 19);
            this.but_GuardarComoPlantilla.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_GuardarComoPlantilla.Name = "but_GuardarComoPlantilla";
            this.but_GuardarComoPlantilla.Size = new System.Drawing.Size(260, 37);
            this.but_GuardarComoPlantilla.TabIndex = 25;
            this.but_GuardarComoPlantilla.Text = "Guardar como Plantilla...";
            this.but_GuardarComoPlantilla.UseVisualStyleBackColor = false;
            this.but_GuardarComoPlantilla.Click += new System.EventHandler(this.but_GuardarComoPlantilla_Click);
            // 
            // but_CargarDesdePlantilla
            // 
            this.but_CargarDesdePlantilla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_CargarDesdePlantilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_CargarDesdePlantilla.FlatAppearance.BorderSize = 0;
            this.but_CargarDesdePlantilla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_CargarDesdePlantilla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_CargarDesdePlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CargarDesdePlantilla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_CargarDesdePlantilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_CargarDesdePlantilla.Location = new System.Drawing.Point(18, 19);
            this.but_CargarDesdePlantilla.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_CargarDesdePlantilla.Name = "but_CargarDesdePlantilla";
            this.but_CargarDesdePlantilla.Size = new System.Drawing.Size(260, 37);
            this.but_CargarDesdePlantilla.TabIndex = 24;
            this.but_CargarDesdePlantilla.Text = "Cargar desde Plantilla...";
            this.but_CargarDesdePlantilla.UseVisualStyleBackColor = false;
            this.but_CargarDesdePlantilla.Click += new System.EventHandler(this.but_CargarDesdePlantilla_Click);
            // 
            // txt_DescripcionPlanificacion
            // 
            this.txt_DescripcionPlanificacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_DescripcionPlanificacion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescripcionPlanificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescripcionPlanificacion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_DescripcionPlanificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_DescripcionPlanificacion.Location = new System.Drawing.Point(117, 102);
            this.txt_DescripcionPlanificacion.MaxLength = 150;
            this.txt_DescripcionPlanificacion.Name = "txt_DescripcionPlanificacion";
            this.txt_DescripcionPlanificacion.Size = new System.Drawing.Size(342, 29);
            this.txt_DescripcionPlanificacion.TabIndex = 46;
            // 
            // lbl_DescripcionPlanificacion
            // 
            this.lbl_DescripcionPlanificacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_DescripcionPlanificacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DescripcionPlanificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_DescripcionPlanificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_DescripcionPlanificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_DescripcionPlanificacion.Location = new System.Drawing.Point(117, 70);
            this.lbl_DescripcionPlanificacion.Name = "lbl_DescripcionPlanificacion";
            this.lbl_DescripcionPlanificacion.Size = new System.Drawing.Size(342, 29);
            this.lbl_DescripcionPlanificacion.TabIndex = 45;
            this.lbl_DescripcionPlanificacion.Text = "Descripción Planificación:";
            this.lbl_DescripcionPlanificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_FrecuenciaInicio
            // 
            this.but_FrecuenciaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_FrecuenciaInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_FrecuenciaInicio.FlatAppearance.BorderSize = 0;
            this.but_FrecuenciaInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_FrecuenciaInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_FrecuenciaInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_FrecuenciaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_FrecuenciaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_FrecuenciaInicio.Location = new System.Drawing.Point(246, 457);
            this.but_FrecuenciaInicio.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_FrecuenciaInicio.Name = "but_FrecuenciaInicio";
            this.but_FrecuenciaInicio.Size = new System.Drawing.Size(32, 29);
            this.but_FrecuenciaInicio.TabIndex = 49;
            this.but_FrecuenciaInicio.Text = "...";
            this.but_FrecuenciaInicio.UseVisualStyleBackColor = false;
            this.but_FrecuenciaInicio.Click += new System.EventHandler(this.but_FrecuenciaInicio_Click);
            // 
            // txt_FrecuenciaInicio
            // 
            this.txt_FrecuenciaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_FrecuenciaInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_FrecuenciaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FrecuenciaInicio.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_FrecuenciaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_FrecuenciaInicio.Location = new System.Drawing.Point(18, 457);
            this.txt_FrecuenciaInicio.Name = "txt_FrecuenciaInicio";
            this.txt_FrecuenciaInicio.ReadOnly = true;
            this.txt_FrecuenciaInicio.Size = new System.Drawing.Size(228, 29);
            this.txt_FrecuenciaInicio.TabIndex = 48;
            // 
            // lbl_FrecuenciaInicio
            // 
            this.lbl_FrecuenciaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_FrecuenciaInicio.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FrecuenciaInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FrecuenciaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FrecuenciaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FrecuenciaInicio.Location = new System.Drawing.Point(18, 425);
            this.lbl_FrecuenciaInicio.Name = "lbl_FrecuenciaInicio";
            this.lbl_FrecuenciaInicio.Size = new System.Drawing.Size(260, 29);
            this.lbl_FrecuenciaInicio.TabIndex = 47;
            this.lbl_FrecuenciaInicio.Text = "Frecuencia e Inicio:";
            this.lbl_FrecuenciaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_GenerarRecordatorio
            // 
            this.check_GenerarRecordatorio.AutoSize = true;
            this.check_GenerarRecordatorio.BackColor = System.Drawing.Color.Transparent;
            this.check_GenerarRecordatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_GenerarRecordatorio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_GenerarRecordatorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_GenerarRecordatorio.Location = new System.Drawing.Point(18, 503);
            this.check_GenerarRecordatorio.Name = "check_GenerarRecordatorio";
            this.check_GenerarRecordatorio.Size = new System.Drawing.Size(276, 25);
            this.check_GenerarRecordatorio.TabIndex = 50;
            this.check_GenerarRecordatorio.Text = "Generar Recordatorio Respectivo";
            this.check_GenerarRecordatorio.UseVisualStyleBackColor = false;
            this.check_GenerarRecordatorio.CheckedChanged += new System.EventHandler(this.check_GenerarRecordatorio_CheckedChanged);
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
            this.check_Categoria.Location = new System.Drawing.Point(369, 221);
            this.check_Categoria.Name = "check_Categoria";
            this.check_Categoria.Size = new System.Drawing.Size(12, 11);
            this.check_Categoria.TabIndex = 54;
            this.check_Categoria.UseVisualStyleBackColor = false;
            this.check_Categoria.CheckedChanged += new System.EventHandler(this.check_Categoria_CheckedChanged);
            // 
            // check_QuitarAlConcluir
            // 
            this.check_QuitarAlConcluir.AutoSize = true;
            this.check_QuitarAlConcluir.BackColor = System.Drawing.Color.Transparent;
            this.check_QuitarAlConcluir.Enabled = false;
            this.check_QuitarAlConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_QuitarAlConcluir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_QuitarAlConcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_QuitarAlConcluir.Location = new System.Drawing.Point(18, 534);
            this.check_QuitarAlConcluir.Name = "check_QuitarAlConcluir";
            this.check_QuitarAlConcluir.Size = new System.Drawing.Size(160, 25);
            this.check_QuitarAlConcluir.TabIndex = 55;
            this.check_QuitarAlConcluir.Text = "Quitar al Concluir";
            this.check_QuitarAlConcluir.UseVisualStyleBackColor = false;
            // 
            // Talonario_Planificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 625);
            this.Controls.Add(this.check_QuitarAlConcluir);
            this.Controls.Add(this.check_Categoria);
            this.Controls.Add(this.check_GenerarRecordatorio);
            this.Controls.Add(this.but_FrecuenciaInicio);
            this.Controls.Add(this.txt_FrecuenciaInicio);
            this.Controls.Add(this.lbl_FrecuenciaInicio);
            this.Controls.Add(this.txt_DescripcionPlanificacion);
            this.Controls.Add(this.lbl_DescripcionPlanificacion);
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
            this.Controls.Add(this.combo_Cuenta);
            this.Controls.Add(this.lbl_Cuenta);
            this.Controls.Add(this.txt_DescripcionTransaccion);
            this.Controls.Add(this.lbl_DescripcionTransaccion);
            this.Controls.Add(this.but_GuardarComoPlantilla);
            this.Controls.Add(this.but_CargarDesdePlantilla);
            this.Name = "Talonario_Planificacion";
            this.Text = "Talonario_Planificaciones";
            this.Shown += new System.EventHandler(this.Talonario_Planificacion_Shown);
            this.Controls.SetChildIndex(this.but_CargarDesdePlantilla, 0);
            this.Controls.SetChildIndex(this.but_GuardarComoPlantilla, 0);
            this.Controls.SetChildIndex(this.lbl_DescripcionTransaccion, 0);
            this.Controls.SetChildIndex(this.txt_DescripcionTransaccion, 0);
            this.Controls.SetChildIndex(this.lbl_Cuenta, 0);
            this.Controls.SetChildIndex(this.combo_Cuenta, 0);
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
            this.Controls.SetChildIndex(this.lbl_DescripcionPlanificacion, 0);
            this.Controls.SetChildIndex(this.txt_DescripcionPlanificacion, 0);
            this.Controls.SetChildIndex(this.lbl_FrecuenciaInicio, 0);
            this.Controls.SetChildIndex(this.txt_FrecuenciaInicio, 0);
            this.Controls.SetChildIndex(this.but_FrecuenciaInicio, 0);
            this.Controls.SetChildIndex(this.check_GenerarRecordatorio, 0);
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.check_Categoria, 0);
            this.Controls.SetChildIndex(this.check_QuitarAlConcluir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Etiquetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private Controls.ComboBoxs.DefaultComboBox combo_Cuenta;
        private Controls.Labels.DarkLabel lbl_Cuenta;
        private Controls.TextBoxs.DefaultTextBox txt_DescripcionTransaccion;
        private Controls.Labels.DarkLabel lbl_DescripcionTransaccion;
        private Controls.Buttons.DarkButton but_GuardarComoPlantilla;
        private Controls.Buttons.DarkButton but_CargarDesdePlantilla;
        private Controls.TextBoxs.DefaultTextBox txt_DescripcionPlanificacion;
        private Controls.Labels.DarkLabel lbl_DescripcionPlanificacion;
        private Controls.Buttons.DarkButton but_FrecuenciaInicio;
        private Controls.TextBoxs.DefaultTextBox txt_FrecuenciaInicio;
        private Controls.Labels.DarkLabel lbl_FrecuenciaInicio;
        private Controls.Labels.DarkCheckbox check_GenerarRecordatorio;
        private Controls.TextBoxs.NumericBox txt_Monto;
        private Controls.Labels.DarkCheckbox check_Categoria;
        private Controls.Labels.DarkCheckbox check_QuitarAlConcluir;
    }
}