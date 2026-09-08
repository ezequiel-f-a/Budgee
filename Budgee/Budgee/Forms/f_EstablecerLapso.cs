using Enums;
using SL.Domain;
using SL.Services;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_EstablecerLapso : Form
    {
        public Lapso ReferenceObject { get; set; }
        public Lapso ReturnedObject { get; private set; }
        public f_EstablecerLapso()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_MediumBackground;
        }
        protected void SetFields(Lapso referenceObject)
        {
            combo_Lapso.SelectedIndex = referenceObject.TipoLapso.Index();

            if (referenceObject.FechaDesde != null) date_FechaDesde.Value = (DateTime)referenceObject.FechaDesde;
            if (referenceObject.FechaHasta != null) date_FechaHasta.Value = (DateTime)referenceObject.FechaHasta;
        }
        protected void SetupReturnedObject()
        {
            Tipo_Lapso tipo_Lapso = EnumHelper.GetEnumFromIndex<Tipo_Lapso>(combo_Lapso.SelectedIndex);

            DateTime? fechaDesde = null;
            if (date_FechaDesde.Enabled) fechaDesde = date_FechaDesde.Value;

            DateTime? fechaHasta = null;
            if (date_FechaHasta.Enabled) fechaHasta = date_FechaHasta.Value;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.TipoLapso = tipo_Lapso;
                ReturnedObject.FechaDesde = fechaDesde;
                ReturnedObject.FechaHasta = fechaHasta;
            }
            else
            {
                ReturnedObject = new Lapso(
                    Guid.NewGuid(),
                    tipo_Lapso,
                    fechaDesde,
                    fechaHasta,
                    AppData.CurrentUser);
            }
        }
        void SetupAll()
        {
            combo_Lapso.DataSource = new Tipo_Lapso().GetDescriptions().Translate().ToList();
            combo_Lapso.SelectedIndex = -1;
        }
        private void but_Establecer_Click(object sender, EventArgs e)
        {
            if (combo_Lapso.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un lapso.");
                return;
            }
            if (EnumHelper.GetEnumFromIndex<Tipo_Lapso>(combo_Lapso.SelectedIndex) == Tipo_Lapso.Intervalo)
            {
                if (date_FechaDesde.Value >= date_FechaHasta.Value)
                {
                    MessageBox.Show("La Fecha Desde es superior o igual a la Fecha Hasta.");
                    return;
                }
            }

            SetupReturnedObject();

            ReferenceObject = null;
            this.DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReferenceObject = null;
            ReturnedObject = null;
            this.DialogResult = DialogResult.Cancel;
        }
        private void f_EstablecerLapso_Load(object sender, EventArgs e)
        {
            SetupAll();
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }

        private void combo_Lapso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Lapso.SelectedIndex == -1) return;

            //Usar enum, no string
            if (EnumHelper.GetEnumFromIndex<Tipo_Lapso>(combo_Lapso.SelectedIndex) == Tipo_Lapso.Intervalo)
            {
                date_FechaDesde.Enabled = true;
                date_FechaHasta.Enabled = true;
            }
            else
            {
                date_FechaDesde.Enabled = false;
                date_FechaHasta.Enabled = false;
            }
        }

        private void f_EstablecerLapso_Shown(object sender, EventArgs e)
        {
            if (ReferenceObject != null)
                new Thread(() => { SetFields(ReferenceObject); }).Start();
        }
    }
}
