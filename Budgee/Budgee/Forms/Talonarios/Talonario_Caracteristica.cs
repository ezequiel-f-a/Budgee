using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Caracteristica : f_Talonario<Caracteristica>
    {
        public Talonario_Caracteristica()
        {
            InitializeComponent();
            this.Text = "Talonario de Caracteristica";
            SetupAll();
        }
        protected override void SetFields(Caracteristica referenceObject)
        {
            txt_Nombre.Text = referenceObject.Nombre;

            if (referenceObject.Color != null)
                combo_Color.SelectedIndex = ((ColorBasico)((Color)referenceObject.Color).ToColorBasico()).Index();
        }
        protected void SetupReturnedObject(Tipo_Caracteristica tipo_Caracteristica)
        {
            string nombre = txt_Nombre.Text;

            ColorBasico? colorBasico = null;
            if (combo_Color.SelectedIndex != -1) colorBasico = EnumHelper.GetEnumFromIndex<ColorBasico>(combo_Color.SelectedIndex);

            Color? color = null;
            if (colorBasico != null) color = ((ColorBasico)colorBasico).ToColor();

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Nombre = nombre;
                ReturnedObject.Color = color;
                ReturnedObject.Tipo_Caracteristica = tipo_Caracteristica;
            }
            else
            {
                ReturnedObject = new Caracteristica(
                    Guid.NewGuid(),
                    nombre,
                    tipo_Caracteristica,
                    color,
                    AppData.CurrentUser,
                    true);
            }
        }
        protected void but_Aceptar_Click(Tipo_Caracteristica tipo_Caracteristica)
        {
            try
            {
                if (!CheckCamposCompletados()) return;

                if (BLL.Services.CaracteristicaService.Current.GetAll(x => x.Nombre == txt_Nombre.Text && x.Tipo_Caracteristica == tipo_Caracteristica && x.Estado == true).Count() > 0)
                {
                    if (ReferenceObject == null || ReferenceObject.Nombre != txt_Nombre.Text)
                    {
                        MessageBox.Show("El nombre ya existe.".Translate());
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
        void SetupAll()
        {
            combo_Color.DataSource = new ColorBasico().GetDescriptions().Translate().ToList();

            combo_Color.SelectedIndex = -1;
        }
    }
}
