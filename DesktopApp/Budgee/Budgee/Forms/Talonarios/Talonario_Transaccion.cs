using Domain;
using Enums;
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
    public partial class Talonario_Transaccion : f_Talonario<Transaccion>
    {
        string[] enumTipoMonto = new string[] { "Fijo", "Calculado" };
        Tipo_Operacion? combo_TipoOperacion_prev_value = null;

        List<Caracteristica> etiquetas = new List<Caracteristica>();
        Expresion montoExpresion;
        public Talonario_Transaccion(bool concretada = false)
        {
            InitializeComponent();
            this.Text = "Talonario de Transacción";
            check_Concretada.Checked = concretada;
        }
        protected override void SetFields(Transaccion referenceObject)
        {
            SetDisponibles();

            txt_Descripcion.Text = referenceObject.Descripcion;

            combo_Cuenta.SelectedIndex = CuentasDisponibles.Select(x => x.ID_Cuenta).ToList().IndexOf(referenceObject.Cuenta.ID_Cuenta);

            if (referenceObject.Categoria != null) combo_Categoria.SelectedIndex = CategoriasDisponibles.Select(x => x.ID_Caracteristica).ToList().IndexOf(referenceObject.Categoria.ID_Caracteristica);
            check_Categoria.Checked = (referenceObject.Categoria != null);

            etiquetas = referenceObject.Etiquetas.ToList();
            check_Concretada.Checked = referenceObject.Concretada;
            montoExpresion = referenceObject.MontoExpresion;

            if (referenceObject.TipoOperacion != null) combo_TipoOperacion.SelectedIndex = ((Tipo_Operacion)referenceObject.TipoOperacion).Index();

            if (referenceObject.Fecha != null)
            {
                date_FechaTransaccion.Value = (DateTime)referenceObject.Fecha;
                check_Fecha.Checked = true;
            }
            else
            {
                check_Fecha.Checked = false;
            }

            RefreshEtiquetas();
            RefreshMontoExpresion();
        }
        void SetFieldsFromPlantilla(PlantillaTransaccion plantilla)
        {
            ClearCustomAttributes();
            ClearFields();

            SetDisponibles();

            txt_Descripcion.Text = plantilla.Descripcion_Transaccion;

            //combo_Cuenta.SelectedIndex = CuentasDisponibles.Select(x => x.ID_Cuenta).ToList().IndexOf(plantilla.Cuenta.ID_Cuenta);

            if (plantilla.Categoria != null) combo_Categoria.SelectedIndex = CategoriasDisponibles.Select(x => x.ID_Caracteristica).ToList().IndexOf(plantilla.Categoria.ID_Caracteristica);
            check_Categoria.Checked = (plantilla.Categoria != null);

            if (plantilla.Etiquetas != null) etiquetas = plantilla.Etiquetas.ToList();

            montoExpresion = plantilla.MontoExpresion;
            if(montoExpresion == null) txt_Monto.Text = "";
            else montoExpresion.ID_Expresion = Guid.NewGuid();

            if (plantilla.TipoOperacion != null) combo_TipoOperacion.SelectedIndex = ((Tipo_Operacion)plantilla.TipoOperacion).Index();

            RefreshEtiquetas();
            RefreshMontoExpresion();
        }
        protected override void SetupReturnedObject()
        {
            string descripcion = txt_Descripcion.Text;
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

            DateTime? fechaTransaccion = null;
            if (date_FechaTransaccion.Enabled) fechaTransaccion = date_FechaTransaccion.Value;

            Tipo_Operacion? tipo_Operacion = null;
            if (combo_TipoOperacion.SelectedIndex != -1) tipo_Operacion = EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex);

            bool concretada = check_Concretada.Checked;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Descripcion = descripcion;
                ReturnedObject.Cuenta = cuenta;
                ReturnedObject.Categoria = categoria;
                ReturnedObject.Etiquetas = etiquetas.ToList();
                ReturnedObject.MontoExpresion = montoExpresion;
                ReturnedObject.Fecha = fechaTransaccion;
                ReturnedObject.TipoOperacion = tipo_Operacion;
                ReturnedObject.Concretada = concretada;
            }
            else
            {
                ReturnedObject = new Transaccion(
                    Guid.NewGuid(),
                    fechaTransaccion,
                    cuenta,
                    concretada,
                    descripcion,
                    categoria,
                    etiquetas.ToList(),
                    montoExpresion,
                    tipo_Operacion,
                    true);
            }
        }
        protected override void ClearCustomAttributes()
        {
            montoExpresion = null;
            etiquetas.Clear();
            combo_TipoOperacion_prev_value = null;
            base.ClearCustomAttributes();
        }
        void RefreshEtiquetas()
        {
            grid_Etiquetas.DataSource = null;
            grid_Etiquetas.DataSource = etiquetas.Select(x => new { Nombre = x.Nombre, Color = (x.Color == null) ? null : ((ColorBasico)((Color)x.Color).ToColorBasico()).GetDescription().Translate() }).ToList();
            grid_Etiquetas.SetupLanguageForDataGridView();
            grid_Etiquetas.ClearSelection();
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
        void SetupAll()
        {
            SetupCheckFecha();

            combo_TipoOperacion.SelectedIndexChanged -= combo_TipoOperacion_SelectedIndexChanged;
            combo_TipoOperacion.DataSource = new Tipo_Operacion().GetDescriptions().Translate().ToList();
            combo_TipoOperacion.SelectedIndex = -1;
            combo_TipoOperacion.SelectedIndexChanged += combo_TipoOperacion_SelectedIndexChanged;
        }
        void SetupCheckFecha()
        {
            if (ViewOnly)
            {
                check_Fecha.Visible = false;
                return;
            }

            check_Fecha.Visible = !check_Concretada.Checked;

            if (!check_Fecha.Visible)
            {
                date_FechaTransaccion.Enabled = true;
                lbl_FechaTransaccion.Enabled = true;
            }
            else
            {
                date_FechaTransaccion.Enabled = check_Fecha.Checked;
                lbl_FechaTransaccion.Enabled = check_Fecha.Checked;
            }
        }
        bool CheckFondosInsuficientes()
        {
            try
            {
                bool fondos_insuficientes = false;

                if (!ReturnedObject.Cuenta.AdmiteFondosNegativos)
                {
                    if (ReturnedObject.Concretada)
                    {
                        if (BLL.Services.TransaccionService.Current.Check_FondosNegativos(ReturnedObject))
                            fondos_insuficientes = true;
                    }
                    else if (!ReturnedObject.Concretada && ReferenceObject != null && ReferenceObject.Concretada)
                    {
                        if (BLL.Services.TransaccionService.Current.Check_FondosNegativos(ReturnedObject))
                            fondos_insuficientes = true;
                    }
                }

                return fondos_insuficientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
                throw;
            }
        }
        void SetDisponibles()
        {
            if (combo_Categoria.DataSource == null) combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Cuenta.DataSource == null) combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
        }
        private void but_CargarDesdePlantilla_Click(object sender, EventArgs e)
        {
            var f_seleccionar = new SeleccionarElem_Plantilla();

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                SetFieldsFromPlantilla(f_seleccionar.ReturnedObject);
                RefreshEtiquetas();
            }
        }
        private void but_GuardarComoPlantilla_Click(object sender, EventArgs e)
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
                txt_Descripcion.Text,
                txt_Descripcion.Text,
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
        private void but_AgregarEtiqueta_Click(object sender, EventArgs e)
        {
            var f_seleccionar = new SeleccionarElem_Etiqueta(etiquetas);

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                etiquetas.Add(f_seleccionar.ReturnedObject);
                RefreshEtiquetas();
            }
        }
        private void but_RemoverEtiqueta_Click(object sender, EventArgs e)
        {
            if (grid_Etiquetas.SelectedRows.Count == 0) return;
            etiquetas.Remove(etiquetas[grid_Etiquetas.CurrentCell.RowIndex]);
            RefreshEtiquetas();
        }
        private void but_Monto_Click(object sender, EventArgs e)
        {
            var f_seleccionar = new f_EstablecerExpresion();

            f_seleccionar.ReferenceObject = montoExpresion;
            f_seleccionar.ExceptObject = ReferenceObject?.ID_Transaccion;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                montoExpresion = f_seleccionar.ReturnedObject;
                RefreshMontoExpresion();
            }
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

            if(combo_TipoOperacion_prev_value != null)
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
        private void Combo_Cuenta_DropDown(object sender, EventArgs e)
        {
            int index = combo_Cuenta.SelectedIndex;
            int count = combo_Cuenta.Items.Count;
            combo_Cuenta.DataSource = null;
            combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
            if (combo_Cuenta.Items.Count == count) combo_Cuenta.SelectedIndex = index;
        }
        private void Combo_Categoria_DropDown(object sender, EventArgs e)
        {
            int index = combo_Categoria.SelectedIndex;
            int count = combo_Categoria.Items.Count;
            combo_Categoria.DataSource = null;
            combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Categoria.Items.Count == count) combo_Categoria.SelectedIndex = index;
        }
        private void check_Categoria_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewOnly) return;
            combo_Categoria.Enabled = check_Categoria.Checked;
        }
        private void check_Concretada_CheckedChanged(object sender, EventArgs e)
        {
            SetupCheckFecha();
        }
        private void check_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            SetupCheckFecha();
        }
        private void date_FechaTransaccion_ValueChanged(object sender, EventArgs e)
        {
            if (date_FechaTransaccion.Value > DateTime.Now && check_Concretada.Checked)
            {
                MessageBox.Show("La fecha y hora de una transacción concretada no puede ser futura.".Translate());
                date_FechaTransaccion.Value = DateTime.Now;
            }
        }
        private void but_Aceptar_Click(object sender, EventArgs e)
        {
            if (!CheckCamposCompletados()) return;

            if (but_Monto.Enabled && montoExpresion == null)
            {
                MessageBox.Show("Falta establecer el monto.".Translate());
                return;
            }

            SetupReturnedObject();

            if (CheckFondosInsuficientes())
            {
                MessageBox.Show(new BLL.BusinessExceptions.FondosInsuficientesException().Message);
                ReturnedObject = null;
                return;
            }

            ReferenceObject = null;
            ClearCustomAttributes();
            DialogResult = DialogResult.OK;
        }
        private void Talonario_Transaccion_Shown(object sender, EventArgs e)
        {
            SetupAll();
        }
    }
}
