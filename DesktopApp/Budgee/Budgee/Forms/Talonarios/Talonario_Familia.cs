using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Familia : f_Talonario<Familia>
    {
        public Talonario_Familia()
        {
            InitializeComponent();
            this.Text = "Talonario de Perfil";
        }
        protected override void SetFields(Familia referenceObject)
        {
            txt_Nombre.Text = referenceObject.Nombre;
        }
        protected override void SetupReturnedObject()
        {
            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Nombre = txt_Nombre.Text;
            }
            else
            {
                ReturnedObject = new Familia(
                    txt_Nombre.Text,
                    Guid.NewGuid(),
                    new System.Collections.Generic.List<Privilegio>());
            }
        }
        private void but_Aceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Nombre.Text))
                {
                    MessageBox.Show("Falta ingresar el nombre del perfil.".Translate());
                    return;
                }
                else if (SL.BLL.Services.FamiliaService.Current.GetAll(x => x.Nombre == txt_Nombre.Text).Count() > 0)
                {
                    if (ReferenceObject == null || ReferenceObject.Nombre != txt_Nombre.Text)
                    {
                        MessageBox.Show("El nombre de perfil ya existe.".Translate());
                        return;
                    }
                }

                SetupReturnedObject();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
