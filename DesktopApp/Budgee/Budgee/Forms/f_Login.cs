using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_Login : Form
    {
        #region Singleton
        private readonly static f_Login _instance;

        public static f_Login Current
        {
            get
            {
                if (_instance != null && _instance.IsDisposed) return new f_Login();
                else return _instance;
            }
        }
        static f_Login()
        {
            _instance = new f_Login();
        }
        private f_Login()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_LightBackground;
            CheckForIllegalCrossThreadCalls = false;
            new Thread(() => GetData()).Start();
        }
        #endregion

        //bool PrivilegiosSet = false;
        int ShownCount = 0;

        internal void ClearFields()
        {
            txt_Username.Text = "";
            txt_Password.Text = "";
            check_ShowPassword.Checked = false;
            check_MantenerSesionIniciada.Checked = false;
        }
        internal void GetData(bool updateCurrentLanguage = true)
        {
            this.Enabled = false;

            try
            {
                var lastTrackSesion = SL.BLL.Services.SesionTrackService.Current.GetAll(x => x.Usuario.Estado == true).OrderByDescending(x => x.FechaProceso).FirstOrDefault();
                var lastUsuario = lastTrackSesion?.Usuario;

                if (lastUsuario != null && lastUsuario.Configuracion.MantenerSesionIniciada)
                {
                    txt_Username.Text = lastUsuario.Username;
                    txt_Password.Text = lastUsuario.Password;
                    check_MantenerSesionIniciada.Checked = lastUsuario.Configuracion.MantenerSesionIniciada;

                    if(updateCurrentLanguage) AppData.CurrentLanguage = lastUsuario.Configuracion.Idioma ?? AppData.CurrentLanguage;
                }

                new Thread(() => this.SetupLanguageForContainer()).Start();

                /*new Thread(() => { 
                    SL.BLL.Services.UsuarioService.Current.SetPrivilegios(lastUsuario); 
                    PrivilegiosSet = true; }).Start();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }

            this.Enabled = true;
        }
        private void but_IniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Username.Text) || string.IsNullOrEmpty(txt_Password.Text))
                {
                    MessageBox.Show("Falta ingresar usuario o contraseña.".Translate());
                    return;
                }
                else if (!SL.BLL.Services.UsuarioService.Current.ValidateUsuario(txt_Username.Text, txt_Password.Text))
                {
                    MessageBox.Show("Usuario o contraseña inválidos.".Translate());
                    return;
                }

                var usuario =
                    SL.BLL.Services.UsuarioService.Current.
                    GetAll(x => x.Username == txt_Username.Text && x.Password == txt_Password.Text)
                    .First();

                SL.BLL.Services.UsuarioService.Current.SetPrivilegios(usuario);

                usuario.Configuracion.MantenerSesionIniciada = check_MantenerSesionIniciada.Checked;

                SL.BLL.Services.UsuarioService.Current.Update(usuario);

                SL.BLL.Services.UsuarioService.Current.Login(usuario);

                new Thread(() => SL.BLL.Services.SesionTrackService.Current.CleanOldSesionTrack(usuario)).Start();

                this.Hide();
                f_Main.Current.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_CrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Username.Text) || string.IsNullOrEmpty(txt_Password.Text))
                {
                    MessageBox.Show("Falta ingresar usuario o contraseña.".Translate());
                    return;
                }
                else if (txt_Username.Text == txt_Password.Text)
                {
                    MessageBox.Show("El nombre de usuario y la contraseña no pueden coincidir.".Translate());
                    return;
                }
                else if (SL.BLL.Services.UsuarioService.Current.GetAll(x => x.Username == txt_Username.Text && x.Estado == true).Count() > 0)
                {
                    MessageBox.Show("El nombre de usuario ya existe.".Translate());
                    return;
                }

                if (new f_ConfirmarPassword(txt_Password.Text).ShowDialog() != DialogResult.OK) return;

                Guid id_usuario = Guid.NewGuid();

                var config = new ConfiguracionUsuario(id_usuario) { MantenerSesionIniciada = check_MantenerSesionIniciada.Checked };
                var usuario = new Usuario(id_usuario, txt_Username.Text, txt_Password.Text, new List<Privilegio>(), config, true);

                SL.BLL.Services.UsuarioService.Current.Add(usuario);

                MessageBox.Show("Creación de usuario exitosa.".Translate());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void check_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = (!check_ShowPassword.Checked);
        }
        private void f_Login_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, HelpService.GetHelpFilePath());
        }
        private void f_Login_VisibleChanged(object sender, EventArgs e)
        {
            if (ShownCount > 0)
                new Thread(() => this.SetupLanguageForContainer()).Start();

            ShownCount++;
        }
    }
}
