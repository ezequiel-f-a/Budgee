using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UI.Forms;

namespace UI.Controls.UC
{
    public partial class UC_Configuracion : UserControl
    {
        SL.Domain.Security.Usuario usuario = AppData.CurrentUser;
        SL.Domain.Security.ConfiguracionUsuario config = AppData.CurrentUser.Configuracion;
        bool getting_data = false;
        public UC_Configuracion()
        {
            InitializeComponent();
            SetupAll();
        }
        void GetData()
        {
            if (getting_data) return;

            getting_data = true;

            lbl_Username.Text = usuario.Username;

            check_MantenerSesionIniciada.Checked = config.MantenerSesionIniciada;
            check_NotifWindows.Checked = config.NotificacionesWindows;
            check_AlarmasWindows.Checked = config.AlarmasWindows;
            check_NotifEstadisticas.Checked = config.NotificacionesEstadisticas;
            check_NotifPrespuestos.Checked = config.NotificacionesPresupuestos;
            check_NotifRecordatorios.Checked = config.NotificacionesRecordatorios;
            check_EliminarNotifs.Checked = config.ExpiranNotificaciones;
            check_Respaldar.Checked = config.Respaldar;
            check_CantidadMaximaRespaldos.Checked = config.LimiteRespaldos;

            check_AlarmasWindows_CheckedChanged(this, null);
            check_CantidadMaximaRespaldos_CheckedChanged(this, null);
            check_EliminarNotifs_CheckedChanged(this, null);
            check_MantenerSesionIniciada_CheckedChanged(this, null);
            check_NotifEstadisticas_CheckedChanged(this, null);
            check_NotifPrespuestos_CheckedChanged(this, null);
            check_NotifRecordatorios_CheckedChanged(this, null);
            check_NotifWindows_CheckedChanged(this, null);
            check_Respaldar_CheckedChanged(this, null);

            txt_EliminarNotifsValor.Text = config.ExpiranNotificacionesValor.ToString();
            txt_CantidadMaximaRespaldos.Text = config.CantidadMaximaRespaldosValor.ToString();

            combo_Idioma.SelectedIndexChanged -= combo_Idioma_SelectedIndexChanged;
            if (config.Idioma != null)
                combo_Idioma.SelectedIndex = ((Idioma)config.Idioma).Index();
            combo_Idioma.SelectedIndexChanged += combo_Idioma_SelectedIndexChanged;

            combo_DivisaDefault.SelectedIndexChanged -= combo_DivisaDefault_SelectedIndexChanged;
            if (config.DivisaDefault != null)
                combo_DivisaDefault.SelectedIndex = ((Divisa)config.DivisaDefault).Index();
            combo_DivisaDefault.SelectedIndexChanged += combo_DivisaDefault_SelectedIndexChanged;

            combo_EliminarNotifsMagnitud.SelectedIndexChanged -= combo_EliminarNotifsMagnitud_SelectedIndexChanged;
            if (config.ExpiranNotificacionesMagnitud != null)
                combo_EliminarNotifsMagnitud.SelectedIndex = ((Frecuencia)config.ExpiranNotificacionesMagnitud).Index();
            combo_EliminarNotifsMagnitud.SelectedIndexChanged += combo_EliminarNotifsMagnitud_SelectedIndexChanged;

            if (config.RespaldarFrecuencia != null)
                lbl_FrecuenciaRespaldar.Text = $"[{SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(config.RespaldarFrecuencia)}]";

            getting_data = false;
        }
        void SetupAll()
        {
            this.BackColor = UI_Config.BackColor_Tab;

            SetupPanels();
            SetupCombos();
        }
        void SetupPanels()
        {
            Panel_NotificacionesBorder.BackColor = UI_Config.BackColor_DarkBackground;
            panel_Notificaciones.BackColor = UI_Config.BackColor_Tab;
            panel_RespaldosBorder.BackColor = UI_Config.BackColor_DarkBackground;
            panel_Respaldos.BackColor = UI_Config.BackColor_Tab;
        }
        void SetupCombos()
        {
            combo_Idioma.DataSource = new Idioma().GetDescriptions().Translate().ToList();
            combo_Idioma.SelectedIndex = -1;
            combo_DivisaDefault.DataSource = new Divisa().GetDescriptions().Translate().ToList();
            combo_DivisaDefault.SelectedIndex = -1;
            combo_EliminarNotifsMagnitud.DataSource = new FrecuenciaSimplificada().GetDescriptions().Translate().ToList();
            combo_EliminarNotifsMagnitud.SelectedIndex = -1;

            this.combo_Idioma.SelectedIndexChanged += new System.EventHandler(this.combo_Idioma_SelectedIndexChanged);
            this.combo_DivisaDefault.SelectedIndexChanged += new System.EventHandler(this.combo_DivisaDefault_SelectedIndexChanged);
            this.combo_EliminarNotifsMagnitud.SelectedIndexChanged += new System.EventHandler(this.combo_EliminarNotifsMagnitud_SelectedIndexChanged);
        }
        void ResizePanel(Panel border, Panel inside)
        {
            inside.Size = new Size(border.Width - 4, border.Height - 4);
            inside.Location = new Point(2, 2);
        }
        private void UC_Configuracion_SizeChanged(object sender, EventArgs e)
        {
            ResizePanel(Panel_NotificacionesBorder, panel_Notificaciones);
            ResizePanel(panel_RespaldosBorder, panel_Respaldos);
        }
        private void check_EliminarNotifs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txt_EliminarNotifsValor.Enabled = check_EliminarNotifs.Checked;
                combo_EliminarNotifsMagnitud.Enabled = check_EliminarNotifs.Checked;

                if (!getting_data)
                {
                    config.ExpiranNotificaciones = check_EliminarNotifs.Checked;

                    if (!check_EliminarNotifs.Checked)
                    {
                        config.ExpiranNotificacionesMagnitud = null;
                        config.ExpiranNotificacionesValor = null;

                        new Thread(() => SL.BLL.Services.UsuarioService.Current.Update(usuario)).Start();
                        BLL.Services.SchedulerService.Current.UpdateTasksProgrammedDate(BLL.Services.SchedulerService.Task_Type.Delete_NotificacionExpirada);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txt_EliminarNotifsValor.Text)) txt_EliminarNotifsValor.Text = "2";
                        if (combo_EliminarNotifsMagnitud.SelectedIndex == -1) combo_EliminarNotifsMagnitud.SelectedIndex = FrecuenciaSimplificada.Semanas.Index();

                        combo_EliminarNotifsMagnitud_SelectedIndexChanged(this, null);
                        txt_EliminarNotifsValor_Validated(this, null);
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_Respaldar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                but_FrecuenciaRespaldar.Enabled = check_Respaldar.Checked;

                config.Respaldar = check_Respaldar.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_CantidadMaximaRespaldos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txt_CantidadMaximaRespaldos.Enabled = check_CantidadMaximaRespaldos.Checked;

                if (!getting_data)
                {
                    config.LimiteRespaldos = check_CantidadMaximaRespaldos.Checked;

                    if (!check_CantidadMaximaRespaldos.Checked)
                    {
                        config.CantidadMaximaRespaldosValor = null;
                        new Thread(()=>SL.BLL.Services.UsuarioService.Current.Update(usuario)).Start();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txt_CantidadMaximaRespaldos.Text)) txt_CantidadMaximaRespaldos.Text = "10";
                        txt_CantidadMaximaRespaldos_Validated(this, null);
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_NotifWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                config.NotificacionesWindows = check_NotifWindows.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_AlarmasWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                config.AlarmasWindows = check_AlarmasWindows.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_NotifEstadisticas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                config.NotificacionesEstadisticas = check_NotifEstadisticas.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_NotifPrespuestos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                config.NotificacionesPresupuestos = check_NotifPrespuestos.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_NotifRecordatorios_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                config.NotificacionesRecordatorios = check_NotifRecordatorios.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_MantenerSesionIniciada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                config.MantenerSesionIniciada = check_MantenerSesionIniciada.Checked;

                if (!getting_data)
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void txt_EliminarNotifsValor_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_EliminarNotifsValor.Text))
                {
                    config.ExpiranNotificacionesValor = Convert.ToInt32(txt_EliminarNotifsValor.Text);

                    if (!getting_data)
                    {
                        new Thread(() => SL.BLL.Services.UsuarioService.Current.Update(usuario)).Start();
                        BLL.Services.SchedulerService.Current.UpdateTasksProgrammedDate(BLL.Services.SchedulerService.Task_Type.Delete_NotificacionExpirada);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void txt_CantidadMaximaRespaldos_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_CantidadMaximaRespaldos.Text))
                {
                    config.CantidadMaximaRespaldosValor = Convert.ToInt32(txt_CantidadMaximaRespaldos.Text);

                    if (!getting_data)
                        SL.BLL.Services.UsuarioService.Current.Update(usuario);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_CambiarUsername_Click(object sender, EventArgs e)
        {
            try
            {
                string old_username = usuario.Username; //Para cambiar carpeta de backups
                var f_Username = new f_CambiarNombreUsuario();
                f_Username.ShowDialog();
                string username = f_Username.Username;

                if (username != null)
                {
                    usuario.Username = username;
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
                    BLL.Services.BackupService.UpdateBackupDirectoryName(usuario, old_username); //Si tiene carpeta de backups, tengo que actualizar el nombre
                }

                lbl_Username.Text = usuario.Username;

                f_Login.Current.GetData(updateCurrentLanguage: false);
                new Thread(() => { f_Main.Current.UpdateNombreUsuario(); }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_CambiarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                var f_password = new f_CambiarPassword();
                f_password.ShowDialog();
                string password = f_password.Password;

                if (password != null)
                {
                    usuario.Password = password;
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
                }

                f_Login.Current.GetData(updateCurrentLanguage: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_BorrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea borrar el usuario?\nEsta acción no se puede revertir.".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (new f_ConfirmarPassword(AppData.CurrentUser.Password).ShowDialog() != DialogResult.OK) return;

                    var id_usuario = usuario.ID_Usuario;
                    f_Main.Current.CerrarSesion();
                    f_Login.Current.ClearFields();

                    var usuario_to_delete = SL.BLL.Services.UsuarioService.Current.GetOne(id_usuario);
                    usuario_to_delete.Estado = false;
                    SL.BLL.Services.UsuarioService.Current.Update(usuario_to_delete);

                    f_Login.Current.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_FrecuenciaRespaldar_Click(object sender, EventArgs e)
        {
            try
            {
                var f_frecuencia = new f_EstablecerFrecuenciaInicio(true);

                if (config.RespaldarFrecuencia != null) f_frecuencia.ReferenceObject = config.RespaldarFrecuencia;

                if (f_frecuencia.ShowDialog() == DialogResult.OK)
                {
                    config.RespaldarFrecuencia = f_frecuencia.ReturnedObject;
                    SL.BLL.Services.UsuarioService.Current.Update(usuario);
                    BLL.Services.SchedulerService.Current.UpdateTasksProgrammedDate(BLL.Services.SchedulerService.Task_Type.Generate_Backup);
                    lbl_FrecuenciaRespaldar.Text = $"[{SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(f_frecuencia.ReturnedObject)}]";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void combo_Idioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_Idioma.SelectedIndex == -1) return;

                config.Idioma = EnumHelper.GetEnumFromIndex<Idioma>(combo_Idioma.SelectedIndex);

                if (!getting_data)
                    new Thread(() => SL.BLL.Services.UsuarioService.Current.Update(usuario)).Start();

                MessageBox.Show("Los cambios surtirán efecto al reiniciar la aplicación".Translate());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void combo_DivisaDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_DivisaDefault.SelectedIndex == -1) return;

                config.DivisaDefault = EnumHelper.GetEnumFromIndex<Divisa>(combo_DivisaDefault.SelectedIndex);

                if (!getting_data)
                    new Thread(() => SL.BLL.Services.UsuarioService.Current.Update(usuario)).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void combo_EliminarNotifsMagnitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_EliminarNotifsMagnitud.SelectedIndex == -1) return;

                config.ExpiranNotificacionesMagnitud = EnumHelper.GetEnumFromIndex<Frecuencia>(combo_EliminarNotifsMagnitud.SelectedIndex);

                if (!getting_data)
                {
                    new Thread(() => SL.BLL.Services.UsuarioService.Current.Update(usuario)).Start();
                    BLL.Services.SchedulerService.Current.UpdateTasksProgrammedDate(BLL.Services.SchedulerService.Task_Type.Delete_NotificacionExpirada);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void UC_Configuracion_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            GetData();
        }
    }
}
