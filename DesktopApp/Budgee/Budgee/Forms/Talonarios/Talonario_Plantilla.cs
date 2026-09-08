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
    public partial class Talonario_Plantilla : f_Talonario<PlantillaTransaccion>
    {
        string[] enumTipoMonto = new string[] { "Fijo", "Calculado" };

        List<Caracteristica> etiquetas = new List<Caracteristica>();
        Expresion montoExpresion;
        Tipo_Operacion? combo_TipoOperacion_prev_value = null;
        public Talonario_Plantilla()
        {
            InitializeComponent();
            this.Text = "Talonario de Plantilla";
            SetupAll();
        }
        protected override void SetFields(PlantillaTransaccion referenceObject)
        {
            if (combo_Categoria.DataSource == null) combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;

            txt_DescripcionPlantilla.Text = referenceObject.Descripcion;
            txt_DescripcionTransaccion.Text = referenceObject.Descripcion_Transaccion;

            if (referenceObject.Categoria != null) combo_Categoria.SelectedIndex = CategoriasDisponibles.Select(x => x.ID_Caracteristica).ToList().IndexOf(referenceObject.Categoria.ID_Caracteristica);
            check_Categoria.Checked = (referenceObject.Categoria != null);

            etiquetas = referenceObject.Etiquetas.ToList();

            if (referenceObject.MontoExpresion != null) montoExpresion = referenceObject.MontoExpresion;
            check_Monto.Checked = (referenceObject.MontoExpresion != null);

            if (referenceObject.TipoOperacion != null) combo_TipoOperacion.SelectedIndex = ((Tipo_Operacion)referenceObject.TipoOperacion).Index();
            check_TipoOperacion.Checked = (referenceObject.TipoOperacion != null);

            RefreshEtiquetas();
            RefreshMontoExpresion();
        }
        protected override void SetupReturnedObject()
        {
            string descripcionPlantilla = txt_DescripcionPlantilla.Text;
            string descripcionTransaccion = (txt_DescripcionTransaccion.Enabled) ? txt_DescripcionTransaccion.Text : null;

            Caracteristica categoria = null;
            if (combo_Categoria.Enabled) categoria = CategoriasDisponibles[combo_Categoria.SelectedIndex];

            Tipo_Operacion? tipo_Operacion = null;
            if (combo_TipoOperacion.SelectedIndex != -1 && combo_TipoOperacion.Enabled) tipo_Operacion = EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex);

            if (tipo_Operacion != null)
            {
                if (montoExpresion == null)
                {
                    Guid id;
                    if (ReferenceObject?.MontoExpresion == null) id = Guid.NewGuid();
                    else id = ReferenceObject.MontoExpresion.ID_Expresion;

                    montoExpresion = new Expresion(id, txt_Monto.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);
                }
                else if (EnumHelper.GetEnumFromIndex<Tipo_Operacion>(combo_TipoOperacion.SelectedIndex) != Tipo_Operacion.Variable) montoExpresion = new Expresion(montoExpresion.ID_Expresion, txt_Monto.Text, new List<Variable>(), Tipo_Expresion.Fija, AppData.CurrentUser);
            }
            else montoExpresion = null;

            if (!check_DescripcionTransaccion.Checked) descripcionTransaccion = null;
            if (!check_Categoria.Checked) categoria = null;
            if (!check_TipoOperacion.Checked) tipo_Operacion = null;
            if (!check_Monto.Checked) montoExpresion = null;

            if (ReferenceObject != null)
            {
                ReturnedObject = ReferenceObject;
                ReturnedObject.Descripcion = descripcionPlantilla;
                ReturnedObject.Descripcion_Transaccion = descripcionTransaccion;
                ReturnedObject.Categoria = categoria;
                ReturnedObject.Etiquetas = etiquetas.ToList();
                ReturnedObject.MontoExpresion = montoExpresion;
                ReturnedObject.TipoOperacion = tipo_Operacion;
            }
            else
            {
                ReturnedObject = new PlantillaTransaccion(
                    Guid.NewGuid(),
                    descripcionPlantilla,
                    descripcionTransaccion,
                    categoria,
                    etiquetas.ToList(),
                    montoExpresion,
                    tipo_Operacion,
                    AppData.CurrentUser,
                    true);
            }
        }
        protected override void ClearCustomAttributes()
        {
            montoExpresion = null;
            check_DescripcionTransaccion.Checked = true;
            check_Categoria.Checked = true;
            check_Monto.Checked = true;
            check_TipoOperacion.Checked = true;
            etiquetas.Clear();
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

            check_Monto_CheckedChanged(null, null);
        }
        void SetupAll()
        {
            combo_TipoOperacion.SelectedIndexChanged -= combo_TipoOperacion_SelectedIndexChanged;
            combo_TipoOperacion.DataSource = new Tipo_Operacion().GetDescriptions().Translate().ToList();
            combo_TipoOperacion.SelectedIndex = -1;
            combo_TipoOperacion.SelectedIndexChanged += combo_TipoOperacion_SelectedIndexChanged;
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
        private void but_Monto_Click(object sender, System.EventArgs e)
        {
            var f_seleccionar = new f_EstablecerExpresion();

            f_seleccionar.ReferenceObject = montoExpresion;
            f_seleccionar.ExceptObject = ReferenceObject?.ID_PlantillaTransaccion;

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

            check_Monto_CheckedChanged(combo_TipoOperacion, null);
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
        private void check_DescripcionTransaccion_CheckedChanged(object sender, EventArgs e)
        {
            txt_DescripcionTransaccion.Enabled = false;
        }
        private void check_Categoria_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ViewOnly) return;
            combo_Categoria.Enabled = check_Categoria.Checked;
        }
        private void check_Monto_CheckedChanged(object sender, EventArgs e)
        {
            if (!check_Monto.Enabled) return;

            if (!check_Monto.Checked || combo_TipoOperacion.SelectedIndex == -1)
            {
                txt_Monto.Enabled = false;
                but_Monto.Enabled = false;
            }
            else if ((Tipo_Operacion)combo_TipoOperacion.SelectedIndex == Tipo_Operacion.Variable)
            {
                txt_Monto.Enabled = false;
                but_Monto.Enabled = true;
            }
            else if ((Tipo_Operacion)combo_TipoOperacion.SelectedIndex != Tipo_Operacion.Variable)
            {
                txt_Monto.Enabled = true;
                but_Monto.Enabled = false;
            }
        }
        private void check_TipoOperacion_CheckedChanged(object sender, EventArgs e)
        {
            combo_TipoOperacion.Enabled = check_TipoOperacion.Checked;
            if (!check_TipoOperacion.Checked)
            {
                check_Monto.Enabled = false;
                txt_Monto.Enabled = false;
                lbl_Monto.Enabled = false;
                but_Monto.Enabled = false;
                check_Monto.Checked = false;
            }
            else
            {
                lbl_Monto.Enabled = true;
                check_Monto.Enabled = true;
                check_Monto_CheckedChanged(combo_TipoOperacion, null);
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

                if (BLL.Services.PlantillaTransaccionService.Current.GetAll(x => x.Descripcion == txt_DescripcionPlantilla.Text && x.Estado).Count() > 0)
                {
                    if (ReferenceObject == null || ReferenceObject.Descripcion != txt_DescripcionPlantilla.Text)
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
        private void Talonario_Plantilla_Shown(object sender, System.EventArgs e)
        {
            SetupAll();
        }
    }
}
