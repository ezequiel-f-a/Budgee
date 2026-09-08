using SL.Services;
using System;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_CambiarPassword : Form
    {
        public string Password { get; private set; }
        public f_CambiarPassword()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_LightBackground;
        }

        private void but_Confirmar_Click(object sender, EventArgs e)
        {
            if (txt_PasswordOld.Text == txt_PasswordNew.Text)
            {
                MessageBox.Show("La nueva contraseña es idéntica a la original.".Translate());
                return;
            }
            else if (txt_PasswordOld.Text != AppData.CurrentUser.Password)
            {
                MessageBox.Show("La contraseña actual ingresada no coincide con la real.".Translate());
                return;
            }

            if (new f_ConfirmarPassword(txt_PasswordNew.Text).ShowDialog() != DialogResult.OK) return;

            Password = txt_PasswordNew.Text;

            DialogResult = DialogResult.OK;
        }

        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void f_CambiarPassword_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
