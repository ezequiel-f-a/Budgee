using Domain;
using Enums;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Presupuesto : f_Talonario<Presupuesto>
    {
        FrecuenciaInicio lapsoPresupuesto;
        Variable variableSupervisada;
        Expresion condicionExpresion;
        public Talonario_Presupuesto()
        {
            InitializeComponent();
            this.Text = "Talonario de Presupuesto";
            SetupAll();
        }
        protected override void SetFields(Presupuesto referenceObject)
        {
            txt_Descripcion.Text = referenceObject.Descripcion;

            lapsoPresupuesto = referenceObject.LapsoPresupuesto;
            variableSupervisada = referenceObject.VariableSupervisada;
            condicionExpresion = referenceObject.CondicionExpresion;

            check_AlarmaWindows.Checked = referenceObject.AlarmaWindows;
            check_NotificacionWindows.Checked = referenceObject.NotificacionWindows;

            combo_CuandoChequear.SelectedIndex = referenceObject.CuandoChequear.Index();
            combo_OperadorRelacional.SelectedIndex = referenceObject.OperadorRelacional.Index();

            RefreshLapsoPresupuesto();
            RefreshVariableSuperVisada();
            RefreshCondicionExpresion();
        }
        protected override void SetupReturnedObject()
        {
            string descripcion = txt_Descripcion.Text;

            Cuando_Chequear cuando_Chequear = EnumHelper.GetEnumFromIndex<Cuando_Chequear>(combo_CuandoChequear.SelectedIndex);

            Operador_Relacional operador_Relacional = EnumHelper.GetEnumFromIndex<Operador_Relacional>(combo_OperadorRelacional.SelectedIndex);

            if (condicionExpresion == null)
            {
                Guid id;
                if (ReferenceObject?.CondicionExpresion == null) id = Guid.NewGuid();
                else id = ReferenceObject.CondicionExpresion.ID_Expresion;

                condicionExpresion = new Expresion(id, txt_ValorCondicion.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);
            }
            else if (txt_ValorCondicion.Text != condicionExpresion.Definicion) condicionExpresion = new Expresion(condicionExpresion.ID_Expresion, txt_ValorCondicion.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);

            bool alarmasWindows = check_AlarmaWindows.Checked;
            bool notificacionesWindows = check_NotificacionWindows.Checked;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Descripcion = descripcion;
                ReturnedObject.LapsoPresupuesto = lapsoPresupuesto;
                ReturnedObject.VariableSupervisada = variableSupervisada;
                ReturnedObject.CondicionExpresion = condicionExpresion;
                ReturnedObject.CuandoChequear = cuando_Chequear;
                ReturnedObject.OperadorRelacional = operador_Relacional;
                ReturnedObject.AlarmaWindows = alarmasWindows;
                ReturnedObject.NotificacionWindows = notificacionesWindows;
            }
            else
            {
                ReturnedObject = new Presupuesto(
                    Guid.NewGuid(),
                    descripcion,
                    variableSupervisada,
                    condicionExpresion,
                    operador_Relacional,
                    lapsoPresupuesto,
                    cuando_Chequear,
                    alarmasWindows,
                    notificacionesWindows,
                    true,
                    true,
                    AppData.CurrentUser);
            }
        }
        void RefreshLapsoPresupuesto()
        {
            if (lapsoPresupuesto != null)
                txt_LapsoPresupuesto.Text = SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(lapsoPresupuesto);
            else
                txt_LapsoPresupuesto.Text = "";

            if (ViewOnly) return;
        }
        void RefreshVariableSuperVisada()
        {
            if (variableSupervisada != null)
            {
                txt_Supervisa.Text = BLL.Services.VariableService.Current.GetDescription(variableSupervisada);
            }
            else txt_Supervisa.Text = "";
        }
        void RefreshCondicionExpresion()
        {
            txt_ValorCondicion.AllowText = true;

            if (condicionExpresion != null)
            {
                txt_ValorCondicion.MaxLength = 500;
                txt_ValorCondicion.Text = condicionExpresion.Definicion;
            }
            else
                txt_ValorCondicion.MaxLength = 10;


            txt_ValorCondicion.AllowText = false;

            if (ViewOnly) return;

            if (condicionExpresion?.Tipo_Expresion == Tipo_Expresion.Calculada) txt_ValorCondicion.ReadOnly = true;
            else txt_ValorCondicion.ReadOnly = false;
        }
        protected override void ClearCustomAttributes()
        {
            lapsoPresupuesto = null;
            variableSupervisada = null;
            condicionExpresion = null;
            
            base.ClearCustomAttributes();
        }
        void SetupAll()
        {
            combo_CuandoChequear.DataSource = new Cuando_Chequear().GetDescriptions().Translate().ToList();
            combo_OperadorRelacional.DataSource = new Operador_Relacional().GetDescriptions().Translate().ToList();

            combo_CuandoChequear.SelectedIndex = -1;
            combo_OperadorRelacional.SelectedIndex = -1;
        }
        private void combo_CuandoChequear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_CuandoChequear.SelectedIndex == -1) return;

            Cuando_Chequear selec = EnumHelper.GetEnumFromIndex<Cuando_Chequear>(combo_CuandoChequear.SelectedIndex);

            if (selec == Cuando_Chequear.Constantemente)
            {
                lbl_LapsoPresupuesto.Enabled = false;
                txt_LapsoPresupuesto.Enabled = false;
                but_LapsoPresupuesto.Enabled = false;
                lapsoPresupuesto = null;
            }
            else
            {
                lbl_LapsoPresupuesto.Enabled = true;
                txt_LapsoPresupuesto.Enabled = true;
                but_LapsoPresupuesto.Enabled = true;
            }

            RefreshLapsoPresupuesto();
        }
        private void but_LapsoPresupuesto_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new f_EstablecerFrecuenciaInicio(true);

            f_seleccionar.ReferenceObject = lapsoPresupuesto;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                lapsoPresupuesto = f_seleccionar.ReturnedObject;
                RefreshLapsoPresupuesto();
            }
        }
        private void but_Supervisa_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new f_EstablecerVariable(false);

            f_seleccionar.ReferenceObject = variableSupervisada;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                variableSupervisada = f_seleccionar.ReturnedObject;
                RefreshVariableSuperVisada();
            }
        }
        private void but_ValorCondición_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new f_EstablecerExpresion();

            f_seleccionar.ReferenceObject = condicionExpresion;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                condicionExpresion = f_seleccionar.ReturnedObject;
                RefreshCondicionExpresion();
            }
        }
        private void but_Aceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckCamposCompletados()) return;
                if (but_Supervisa.Enabled && variableSupervisada == null)
                {
                    MessageBox.Show("Falta establecer la variable supervisada.".Translate());
                    return;
                }
                if (but_ValorCondición.Enabled && condicionExpresion == null && string.IsNullOrEmpty(txt_ValorCondicion.Text))
                {
                    MessageBox.Show("Falta establecer la condición.".Translate());
                    return;
                }
                if (but_LapsoPresupuesto.Enabled && lapsoPresupuesto == null)
                {
                    MessageBox.Show("Falta establecer el lapso del presupuesto.".Translate());
                    return;
                }
                if (BLL.Services.PresupuestoService.Current.GetAll(x => x.Descripcion == txt_Descripcion.Text && x.Estado == true).Count() > 0)
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
        private void Talonario_Presupuesto_Shown(object sender, EventArgs e)
        {
            SetupAll();
        }
    }
}
