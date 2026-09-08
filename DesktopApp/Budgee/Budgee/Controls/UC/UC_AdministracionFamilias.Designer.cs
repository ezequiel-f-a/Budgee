
namespace UI.Controls.UC
{
    partial class UC_AdministracionFamilias
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
            this.lbox_Poseedor = new System.Windows.Forms.ListBox();
            this.lbox_Componentes = new System.Windows.Forms.ListBox();
            this.flow_Organizar = new System.Windows.Forms.TableLayoutPanel();
            this.but_Buscar = new UI.Controls.Buttons.DarkButton();
            this.lbl_Nombre = new UI.Controls.Labels.DarkLabel();
            this.txt_Nombre = new UI.Controls.TextBoxs.DefaultTextBox();
            this.but_ModificarPoseedor = new UI.Controls.Buttons.DarkButton();
            this.but_EliminarPoseedor = new UI.Controls.Buttons.DarkButton();
            this.but_EliminarComponente = new UI.Controls.Buttons.DarkButton();
            this.but_AgregarPoseedor = new UI.Controls.Buttons.DarkButton();
            this.but_AgregarFamilia = new UI.Controls.Buttons.DarkButton();
            this.but_AgregarPatente = new UI.Controls.Buttons.DarkButton();
            this.lbl_Poseedor = new UI.Controls.Labels.DarkLabel();
            this.lbl_Componentes = new UI.Controls.Labels.DarkLabel();
            this.flow_Organizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbox_Poseedor
            // 
            this.lbox_Poseedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbox_Poseedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_Poseedor.FormattingEnabled = true;
            this.lbox_Poseedor.ItemHeight = 20;
            this.lbox_Poseedor.Location = new System.Drawing.Point(10, 120);
            this.lbox_Poseedor.Margin = new System.Windows.Forms.Padding(10);
            this.lbox_Poseedor.Name = "lbox_Poseedor";
            this.lbox_Poseedor.Size = new System.Drawing.Size(298, 204);
            this.lbox_Poseedor.TabIndex = 0;
            this.lbox_Poseedor.SelectedIndexChanged += new System.EventHandler(this.lbox_Poseedor_SelectedIndexChanged);
            // 
            // lbox_Componentes
            // 
            this.lbox_Componentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbox_Componentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_Componentes.FormattingEnabled = true;
            this.lbox_Componentes.ItemHeight = 20;
            this.lbox_Componentes.Location = new System.Drawing.Point(328, 120);
            this.lbox_Componentes.Margin = new System.Windows.Forms.Padding(10);
            this.lbox_Componentes.Name = "lbox_Componentes";
            this.lbox_Componentes.Size = new System.Drawing.Size(298, 204);
            this.lbox_Componentes.TabIndex = 1;
            // 
            // flow_Organizar
            // 
            this.flow_Organizar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_Organizar.ColumnCount = 2;
            this.flow_Organizar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flow_Organizar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flow_Organizar.Controls.Add(this.but_Buscar, 1, 1);
            this.flow_Organizar.Controls.Add(this.lbl_Nombre, 0, 0);
            this.flow_Organizar.Controls.Add(this.txt_Nombre, 0, 1);
            this.flow_Organizar.Controls.Add(this.but_ModificarPoseedor, 0, 6);
            this.flow_Organizar.Controls.Add(this.but_EliminarPoseedor, 0, 5);
            this.flow_Organizar.Controls.Add(this.but_EliminarComponente, 1, 6);
            this.flow_Organizar.Controls.Add(this.but_AgregarPoseedor, 0, 4);
            this.flow_Organizar.Controls.Add(this.but_AgregarFamilia, 1, 4);
            this.flow_Organizar.Controls.Add(this.but_AgregarPatente, 1, 5);
            this.flow_Organizar.Controls.Add(this.lbox_Poseedor, 0, 3);
            this.flow_Organizar.Controls.Add(this.lbox_Componentes, 1, 3);
            this.flow_Organizar.Controls.Add(this.lbl_Poseedor, 0, 2);
            this.flow_Organizar.Controls.Add(this.lbl_Componentes, 1, 2);
            this.flow_Organizar.Location = new System.Drawing.Point(12, 12);
            this.flow_Organizar.Name = "flow_Organizar";
            this.flow_Organizar.RowCount = 7;
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.flow_Organizar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.flow_Organizar.Size = new System.Drawing.Size(636, 484);
            this.flow_Organizar.TabIndex = 4;
            // 
            // but_Buscar
            // 
            this.but_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.but_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_Buscar.FlatAppearance.BorderSize = 0;
            this.but_Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Buscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_Buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_Buscar.Location = new System.Drawing.Point(330, 38);
            this.but_Buscar.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_Buscar.Name = "but_Buscar";
            this.but_Buscar.Size = new System.Drawing.Size(122, 34);
            this.but_Buscar.TabIndex = 6;
            this.but_Buscar.Text = "Buscar";
            this.but_Buscar.UseVisualStyleBackColor = false;
            this.but_Buscar.Click += new System.EventHandler(this.but_Buscar_Click);
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_Nombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Nombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Nombre.Location = new System.Drawing.Point(38, 3);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(242, 27);
            this.lbl_Nombre.TabIndex = 2;
            this.lbl_Nombre.Text = "Nombre:";
            this.lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Nombre.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nombre.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Nombre.Location = new System.Drawing.Point(12, 42);
            this.txt_Nombre.Margin = new System.Windows.Forms.Padding(12);
            this.txt_Nombre.MaxLength = 50;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(294, 29);
            this.txt_Nombre.TabIndex = 3;
            // 
            // but_ModificarPoseedor
            // 
            this.but_ModificarPoseedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_ModificarPoseedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_ModificarPoseedor.FlatAppearance.BorderSize = 0;
            this.but_ModificarPoseedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_ModificarPoseedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_ModificarPoseedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ModificarPoseedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_ModificarPoseedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_ModificarPoseedor.Location = new System.Drawing.Point(12, 442);
            this.but_ModificarPoseedor.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_ModificarPoseedor.Name = "but_ModificarPoseedor";
            this.but_ModificarPoseedor.Size = new System.Drawing.Size(294, 34);
            this.but_ModificarPoseedor.TabIndex = 11;
            this.but_ModificarPoseedor.Text = "Modificar";
            this.but_ModificarPoseedor.UseVisualStyleBackColor = false;
            this.but_ModificarPoseedor.Click += new System.EventHandler(this.but_ModificarPoseedor_Click);
            // 
            // but_EliminarPoseedor
            // 
            this.but_EliminarPoseedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_EliminarPoseedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_EliminarPoseedor.FlatAppearance.BorderSize = 0;
            this.but_EliminarPoseedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_EliminarPoseedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_EliminarPoseedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_EliminarPoseedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_EliminarPoseedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_EliminarPoseedor.Location = new System.Drawing.Point(12, 392);
            this.but_EliminarPoseedor.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_EliminarPoseedor.Name = "but_EliminarPoseedor";
            this.but_EliminarPoseedor.Size = new System.Drawing.Size(294, 34);
            this.but_EliminarPoseedor.TabIndex = 9;
            this.but_EliminarPoseedor.Text = "Eliminar";
            this.but_EliminarPoseedor.UseVisualStyleBackColor = false;
            this.but_EliminarPoseedor.Click += new System.EventHandler(this.but_EliminarPoseedor_Click);
            // 
            // but_EliminarComponente
            // 
            this.but_EliminarComponente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_EliminarComponente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_EliminarComponente.FlatAppearance.BorderSize = 0;
            this.but_EliminarComponente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_EliminarComponente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_EliminarComponente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_EliminarComponente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_EliminarComponente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_EliminarComponente.Location = new System.Drawing.Point(330, 442);
            this.but_EliminarComponente.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_EliminarComponente.Name = "but_EliminarComponente";
            this.but_EliminarComponente.Size = new System.Drawing.Size(294, 34);
            this.but_EliminarComponente.TabIndex = 10;
            this.but_EliminarComponente.Text = "Eliminar";
            this.but_EliminarComponente.UseVisualStyleBackColor = false;
            this.but_EliminarComponente.Click += new System.EventHandler(this.but_EliminarComponente_Click);
            // 
            // but_AgregarPoseedor
            // 
            this.but_AgregarPoseedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_AgregarPoseedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_AgregarPoseedor.FlatAppearance.BorderSize = 0;
            this.but_AgregarPoseedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_AgregarPoseedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_AgregarPoseedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_AgregarPoseedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_AgregarPoseedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_AgregarPoseedor.Location = new System.Drawing.Point(12, 342);
            this.but_AgregarPoseedor.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_AgregarPoseedor.Name = "but_AgregarPoseedor";
            this.but_AgregarPoseedor.Size = new System.Drawing.Size(294, 34);
            this.but_AgregarPoseedor.TabIndex = 4;
            this.but_AgregarPoseedor.Text = "Agregar";
            this.but_AgregarPoseedor.UseVisualStyleBackColor = false;
            this.but_AgregarPoseedor.Click += new System.EventHandler(this.but_AgregarPoseedor_Click);
            // 
            // but_AgregarFamilia
            // 
            this.but_AgregarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_AgregarFamilia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_AgregarFamilia.FlatAppearance.BorderSize = 0;
            this.but_AgregarFamilia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_AgregarFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_AgregarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_AgregarFamilia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_AgregarFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_AgregarFamilia.Location = new System.Drawing.Point(330, 342);
            this.but_AgregarFamilia.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_AgregarFamilia.Name = "but_AgregarFamilia";
            this.but_AgregarFamilia.Size = new System.Drawing.Size(294, 34);
            this.but_AgregarFamilia.TabIndex = 8;
            this.but_AgregarFamilia.Text = "Agregar Perfil";
            this.but_AgregarFamilia.UseVisualStyleBackColor = false;
            this.but_AgregarFamilia.Click += new System.EventHandler(this.but_AgregarFamilia_Click);
            // 
            // but_AgregarPatente
            // 
            this.but_AgregarPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_AgregarPatente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_AgregarPatente.FlatAppearance.BorderSize = 0;
            this.but_AgregarPatente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_AgregarPatente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_AgregarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_AgregarPatente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_AgregarPatente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_AgregarPatente.Location = new System.Drawing.Point(330, 392);
            this.but_AgregarPatente.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.but_AgregarPatente.Name = "but_AgregarPatente";
            this.but_AgregarPatente.Size = new System.Drawing.Size(294, 34);
            this.but_AgregarPatente.TabIndex = 8;
            this.but_AgregarPatente.Text = "Agregar Permiso";
            this.but_AgregarPatente.UseVisualStyleBackColor = false;
            this.but_AgregarPatente.Click += new System.EventHandler(this.but_AgregarPatente_Click);
            // 
            // lbl_Poseedor
            // 
            this.lbl_Poseedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Poseedor.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Poseedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Poseedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Poseedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Poseedor.Location = new System.Drawing.Point(3, 83);
            this.lbl_Poseedor.Name = "lbl_Poseedor";
            this.lbl_Poseedor.Size = new System.Drawing.Size(312, 27);
            this.lbl_Poseedor.TabIndex = 12;
            this.lbl_Poseedor.Text = "Perfiles:";
            this.lbl_Poseedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Componentes
            // 
            this.lbl_Componentes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Componentes.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Componentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Componentes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Componentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Componentes.Location = new System.Drawing.Point(321, 83);
            this.lbl_Componentes.Name = "lbl_Componentes";
            this.lbl_Componentes.Size = new System.Drawing.Size(312, 27);
            this.lbl_Componentes.TabIndex = 13;
            this.lbl_Componentes.Text = "Perfiles o Permisos Relacionados:";
            this.lbl_Componentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_AdministracionFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flow_Organizar);
            this.Name = "UC_AdministracionFamilias";
            this.Size = new System.Drawing.Size(660, 508);
            this.Load += new System.EventHandler(this.UC_AdministracionFamilias_Load);
            this.flow_Organizar.ResumeLayout(false);
            this.flow_Organizar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel flow_Organizar;
        protected Controls.Buttons.DarkButton but_ModificarPoseedor;
        protected Controls.Buttons.DarkButton but_EliminarComponente;
        protected Controls.Buttons.DarkButton but_EliminarPoseedor;
        protected Controls.Buttons.DarkButton but_AgregarFamilia;
        protected Controls.Buttons.DarkButton but_AgregarPatente;
        protected Controls.Buttons.DarkButton but_Buscar;
        protected Controls.Buttons.DarkButton but_AgregarPoseedor;
        protected System.Windows.Forms.ListBox lbox_Poseedor;
        protected System.Windows.Forms.ListBox lbox_Componentes;
        protected Controls.Labels.DarkLabel lbl_Nombre;
        protected Controls.TextBoxs.DefaultTextBox txt_Nombre;
        protected Controls.Labels.DarkLabel lbl_Poseedor;
        protected Controls.Labels.DarkLabel lbl_Componentes;
    }
}