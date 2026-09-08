using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_CambiarNombreUsuario : Form
    {
        public string Username { get; private set; }
        public f_CambiarNombreUsuario()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_LightBackground;
        }

        private void but_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Username.Text == AppData.CurrentUser.Username)
                {
                    MessageBox.Show("El nuevo nombre es idéntico al que ya posee.".Translate());
                    return;
                }
                else if (SL.BLL.Services.UsuarioService.Current.GetAll(x => x.Username == txt_Username.Text && x.Estado == true).Count() > 0)
                {
                    MessageBox.Show("El nombre de usuario ya existe.".Translate());
                    return;
                }

                if (new f_ConfirmarPassword(AppData.CurrentUser.Password).ShowDialog() != DialogResult.OK) return;

                Username = txt_Username.Text;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }

        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void f_CambiarNombreUsuario_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
