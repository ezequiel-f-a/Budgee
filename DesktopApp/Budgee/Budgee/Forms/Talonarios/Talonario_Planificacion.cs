using Domain;
using Enums;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Forms.SeleccionarElems;

namespace UI.Forms.Talonarios
{
    public partial class Talonario_Planificacion : f_Talonario<Planificacion>
    {
        List<Caracteristica> etiquetas = new List<Caracteristica>();
        Expresion montoExpresion;
        FrecuenciaInicio frecuenciaInicio;
        Recordatorio recordatorio;
        Tipo_Operacion? combo_TipoOperacion_prev_value = null;
        public Talonario_Planificacion()
        {
            InitializeComponent();
            this.Text = "Talonario de Planificación";
        }
        protected override void SetFields(Planificacion referenceObject)
        {
            SetDisponibles();

            txt_DescripcionPlanificacion.Text = referenceObject.Descripcion;
            txt_DescripcionTransaccion.Text = referenceObject.Descripcion_Transaccion;
            combo_Cuenta.SelectedIndex = CuentasDisponibles.Select(x => x.ID_Cuenta).ToList().IndexOf(referenceObject.Cuenta.ID_Cuenta);

            if (referenceObject.Categoria != null) combo_Categoria.SelectedIndex = CategoriasDisponibles.Select(x => x.ID_Caracteristica).ToList().IndexOf(referenceObject.Categoria.ID_Caracteristica);
            check_Categoria.Checked = (referenceObject.Categoria != null);

            etiquetas = referenceObject.Etiquetas.ToList();

            recordatorio = referenceObject.RecordatorioLigado;

            check_GenerarRecordatorio.CheckedChanged -= check_GenerarRecordatorio_CheckedChanged;
            check_GenerarRecordatorio.Checked = (recordatorio != null);
            check_GenerarRecordatorio.CheckedChanged += check_GenerarRecordatorio_CheckedChanged;

            montoExpresion = referenceObject.MontoExpresion;
            frecuenciaInicio = referenceObject.FrecuenciaInicio;

            if (referenceObject.TipoOperacion != null) combo_TipoOperacion.SelectedIndex = ((Tipo_Operacion)referenceObject.TipoOperacion).Index();

            RefreshEtiquetas();
            RefreshMontoExpresion();
            RefreshFrecuenciaInicio();
        }
        void SetFieldsFromPlantilla(PlantillaTransaccion plantilla)
        {
            ClearCustomAttributes();
            ClearFields();

            SetDisponibles();

            txt_DescripcionPlanificacion.Text = plantilla.Descripcion_Transaccion;
            txt_DescripcionTransaccion.Text = plantilla.Descripcion_Transaccion;

            //combo_Cuenta.SelectedIndex = CuentasDisponibles.Select(x => x.ID_Cuenta).ToList().IndexOf(plantilla.Cuenta.ID_Cuenta);

            if (plantilla.Categoria != null) combo_Categoria.SelectedIndex = CategoriasDisponibles.Select(x => x.ID_Caracteristica).ToList().IndexOf(plantilla.Categoria.ID_Caracteristica);
            check_Categoria.Checked = (plantilla.Categoria != null);

            if (plantilla.Etiquetas != null) etiquetas = plantilla.Etiquetas.ToList();

            montoExpresion = plantilla.MontoExpresion;
            if (montoExpresion == null) txt_Monto.Text = "";
            else montoExpresion.ID_Expresion = Guid.NewGuid();

            if (plantilla.TipoOperacion != null) combo_TipoOperacion.SelectedIndex = ((Tipo_Operacion)plantilla.TipoOperacion).Index();

            RefreshEtiquetas();
            RefreshMontoExpresion();
        }
        protected override void SetupReturnedObject()
        {
            string descripcionPlanificacion = txt_DescripcionPlanificacion.Text;
            string descripcionTransaccion = txt_DescripcionTransaccion.Text;
            Cuenta cuenta = CuentasDisponibles[combo_Cuenta.SelectedIndex];

            Caracteristica categoria = null;
            if (combo_Categoria.Enabled) categoria = CategoriasDisponibles[combo_Categoria.SelectedIndex];

            if (montoExpresion == null)
            {
                Guid id;
                if (ReferenceObject?.MontoExpresion == null) id = Guid.NewGuid();
                else id = ReferenceObject.MontoExpresion.ID_Expresion;

                montoExpresion = new Expresion(id, txt_Monto.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);
            }
            else if (EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex) != Tipo_Operacion.Variable) montoExpresion = new Expresion(montoExpresion.ID_Expresion, txt_Monto.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);

            Tipo_Operacion? tipo_Operacion = null;
            if (combo_TipoOperacion.SelectedIndex != -1) tipo_Operacion = EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex);

            bool quitar_al_concluir = (check_QuitarAlConcluir.Enabled) ? check_QuitarAlConcluir.Checked : false;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Descripcion = descripcionPlanificacion;
                ReturnedObject.Descripcion_Transaccion = descripcionTransaccion;
                ReturnedObject.Cuenta = cuenta;
                ReturnedObject.Categoria = categoria;
                ReturnedObject.Etiquetas = etiquetas.ToList();
                ReturnedObject.TipoOperacion = tipo_Operacion;
                ReturnedObject.MontoExpresion = montoExpresion;
                ReturnedObject.FrecuenciaInicio = frecuenciaInicio;
                ReturnedObject.QuitarAlConcluir = quitar_al_concluir;
            }
            else
            {
                ReturnedObject = new Planificacion(
                    Guid.NewGuid(),
                    descripcionPlanificacion,
                    descripcionTransaccion,
                    categoria,
                    etiquetas.ToList(),
                    montoExpresion,
                    tipo_Operacion,
                    cuenta,
                    frecuenciaInicio,
                    recordatorio,
                    quitar_al_concluir,
                    true,
                    true);
            }
        }
        void SetupAll()
        {
            combo_TipoOperacion.SelectedIndexChanged -= combo_TipoOperacion_SelectedIndexChanged;
            combo_TipoOperacion.DataSource = new Tipo_Operacion().GetDescriptions().Translate().ToList();
            combo_TipoOperacion.SelectedIndex = -1;
            combo_TipoOperacion.SelectedIndexChanged += combo_TipoOperacion_SelectedIndexChanged;
        }
        void RefreshMontoExpresion()
        {
            txt_Monto.AllowText = true;

            if (montoExpresion != null)
                txt_Monto.Text = montoExpresion.Definicion;

            txt_Monto.AllowText = false;

            if (ViewOnly) return;

            if (montoExpresion?.Tipo_Expresion == Tipo_Expresion.Calculada) txt_Monto.ReadOnly = true;
            else txt_Monto.ReadOnly = false;
        }
        void RefreshFrecuenciaInicio()
        {
            txt_FrecuenciaInicio.Text = SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(frecuenciaInicio);
            check_QuitarAlConcluir.Enabled = (frecuenciaInicio.FrecuenciaMagnitud == null);
        }
        void RefreshEtiquetas()
        {
            grid_Etiquetas.DataSource = null;
            grid_Etiquetas.DataSource = etiquetas.Select(x => new { Nombre = x.Nombre, Color = (x.Color == null) ? null : ((ColorBasico)((Color)x.Color).ToColorBasico()).GetDescription().Translate() }).ToList();
            grid_Etiquetas.SetupLanguageForDataGridView();
            grid_Etiquetas.ClearSelection();
        }
        void SetDisponibles()
        {
            if (combo_Categoria.DataSource == null) combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Cuenta.DataSource == null) combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
        }
        protected override void ClearCustomAttributes()
        {
            montoExpresion = null;
            frecuenciaInicio = null;
            recordatorio = null;
            etiquetas.Clear();
            base.ClearCustomAttributes();
        }
        private void but_CargarDesdePlantilla_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new SeleccionarElem_Plantilla();

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                SetFieldsFromPlantilla(f_seleccionar.ReturnedObject);
                RefreshEtiquetas();
            }
        }
        private void but_GuardarComoPlantilla_Click(object sender, System.EventArgs e)
        {
            Cuenta cuenta = null;
            if (combo_Cuenta.Enabled && combo_Cuenta.SelectedIndex != -1) cuenta = CuentasDisponibles[combo_Cuenta.SelectedIndex];

            Caracteristica categoria = null;
            if (combo_Categoria.Enabled && combo_Categoria.SelectedIndex != -1) categoria = CategoriasDisponibles[combo_Categoria.SelectedIndex];

            var montoExpr = montoExpresion;
            if (montoExpr == null)
            {
                Guid id;
                if (ReferenceObject?.MontoExpresion == null) id = Guid.NewGuid();
                else id = ReferenceObject.MontoExpresion.ID_Expresion;

                montoExpr = new Expresion(id, txt_Monto.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);
            }
            else if (EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex) != Tipo_Operacion.Variable) montoExpr = new Expresion(montoExpresion.ID_Expresion, txt_Monto.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);

            Tipo_Operacion? tipo_Operacion = null;
            if (combo_TipoOperacion.SelectedIndex != -1) tipo_Operacion = EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex);

            var plantilla = new PlantillaTransaccion(
                Guid.NewGuid(),
                txt_DescripcionPlanificacion.Text,
                txt_DescripcionPlanificacion.Text,
                categoria,
                etiquetas.ToList(),
                montoExpr,
                tipo_Operacion,
                AppData.CurrentUser,
                true
                );

            var talonario = new Talonario_Plantilla() { ReferenceObject = plantilla };
            if (talonario.ShowDialog() == DialogResult.OK)
                BLL.Services.PlantillaTransaccionService.Current.Add(talonario.ReturnedObject);
        }
        private void but_Monto_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new f_EstablecerExpresion();

            f_seleccionar.ReferenceObject = montoExpresion;
            f_seleccionar.ExceptObject = ReferenceObject?.ID_Planificacion;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                montoExpresion = f_seleccionar.ReturnedObject;
                RefreshMontoExpresion();
            }
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
        private void but_AgregarEtiqueta_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new SeleccionarElem_Etiqueta(etiquetas);

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                etiquetas.Add(f_seleccionar.ReturnedObject);
                RefreshEtiquetas();
            }
        }
        private void but_RemoverEtiqueta_Click(object sender, System.EventArgs e)
        {
            if (grid_Etiquetas.SelectedRows.Count == 0) return;
            etiquetas.Remove(etiquetas[grid_Etiquetas.CurrentCell.RowIndex]);
            RefreshEtiquetas();
        }
        private void combo_TipoOperacion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ViewOnly) return;
            if (combo_TipoOperacion.SelectedIndex == -1) return;

            if ((Tipo_Operacion)combo_TipoOperacion.SelectedIndex == Tipo_Operacion.Variable)
            {
                txt_Monto.MaxLength = 500;
                txt_Monto.Enabled = false;
                but_Monto.Enabled = true;
            }
            else
            {
                if (montoExpresion != null && montoExpresion.Tipo_Expresion != Tipo_Expresion.Fija)
                {
                    montoExpresion = null;
                    RefreshMontoExpresion();
                }

                txt_Monto.Enabled = true;
                but_Monto.Enabled = false;
                txt_Monto.MaxLength = 10;
            }

            if (combo_TipoOperacion_prev_value != null)
            {
                bool tipoOp_changed = false;

                if (combo_TipoOperacion_prev_value != Tipo_Operacion.Variable && (Tipo_Operacion)combo_TipoOperacion.SelectedIndex == Tipo_Operacion.Variable)
                    tipoOp_changed = true;
                else if (combo_TipoOperacion_prev_value == Tipo_Operacion.Variable && (Tipo_Operacion)combo_TipoOperacion.SelectedIndex != Tipo_Operacion.Variable)
                    tipoOp_changed = true;

                if (tipoOp_changed)
                {
                    montoExpresion = null;
                    txt_Monto.Text = "";
                    RefreshMontoExpresion();
                }
            }

            combo_TipoOperacion_prev_value = (Tipo_Operacion)combo_TipoOperacion.SelectedIndex;
        }
        private void combo_Cuenta_DropDown(object sender, System.EventArgs e)
        {
            int index = combo_Cuenta.SelectedIndex;
            int count = combo_Cuenta.Items.Count;
            combo_Cuenta.DataSource = null;
            combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
            if (combo_Cuenta.Items.Count == count) combo_Cuenta.SelectedIndex = index;
        }
        private void combo_Categoria_DropDown(object sender, System.EventArgs e)
        {
            int index = combo_Categoria.SelectedIndex;
            int count = combo_Categoria.Items.Count;
            combo_Categoria.DataSource = null;
            combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Categoria.Items.Count == count) combo_Categoria.SelectedIndex = index;
        }
        private void check_Categoria_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ViewOnly) return;
            combo_Categoria.Enabled = check_Categoria.Checked;
        }
        private void check_GenerarRecordatorio_CheckedChanged(object sender, EventArgs e)
        {
            if (check_GenerarRecordatorio.Checked)
            {
                var talonario = new Talonario_Recordatorio(txt_DescripcionPlanificacion.Text);
                talonario.ViewOnly = this.ViewOnly;
                talonario.ReferenceObject = recordatorio ?? new Recordatorio(
                    Guid.NewGuid(),
                    txt_DescripcionPlanificacion.Text,
                    frecuenciaInicio,
                    false,
                    false,
                    check_QuitarAlConcluir.Checked,
                    true,
                    true,
                    AppData.CurrentUser);

                if (talonario.ShowDialog() == DialogResult.OK)
                    recordatorio = talonario.ReturnedObject;
                else
                {
                    check_GenerarRecordatorio.CheckedChanged -= check_GenerarRecordatorio_CheckedChanged;
                    check_GenerarRecordatorio.Checked = false;
                    check_GenerarRecordatorio.CheckedChanged += check_GenerarRecordatorio_CheckedChanged;
                }
            }
            else
            {
                var dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el recordatorio ligado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel);

                if (dialogResult != DialogResult.OK)
                {
                    check_GenerarRecordatorio.CheckedChanged -= check_GenerarRecordatorio_CheckedChanged;
                    check_GenerarRecordatorio.Checked = true;
                    check_GenerarRecordatorio.CheckedChanged += check_GenerarRecordatorio_CheckedChanged;
                }
                else
                    recordatorio = null;
            }
        }
        private void but_Aceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckCamposCompletados()) return;
                if (but_Monto.Enabled && montoExpresion == null)
                {
                    MessageBox.Show("Falta establecer el monto.".Translate());
                    return;
                }
                if (but_FrecuenciaInicio.Enabled && frecuenciaInicio == null)
                {
                    MessageBox.Show("Falta establecer la frecuencia e inicio.".Translate());
                    return;
                }
                if (BLL.Services.PlanificacionService.Current.GetAll(x => x.Descripcion == txt_DescripcionPlanificacion.Text && x.Estado == true).Count() > 0)
                {
                    if (ReferenceObject == null || ReferenceObject.Descripcion != txt_DescripcionPlanificacion.Text)
                    {
                        MessageBox.Show("El nombre ya existe.".Translate());
                        return;
                    }
                }

                SetupReturnedObject();

                if (ReferenceObject?.RecordatorioLigado != null && recordatorio == null)
                    BLL.Services.RecordatorioService.Current.Remove(ReferenceObject.RecordatorioLigado);
                else if (recordatorio != null)
                    BLL.Services.RecordatorioService.Current.AddOrUpdate(recordatorio);

                ReferenceObject = null;
                ClearCustomAttributes();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void Talonario_Planificacion_Shown(object sender, System.EventArgs e)
        {
            SetupAll();
        }
    }
}
