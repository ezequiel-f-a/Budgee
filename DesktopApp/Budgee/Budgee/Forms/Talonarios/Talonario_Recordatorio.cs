using Domain;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Recordatorio : f_Talonario<Recordatorio>
    {
        FrecuenciaInicio frecuenciaInicio;
        string PlanificacionLigada;
        public Talonario_Recordatorio()
        {
            InitializeComponent();
            this.Text = "Talonario de Recordatorio";
        }
        public Talonario_Recordatorio(string planificacionLigada)
        {
            InitializeComponent();
            this.Text = "Talonario de Recordatorio";
            PlanificacionLigada = planificacionLigada;
        }
        protected override void SetFields(Recordatorio referenceObject)
        {
            txt_Descripcion.Text = referenceObject.Descripcion;

            frecuenciaInicio = referenceObject.FrecuenciaInicio;

            check_AlarmaWindows.Checked = referenceObject.AlarmaWindows;
            check_NotificacionWindows.Checked = referenceObject.NotificacionWindows;
            check_QuitarAlConcluir.Checked = referenceObject.QuitarAlConcluir;

            RefreshFrecuenciaInicio();
        }
        protected override void SetupReturnedObject()
        {
            string descripcion = txt_Descripcion.Text;

            bool alarmasWindows = check_AlarmaWindows.Checked;
            bool notificacionesWindows = check_NotificacionWindows.Checked;
            bool quitar_al_concluir = (check_QuitarAlConcluir.Enabled) ? check_QuitarAlConcluir.Checked : false;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Descripcion = descripcion;
                ReturnedObject.FrecuenciaInicio = frecuenciaInicio;
                ReturnedObject.AlarmaWindows = alarmasWindows;
                ReturnedObject.NotificacionWindows = notificacionesWindows;
                ReturnedObject.QuitarAlConcluir = quitar_al_concluir;
            }
            else
            {
                ReturnedObject = new Recordatorio(
                    Guid.NewGuid(),
                    descripcion,
                    frecuenciaInicio,
                    alarmasWindows,
                    notificacionesWindows,
                    quitar_al_concluir,
                    true,
                    true,
                    AppData.CurrentUser);
            }
        }
        void RefreshFrecuenciaInicio()
        {
            txt_FrecuenciaInicio.Text = SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(frecuenciaInicio);

            if (ViewOnly) return;

            check_QuitarAlConcluir.Enabled = (frecuenciaInicio.FrecuenciaMagnitud == null);
        }
        void RefreshPlanificacionLigada()
        {
            try
            {
                if (ReferenceObject != null)
                {
                    var planificacionLigada = BLL.Services.PlanificacionService.Current.GetAll(x => x.RecordatorioLigado?.ID_Recordatorio == ReferenceObject.ID_Recordatorio).FirstOrDefault();
                    if (planificacionLigada != null)
                        PlanificacionLigada = planificacionLigada.Descripcion;
                }

                string valor = "N/A";

                if (PlanificacionLigada != null) valor = $"\"{PlanificacionLigada}\"";

                lbl_LigadoAPlanificacion.Text = $"{"Ligado a Planificación".Translate()}: {valor}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        protected override void ClearCustomAttributes()
        {
            frecuenciaInicio = null;
            PlanificacionLigada = null;
            base.ClearCustomAttributes();
        }
        private void but_FrecuenciaInicio_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new f_EstablecerFrecuenciaInicio();

            f_seleccionar.ReferenceObject = frecuenciaInicio;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                frecuenciaInicio = f_seleccionar.ReturnedObject;
                RefreshFrecuenciaInicio();
            }
        }
        private void but_Aceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckCamposCompletados()) return;

                if (but_FrecuenciaInicio.Enabled && frecuenciaInicio == null)
                {
                    MessageBox.Show("Falta establecer la frecuencia e inicio.".Translate());
                    return;
                }
                if (BLL.Services.RecordatorioService.Current.GetAll(x => x.Descripcion == txt_Descripcion.Text && x.Estado == true).Count() > 0)
                {
                    if (ReferenceObject == null || ReferenceObject.Descripcion != txt_Descripcion.Text)
                    {
                        MessageBox.Show("El nombre ya existe.".Translate());
                        return;
                    }
                }

                SetupReturnedObject();

                ReferenceObject = null;
                ClearCustomAttributes();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void Talonario_Recordatorio_Shown(object sender, EventArgs e)
        {
            RefreshPlanificacionLigada();
        }
    }
}
