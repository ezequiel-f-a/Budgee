using SL.Services;
using System;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_ConfirmarPassword : Form
    {
        string Password;
        public f_ConfirmarPassword(string password)
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_LightBackground;
            Password = password;
        }

        private void but_Confirmar_Click(object sender, EventArgs e)
        {
            if (Password != txt_ConfirmarPassword.Text)
            {
                MessageBox.Show("La contraseña no coincide.".Translate());
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void f_ConfirmarPassword_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
