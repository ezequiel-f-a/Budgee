using BLL.Services;
using Domain;
using Enums;
using LiveCharts;
using LiveCharts.Wpf;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using UI.Controls.UC.Filterable;

namespace UI.Controls.UC.FilterChart
{
    public partial class FilterChart_Distribucion : Filterable_FilterChart<Estadistica_Distribucion, Transaccion>
    {
        protected Label lbl_Mostrar, lbl_EnFuncionDe;
        protected ComboBox combo_DatoAMostrar, combo_EnFuncionDe;

        List<Transaccion> Ingresos => filtered_list.Where(x => x.TipoOperacion != Enums.Tipo_Operacion.Egreso && TransaccionService.Current.GetMonto(x, Transacciones) > 0).ToList();
        List<Transaccion> Egresos => filtered_list.Where(x => x.TipoOperacion != Enums.Tipo_Operacion.Ingreso && TransaccionService.Current.GetMonto(x, Transacciones) < 0).ToList();
        List<Transaccion> GananciaNeta => filtered_list.ToList();
        List<Transaccion> SegunDatoAMostrar { get 
            {
                if (combo_DatoAMostrar.SelectedIndex == 0) return Ingresos;
                if (combo_DatoAMostrar.SelectedIndex == 1) return Egresos;
                if (combo_DatoAMostrar.SelectedIndex == 2) return GananciaNeta;
                else return null;
            } }

        string[] DatosAMostrar = new string[] { "Ingresos", "Egresos", "Ganancia Neta" }.Translate();
        string[] EnFuncionDe = new string[] { "Cuenta", "Categoría", "Etiqueta" }.Translate();

        bool refreshing = false;

        public FilterChart_Distribucion()
        {
            CheckForIllegalCrossThreadCalls = false;
            servicio = BLL.Services.EstadisticaDistribucionService.Current;
            Titulo = "Distribución".Translate();
            InitializeComponent();
            SetupAll();
        }
        protected override void RefreshList()
        {
            list = estadistica.Transacciones.ToList();
            base.RefreshList();
        }
        void SetupAll()
        {
            panel_Chart.BackColor = System.Drawing.Color.White;

            lbl_Mostrar = new Label() { Text = "Mostrar:" };
            combo_DatoAMostrar = new ComboBox()
            {
                DataSource = DatosAMostrar,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_DatoAMostrar.SelectedIndexChanged += Combo_DatoAMostrar_SelectedIndexChanged;

            lbl_EnFuncionDe = new Label() { Text = "En Función de:" };
            combo_EnFuncionDe = new ComboBox()
            {
                DataSource = EnFuncionDe,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_EnFuncionDe.SelectedIndexChanged += Combo_EnFuncionDe_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Mostrar, 4, 0);
            flow_Filtros.Controls.Add(combo_DatoAMostrar, 5, 0);
            flow_Filtros.Controls.Add(lbl_EnFuncionDe, 2, 0);
            flow_Filtros.Controls.Add(combo_EnFuncionDe, 3, 0);

            //combo_EstiloGrafico.DataSource = /*Pegar a enum de estilo_grafico_distribucion*/new string[] { "Pie", "Donut" };
            flow_Filtros.Controls.Remove(lbl_EstiloGrafico);
            flow_Filtros.Controls.Remove(combo_EstiloGrafico);

            combo_Cuenta.Enabled = false;
            combo_Categoria.Enabled = false;
            combo_Etiqueta.Enabled = false;
        }
        protected override void SetupChart()
        {
            bool alreadyRefreshing = refreshing;
            refreshing = true;
            this.Enabled = false;

            //chart_Distribucion.AutoSize = false;
            chart_Distribucion.Size = new System.Drawing.Size(
                panel_Chart.Width * 2 / 3,
                panel_Chart.Height - chart_Distribucion.Margin.Top * 2);
            chart_Distribucion.Location = new System.Drawing.Point(panel_Chart.Width * 10 / 45, chart_Distribucion.Margin.Top);
            chart_Distribucion.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            chart_Distribucion.StartingRotationAngle = 0;

            float font_size = 14f;
            var font = new System.Drawing.Font(chart_Distribucion.Font.FontFamily.Name, font_size, chart_Distribucion.Font.Style);

            ChartManager.SetupChart(chart_Distribucion, font);

            base.SetupChart();

            this.Enabled = !alreadyRefreshing;
            refreshing = alreadyRefreshing;
        }
        protected override void RefreshCharts()
        {
            if (refreshing) return;
            refreshing = true;
            this.Enabled = true;

            try
            {
                if (combo_DatoAMostrar.SelectedIndex == -1 || combo_EnFuncionDe.SelectedIndex == -1)
                {
                    chart_Distribucion.Series.Clear();
                    refreshing = false;
                    return;
                }

                SetupChart();

                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
                {
                    var pieSeries = new List<PieSeries>();

                    if (combo_EnFuncionDe.SelectedIndex == 0)//Cuenta
                    {
                        foreach (var agrupacion in (servicio as EstadisticaDistribucionService).GetGroupedByCuenta(SegunDatoAMostrar))
                        {
                            pieSeries.Add(NewPieSeries(agrupacion.Nombre, agrupacion.Monto));
                        }
                    }
                    else if (combo_EnFuncionDe.SelectedIndex == 1)//Categoria
                    {
                        foreach (var agrupacion in (servicio as EstadisticaDistribucionService).GetGroupedByCategoria(SegunDatoAMostrar))
                        {
                            pieSeries.Add(NewPieSeries(agrupacion.Nombre, agrupacion.Monto));
                        }
                    }
                    else if (combo_EnFuncionDe.SelectedIndex == 2)//Etiqueta
                    {
                        foreach (var agrupacion in (servicio as EstadisticaDistribucionService).GetGroupedByEtiqueta(SegunDatoAMostrar))
                        {
                            pieSeries.Add(NewPieSeries(agrupacion.Nombre, agrupacion.Monto));
                        }
                    }

                    ChartManager.RefreshChart(chart_Distribucion, pieSeries, LegendLocation.Right);

                    base.RefreshCharts();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }

            this.Enabled = true;
            refreshing = false;
        }
        protected override void SetDefaultValues()
        {
            combo_DatoAMostrar.SelectedIndex = 2;
            combo_EnFuncionDe.SelectedIndex = 0;
            base.SetDefaultValues();
        }
        protected override void ExportPDF(string path)
        {
            try
            {
                var headers = new string[] { $"{"Fecha".Translate()}: {DateTime.Now}" };

                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(chart_Distribucion.Width, chart_Distribucion.Height);
                chart_Distribucion.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                ConversionService.Image_to_PDF(bmp, path, Titulo, true, headers: headers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void RefreshTitulo()
        {
            if (combo_DatoAMostrar.SelectedIndex == -1) return;
            if (combo_EnFuncionDe.SelectedIndex == -1) return;
            Titulo = $"{"Distribución".Translate().ToUpper()} {DatosAMostrar[combo_DatoAMostrar.SelectedIndex].ToUpper()}: {EnFuncionDe[combo_EnFuncionDe.SelectedIndex].ToUpper()}";
        }
        PieSeries NewPieSeries(string nombre, decimal valor)
        {
            int font_size = 14;
            //byte alpha = 200;
            int pushOut = 2;

            //Formateo de info
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0}", chartPoint.Y.ToString("C"), chartPoint.Participation.ToString("P"));

            return new PieSeries()
            {
                Title = nombre,
                FontSize = font_size,
                PushOut = pushOut,
                LabelPoint = labelPoint,
                DataLabels = true,
                Values = new ChartValues<decimal> { valor }
            };
        }
        private void Combo_EnFuncionDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_EnFuncionDe.SelectedIndex == -1)
            {
                combo_Cuenta.SelectedIndex = -1; combo_Cuenta.SelectedIndex = -1;
                combo_Categoria.SelectedIndex = -1; combo_Categoria.SelectedIndex = -1;
                combo_Etiqueta.SelectedIndex = -1; combo_Etiqueta.SelectedIndex = -1;

                combo_Cuenta.Enabled = false;
                combo_Categoria.Enabled = false;
                combo_Etiqueta.Enabled = false;
                return;
            }

            if (combo_EnFuncionDe.SelectedIndex == 0) //cuenta
            {
                combo_Cuenta.Enabled = false; combo_Cuenta.SelectedIndex = -1; combo_Cuenta.SelectedIndex = -1;
                combo_Categoria.Enabled = true;
                combo_Etiqueta.Enabled = true;
            }
            else if (combo_EnFuncionDe.SelectedIndex == 1) //categoria
            {
                combo_Cuenta.Enabled = true;
                combo_Categoria.Enabled = false; combo_Categoria.SelectedIndex = -1; combo_Categoria.SelectedIndex = -1;
                combo_Etiqueta.Enabled = true;
            }
            else if (combo_EnFuncionDe.SelectedIndex == 2) //etiqueta
            {
                combo_Cuenta.Enabled = true;
                combo_Categoria.Enabled = true;
                combo_Etiqueta.Enabled = false; combo_Etiqueta.SelectedIndex = -1; combo_Etiqueta.SelectedIndex = -1;
            }

            RefreshTitulo();
        }
        private void Combo_DatoAMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTitulo();
        }
        private void FilterChart_Distribucion_Load(object sender, System.EventArgs e)
        {

        }
        private void FilterChart_Distribucion_VisibleChanged(object sender, System.EventArgs e)
        {
        }
    }
}
