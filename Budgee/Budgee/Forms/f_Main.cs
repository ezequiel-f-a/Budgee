using BLL.Services;
using Enums;
using SL.Domain;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.UC;
using UI.Controls.UC.MenuTab;
using UI.Forms.SeleccionarElems;

namespace UI.Forms
{
    public partial class f_Main : Form
    {
        #region Singleton
        private readonly static f_Main _instance;
        public static f_Main Current
        {
            get
            {
                //Si esta deshechado lo tengo que recrear (ya que la instancia no es nula)
                if (_instance != null && _instance.IsDisposed) return new f_Main();
                else return _instance;
            }
        }
        static f_Main()
        {
            _instance = new f_Main();
        }
        private f_Main()
        {
            InitializeComponent();
        }
        #endregion

        private TaskTimer NotificationCollector;

        UC_SideMenu UC_SideMenu;
        bool CerrandoSesion = false;
        bool CerrandoIgnorarAdvertencia = false;
        void SetupAll()
        {
            NotificationCollector = new TaskTimer(
                UpdateNotificacionesCount,
                AppData.Config.NotificationCollectorDelay_ms);

            NotificationCollector.Start();

            Current.BackColor = UI_Config.BackColor_DarkBackground;
            SetupControls();
            AddControls();
            SetMinimumSize();
        }
        void SetupControls()
        {
            SetupStripMenu();
            SetupSideMenu();
            SetupNotificationButton();
            SetupLblLogo();
        }
        void SetupLblLogo()
        {
            lbl_Logo.ForeColor = UI_Config.ForeColor_StripMenu;
            lbl_Logo.Location = GetLblLogoLocation();
        }
        void SetupStripMenu()
        {
            strip_Main.BackColor = UI_Config.BackColor_StripMenu;
            strip_Main.ForeColor = UI_Config.ForeColor_StripMenu;
            strip_Main.Font = UI_Config.Font_Default_Primary;
        }
        void SetupSideMenu()
        {
            var UC_Menu_Width = Current.ClientSize.Width * 1 / 6;
            var UC_Menu_Height = Current.ClientSize.Height - strip_Main.Size.Height;
            var Tab_Location = new Point(UC_Menu_Width, strip_Main.Size.Height);
            var Tab_Size = new Size(Current.Width - UC_Menu_Width, Current.Height - strip_Main.Height);

            var buttons = new List<Button>();
            buttons.Add(new MenuButton(new MenuTab_Transacciones() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Planificacion() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Plantillas() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Recordatorios() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Presupuestos() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Estadisticas() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Categorias() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Etiquetas() { Location = Tab_Location, Size = Tab_Size }));
            buttons.Add(new MenuButton(new MenuTab_Cuentas() { Location = Tab_Location, Size = Tab_Size }));

            UC_SideMenu = new UC_SideMenu(buttons);

            UC_SideMenu.ClientSize = new Size(UC_Menu_Width, UC_Menu_Height);
            UC_SideMenu.Location = new Point(0, strip_Main.Size.Height);

            UC_SideMenu.SizeChanged += UC_SideMenu_SizeChanged;
        }
        void SetupNotificationButton()
        {
            But_Notificaciones.ForeColor = UI_Config.ForeColor_StripMenu;
            But_Notificaciones.BackColor = UI_Config.BackColor_StripMenu;
            But_Notificaciones.FlatAppearance.BorderSize = 0;
            But_Notificaciones.FlatAppearance.BorderColor = But_Notificaciones.BackColor;
        }
        void AddControls()
        {
            Current.Controls.Add(UC_SideMenu);
            UC_SideMenu.BringToFront();
        }
        public void SetTab(UC_MenuTab tab)
        {
            var current_tab = Current.Controls.Cast<Control>().Where(x => x is UC_MenuTab).FirstOrDefault();

            if (current_tab != null)
            {
                if (current_tab.GetType() == tab.GetType())
                {
                    ResizeCurrentTab();
                    return;
                }
                else
                {
                    current_tab.Visible = false;
                    Current.Controls.Remove(current_tab);
                }

            }

            Current.Controls.Add(tab);
            ResizeCurrentTab();

            lbl_Logo.Visible = false;
            pic_Logo.Visible = false;

            SetMinimumSize();

            tab.Visible = false;
            tab.Visible = true;
        }
        void ResizeCurrentTab()
        {
            var current_tab = Current.Controls.Cast<Control>().Where(x => x is UC_MenuTab).FirstOrDefault();

            if (current_tab == null) return;

            current_tab.Size = GetTabSize();
            current_tab.Location = GetTabLocation();
            current_tab.BringToFront();
            //current_tab.Show();
        }
        void CloseTabs()
        {
            var tabs = Current.Controls.Cast<Control>().Where(x => x is UC_MenuTab);

            foreach (var tab in tabs)
                Current.Controls.Remove(tab);
        }
        Size GetTabSize()
        {
            var uc_menu = Controls.Cast<Control>().Where(x => x is UC_SideMenu).FirstOrDefault();
            return new Size(Current.ClientSize.Width - uc_menu.ClientSize.Width, Current.ClientSize.Height - strip_Main.ClientSize.Height);
        }
        Point GetLblLogoLocation()
        {
            return new Point(
                UC_SideMenu.ClientSize.Width + 20,
                Current.ClientSize.Height - lbl_Logo.Size.Height);
        }
        Point GetTabLocation()
        {
            var uc_menu = Controls.Cast<Control>().Where(x => x is UC_SideMenu).FirstOrDefault();
            return new Point(uc_menu.ClientSize.Width, strip_Main.ClientSize.Height);
        }
        void SetMinimumSize()
        {
            Current.MinimumSize = new Size(1278, 768);

            /*Current.MinimumSize = new Size(
                UC_SideMenu.ClientSize.Width + lbl_Logo.Size.Width + pic_Logo.Size.Width - 42 + 62,
                pic_Logo.Size.Height + strip_Main.Size.Height + (Current.Size.Height - Current.ClientSize.Height) + 15);*/
        }
        void SetupPermisos()
        {
            if (AppData.CurrentUser != null && AppData.CurrentUser.Permisos.Select(x => x.Nombre).Contains("Permisos de Administrador"))
                stripBut1_Administrador.Visible = true;
            else
                stripBut1_Administrador.Visible = false;
        }
        internal void UpdateNotificacionesCount()
        {
            if (AppData.CurrentUser == null) return;

            try
            {
                var count_notifs = BLL.Services.NotificacionService.Current.GetAll(x => x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true && x.Visto == false).Count();
                But_Notificaciones.Text = $"{"Notificaciones".Translate()} ({count_notifs})";
            }
            catch (Exception ex)
            {
                //Esto pasa cuando se ejecuta el thread justo cuando se deslogea el usuario
            }
        }
        internal void UpdateNombreUsuario()
        {
            string username = AppData.CurrentUser.Username;

            username = UIManager.Format_OverflowText(username, stripBut1_Usuario.Font, stripBut1_Usuario.Width);

            stripBut1_Usuario.Text = $" {username} ";
        }
        internal void CerrarSesion()
        {
            try
            {
                CerrandoSesion = true;

                if (AppData.CurrentUser.Configuracion.MantenerSesionIniciada == false)
                    f_Login.Current.ClearFields();

                SchedulerService.Current.Stop();

                if (AppData.CurrentUser != null)
                    SL.BLL.Services.UsuarioService.Current.Logout(AppData.CurrentUser);

                Current.Hide();

                CloseTabs();

                f_Login.Current.Show();

                CerrandoSesion = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void UpdateSelectedLanguage()
        {
            Idioma idioma = AppData.CurrentUser.Configuracion.Idioma ?? AppData.CurrentLanguage;

            int index = idioma.Index();

            var stripItems = stripBut1_Idioma.DropDownItems.Cast<ToolStripMenuItem>().ToList();

            for (int i = 0; i < stripItems.Count; i++)
                stripItems[i].Checked = (i == index);
        }
        void UC_SideMenu_SizeChanged(object sender, EventArgs e)
        {
            var tab = (UC_MenuTab)Controls.Cast<Control>().Where(x => x is UC_MenuTab).FirstOrDefault();

            if (tab != null)
                SetTab(tab);

            lbl_Logo.Location = GetLblLogoLocation();
            But_Notificaciones.Location = new Point(
                Current.ClientSize.Width - But_Notificaciones.Width, 0);

            SetMinimumSize();
        }
        private void stripBut1_Usuario_Click(object sender, EventArgs e)
        {
            SetTab(new MenuTab_Configuracion());
        }
        private void stripBut2_Configuracion_Click(object sender, EventArgs e)
        {
            SetTab(new MenuTab_Configuracion());
        }
        private void stripBut2_CerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CerrarSesion();
            }
        }
        private void stripBut2_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void stripBut2_ExportarRespaldo_Click(object sender, EventArgs e)
        {
           try
            {
                var exportar = new SaveFileDialog()
                {
                    Title = "Guardar como".Translate(),
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter = $"{"Archivo Binario".Translate()} (.bin) | *.bin"
                };

                if (exportar.ShowDialog() == DialogResult.OK)
                {
                    string path = exportar.FileName;

                    this.Enabled = false;

                    BackupService.GenerateBackup(AppData.CurrentUser, path);
                    MessageBox.Show("Exportación de respaldo exitosa.".Translate());

                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void stripBut2_RestaurarDesdeRespaldo_Click(object sender, EventArgs e)
        {
            try
            {
                var exportar = new OpenFileDialog()
                {
                    Title = "Abrir".Translate(),
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter = $"{"Archivo Binario".Translate()} (.bin) | *.bin"
                };

                if (exportar.ShowDialog() == DialogResult.OK)
                {
                    string path = exportar.FileName;

                    if (MessageBox.Show("¿Está seguro que desea restaurar?\nLos datos actuales del usuario serán reemplazados por los importados. Este proceso no es reversible y durará varios segundos.".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Enabled = false;

                        BackupService.RestoreFromBackup(AppData.CurrentUser, path);
                        MessageBox.Show("Restauración desde respaldo exitosa.\nLa aplicación se cerrará para aplicar los cambios.".Translate());
                        CerrandoIgnorarAdvertencia = true;
                        this.Close();

                        this.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void stripBut2_Español_Click(object sender, EventArgs e)
        {
            try
            {
                (sender as ToolStripMenuItem).Click -= stripBut2_Español_Click;
                (sender as ToolStripMenuItem).Checked = true;
                (sender as ToolStripMenuItem).Click += stripBut2_Español_Click;

                foreach (var control in stripBut1_Idioma.DropDownItems.Cast<ToolStripMenuItem>())
                {
                    if (control != sender)
                        control.Checked = false;
                }

                AppData.CurrentUser.Configuracion.Idioma = Enums.Idioma.Español;

                new Thread(() =>
                    SL.BLL.Services.UsuarioService.Current.Update(AppData.CurrentUser)).Start();

                MessageBox.Show("Los cambios surtirán efecto al reiniciar la aplicación".Translate());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void stripBut2_English_Click(object sender, EventArgs e)
        {
            try
            {
                (sender as ToolStripMenuItem).Click -= stripBut2_English_Click;
                (sender as ToolStripMenuItem).Checked = true;
                (sender as ToolStripMenuItem).Click += stripBut2_English_Click;

                foreach (var control in stripBut1_Idioma.DropDownItems.Cast<ToolStripMenuItem>())
                {
                    if (control != sender)
                        control.Checked = false;
                }

                AppData.CurrentUser.Configuracion.Idioma = Enums.Idioma.English;

                new Thread(() =>
                    SL.BLL.Services.UsuarioService.Current.Update(AppData.CurrentUser)).Start();

                MessageBox.Show("Los cambios surtirán efecto al reiniciar la aplicación".Translate());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void stripBut2_AdministrarUsuarios_Click(object sender, EventArgs e)
        {
            SetTab(new MenuTab_Usuarios());
        }
        private void stripBut2_AdministrarPerfilesPermisos_Click(object sender, EventArgs e)
        {
            SetTab(new MenuTab_Familias());
        }
        private void stripBut2_RestablecerIdiomas_Click(object sender, EventArgs e)
        {
            LanguageService.RestoreLanguages();
            MessageBox.Show("Idiomas restablecidos. Reinicie la aplicación para que los cambios surtan efecto.".Translate());
        }
        private void stripBut2_ManualAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HelpService.GetHelpFilePath());
        }
        private void stripBut2_AcercaDe_Click(object sender, EventArgs e)
        {
            new f_AcercaDe().ShowDialog();
        }
        private void But_Notificaciones_Click(object sender, EventArgs e)
        {
            SetTab(new MenuTab_Notificaciones());
        }
        private void f_Main_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is UC_MenuTab)
            {
                lbl_Logo.Visible = true;
                pic_Logo.Visible = true;
                SetMinimumSize();
            }
        }
        private void f_Main_ResizeEnd(object sender, EventArgs e)
        {
            SetMinimumSize();
        }
        private void f_Main_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, HelpService.GetHelpFilePath());
        }
        private void f_Main_Load(object sender, EventArgs e)
        {
            StartupService.Startup();
            SetupAll();

            new Thread(() => Current.SetupLanguageForContainer()).Start();
        }
        private void f_Main_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            SetupPermisos();

            new Thread(() => UpdateNombreUsuario()).Start();
            new Thread(() => UpdateSelectedLanguage()).Start();
        }
        private void f_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CerrandoSesion || CerrandoIgnorarAdvertencia) return;

                if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void f_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Current.Enabled = false;

            if (AppData.CurrentUser != null)
                SL.BLL.Services.UsuarioService.Current.Logout(AppData.CurrentUser);

            if (!CerrandoSesion) 
            {
                this.Hide();
                Environment.Exit(0);
            } 
        }
    }
}
