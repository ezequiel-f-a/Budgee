using Domain;
using Enums;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UI.Forms.SeleccionarElems;

namespace UI.Forms
{
    public partial class f_EstablecerVariableDetalle1 : Form
    {
        Variable_Target[] targets = new Variable_Target[] {
                Variable_Target.Transaccion,
                Variable_Target.Planificacion,
                Variable_Target.Plantilla };

        GenericTransaccion Object;
        public Guid? ExceptObject { get; set; }

        public GenericTransaccion ReturnedObject { get; private set; }
        public f_EstablecerVariableDetalle1()
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_MediumBackground;
            SetupAll();
        }
        void SetupAll()
        {
            combo_EnFuncionDe.SelectedIndexChanged -= combo_EnFuncionDe_SelectedIndexChanged;
            combo_EnFuncionDe.DataSource = targets.Select(x=>x.GetDescription().Translate()).ToList();
            combo_EnFuncionDe.SelectedIndex = -1;
            combo_EnFuncionDe.SelectedIndexChanged += combo_EnFuncionDe_SelectedIndexChanged;
        }
        private void combo_EnFuncionDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_EnFuncionDe.SelectedIndex == targets.ToList().IndexOf(Variable_Target.Transaccion))
            {
                var f_seleccionar = new SeleccionarElem_Transaccion(except: ExceptObject);
                if(f_seleccionar.ShowDialog() == DialogResult.OK)
                {
                    Object = f_seleccionar.ReturnedObject;
                }
            }
            else if (combo_EnFuncionDe.SelectedIndex == targets.ToList().IndexOf(Variable_Target.Planificacion))
            {
                var f_seleccionar = new SeleccionarElem_Planificacion(except: ExceptObject);
                if (f_seleccionar.ShowDialog() == DialogResult.OK)
                {
                    Object = f_seleccionar.ReturnedObject;
                }
            }
            else if (combo_EnFuncionDe.SelectedIndex == targets.ToList().IndexOf(Variable_Target.Plantilla))
            {
                var f_seleccionar = new SeleccionarElem_Plantilla(except: ExceptObject);
                if (f_seleccionar.ShowDialog() == DialogResult.OK)
                {
                    Object = f_seleccionar.ReturnedObject;
                }
            }

            if (Object == null) combo_EnFuncionDe.SelectedIndex = -1;
            else lbl_Detalle.Text = Object.Descripcion;
        }
        private void but_Establecer_Click(object sender, EventArgs e)
        {
            if(combo_EnFuncionDe.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un elemento.".Translate());
                return;
            }

            ReturnedObject = Object;

            this.DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReturnedObject = null;
            Object = null;

            this.DialogResult = DialogResult.Cancel;
        }
        private void f_EstablecerVariableDetalle1_Load(object sender, EventArgs e)
        {
            new Thread(() => this.SetupLanguageForContainer()).Start();
        }
    }
}
