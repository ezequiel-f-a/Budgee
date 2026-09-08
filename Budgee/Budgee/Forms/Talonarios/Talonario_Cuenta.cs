using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Cuenta : f_Talonario<Cuenta>
    {
        public Talonario_Cuenta()
        {
            InitializeComponent();
            this.Text = "Talonario de Cuenta";
            SetupAll();
        }
        void SetupAll()
        {
            combo_Divisa.DataSource = new Divisa().GetDescriptions().Translate().ToList();

            combo_Divisa.SelectedIndex = -1;
        }
        protected override void SetFields(Cuenta referenceObject)
        {
            txt_Nombre.Text = referenceObject.Nombre;
            combo_Divisa.SelectedIndex = referenceObject.Divisa.Index();
            check_AdmiteFondosNegativos.Checked = referenceObject.AdmiteFondosNegativos;
        }
        protected override void SetupReturnedObject()
        {
            string nombre = txt_Nombre.Text;

            Divisa divisa = EnumHelper.GetEnumFromIndex<Divisa>(combo_Divisa.SelectedIndex);

            bool admiteFondosNegativos = check_AdmiteFondosNegativos.Checked;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Nombre = nombre;
                ReturnedObject.Divisa = divisa;
                ReturnedObject.AdmiteFondosNegativos = admiteFondosNegativos;
            }
            else
            {
                ReturnedObject = new Cuenta(
                    Guid.NewGuid(),
                    nombre,
                    divisa,
                    AppData.CurrentUser,
                    admiteFondosNegativos,
                    true,
                    true);
            }
        }
        private void but_Aceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckCamposCompletados()) return;

                if (BLL.Services.CuentaService.Current.GetAll(x => x.Nombre == txt_Nombre.Text && x.Estado == true).Count() > 0)
                {
                    if (ReferenceObject == null || ReferenceObject.Nombre != txt_Nombre.Text)
                    {
                        MessageBox.Show("El nombre ya existe.".Translate());
                        return;
                    }
                }

                if (ReferenceObject != null && ReferenceObject.AdmiteFondosNegativos && !check_AdmiteFondosNegativos.Checked)
                {
                    if (BLL.Services.CuentaService.Current.GetBalance(ReferenceObject) < 0)
                    {
                        MessageBox.Show("Para que la cuenta deje de admitir fondos negativos, su balance actual no puede ser negativo.".Translate());
                        return;
                    }
                }

                SetupReturnedObject();

                ReferenceObject = null;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void Talonario_Cuenta_Shown(object sender, EventArgs e)
        {
            if(ReferenceObject == null && AppData.CurrentUser.Configuracion.DivisaDefault != null)
                combo_Divisa.SelectedIndex = ((Divisa)AppData.CurrentUser.Configuracion.DivisaDefault).Index();
        }
    }
}
