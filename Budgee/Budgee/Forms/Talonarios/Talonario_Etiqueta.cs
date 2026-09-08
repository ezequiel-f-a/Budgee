using Enums;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Etiqueta : Talonario_Caracteristica
    {
        public Talonario_Etiqueta()
        {
            InitializeComponent();
            this.Text = "Talonario de Etiqueta";
        }
        protected override void SetupReturnedObject()
        {
            SetupReturnedObject(Tipo_Caracteristica.Etiqueta);
        }
        private void but_Aceptar_Click(object sender, System.EventArgs e)
        {
            but_Aceptar_Click(Tipo_Caracteristica.Etiqueta);
        }
    }
}
