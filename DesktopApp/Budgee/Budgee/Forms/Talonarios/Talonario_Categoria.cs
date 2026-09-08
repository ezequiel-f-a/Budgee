using Enums;
using System;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Categoria : Talonario_Caracteristica
    {
        public Talonario_Categoria()
        {
            InitializeComponent();
            this.Text = "Talonario de Categoría";
        }
        protected override void SetupReturnedObject()
        {
            SetupReturnedObject(Tipo_Caracteristica.Categoria);
        }
        private void but_Aceptar_Click(object sender, EventArgs e)
        {
            but_Aceptar_Click(Tipo_Caracteristica.Categoria);
        }
    }
}
