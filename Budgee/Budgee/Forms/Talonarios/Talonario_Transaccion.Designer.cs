
using System;

namespace UI.Forms.Talonarios
{
    partial class Talonario_Transaccion
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
            this.but_CargarDesdePlantilla = new UI.Controls.Buttons.DarkButton();
            this.lbl_Descripcion = new UI.Controls.Labels.DarkLabel();
            this.txt_Descripcion = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Cuenta = new UI.Controls.Labels.DarkLabel();
            this.combo_Categoria = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Categoria = new UI.Controls.Labels.DarkLabel();
            this.combo_Cuenta = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.but_GuardarComoPlantilla = new UI.Controls.Buttons.DarkButton();
            this.combo_TipoOperacion = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_TipoOperacion = new UI.Controls.Labels.DarkLabel();
            this.lbl_Monto = new UI.Controls.Labels.DarkLabel();
            this.but_AgregarEtiqueta = new UI.Controls.Buttons.DarkButton();
            this.but_RemoverEtiqueta = new UI.Controls.Buttons.DarkButton();
            this.lbl_Etiquetas = new UI.Controls.Labels.DarkLabel();
            this.grid_Etiquetas = new UI.Controls.Grids.DefaultDataGridView();
            this.but_Monto = new UI.Controls.Buttons.DarkButton();
            this.date_FechaTransaccion = new System.Windows.Forms.DateTimePicker();
            this.lbl_FechaTransaccion = new UI.Controls.Labels.DarkLabel();
            this.check_Concretada = new UI.Controls.Labels.DarkCheckbox();
            this.txt_Monto = new UI.Controls.TextBoxs.NumericBox();
            this.check_Fecha = new UI.Controls.Labels.DarkCheckbox();
            this.check_Categoria = new UI.Controls.Labels.DarkCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Etiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(157, 487);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(298, 487);
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
            this.but_CargarDesdePlantilla.Location = new System.Drawing.Point(19, 19);
            this.but_CargarDesdePlantilla.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_CargarDesdePlantilla.Name = "but_CargarDesdePlantilla";
            this.but_CargarDesdePlantilla.Size = new System.Drawing.Size(259, 37);
            this.but_CargarDesdePlantilla.TabIndex = 2;
            this.but_CargarDesdePlantilla.Text = "Cargar desde Plantilla...";
            this.but_CargarDesdePlantilla.UseVisualStyleBackColor = false;
            this.but_CargarDesdePlantilla.Click += new System.EventHandler(this.but_CargarDesdePlantilla_Click);
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Descripcion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Descripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Descripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Descripcion.Location = new System.Drawing.Point(117, 73);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(342, 29);
            this.lbl_Descripcion.TabIndex = 4;
            this.lbl_Descripcion.Text = "Descripción:";
            this.lbl_Descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Descripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Descripcion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Descripcion.Location = new System.Drawing.Point(117, 105);
            this.txt_Descripcion.MaxLength = 150;
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(342, 29);
            this.txt_Descripcion.TabIndex = 5;
            // 
            // lbl_Cuenta
            // 
            this.lbl_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Cuenta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Cuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Cuenta.Location = new System.Drawing.Point(19, 144);
            this.lbl_Cuenta.Name = "lbl_Cuenta";
            this.lbl_Cuenta.Size = new System.Drawing.Size(259, 29);
            this.lbl_Cuenta.TabIndex = 6;
            this.lbl_Cuenta.Text = "Cuenta:";
            this.lbl_Cuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Categoria
            // 
            this.combo_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Categoria.FormattingEnabled = true;
            this.combo_Categoria.Location = new System.Drawing.Point(298, 176);
            this.combo_Categoria.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Categoria.Name = "combo_Categoria";
            this.combo_Categoria.Size = new System.Drawing.Size(260, 29);
            this.combo_Categoria.TabIndex = 9;
            this.combo_Categoria.DropDown += new System.EventHandler(this.Combo_Categoria_DropDown);
            // 
            // lbl_Categoria
            // 
            this.lbl_Categoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Categoria.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Categoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Categoria.Location = new System.Drawing.Point(298, 144);
            this.lbl_Categoria.Name = "lbl_Categoria";
            this.lbl_Categoria.Size = new System.Drawing.Size(260, 30);
            this.lbl_Categoria.TabIndex = 8;
            this.lbl_Categoria.Text = "Categoría:";
            this.lbl_Categoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Cuenta
            // 
            this.combo_Cuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_Cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Cuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Cuenta.FormattingEnabled = true;
            this.combo_Cuenta.Location = new System.Drawing.Point(19, 176);
            this.combo_Cuenta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_Cuenta.Name = "combo_Cuenta";
            this.combo_Cuenta.Size = new System.Drawing.Size(259, 29);
            this.combo_Cuenta.TabIndex = 7;
            this.combo_Cuenta.DropDown += new System.EventHandler(this.Combo_Cuenta_DropDown);
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
            this.but_GuardarComoPlantilla.TabIndex = 3;
            this.but_GuardarComoPlantilla.Text = "Guardar como Plantilla...";
            this.but_GuardarComoPlantilla.UseVisualStyleBackColor = false;
            this.but_GuardarComoPlantilla.Click += new System.EventHandler(this.but_GuardarComoPlantilla_Click);
            // 
            // combo_TipoOperacion
            // 
            this.combo_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.combo_TipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_TipoOperacion.FormattingEnabled = true;
            this.combo_TipoOperacion.Location = new System.Drawing.Point(19, 248);
            this.combo_TipoOperacion.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_TipoOperacion.Name = "combo_TipoOperacion";
            this.combo_TipoOperacion.Size = new System.Drawing.Size(259, 29);
            this.combo_TipoOperacion.TabIndex = 11;
            // 
            // lbl_TipoOperacion
            // 
            this.lbl_TipoOperacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_TipoOperacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TipoOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_TipoOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_TipoOperacion.Location = new System.Drawing.Point(19, 216);
            this.lbl_TipoOperacion.Name = "lbl_TipoOperacion";
            this.lbl_TipoOperacion.Size = new System.Drawing.Size(259, 29);
            this.lbl_TipoOperacion.TabIndex = 10;
            this.lbl_TipoOperacion.Text = "Tipo Operación:";
            this.lbl_TipoOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Monto
            // 
            this.lbl_Monto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Monto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Monto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Monto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Monto.Location = new System.Drawing.Point(19, 287);
            this.lbl_Monto.Name = "lbl_Monto";
            this.lbl_Monto.Size = new System.Drawing.Size(259, 29);
            this.lbl_Monto.TabIndex = 14;
            this.lbl_Monto.Text = "Monto:";
            this.lbl_Monto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.but_AgregarEtiqueta.Location = new System.Drawing.Point(298, 390);
            this.but_AgregarEtiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_AgregarEtiqueta.Name = "but_AgregarEtiqueta";
            this.but_AgregarEtiqueta.Size = new System.Drawing.Size(124, 29);
            this.but_AgregarEtiqueta.TabIndex = 16;
            this.but_AgregarEtiqueta.Text = "Agregar";
            this.but_AgregarEtiqueta.UseVisualStyleBackColor = false;
            this.but_AgregarEtiqueta.Click += new System.EventHandler(this.but_AgregarEtiqueta_Click);
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
            this.but_RemoverEtiqueta.Location = new System.Drawing.Point(434, 390);
            this.but_RemoverEtiqueta.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_RemoverEtiqueta.Name = "but_RemoverEtiqueta";
            this.but_RemoverEtiqueta.Size = new System.Drawing.Size(124, 29);
            this.but_RemoverEtiqueta.TabIndex = 17;
            this.but_RemoverEtiqueta.Text = "Remover";
            this.but_RemoverEtiqueta.UseVisualStyleBackColor = false;
            this.but_RemoverEtiqueta.Click += new System.EventHandler(this.but_RemoverEtiqueta_Click);
            // 
            // lbl_Etiquetas
            // 
            this.lbl_Etiquetas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Etiquetas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Etiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Etiquetas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Etiquetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Etiquetas.Location = new System.Drawing.Point(298, 216);
            this.lbl_Etiquetas.Name = "lbl_Etiquetas";
            this.lbl_Etiquetas.Size = new System.Drawing.Size(260, 30);
            this.lbl_Etiquetas.TabIndex = 18;
            this.lbl_Etiquetas.Text = "Etiquetas:";
            this.lbl_Etiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.grid_Etiquetas.Location = new System.Drawing.Point(298, 248);
            this.grid_Etiquetas.MultiSelect = false;
            this.grid_Etiquetas.Name = "grid_Etiquetas";
            this.grid_Etiquetas.ReadOnly = true;
            this.grid_Etiquetas.RowHeadersVisible = false;
            this.grid_Etiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Etiquetas.Size = new System.Drawing.Size(260, 129);
            this.grid_Etiquetas.TabIndex = 19;
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
            this.but_Monto.Location = new System.Drawing.Point(246, 319);
            this.but_Monto.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_Monto.Name = "but_Monto";
            this.but_Monto.Size = new System.Drawing.Size(32, 29);
            this.but_Monto.TabIndex = 21;
            this.but_Monto.Text = "...";
            this.but_Monto.UseVisualStyleBackColor = false;
            this.but_Monto.Click += new System.EventHandler(this.but_Monto_Click);
            // 
            // date_FechaTransaccion
            // 
            this.date_FechaTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.date_FechaTransaccion.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.date_FechaTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_FechaTransaccion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_FechaTransaccion.Location = new System.Drawing.Point(19, 392);
            this.date_FechaTransaccion.Name = "date_FechaTransaccion";
            this.date_FechaTransaccion.Size = new System.Drawing.Size(259, 26);
            this.date_FechaTransaccion.TabIndex = 22;
            this.date_FechaTransaccion.ValueChanged += new System.EventHandler(this.date_FechaTransaccion_ValueChanged);
            // 
            // lbl_FechaTransaccion
            // 
            this.lbl_FechaTransaccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_FechaTransaccion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FechaTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FechaTransaccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FechaTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FechaTransaccion.Location = new System.Drawing.Point(19, 360);
            this.lbl_FechaTransaccion.Name = "lbl_FechaTransaccion";
            this.lbl_FechaTransaccion.Size = new System.Drawing.Size(259, 29);
            this.lbl_FechaTransaccion.TabIndex = 23;
            this.lbl_FechaTransaccion.Text = "Fecha Transacción:";
            this.lbl_FechaTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_Concretada
            // 
            this.check_Concretada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Concretada.AutoSize = true;
            this.check_Concretada.BackColor = System.Drawing.Color.Transparent;
            this.check_Concretada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Concretada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Concretada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Concretada.Location = new System.Drawing.Point(19, 439);
            this.check_Concretada.Name = "check_Concretada";
            this.check_Concretada.Size = new System.Drawing.Size(207, 25);
            this.check_Concretada.TabIndex = 51;
            this.check_Concretada.Text = "Transacción Concretada";
            this.check_Concretada.UseVisualStyleBackColor = false;
            this.check_Concretada.CheckedChanged += new System.EventHandler(this.check_Concretada_CheckedChanged);
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
            this.txt_Monto.Location = new System.Drawing.Point(19, 319);
            this.txt_Monto.MaxLength = 10;
            this.txt_Monto.Name = "txt_Monto";
            this.txt_Monto.Size = new System.Drawing.Size(227, 29);
            this.txt_Monto.TabIndex = 20;
            // 
            // check_Fecha
            // 
            this.check_Fecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_Fecha.AutoSize = true;
            this.check_Fecha.BackColor = System.Drawing.Color.Transparent;
            this.check_Fecha.Checked = true;
            this.check_Fecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Fecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Fecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.check_Fecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Fecha.Location = new System.Drawing.Point(56, 369);
            this.check_Fecha.Name = "check_Fecha";
            this.check_Fecha.Size = new System.Drawing.Size(12, 11);
            this.check_Fecha.TabIndex = 52;
            this.check_Fecha.UseVisualStyleBackColor = false;
            this.check_Fecha.CheckedChanged += new System.EventHandler(this.check_Fecha_CheckedChanged);
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
            this.check_Categoria.Location = new System.Drawing.Point(367, 154);
            this.check_Categoria.Name = "check_Categoria";
            this.check_Categoria.Size = new System.Drawing.Size(12, 11);
            this.check_Categoria.TabIndex = 53;
            this.check_Categoria.UseVisualStyleBackColor = false;
            this.check_Categoria.CheckedChanged += new System.EventHandler(this.check_Categoria_CheckedChanged);
            // 
            // Talonario_Transaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 541);
            this.Controls.Add(this.check_Categoria);
            this.Controls.Add(this.check_Fecha);
            this.Controls.Add(this.check_Concretada);
            this.Controls.Add(this.lbl_FechaTransaccion);
            this.Controls.Add(this.date_FechaTransaccion);
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
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.lbl_Descripcion);
            this.Controls.Add(this.but_GuardarComoPlantilla);
            this.Controls.Add(this.but_CargarDesdePlantilla);
            this.Name = "Talonario_Transaccion";
            this.Text = "Talonario de Transacciones";
            this.Shown += new System.EventHandler(this.Talonario_Transaccion_Shown);
            this.Controls.SetChildIndex(this.but_CargarDesdePlantilla, 0);
            this.Controls.SetChildIndex(this.but_GuardarComoPlantilla, 0);
            this.Controls.SetChildIndex(this.lbl_Descripcion, 0);
            this.Controls.SetChildIndex(this.txt_Descripcion, 0);
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
            this.Controls.SetChildIndex(this.date_FechaTransaccion, 0);
            this.Controls.SetChildIndex(this.lbl_FechaTransaccion, 0);
            this.Controls.SetChildIndex(this.check_Concretada, 0);
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.Controls.SetChildIndex(this.check_Fecha, 0);
            this.Controls.SetChildIndex(this.check_Categoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Etiquetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private Controls.Buttons.DarkButton but_CargarDesdePlantilla;
        private Controls.Labels.DarkLabel lbl_Descripcion;
        private Controls.TextBoxs.DefaultTextBox txt_Descripcion;
        private Controls.Labels.DarkLabel lbl_Cuenta;
        private Controls.ComboBoxs.DefaultComboBox combo_Categoria;
        private Controls.Labels.DarkLabel lbl_Categoria;
        private Controls.ComboBoxs.DefaultComboBox combo_Cuenta;
        private Controls.Buttons.DarkButton but_GuardarComoPlantilla;
        private Controls.ComboBoxs.DefaultComboBox combo_TipoOperacion;
        private Controls.Labels.DarkLabel lbl_TipoOperacion;
        private Controls.Labels.DarkLabel lbl_Monto;
        private Controls.Buttons.DarkButton but_AgregarEtiqueta;
        private Controls.Buttons.DarkButton but_RemoverEtiqueta;
        private Controls.Labels.DarkLabel lbl_Etiquetas;
        private Controls.Grids.DefaultDataGridView grid_Etiquetas;
        private Controls.Buttons.DarkButton but_Monto;
        private System.Windows.Forms.DateTimePicker date_FechaTransaccion;
        private Controls.Labels.DarkLabel lbl_FechaTransaccion;
        private Controls.Labels.DarkCheckbox check_Concretada;
        private Controls.TextBoxs.NumericBox txt_Monto;
        private Controls.Labels.DarkCheckbox check_Fecha;
        private Controls.Labels.DarkCheckbox check_Categoria;
    }
}