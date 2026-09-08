
namespace UI.Controls.UC
{
    partial class UC_Configuracion
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flow_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.but_CambiarUsername = new UI.Controls.Buttons.DarkButton();
            this.but_BorrarUsuario = new UI.Controls.Buttons.DarkButton();
            this.but_CambiarPassword = new UI.Controls.Buttons.DarkButton();
            this.flow_ComboBoxs = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_DivisaDefault = new UI.Controls.Labels.DarkLabel();
            this.combo_Idioma = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.lbl_Idioma = new UI.Controls.Labels.DarkLabel();
            this.combo_DivisaDefault = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.panel_Notificaciones = new System.Windows.Forms.Panel();
            this.txt_EliminarNotifsValor = new UI.Controls.TextBoxs.IntegerBox();
            this.combo_EliminarNotifsMagnitud = new UI.Controls.ComboBoxs.DefaultComboBox();
            this.check_EliminarNotifs = new UI.Controls.Labels.DarkCheckbox();
            this.check_NotifRecordatorios = new UI.Controls.Labels.DarkCheckbox();
            this.check_NotifPrespuestos = new UI.Controls.Labels.DarkCheckbox();
            this.check_NotifEstadisticas = new UI.Controls.Labels.DarkCheckbox();
            this.check_NotifWindows = new UI.Controls.Labels.DarkCheckbox();
            this.check_AlarmasWindows = new UI.Controls.Labels.DarkCheckbox();
            this.Panel_NotificacionesBorder = new System.Windows.Forms.Panel();
            this.panel_RespaldosBorder = new System.Windows.Forms.Panel();
            this.panel_Respaldos = new System.Windows.Forms.Panel();
            this.lbl_FrecuenciaRespaldar = new UI.Controls.Labels.DarkLabel();
            this.but_FrecuenciaRespaldar = new UI.Controls.Buttons.DarkButton();
            this.txt_CantidadMaximaRespaldos = new UI.Controls.TextBoxs.IntegerBox();
            this.check_CantidadMaximaRespaldos = new UI.Controls.Labels.DarkCheckbox();
            this.check_Respaldar = new UI.Controls.Labels.DarkCheckbox();
            this.check_MantenerSesionIniciada = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_Respaldos = new UI.Controls.Labels.DarkLabel();
            this.lbl_Notificaciones = new UI.Controls.Labels.DarkLabel();
            this.lbl_Username = new UI.Controls.Labels.DarkLabel();
            this.flow_Buttons.SuspendLayout();
            this.flow_ComboBoxs.SuspendLayout();
            this.panel_Notificaciones.SuspendLayout();
            this.Panel_NotificacionesBorder.SuspendLayout();
            this.panel_RespaldosBorder.SuspendLayout();
            this.panel_Respaldos.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow_Buttons
            // 
            this.flow_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_Buttons.ColumnCount = 3;
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_Buttons.Controls.Add(this.but_CambiarUsername, 0, 0);
            this.flow_Buttons.Controls.Add(this.but_BorrarUsuario, 2, 0);
            this.flow_Buttons.Controls.Add(this.but_CambiarPassword, 1, 0);
            this.flow_Buttons.Location = new System.Drawing.Point(0, 61);
            this.flow_Buttons.Name = "flow_Buttons";
            this.flow_Buttons.RowCount = 1;
            this.flow_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flow_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.flow_Buttons.Size = new System.Drawing.Size(892, 53);
            this.flow_Buttons.TabIndex = 8;
            // 
            // but_CambiarUsername
            // 
            this.but_CambiarUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.but_CambiarUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_CambiarUsername.FlatAppearance.BorderSize = 0;
            this.but_CambiarUsername.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_CambiarUsername.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_CambiarUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CambiarUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_CambiarUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_CambiarUsername.Location = new System.Drawing.Point(10, 10);
            this.but_CambiarUsername.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_CambiarUsername.Name = "but_CambiarUsername";
            this.but_CambiarUsername.Size = new System.Drawing.Size(277, 35);
            this.but_CambiarUsername.TabIndex = 5;
            this.but_CambiarUsername.Text = "Cambiar Nombre";
            this.but_CambiarUsername.UseVisualStyleBackColor = false;
            this.but_CambiarUsername.Click += new System.EventHandler(this.but_CambiarUsername_Click);
            // 
            // but_BorrarUsuario
            // 
            this.but_BorrarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.but_BorrarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_BorrarUsuario.FlatAppearance.BorderSize = 0;
            this.but_BorrarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_BorrarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_BorrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_BorrarUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_BorrarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_BorrarUsuario.Location = new System.Drawing.Point(604, 10);
            this.but_BorrarUsuario.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_BorrarUsuario.Name = "but_BorrarUsuario";
            this.but_BorrarUsuario.Size = new System.Drawing.Size(278, 35);
            this.but_BorrarUsuario.TabIndex = 7;
            this.but_BorrarUsuario.Text = "Borrar Usuario";
            this.but_BorrarUsuario.UseVisualStyleBackColor = false;
            this.but_BorrarUsuario.Click += new System.EventHandler(this.but_BorrarUsuario_Click);
            // 
            // but_CambiarPassword
            // 
            this.but_CambiarPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.but_CambiarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_CambiarPassword.FlatAppearance.BorderSize = 0;
            this.but_CambiarPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_CambiarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_CambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CambiarPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_CambiarPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_CambiarPassword.Location = new System.Drawing.Point(307, 10);
            this.but_CambiarPassword.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_CambiarPassword.Name = "but_CambiarPassword";
            this.but_CambiarPassword.Size = new System.Drawing.Size(277, 35);
            this.but_CambiarPassword.TabIndex = 6;
            this.but_CambiarPassword.Text = "Cambiar Contraseña";
            this.but_CambiarPassword.UseVisualStyleBackColor = false;
            this.but_CambiarPassword.Click += new System.EventHandler(this.but_CambiarPassword_Click);
            // 
            // flow_ComboBoxs
            // 
            this.flow_ComboBoxs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_ComboBoxs.ColumnCount = 3;
            this.flow_ComboBoxs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_ComboBoxs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_ComboBoxs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flow_ComboBoxs.Controls.Add(this.lbl_DivisaDefault, 1, 0);
            this.flow_ComboBoxs.Controls.Add(this.combo_Idioma, 0, 1);
            this.flow_ComboBoxs.Controls.Add(this.lbl_Idioma, 0, 0);
            this.flow_ComboBoxs.Controls.Add(this.combo_DivisaDefault, 1, 1);
            this.flow_ComboBoxs.Location = new System.Drawing.Point(0, 124);
            this.flow_ComboBoxs.Name = "flow_ComboBoxs";
            this.flow_ComboBoxs.RowCount = 2;
            this.flow_ComboBoxs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flow_ComboBoxs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.flow_ComboBoxs.Size = new System.Drawing.Size(892, 63);
            this.flow_ComboBoxs.TabIndex = 9;
            // 
            // lbl_DivisaDefault
            // 
            this.lbl_DivisaDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DivisaDefault.AutoSize = true;
            this.lbl_DivisaDefault.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DivisaDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_DivisaDefault.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_DivisaDefault.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_DivisaDefault.Location = new System.Drawing.Point(300, 7);
            this.lbl_DivisaDefault.Name = "lbl_DivisaDefault";
            this.lbl_DivisaDefault.Size = new System.Drawing.Size(291, 21);
            this.lbl_DivisaDefault.TabIndex = 13;
            this.lbl_DivisaDefault.Text = "Divisa Default:";
            this.lbl_DivisaDefault.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Idioma
            // 
            this.combo_Idioma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Idioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Idioma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_Idioma.FormattingEnabled = true;
            this.combo_Idioma.Location = new System.Drawing.Point(5, 33);
            this.combo_Idioma.Margin = new System.Windows.Forms.Padding(5);
            this.combo_Idioma.Name = "combo_Idioma";
            this.combo_Idioma.Size = new System.Drawing.Size(287, 29);
            this.combo_Idioma.TabIndex = 10;
            // 
            // lbl_Idioma
            // 
            this.lbl_Idioma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Idioma.AutoSize = true;
            this.lbl_Idioma.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Idioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Idioma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Idioma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Idioma.Location = new System.Drawing.Point(3, 7);
            this.lbl_Idioma.Name = "lbl_Idioma";
            this.lbl_Idioma.Size = new System.Drawing.Size(291, 21);
            this.lbl_Idioma.TabIndex = 12;
            this.lbl_Idioma.Text = "Idioma:";
            this.lbl_Idioma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_DivisaDefault
            // 
            this.combo_DivisaDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_DivisaDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_DivisaDefault.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_DivisaDefault.FormattingEnabled = true;
            this.combo_DivisaDefault.Location = new System.Drawing.Point(302, 33);
            this.combo_DivisaDefault.Margin = new System.Windows.Forms.Padding(5);
            this.combo_DivisaDefault.Name = "combo_DivisaDefault";
            this.combo_DivisaDefault.Size = new System.Drawing.Size(287, 29);
            this.combo_DivisaDefault.TabIndex = 11;
            // 
            // panel_Notificaciones
            // 
            this.panel_Notificaciones.Controls.Add(this.txt_EliminarNotifsValor);
            this.panel_Notificaciones.Controls.Add(this.combo_EliminarNotifsMagnitud);
            this.panel_Notificaciones.Controls.Add(this.check_EliminarNotifs);
            this.panel_Notificaciones.Controls.Add(this.check_NotifRecordatorios);
            this.panel_Notificaciones.Controls.Add(this.check_NotifPrespuestos);
            this.panel_Notificaciones.Controls.Add(this.check_NotifEstadisticas);
            this.panel_Notificaciones.Controls.Add(this.check_NotifWindows);
            this.panel_Notificaciones.Controls.Add(this.check_AlarmasWindows);
            this.panel_Notificaciones.Location = new System.Drawing.Point(7, 8);
            this.panel_Notificaciones.Name = "panel_Notificaciones";
            this.panel_Notificaciones.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Notificaciones.Size = new System.Drawing.Size(864, 115);
            this.panel_Notificaciones.TabIndex = 18;
            // 
            // txt_EliminarNotifsValor
            // 
            this.txt_EliminarNotifsValor.AllowText = false;
            this.txt_EliminarNotifsValor.BackColor = System.Drawing.SystemColors.Window;
            this.txt_EliminarNotifsValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_EliminarNotifsValor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_EliminarNotifsValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_EliminarNotifsValor.Location = new System.Drawing.Point(284, 79);
            this.txt_EliminarNotifsValor.MaxLength = 4;
            this.txt_EliminarNotifsValor.Name = "txt_EliminarNotifsValor";
            this.txt_EliminarNotifsValor.Size = new System.Drawing.Size(48, 29);
            this.txt_EliminarNotifsValor.TabIndex = 23;
            this.txt_EliminarNotifsValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_EliminarNotifsValor.Validated += new System.EventHandler(this.txt_EliminarNotifsValor_Validated);
            // 
            // combo_EliminarNotifsMagnitud
            // 
            this.combo_EliminarNotifsMagnitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_EliminarNotifsMagnitud.Enabled = false;
            this.combo_EliminarNotifsMagnitud.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.combo_EliminarNotifsMagnitud.FormattingEnabled = true;
            this.combo_EliminarNotifsMagnitud.Location = new System.Drawing.Point(338, 79);
            this.combo_EliminarNotifsMagnitud.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.combo_EliminarNotifsMagnitud.Name = "combo_EliminarNotifsMagnitud";
            this.combo_EliminarNotifsMagnitud.Size = new System.Drawing.Size(110, 29);
            this.combo_EliminarNotifsMagnitud.TabIndex = 14;
            // 
            // check_EliminarNotifs
            // 
            this.check_EliminarNotifs.AutoSize = true;
            this.check_EliminarNotifs.BackColor = System.Drawing.Color.Transparent;
            this.check_EliminarNotifs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_EliminarNotifs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_EliminarNotifs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_EliminarNotifs.Location = new System.Drawing.Point(8, 80);
            this.check_EliminarNotifs.Name = "check_EliminarNotifs";
            this.check_EliminarNotifs.Size = new System.Drawing.Size(276, 25);
            this.check_EliminarNotifs.TabIndex = 20;
            this.check_EliminarNotifs.Text = "Eliminar Notificaciones luego de";
            this.check_EliminarNotifs.UseVisualStyleBackColor = false;
            this.check_EliminarNotifs.CheckedChanged += new System.EventHandler(this.check_EliminarNotifs_CheckedChanged);
            // 
            // check_NotifRecordatorios
            // 
            this.check_NotifRecordatorios.AutoSize = true;
            this.check_NotifRecordatorios.BackColor = System.Drawing.Color.Transparent;
            this.check_NotifRecordatorios.Checked = true;
            this.check_NotifRecordatorios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_NotifRecordatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_NotifRecordatorios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_NotifRecordatorios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_NotifRecordatorios.Location = new System.Drawing.Point(593, 44);
            this.check_NotifRecordatorios.Name = "check_NotifRecordatorios";
            this.check_NotifRecordatorios.Size = new System.Drawing.Size(247, 25);
            this.check_NotifRecordatorios.TabIndex = 19;
            this.check_NotifRecordatorios.Text = "Notificaciones Recordatorios";
            this.check_NotifRecordatorios.UseVisualStyleBackColor = false;
            this.check_NotifRecordatorios.CheckedChanged += new System.EventHandler(this.check_NotifRecordatorios_CheckedChanged);
            // 
            // check_NotifPrespuestos
            // 
            this.check_NotifPrespuestos.AutoSize = true;
            this.check_NotifPrespuestos.BackColor = System.Drawing.Color.Transparent;
            this.check_NotifPrespuestos.Checked = true;
            this.check_NotifPrespuestos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_NotifPrespuestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_NotifPrespuestos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_NotifPrespuestos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_NotifPrespuestos.Location = new System.Drawing.Point(303, 44);
            this.check_NotifPrespuestos.Name = "check_NotifPrespuestos";
            this.check_NotifPrespuestos.Size = new System.Drawing.Size(242, 25);
            this.check_NotifPrespuestos.TabIndex = 18;
            this.check_NotifPrespuestos.Text = "Notificaciones Presupuestos";
            this.check_NotifPrespuestos.UseVisualStyleBackColor = false;
            this.check_NotifPrespuestos.CheckedChanged += new System.EventHandler(this.check_NotifPrespuestos_CheckedChanged);
            // 
            // check_NotifEstadisticas
            // 
            this.check_NotifEstadisticas.AutoSize = true;
            this.check_NotifEstadisticas.BackColor = System.Drawing.Color.Transparent;
            this.check_NotifEstadisticas.Checked = true;
            this.check_NotifEstadisticas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_NotifEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_NotifEstadisticas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_NotifEstadisticas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_NotifEstadisticas.Location = new System.Drawing.Point(8, 44);
            this.check_NotifEstadisticas.Name = "check_NotifEstadisticas";
            this.check_NotifEstadisticas.Size = new System.Drawing.Size(229, 25);
            this.check_NotifEstadisticas.TabIndex = 17;
            this.check_NotifEstadisticas.Text = "Notificaciones Estadísticas";
            this.check_NotifEstadisticas.UseVisualStyleBackColor = false;
            this.check_NotifEstadisticas.CheckedChanged += new System.EventHandler(this.check_NotifEstadisticas_CheckedChanged);
            // 
            // check_NotifWindows
            // 
            this.check_NotifWindows.AutoSize = true;
            this.check_NotifWindows.BackColor = System.Drawing.Color.Transparent;
            this.check_NotifWindows.Checked = true;
            this.check_NotifWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_NotifWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_NotifWindows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_NotifWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_NotifWindows.Location = new System.Drawing.Point(8, 8);
            this.check_NotifWindows.Name = "check_NotifWindows";
            this.check_NotifWindows.Size = new System.Drawing.Size(212, 25);
            this.check_NotifWindows.TabIndex = 15;
            this.check_NotifWindows.Text = "Notificaciones Windows";
            this.check_NotifWindows.UseVisualStyleBackColor = false;
            this.check_NotifWindows.CheckedChanged += new System.EventHandler(this.check_NotifWindows_CheckedChanged);
            // 
            // check_AlarmasWindows
            // 
            this.check_AlarmasWindows.AutoSize = true;
            this.check_AlarmasWindows.BackColor = System.Drawing.Color.Transparent;
            this.check_AlarmasWindows.Checked = true;
            this.check_AlarmasWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_AlarmasWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_AlarmasWindows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_AlarmasWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_AlarmasWindows.Location = new System.Drawing.Point(303, 8);
            this.check_AlarmasWindows.Name = "check_AlarmasWindows";
            this.check_AlarmasWindows.Size = new System.Drawing.Size(163, 25);
            this.check_AlarmasWindows.TabIndex = 16;
            this.check_AlarmasWindows.Text = "Alarmas Windows";
            this.check_AlarmasWindows.UseVisualStyleBackColor = false;
            this.check_AlarmasWindows.CheckedChanged += new System.EventHandler(this.check_AlarmasWindows_CheckedChanged);
            // 
            // Panel_NotificacionesBorder
            // 
            this.Panel_NotificacionesBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_NotificacionesBorder.Controls.Add(this.panel_Notificaciones);
            this.Panel_NotificacionesBorder.Location = new System.Drawing.Point(5, 248);
            this.Panel_NotificacionesBorder.Name = "Panel_NotificacionesBorder";
            this.Panel_NotificacionesBorder.Padding = new System.Windows.Forms.Padding(5);
            this.Panel_NotificacionesBorder.Size = new System.Drawing.Size(879, 131);
            this.Panel_NotificacionesBorder.TabIndex = 20;
            // 
            // panel_RespaldosBorder
            // 
            this.panel_RespaldosBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_RespaldosBorder.Controls.Add(this.panel_Respaldos);
            this.panel_RespaldosBorder.Location = new System.Drawing.Point(5, 412);
            this.panel_RespaldosBorder.Name = "panel_RespaldosBorder";
            this.panel_RespaldosBorder.Padding = new System.Windows.Forms.Padding(5);
            this.panel_RespaldosBorder.Size = new System.Drawing.Size(879, 112);
            this.panel_RespaldosBorder.TabIndex = 21;
            // 
            // panel_Respaldos
            // 
            this.panel_Respaldos.Controls.Add(this.lbl_FrecuenciaRespaldar);
            this.panel_Respaldos.Controls.Add(this.but_FrecuenciaRespaldar);
            this.panel_Respaldos.Controls.Add(this.txt_CantidadMaximaRespaldos);
            this.panel_Respaldos.Controls.Add(this.check_CantidadMaximaRespaldos);
            this.panel_Respaldos.Controls.Add(this.check_Respaldar);
            this.panel_Respaldos.Location = new System.Drawing.Point(7, 8);
            this.panel_Respaldos.Name = "panel_Respaldos";
            this.panel_Respaldos.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Respaldos.Size = new System.Drawing.Size(864, 96);
            this.panel_Respaldos.TabIndex = 18;
            // 
            // lbl_FrecuenciaRespaldar
            // 
            this.lbl_FrecuenciaRespaldar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FrecuenciaRespaldar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FrecuenciaRespaldar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FrecuenciaRespaldar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FrecuenciaRespaldar.Location = new System.Drawing.Point(415, 9);
            this.lbl_FrecuenciaRespaldar.Name = "lbl_FrecuenciaRespaldar";
            this.lbl_FrecuenciaRespaldar.Size = new System.Drawing.Size(441, 35);
            this.lbl_FrecuenciaRespaldar.TabIndex = 31;
            this.lbl_FrecuenciaRespaldar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // but_FrecuenciaRespaldar
            // 
            this.but_FrecuenciaRespaldar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_FrecuenciaRespaldar.FlatAppearance.BorderSize = 0;
            this.but_FrecuenciaRespaldar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_FrecuenciaRespaldar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_FrecuenciaRespaldar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_FrecuenciaRespaldar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_FrecuenciaRespaldar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_FrecuenciaRespaldar.Location = new System.Drawing.Point(200, 9);
            this.but_FrecuenciaRespaldar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_FrecuenciaRespaldar.Name = "but_FrecuenciaRespaldar";
            this.but_FrecuenciaRespaldar.Size = new System.Drawing.Size(206, 35);
            this.but_FrecuenciaRespaldar.TabIndex = 30;
            this.but_FrecuenciaRespaldar.Text = "Establecer Frecuencia";
            this.but_FrecuenciaRespaldar.UseVisualStyleBackColor = false;
            this.but_FrecuenciaRespaldar.Click += new System.EventHandler(this.but_FrecuenciaRespaldar_Click);
            // 
            // txt_CantidadMaximaRespaldos
            // 
            this.txt_CantidadMaximaRespaldos.AllowText = false;
            this.txt_CantidadMaximaRespaldos.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CantidadMaximaRespaldos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CantidadMaximaRespaldos.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_CantidadMaximaRespaldos.Enabled = false;
            this.txt_CantidadMaximaRespaldos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_CantidadMaximaRespaldos.Location = new System.Drawing.Point(253, 56);
            this.txt_CantidadMaximaRespaldos.MaxLength = 4;
            this.txt_CantidadMaximaRespaldos.Name = "txt_CantidadMaximaRespaldos";
            this.txt_CantidadMaximaRespaldos.Size = new System.Drawing.Size(48, 29);
            this.txt_CantidadMaximaRespaldos.TabIndex = 29;
            this.txt_CantidadMaximaRespaldos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_CantidadMaximaRespaldos.Validated += new System.EventHandler(this.txt_CantidadMaximaRespaldos_Validated);
            // 
            // check_CantidadMaximaRespaldos
            // 
            this.check_CantidadMaximaRespaldos.AutoSize = true;
            this.check_CantidadMaximaRespaldos.BackColor = System.Drawing.Color.Transparent;
            this.check_CantidadMaximaRespaldos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_CantidadMaximaRespaldos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_CantidadMaximaRespaldos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_CantidadMaximaRespaldos.Location = new System.Drawing.Point(8, 57);
            this.check_CantidadMaximaRespaldos.Name = "check_CantidadMaximaRespaldos";
            this.check_CantidadMaximaRespaldos.Size = new System.Drawing.Size(246, 25);
            this.check_CantidadMaximaRespaldos.TabIndex = 26;
            this.check_CantidadMaximaRespaldos.Text = "Cantidad Máxima Respaldos:";
            this.check_CantidadMaximaRespaldos.UseVisualStyleBackColor = false;
            this.check_CantidadMaximaRespaldos.CheckedChanged += new System.EventHandler(this.check_CantidadMaximaRespaldos_CheckedChanged);
            // 
            // check_Respaldar
            // 
            this.check_Respaldar.AutoSize = true;
            this.check_Respaldar.BackColor = System.Drawing.Color.Transparent;
            this.check_Respaldar.Checked = true;
            this.check_Respaldar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Respaldar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Respaldar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Respaldar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_Respaldar.Location = new System.Drawing.Point(8, 13);
            this.check_Respaldar.Name = "check_Respaldar";
            this.check_Respaldar.Size = new System.Drawing.Size(187, 25);
            this.check_Respaldar.TabIndex = 24;
            this.check_Respaldar.Text = "Respaldar datos cada";
            this.check_Respaldar.UseVisualStyleBackColor = false;
            this.check_Respaldar.CheckedChanged += new System.EventHandler(this.check_Respaldar_CheckedChanged);
            // 
            // check_MantenerSesionIniciada
            // 
            this.check_MantenerSesionIniciada.BackColor = System.Drawing.Color.Transparent;
            this.check_MantenerSesionIniciada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_MantenerSesionIniciada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_MantenerSesionIniciada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_MantenerSesionIniciada.Location = new System.Drawing.Point(10, 198);
            this.check_MantenerSesionIniciada.Name = "check_MantenerSesionIniciada";
            this.check_MantenerSesionIniciada.Size = new System.Drawing.Size(373, 34);
            this.check_MantenerSesionIniciada.TabIndex = 10;
            this.check_MantenerSesionIniciada.Text = "Mantener Sesión Iniciada";
            this.check_MantenerSesionIniciada.UseVisualStyleBackColor = false;
            this.check_MantenerSesionIniciada.CheckedChanged += new System.EventHandler(this.check_MantenerSesionIniciada_CheckedChanged);
            // 
            // lbl_Respaldos
            // 
            this.lbl_Respaldos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Respaldos.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Respaldos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Respaldos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Respaldos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Respaldos.Location = new System.Drawing.Point(5, 386);
            this.lbl_Respaldos.Name = "lbl_Respaldos";
            this.lbl_Respaldos.Size = new System.Drawing.Size(879, 23);
            this.lbl_Respaldos.TabIndex = 22;
            this.lbl_Respaldos.Text = "Respaldos:";
            this.lbl_Respaldos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Notificaciones
            // 
            this.lbl_Notificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Notificaciones.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Notificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Notificaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Notificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Notificaciones.Location = new System.Drawing.Point(10, 222);
            this.lbl_Notificaciones.Name = "lbl_Notificaciones";
            this.lbl_Notificaciones.Size = new System.Drawing.Size(872, 23);
            this.lbl_Notificaciones.TabIndex = 14;
            this.lbl_Notificaciones.Text = "Notificaciones:";
            this.lbl_Notificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Username
            // 
            this.lbl_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Username.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Username.Location = new System.Drawing.Point(0, 0);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(892, 61);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "[Nombre de Usuario]";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.check_MantenerSesionIniciada);
            this.Controls.Add(this.lbl_Respaldos);
            this.Controls.Add(this.Panel_NotificacionesBorder);
            this.Controls.Add(this.lbl_Notificaciones);
            this.Controls.Add(this.flow_ComboBoxs);
            this.Controls.Add(this.flow_Buttons);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.panel_RespaldosBorder);
            this.Name = "UC_Configuracion";
            this.Size = new System.Drawing.Size(892, 531);
            this.SizeChanged += new System.EventHandler(this.UC_Configuracion_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.UC_Configuracion_VisibleChanged);
            this.flow_Buttons.ResumeLayout(false);
            this.flow_ComboBoxs.ResumeLayout(false);
            this.flow_ComboBoxs.PerformLayout();
            this.panel_Notificaciones.ResumeLayout(false);
            this.panel_Notificaciones.PerformLayout();
            this.Panel_NotificacionesBorder.ResumeLayout(false);
            this.panel_RespaldosBorder.ResumeLayout(false);
            this.panel_Respaldos.ResumeLayout(false);
            this.panel_Respaldos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Labels.DarkLabel lbl_Username;
        private Buttons.DarkButton but_CambiarPassword;
        private Buttons.DarkButton but_CambiarUsername;
        private Buttons.DarkButton but_BorrarUsuario;
        private System.Windows.Forms.TableLayoutPanel flow_Buttons;
        private System.Windows.Forms.TableLayoutPanel flow_ComboBoxs;
        private ComboBoxs.DefaultComboBox combo_DivisaDefault;
        private ComboBoxs.DefaultComboBox combo_Idioma;
        private Labels.DarkLabel lbl_DivisaDefault;
        private Labels.DarkLabel lbl_Idioma;
        private Labels.DarkCheckbox check_MantenerSesionIniciada;
        private Labels.DarkLabel lbl_Notificaciones;
        private Labels.DarkCheckbox check_NotifWindows;
        private Labels.DarkCheckbox check_AlarmasWindows;
        private System.Windows.Forms.Panel panel_Notificaciones;
        private Labels.DarkCheckbox check_NotifRecordatorios;
        private Labels.DarkCheckbox check_NotifPrespuestos;
        private Labels.DarkCheckbox check_NotifEstadisticas;
        private System.Windows.Forms.Panel Panel_NotificacionesBorder;
        private Labels.DarkCheckbox check_EliminarNotifs;
        private ComboBoxs.DefaultComboBox combo_EliminarNotifsMagnitud;
        private Labels.DarkCheckbox check_Respaldar;
        private System.Windows.Forms.Panel panel_RespaldosBorder;
        private System.Windows.Forms.Panel panel_Respaldos;
        private Labels.DarkLabel lbl_Respaldos;
        private Labels.DarkCheckbox check_CantidadMaximaRespaldos;
        private TextBoxs.IntegerBox txt_CantidadMaximaRespaldos;
        private TextBoxs.IntegerBox txt_EliminarNotifsValor;
        private Buttons.DarkButton but_FrecuenciaRespaldar;
        private Labels.DarkLabel lbl_FrecuenciaRespaldar;
    }
}
