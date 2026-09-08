using BLL.Services;
using Domain;
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
    public partial class FilterChart_PatrimonioNeto : Filterable_FilterChart<Estadistica_PatrimonioNeto, Transaccion>
    {
        List<Transaccion> TransaccionesFiltradas => filtered_list.ToList();
        List<(int Año, int Mes, decimal Monto)> BalancesAgrupados => (servicio as EstadisticaPatrimonioNetoService).GetGroupedBalances(TransaccionesFiltradas, time_range).ToList();

        bool refreshing = false;

        public FilterChart_PatrimonioNeto()
        {
            CheckForIllegalCrossThreadCalls = false;
            servicio = BLL.Services.EstadisticaPatrimonioNetoService.Current;
            Titulo = "Patrimonio Neto".Translate();
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
        }
        protected override void SetupChart()
        {
            bool alreadyRefreshing = refreshing;
            refreshing = true;
            this.Enabled = false;

            chart_PatrimonioNeto.AutoSize = false;
            chart_PatrimonioNeto.Size = new System.Drawing.Size(
                panel_Chart.Width - chart_PatrimonioNeto.Margin.Left * 2,
                panel_Chart.Height - chart_PatrimonioNeto.Margin.Top * 2);
            chart_PatrimonioNeto.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            int font_size = 14;

            var x_axis = new LiveCharts.Wpf.Axis
            {
                Title = "",//"Línea de tiempo".Translate(),
                FontSize = font_size,
                Labels = time_labels
            };
            var y_axis = new LiveCharts.Wpf.Axis
            {
                Title = "",//"Valores".Translate(),
                FontSize = font_size,
                MinValue = 0,
                MaxValue = 100,
                LabelFormatter = x => x.ToString("C")
            };
            ChartManager.SetupChart(chart_PatrimonioNeto, x_axis, y_axis);

            base.SetupChart();

            this.Enabled = !alreadyRefreshing;
            refreshing = alreadyRefreshing;
        }
        protected override void RefreshCharts()
        {
            if (refreshing) return;
            refreshing = true;
            this.Enabled = false;

            if (combo_EstiloGrafico.SelectedIndex == -1)
            {
                chart_PatrimonioNeto.Series.Clear();
                refreshing = false;
                return;
            }

            SetupChart();

            chart_PatrimonioNeto.AxisX[0].Labels = time_labels;

            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                var lineSeries = new List<LineSeries>();
                var barSeries = new List<ColumnSeries>();

                if (combo_EstiloGrafico.SelectedIndex == 0)
                {
                    byte alpha = 100;

                    lineSeries.Add(new LineSeries()
                    {
                        Title = "Patrimonio Neto".Translate(),
                        Fill = new SolidColorBrush(Color.FromArgb(alpha, 41, 156, 223)),
                        Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 91, 162)),
                        Values = new ChartValues<decimal>(BalancesAgrupados.Select(x => x.Monto))
                    });
                }
                if (combo_EstiloGrafico.SelectedIndex == 1)
                {
                    byte alpha = 200;
                    double column_padding = 5;

                    barSeries.Add(new ColumnSeries()
                    {
                        Title = "Patrimonio Neto",
                        ColumnPadding = column_padding,
                        Fill = new SolidColorBrush(Color.FromArgb(alpha, 41, 156, 223)),
                        Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 91, 162)),
                        Values = new ChartValues<decimal>(BalancesAgrupados.Select(x => x.Monto))
                    });
                }

                if (combo_EstiloGrafico.SelectedIndex == 0)
                    ChartManager.RefreshChart(chart_PatrimonioNeto, lineSeries, LegendLocation.Bottom);
                else
                    ChartManager.RefreshChart(chart_PatrimonioNeto, barSeries, LegendLocation.Bottom);

                base.RefreshCharts();

                RetocarChart();

                this.Enabled = true;
                refreshing = false;
            });
        }
        protected override void SetDefaultValues()
        {
            base.SetDefaultValues();
        }
        void RetocarChart()
        {
            var montos = BalancesAgrupados.Select(x => x.Monto).ToList();
            var max = (montos.Count > 0) ? Convert.ToDouble(montos.Max()) : 0;
            var min = (montos.Count > 0) ? Convert.ToDouble(montos.Min()) : 0;

            chart_PatrimonioNeto.AxisY[0].MinValue = (min > 0) ? 0 : min;
            chart_PatrimonioNeto.AxisY[0].MaxValue = (max < 0) ? 0 : max;

            //Creo la línea en eje 0
            chart_PatrimonioNeto.AxisY[0].Sections.Clear();

            double punto_eje_0 = (max > min) ? max : min;
            punto_eje_0 = punto_eje_0 / 150;

            chart_PatrimonioNeto.AxisY[0].Sections.Add(new AxisSection()
            {
                Value = punto_eje_0 * -0.5,
                SectionWidth = punto_eje_0,
                Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0))
            });
        }
        protected override void ExportPDF(string path)
        {
            try
            {
                var headers = new string[] { $"{"Fecha".Translate()}: {DateTime.Now}" };

                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(chart_PatrimonioNeto.Width, chart_PatrimonioNeto.Height);
                chart_PatrimonioNeto.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                ConversionService.Image_to_PDF(bmp, path, Titulo, true, headers: headers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void FilterChart_PatrimonioNeto_Load(object sender, System.EventArgs e)
        {
        }
        private void FilterChart_PatrimonioNeto_VisibleChanged(object sender, System.EventArgs e)
        {
        }
    }
}
