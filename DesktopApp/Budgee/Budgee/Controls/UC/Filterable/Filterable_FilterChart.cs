using BLL.Contracts;
using Domain;
using SL.BLL.Services;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Threading;
using UI.Controls.Buttons;
using UI.Controls.Labels;
using UI.Forms;

namespace UI.Controls.UC.Filterable
{
    public partial class Filterable_FilterChart<U, T> : UC_Filterable<T> where U : Estadistica where T : Transaccion
    {
        protected string Titulo;

        protected Label lbl_Cuenta, lbl_Categoria, lbl_Etiqueta, lbl_EstiloGrafico, lbl_Lapso;
        protected ComboBox combo_Cuenta, combo_Categoria, combo_Etiqueta, combo_EstiloGrafico;
        protected DarkButton but_Exportar, but_Lapso;
        protected Button but_Habilitar, but_Deshabilitar;
        protected Lapso lapso;

        protected List<Cuenta> CuentasDisponibles = new List<Cuenta>();
        protected List<Caracteristica> CategoriasDisponibles = new List<Caracteristica>();
        protected List<Caracteristica> EtiquetasDisponibles = new List<Caracteristica>();

        protected IEstadisticaService<U> servicio;
        protected U estadistica 
        { 
            get 
            {
                try
                {
                    var estadistica = servicio.GetEstadistica();
                    Transacciones = (estadistica as dynamic).Transacciones;
                    return estadistica;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetFullMessage());
                    throw;
                }
            } 
        }

        protected List<Transaccion> Transacciones;
        protected List<DateTime> time_range => GetTimeRange();
        protected List<string> time_labels => ChartManager.GetTimeLabels(time_range, true);

        public Filterable_FilterChart()
        {
            InitializeComponent();
            SetupAll();
        }
        void SetupAll()
        {
            this.BackColor = UI_Config.BackColor_Tab;
            panel_Chart.BackColor = UI_Config.BackColor_DarkBackground;
            panel_Chart.Location = new Point(panel_Chart.Location.X, flow_Filtros.ClientSize.Height - 15);
            SetupFiltros();
        }
        void SetupFiltros()
        {
            but_Exportar = new DarkButton() { Text = "Exportar...", Anchor = AnchorStyles.Bottom, Margin = new Padding(3, 0, 3, 0) };
            but_Exportar.Click += But_Exportar_Click;

            lbl_Cuenta = new Label() { Text = "Cuenta:" };
            combo_Cuenta = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;
            combo_Cuenta.DropDown += Combo_Cuenta_DropDown;

            lbl_Categoria = new Label() { Text = "Categoría:" };
            combo_Categoria = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Categoria.SelectedIndexChanged += Combo_Categoria_SelectedIndexChanged;
            combo_Categoria.DropDown += Combo_Categoria_DropDown;

            lbl_Etiqueta = new Label() { Text = "Etiqueta:" };
            combo_Etiqueta = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Etiqueta.SelectedIndexChanged += Combo_Etiqueta_SelectedIndexChanged;
            combo_Etiqueta.DropDown += Combo_Etiqueta_DropDown;

            lbl_EstiloGrafico = new Label() { Text = "Estilo Gráfico:" };
            combo_EstiloGrafico = new ComboBox()
            {
                DataSource = new string[] { "Lineal", "Columnas" }.Translate(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            but_Lapso = new DarkButton() { Text = "Lapso...", Anchor = AnchorStyles.Bottom, Margin = new Padding(3, 0, 3, 0) };
            but_Lapso.Click += But_Lapso_Click;
            lbl_Lapso = new DarkLabel() { Text = "" };

            flow_Filtros.Controls.Add(but_Lapso, 0, 0);
            flow_Filtros.Controls.Add(lbl_Lapso, 1, 0);
            flow_Filtros.Controls.Add(lbl_Cuenta, 0, 1);
            flow_Filtros.Controls.Add(combo_Cuenta, 1, 1);
            flow_Filtros.Controls.Add(lbl_Categoria, 2, 1);
            flow_Filtros.Controls.Add(combo_Categoria, 3, 1);
            flow_Filtros.Controls.Add(lbl_Etiqueta, 4, 1);
            flow_Filtros.Controls.Add(combo_Etiqueta, 5, 1);
            flow_Filtros.Controls.Add(lbl_EstiloGrafico, 0, 2);
            flow_Filtros.Controls.Add(combo_EstiloGrafico, 1, 2);
            flow_Filtros.Controls.Add(but_Exportar, 3, 2);

            but_ResetearFiltros.Click += But_ResetearFiltros_Click;
        }
        protected override void RefreshList()
        {
            try
            {
                CuentasDisponibles = BLL.Services.CuentaService.Current.GetAll(x => x.Habilitada && x.Estado && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                CategoriasDisponibles = BLL.Services.CaracteristicaService.Current.GetAll(x => x.Estado && x.Tipo_Caracteristica == Enums.Tipo_Caracteristica.Categoria && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                EtiquetasDisponibles = BLL.Services.CaracteristicaService.Current.GetAll(x => x.Estado && x.Tipo_Caracteristica == Enums.Tipo_Caracteristica.Etiqueta && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        protected override void SetDefaultValues()
        {
            if (flow_Filtros.Controls.Contains(combo_EstiloGrafico))
            {
                combo_EstiloGrafico.SelectedIndexChanged -= Combo_EstiloGrafico_SelectedIndexChanged;
                combo_EstiloGrafico.SelectedIndex = 0;
                combo_EstiloGrafico.SelectedIndexChanged += Combo_EstiloGrafico_SelectedIndexChanged;
            }

            var now = DateTime.Now;
            var haceUnAño = new DateTime(now.Year, now.Month, now.Day, 1, 1, 1, 1).AddYears(-1);
            var nowFin = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 999);

            lapso = new Lapso(Guid.NewGuid(), Enums.Tipo_Lapso.Intervalo, haceUnAño, nowFin, AppData.CurrentUser);
            RefreshLapso();
            ConfirmFilters();

            base.SetDefaultValues();
        }
        protected virtual void SetupChart()
        {
            //SOLO PARA REIMPLEMENTACION
        }
        protected override void RefreshCharts()
        {
            base.RefreshCharts();
        }
        void RefreshLapso()
        {
            if (lapso == null)
            {
                lbl_Lapso.Text = "";
                RemoveFilter(but_Lapso);
            }
            else 
            {
                lbl_Lapso.Text = LapsoService.Current.GetDescription(lapso, shorter:true);

                SetFilter(but_Lapso, x => 
                x.Fecha != null &&
                LapsoService.Current.FechaEntraEnLapso(lapso, (DateTime)x.Fecha));

                if(lapso.TipoLapso == Enums.Tipo_Lapso.Intervalo)
                    lbl_Lapso.Font = new Font(lbl_Lapso.Font.FontFamily, 10f, FontStyle.Bold);
                else
                    lbl_Lapso.Font = new Font(lbl_Lapso.Font.FontFamily, 12f, FontStyle.Bold);

                lbl_Lapso.TextAlign = ContentAlignment.MiddleCenter;
            } 
        }
        protected virtual void ExportPDF(string path)
        {
            //Reimplementar
        }
        List<DateTime> GetTimeRange()
        {
            //return filtered_list.Where(x => x.Fecha != null).Select(x => (DateTime)x.Fecha).ToList();
            if (lapso == null) return Transacciones.Where(x => x.Fecha != null).Select(x => (DateTime)x.Fecha).ToList();
            else return Transacciones.Where(x => x.Fecha != null && LapsoService.Current.FechaEntraEnLapso(lapso, (DateTime)x.Fecha)).Select(x => (DateTime)x.Fecha).ToList();
        }
        protected override void But_ResetearFiltros_Click(object sender, EventArgs e)
        {
            base.But_ResetearFiltros_Click(sender, e);
            lapso = null;
            RefreshLapso();
        }
        private void But_Exportar_Click(object sender, EventArgs e)
        {
            var sv = new SaveFileDialog()
            {
                Title = "Guardar como".Translate(),
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter =
                //$"{"Libro de Excel".Translate()} (.xlsx) | *.xlsx|" +
                //$"CSV | *.csv|" +
                $"PDF | *.pdf"
            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string path = sv.FileName;
                ExportPDF(path);
            }
        }
        private void But_Lapso_Click(object sender, EventArgs e)
        {
            var f_seleccionar = new f_EstablecerLapso();

            f_seleccionar.ReferenceObject = lapso;

            if (f_seleccionar.ShowDialog() == DialogResult.OK)
            {
                lapso = f_seleccionar.ReturnedObject;
                RefreshLapso();
            }
        }
        private void Combo_EstiloGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate { RefreshCharts(); });
        }
        private void Combo_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Cuenta.SelectedIndex == -1) return;

            var id = CuentasDisponibles[combo_Cuenta.SelectedIndex].ID_Cuenta;

            SetFilter(combo_Cuenta, x =>
            x.Cuenta?.ID_Cuenta == id);
        }
        private void Combo_Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Categoria.SelectedIndex == -1)
            {
                RemoveFilter(combo_Categoria);
                return;
            }

            var id = CategoriasDisponibles[combo_Categoria.SelectedIndex].ID_Caracteristica;

            SetFilter(combo_Categoria, x =>
            x.Categoria?.ID_Caracteristica == id);
        }
        private void Combo_Etiqueta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Etiqueta.SelectedIndex == -1)
            {
                RemoveFilter(combo_Etiqueta);
                return;
            }

            var id = EtiquetasDisponibles[combo_Etiqueta.SelectedIndex].ID_Caracteristica;

            SetFilter(combo_Etiqueta, x =>
            x.Etiquetas.Select(y => y.ID_Caracteristica).Contains(id));
        }
        private void Combo_Cuenta_DropDown(object sender, EventArgs e)
        {
            combo_Cuenta.SelectedIndexChanged -= Combo_Cuenta_SelectedIndexChanged;
            int index = combo_Cuenta.SelectedIndex;
            int count = combo_Cuenta.Items.Count;
            combo_Cuenta.DataSource = null;
            combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
            if (combo_Cuenta.Items.Count == count) combo_Cuenta.SelectedIndex = index;
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;
        }
        private void Combo_Categoria_DropDown(object sender, EventArgs e)
        {
            combo_Categoria.SelectedIndexChanged -= Combo_Categoria_SelectedIndexChanged;
            int index = combo_Categoria.SelectedIndex;
            int count = combo_Categoria.Items.Count;
            combo_Categoria.DataSource = null;
            combo_Categoria.DataSource = CategoriasDisponibles.Select(x => x.Nombre).ToList();
            combo_Categoria.SelectedIndex = -1;
            if (combo_Categoria.Items.Count == count) combo_Categoria.SelectedIndex = index;
            combo_Categoria.SelectedIndexChanged += Combo_Categoria_SelectedIndexChanged;
        }
        private void Combo_Etiqueta_DropDown(object sender, EventArgs e)
        {
            combo_Etiqueta.SelectedIndexChanged -= Combo_Etiqueta_SelectedIndexChanged;
            int index = combo_Etiqueta.SelectedIndex;
            int count = combo_Etiqueta.Items.Count;
            combo_Etiqueta.DataSource = null;
            combo_Etiqueta.DataSource = EtiquetasDisponibles.Select(x => x.Nombre).ToList();
            combo_Etiqueta.SelectedIndex = -1;
            if (combo_Etiqueta.Items.Count == count) combo_Etiqueta.SelectedIndex = index;
            combo_Etiqueta.SelectedIndexChanged += Combo_Etiqueta_SelectedIndexChanged;
        }
        private void Filterable_FilterChart_SizeChanged(object sender, EventArgs e)
        {
            panel_Chart.Size = new Size(panel_Chart.Width, ClientSize.Height - panel_Chart.Location.Y - 25);
        }
        private void Filterable_FilterChart_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            Transacciones = (estadistica as dynamic).Transacciones;
        }
        private void Filterable_FilterChart_Load(object sender, EventArgs e)
        {
            Transacciones = (estadistica as dynamic).Transacciones;
            SetupChart();
            SetDefaultValues();
            RefreshListWithoutCharts();
        }
    }
}
