using SL.BLL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class f_SeleccionarElem<T> : Form
    {
        public T ReturnedObject { get; protected set; }
        protected IGenericBusinessLogic<T> servicio;
        protected List<T> list = new List<T>();
        protected List<T> not_in = new List<T>();
        protected f_Talonario<T> talonario;
        protected Func<T, dynamic> datasource_configuration = null;
        private Point loc_centerButton = new Point(132, 277);
        public f_SeleccionarElem(IEnumerable<T> not_in, bool tieneVerDetalle = true, bool tieneCrear = true)
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_Tab;

            if (!tieneVerDetalle)
            {
                Controls.Remove(but_VerDetalles);
                but_Crear.Location = loc_centerButton;
                but_Crear.Anchor = AnchorStyles.Top;
            }
            if (!tieneCrear)
            {
                Controls.Remove(but_Crear);
                but_VerDetalles.Location = loc_centerButton;
                but_VerDetalles.Anchor = AnchorStyles.Top;
            }
            if (not_in != null)
            {
                this.not_in = not_in.ToList();
            }
        }
        protected virtual void RefreshList()
        {
            grid_Seleccionar.DataSource = null;

            if (datasource_configuration == null) grid_Seleccionar.DataSource = list;
            else grid_Seleccionar.DataSource = list.Select(datasource_configuration).ToList();

            new Thread(() => grid_Seleccionar.SetupLanguageForDataGridView()).Start();

            grid_Seleccionar.ClearSelection();
        }
        void SetupAll()
        {
            this.BackColor = UI_Config.BackColor_Tab;
            this.grid_Seleccionar.Size = new Size(this.ClientSize.Width - grid_Seleccionar.Location.X * 2, grid_Seleccionar.Height);
            this.MinimumSize = new Size(Width, Height);
        }
        private void but_VerDetalles_Click(object sender, EventArgs e)
        {
            if (grid_Seleccionar.SelectedRows.Count == 0) return;

            talonario.ViewOnly = true;
            talonario.ReferenceObject = list[grid_Seleccionar.CurrentCell.RowIndex];
            talonario.ShowDialog();
            talonario.ViewOnly = false;
        }
        private void but_Crear_Click(object sender, EventArgs e)
        {
            try
            {
                if (talonario.ShowDialog() == DialogResult.OK)
                {
                    servicio.Add(talonario.ReturnedObject);
                    RefreshList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_Seleccionar_Click(object sender, EventArgs e)
        {
            if (grid_Seleccionar.SelectedCells.Count == 0) return;

            ReturnedObject = list[grid_Seleccionar.CurrentCell.RowIndex];
            this.DialogResult = DialogResult.OK;
        }
        private void but_Cancelar_Click(object sender, EventArgs e)
        {
            ReturnedObject = default;
            this.DialogResult = DialogResult.Cancel;
        }
        private void f_SeleccionarElem_Load(object sender, EventArgs e)
        {
            SetupAll();
            new Thread(() => this.SetupLanguageForContainer()).Start();
            RefreshList();
        }
    }
}
