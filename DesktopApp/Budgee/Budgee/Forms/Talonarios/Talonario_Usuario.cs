using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Usuario : f_Talonario<Usuario>
    {
        public Talonario_Usuario()
        {
            InitializeComponent();
            this.Text = "Talonario de Usuario";
        }
        protected override void SetFields(Usuario referenceObject)
        {
            txt_Username.Text = referenceObject.Username;
            txt_Password.Text = referenceObject.Password;
        }
        protected override void SetupReturnedObject()
        {
            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Username = txt_Username.Text;
                ReturnedObject.Password = txt_Password.Text;
            }
            else
            {
                Guid id_usuario = Guid.NewGuid();

                ReturnedObject = new Usuario(
                    id_usuario,
                    txt_Username.Text,
                    txt_Password.Text,
                    new System.Collections.Generic.List<Privilegio>(),
                    new ConfiguracionUsuario(id_usuario),
                    true);
            }
        }
        private void check_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = (!check_ShowPassword.Checked);
        }
        private void but_Aceptar_Click(object sender, EventArgs e)
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
                    if (ReferenceObject == null || ReferenceObject.Username != txt_Username.Text)
                    {
                        MessageBox.Show("El nombre de usuario ya existe.".Translate());
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }

            if (new f_ConfirmarPassword(txt_Password.Text).ShowDialog() != DialogResult.OK) return;

            SetupReturnedObject();

            DialogResult = DialogResult.OK;
        }
    }
}
