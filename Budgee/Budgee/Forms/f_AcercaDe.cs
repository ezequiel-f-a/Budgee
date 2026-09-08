using SL.Services;
using System;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_AcercaDe : Form
    {
        public f_AcercaDe()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_Tab;
        }

        private void but_Aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_AcercaDe_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
