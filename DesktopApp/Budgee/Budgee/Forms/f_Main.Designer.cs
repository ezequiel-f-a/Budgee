
using System.Windows.Forms;

namespace UI.Forms
{
    partial class f_Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Main));
            this.But_Notificaciones = new System.Windows.Forms.Button();
            this.strip_Main = new System.Windows.Forms.MenuStrip();
            this.stripBut1_Usuario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut1_Sesion = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_Configuracion = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_CerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut1_Datos = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_ExportarRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_RestaurarDesdeRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut1_Idioma = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_Español = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_English = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut1_Administrador = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_AdministrarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_AdministrarPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_RestablecerIdiomas = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut1_Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_ManualAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBut2_AcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Logo = new System.Windows.Forms.Label();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.strip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // But_Notificaciones
            // 
            this.But_Notificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.But_Notificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(125)))), ((int)(((byte)(28)))));
            this.But_Notificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.But_Notificaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.But_Notificaciones.Location = new System.Drawing.Point(1090, 0);
            this.But_Notificaciones.Name = "But_Notificaciones";
            this.But_Notificaciones.Size = new System.Drawing.Size(172, 40);
            this.But_Notificaciones.TabIndex = 2;
            this.But_Notificaciones.Text = "Notificaciones (0)";
            this.But_Notificaciones.UseVisualStyleBackColor = false;
            this.But_Notificaciones.Click += new System.EventHandler(this.But_Notificaciones_Click);
            // 
            // strip_Main
            // 
            this.strip_Main.AutoSize = false;
            this.strip_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(96)))), ((int)(((byte)(21)))));
            this.strip_Main.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBut1_Usuario,
            this.toolStripMenuItem1,
            this.stripBut1_Sesion,
            this.stripBut1_Datos,
            this.stripBut1_Idioma,
            this.stripBut1_Administrador,
            this.stripBut1_Ayuda});
            this.strip_Main.Location = new System.Drawing.Point(0, 0);
            this.strip_Main.Name = "strip_Main";
            this.strip_Main.Size = new System.Drawing.Size(1262, 40);
            this.strip_Main.TabIndex = 3;
            this.strip_Main.Text = "menuStrip1";
            // 
            // stripBut1_Usuario
            // 
            this.stripBut1_Usuario.AutoSize = false;
            this.stripBut1_Usuario.Name = "stripBut1_Usuario";
            this.stripBut1_Usuario.Size = new System.Drawing.Size(169, 36);
            this.stripBut1_Usuario.Text = "...";
            this.stripBut1_Usuario.Click += new System.EventHandler(this.stripBut1_Usuario_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 36);
            this.toolStripMenuItem1.Text = "||";
            // 
            // stripBut1_Sesion
            // 
            this.stripBut1_Sesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBut2_Configuracion,
            this.stripBut2_CerrarSesion,
            this.stripBut2_Salir});
            this.stripBut1_Sesion.Name = "stripBut1_Sesion";
            this.stripBut1_Sesion.Size = new System.Drawing.Size(68, 36);
            this.stripBut1_Sesion.Text = "Sesión";
            // 
            // stripBut2_Configuracion
            // 
            this.stripBut2_Configuracion.Name = "stripBut2_Configuracion";
            this.stripBut2_Configuracion.Size = new System.Drawing.Size(223, 26);
            this.stripBut2_Configuracion.Text = "Configuración";
            this.stripBut2_Configuracion.Click += new System.EventHandler(this.stripBut2_Configuracion_Click);
            // 
            // stripBut2_CerrarSesion
            // 
            this.stripBut2_CerrarSesion.Name = "stripBut2_CerrarSesion";
            this.stripBut2_CerrarSesion.Size = new System.Drawing.Size(223, 26);
            this.stripBut2_CerrarSesion.Text = "Cerrar Sesión";
            this.stripBut2_CerrarSesion.Click += new System.EventHandler(this.stripBut2_CerrarSesion_Click);
            // 
            // stripBut2_Salir
            // 
            this.stripBut2_Salir.Name = "stripBut2_Salir";
            this.stripBut2_Salir.Size = new System.Drawing.Size(223, 26);
            this.stripBut2_Salir.Text = "Salir de la Aplicación";
            this.stripBut2_Salir.Click += new System.EventHandler(this.stripBut2_Salir_Click);
            // 
            // stripBut1_Datos
            // 
            this.stripBut1_Datos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBut2_ExportarRespaldo,
            this.stripBut2_RestaurarDesdeRespaldo});
            this.stripBut1_Datos.Name = "stripBut1_Datos";
            this.stripBut1_Datos.Size = new System.Drawing.Size(62, 36);
            this.stripBut1_Datos.Text = "Datos";
            // 
            // stripBut2_ExportarRespaldo
            // 
            this.stripBut2_ExportarRespaldo.Name = "stripBut2_ExportarRespaldo";
            this.stripBut2_ExportarRespaldo.Size = new System.Drawing.Size(271, 26);
            this.stripBut2_ExportarRespaldo.Text = "Exportar Respaldo";
            this.stripBut2_ExportarRespaldo.Click += new System.EventHandler(this.stripBut2_ExportarRespaldo_Click);
            // 
            // stripBut2_RestaurarDesdeRespaldo
            // 
            this.stripBut2_RestaurarDesdeRespaldo.Name = "stripBut2_RestaurarDesdeRespaldo";
            this.stripBut2_RestaurarDesdeRespaldo.Size = new System.Drawing.Size(271, 26);
            this.stripBut2_RestaurarDesdeRespaldo.Text = "Restaurar Desde Respaldo...";
            this.stripBut2_RestaurarDesdeRespaldo.Click += new System.EventHandler(this.stripBut2_RestaurarDesdeRespaldo_Click);
            // 
            // stripBut1_Idioma
            // 
            this.stripBut1_Idioma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBut2_Español,
            this.stripBut2_English});
            this.stripBut1_Idioma.Name = "stripBut1_Idioma";
            this.stripBut1_Idioma.Size = new System.Drawing.Size(70, 36);
            this.stripBut1_Idioma.Text = "Idioma";
            // 
            // stripBut2_Español
            // 
            this.stripBut2_Español.Checked = true;
            this.stripBut2_Español.CheckOnClick = true;
            this.stripBut2_Español.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stripBut2_Español.Name = "stripBut2_Español";
            this.stripBut2_Español.Size = new System.Drawing.Size(134, 26);
            this.stripBut2_Español.Text = "Español";
            this.stripBut2_Español.Click += new System.EventHandler(this.stripBut2_Español_Click);
            // 
            // stripBut2_English
            // 
            this.stripBut2_English.CheckOnClick = true;
            this.stripBut2_English.Name = "stripBut2_English";
            this.stripBut2_English.Size = new System.Drawing.Size(134, 26);
            this.stripBut2_English.Text = "English";
            this.stripBut2_English.Click += new System.EventHandler(this.stripBut2_English_Click);
            // 
            // stripBut1_Administrador
            // 
            this.stripBut1_Administrador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBut2_AdministrarUsuarios,
            this.stripBut2_AdministrarPerfiles,
            this.stripBut2_RestablecerIdiomas});
            this.stripBut1_Administrador.Name = "stripBut1_Administrador";
            this.stripBut1_Administrador.Size = new System.Drawing.Size(122, 36);
            this.stripBut1_Administrador.Text = "Administrador";
            // 
            // stripBut2_AdministrarUsuarios
            // 
            this.stripBut2_AdministrarUsuarios.Name = "stripBut2_AdministrarUsuarios";
            this.stripBut2_AdministrarUsuarios.Size = new System.Drawing.Size(236, 26);
            this.stripBut2_AdministrarUsuarios.Text = "Administrar Usuarios...";
            this.stripBut2_AdministrarUsuarios.Click += new System.EventHandler(this.stripBut2_AdministrarUsuarios_Click);
            // 
            // stripBut2_AdministrarPerfiles
            // 
            this.stripBut2_AdministrarPerfiles.Name = "stripBut2_AdministrarPerfiles";
            this.stripBut2_AdministrarPerfiles.Size = new System.Drawing.Size(236, 26);
            this.stripBut2_AdministrarPerfiles.Text = "Administrar Perfiles...";
            this.stripBut2_AdministrarPerfiles.Click += new System.EventHandler(this.stripBut2_AdministrarPerfilesPermisos_Click);
            // 
            // stripBut2_RestablecerIdiomas
            // 
            this.stripBut2_RestablecerIdiomas.Name = "stripBut2_RestablecerIdiomas";
            this.stripBut2_RestablecerIdiomas.Size = new System.Drawing.Size(236, 26);
            this.stripBut2_RestablecerIdiomas.Text = "Restablecer Idiomas";
            this.stripBut2_RestablecerIdiomas.Click += new System.EventHandler(this.stripBut2_RestablecerIdiomas_Click);
            // 
            // stripBut1_Ayuda
            // 
            this.stripBut1_Ayuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBut2_ManualAyuda,
            this.stripBut2_AcercaDe});
            this.stripBut1_Ayuda.Name = "stripBut1_Ayuda";
            this.stripBut1_Ayuda.Size = new System.Drawing.Size(66, 36);
            this.stripBut1_Ayuda.Text = "Ayuda";
            // 
            // stripBut2_ManualAyuda
            // 
            this.stripBut2_ManualAyuda.Name = "stripBut2_ManualAyuda";
            this.stripBut2_ManualAyuda.Size = new System.Drawing.Size(232, 26);
            this.stripBut2_ManualAyuda.Text = "Manual de Ayuda [F1]";
            this.stripBut2_ManualAyuda.Click += new System.EventHandler(this.stripBut2_ManualAyuda_Click);
            // 
            // stripBut2_AcercaDe
            // 
            this.stripBut2_AcercaDe.Name = "stripBut2_AcercaDe";
            this.stripBut2_AcercaDe.Size = new System.Drawing.Size(232, 26);
            this.stripBut2_AcercaDe.Text = "Acerca de Budgee...";
            this.stripBut2_AcercaDe.Click += new System.EventHandler(this.stripBut2_AcercaDe_Click);
            // 
            // lbl_Logo
            // 
            this.lbl_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Logo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Logo.Font = new System.Drawing.Font("Segoe Print", 54.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Logo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(114)))), ((int)(((byte)(88)))));
            this.lbl_Logo.Location = new System.Drawing.Point(288, 584);
            this.lbl_Logo.Name = "lbl_Logo";
            this.lbl_Logo.Size = new System.Drawing.Size(448, 136);
            this.lbl_Logo.TabIndex = 5;
            this.lbl_Logo.Text = "Budgee";
            // 
            // pic_Logo
            // 
            this.pic_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_Logo.Image = global::UI.Properties.Resources.piggy_bg_2;
            this.pic_Logo.Location = new System.Drawing.Point(736, 228);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(500, 500);
            this.pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Logo.TabIndex = 4;
            this.pic_Logo.TabStop = false;
            // 
            // f_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1262, 729);
            this.Controls.Add(this.But_Notificaciones);
            this.Controls.Add(this.strip_Main);
            this.Controls.Add(this.pic_Logo);
            this.Controls.Add(this.lbl_Logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.strip_Main;
            this.Name = "f_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budgee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f_Main_FormClosed);
            this.Load += new System.EventHandler(this.f_Main_Load);
            this.ResizeEnd += new System.EventHandler(this.f_Main_ResizeEnd);
            this.VisibleChanged += new System.EventHandler(this.f_Main_VisibleChanged);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.f_Main_ControlRemoved);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.f_Main_HelpRequested);
            this.strip_Main.ResumeLayout(false);
            this.strip_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button But_Notificaciones;
        private System.Windows.Forms.MenuStrip strip_Main;
        private System.Windows.Forms.ToolStripMenuItem stripBut1_Sesion;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_Configuracion;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_CerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_Salir;
        private System.Windows.Forms.ToolStripMenuItem stripBut1_Datos;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_ExportarRespaldo;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_RestaurarDesdeRespaldo;
        private System.Windows.Forms.ToolStripMenuItem stripBut1_Idioma;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_Español;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_English;
        private System.Windows.Forms.ToolStripMenuItem stripBut1_Administrador;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_AdministrarPerfiles;
        private System.Windows.Forms.ToolStripMenuItem stripBut1_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem stripBut2_ManualAyuda;
        private System.Windows.Forms.Label lbl_Logo;
        private System.Windows.Forms.PictureBox pic_Logo;
        private ToolStripMenuItem stripBut2_AdministrarUsuarios;
        private ToolStripMenuItem stripBut2_AcercaDe;
        private ToolStripMenuItem stripBut1_Usuario;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem stripBut2_RestablecerIdiomas;
    }
}

