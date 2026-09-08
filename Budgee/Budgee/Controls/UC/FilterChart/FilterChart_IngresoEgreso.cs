using BLL.Services;
using Domain;
using LiveCharts;
using LiveCharts.Wpf;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using UI.Controls.UC.Filterable;

namespace UI.Controls.UC.FilterChart
{
    public partial class FilterChart_IngresoEgreso : Filterable_FilterChart<Estadistica_IngresoEgreso, Transaccion>
    {
        protected Label lbl_DatoAMostrar;
        protected ComboBox combo_DatoAMostrar;
        List<Transaccion> Ingresos => filtered_list.Where(x => x.TipoOperacion != Enums.Tipo_Operacion.Egreso && TransaccionService.Current.GetMonto(x, Transacciones) > 0).ToList();
        List<Transaccion> Egresos => filtered_list.Where(x => x.TipoOperacion != Enums.Tipo_Operacion.Ingreso && TransaccionService.Current.GetMonto(x, Transacciones) < 0).ToList();
        List<Transaccion> GananciaNeta => filtered_list.ToList();
        List<(int Año, int Mes, decimal Monto)> TransaccionesAgrupadas => (servicio as EstadisticaIngresoEgresoService).GetGroupedTransacciones(filtered_list, time_range, transacciones_temp: Transacciones).ToList();
        List<(int Año, int Mes, decimal Monto)> IngresosAgrupados => (servicio as EstadisticaIngresoEgresoService).GetGroupedTransacciones(Ingresos, time_range, transacciones_temp: Transacciones).ToList();
        List<(int Año, int Mes, decimal Monto)> EgresosAgrupados => (servicio as EstadisticaIngresoEgresoService).GetGroupedTransacciones(Egresos, time_range, esEgreso: true, transacciones_temp: Transacciones).ToList();
        List<(int Año, int Mes, decimal Monto)> GananciaNetaAgrupada => (servicio as EstadisticaIngresoEgresoService).GetGroupedTransacciones(GananciaNeta, time_range, transacciones_temp: Transacciones).ToList();

        bool refreshing = false;

        string[] DatosAMostrar = new string[] { "Ingresos y Egresos".Translate(), "Ingresos".Translate(), "Egresos".Translate(), "Ganancia Neta".Translate() };
        public FilterChart_IngresoEgreso()
        {
            CheckForIllegalCrossThreadCalls = false;
            servicio = BLL.Services.EstadisticaIngresoEgresoService.Current;
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

            lbl_DatoAMostrar = new Label() { Text = "Mostrar:" };
            combo_DatoAMostrar = new ComboBox()
            {
                DataSource = DatosAMostrar,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_DatoAMostrar.SelectedIndexChanged += Combo_DatoAMostrar_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_DatoAMostrar, 4, 0);
            flow_Filtros.Controls.Add(combo_DatoAMostrar, 5, 0);
        }
        protected override void SetupChart()
        {
            bool alreadyRefreshing = refreshing;
            refreshing = true;
            this.Enabled = false;

            chart_IngresoEgreso.AutoSize = false;
            chart_IngresoEgreso.Size = new System.Drawing.Size(
                panel_Chart.Width - chart_IngresoEgreso.Margin.Left * 2, 
                panel_Chart.Height - chart_IngresoEgreso.Margin.Top * 2);
            chart_IngresoEgreso.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
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
            ChartManager.SetupChart(chart_IngresoEgreso, x_axis, y_axis);

            base.SetupChart();

            this.Enabled = !alreadyRefreshing;
            refreshing = alreadyRefreshing;
        }
        protected override void RefreshCharts()
        {
            if (refreshing) return;
            refreshing = true;
            this.Enabled = true;

            if (combo_DatoAMostrar.SelectedIndex == -1 || combo_EstiloGrafico.SelectedIndex == -1)
            {
                chart_IngresoEgreso.Series.Clear();
                refreshing = false;
                return;
            }

            SetupChart();

            chart_IngresoEgreso.AxisX[0].Labels = time_labels;

            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate 
            {
                var lineSeries = new List<LineSeries>();
                var barSeries = new List<ColumnSeries>();

                if (combo_EstiloGrafico.SelectedIndex == 0)
                {
                    byte alpha = 100;

                    if (combo_DatoAMostrar.SelectedIndex == 0 || combo_DatoAMostrar.SelectedIndex == 1)
                    {
                        lineSeries.Add(new LineSeries()
                        {
                            Title = "Ingresos".Translate(),
                            Fill = new SolidColorBrush(Color.FromArgb(alpha, 50, 255, 83)),
                            Stroke = new SolidColorBrush(Colors.Green),
                            Values = new ChartValues<decimal>(IngresosAgrupados.Select(x => x.Monto))
                        });
                    }

                    if (combo_DatoAMostrar.SelectedIndex == 0 || combo_DatoAMostrar.SelectedIndex == 2)
                    {
                        lineSeries.Add(new LineSeries()
                        {
                            Title = "Egresos".Translate(),
                            Fill = new SolidColorBrush(Color.FromArgb(alpha, 255, 57, 51)),
                            Stroke = new SolidColorBrush(Colors.Red),
                            Values = new ChartValues<decimal>(EgresosAgrupados.Select(x => x.Monto))
                        });
                    }

                    if (combo_DatoAMostrar.SelectedIndex == 3)
                    {
                        lineSeries.Add(new LineSeries()
                        {
                            Title = "Ganancia Neta".Translate(),
                            Fill = new SolidColorBrush(Color.FromArgb(alpha, 255, 229, 0)),
                            Stroke = new SolidColorBrush(Color.FromArgb(255, 205, 184, 0)),
                            Values = new ChartValues<decimal>(GananciaNetaAgrupada.Select(x => x.Monto))
                        });
                    }
                }
                if (combo_EstiloGrafico.SelectedIndex == 1)
                {
                    byte alpha = 200;
                    double column_padding = 5;

                    if (combo_DatoAMostrar.SelectedIndex == 0 || combo_DatoAMostrar.SelectedIndex == 1)
                    {
                        barSeries.Add(new ColumnSeries()
                        {
                            Title = "Ingresos",
                            ColumnPadding = column_padding,
                            Fill = new SolidColorBrush(Color.FromArgb(alpha, 36, 203, 63)),
                            Stroke = new SolidColorBrush(Colors.Green),
                            Values = new ChartValues<decimal>(IngresosAgrupados.Select(x => x.Monto))
                        });
                    }

                    if (combo_DatoAMostrar.SelectedIndex == 0 || combo_DatoAMostrar.SelectedIndex == 2)
                    {
                        barSeries.Add(new ColumnSeries()
                        {
                            Title = "Egresos",
                            ColumnPadding = column_padding,
                            Fill = new SolidColorBrush(Color.FromArgb(alpha, 255, 57, 51)),
                            Stroke = new SolidColorBrush(Colors.Red),
                            Values = new ChartValues<decimal>(EgresosAgrupados.Select(x => x.Monto))
                        });
                    }

                    if (combo_DatoAMostrar.SelectedIndex == 3)
                    {
                        barSeries.Add(new ColumnSeries()
                        {
                            Title = "Ganancia Neta",
                            ColumnPadding = column_padding,
                            Fill = new SolidColorBrush(Color.FromArgb(alpha, 255, 229, 0)),
                            Stroke = new SolidColorBrush(Color.FromArgb(255, 205, 184, 0)),
                            Values = new ChartValues<decimal>(GananciaNetaAgrupada.Select(x => x.Monto))
                        });
                    }
                }

                if (combo_EstiloGrafico.SelectedIndex == 0)
                    ChartManager.RefreshChart(chart_IngresoEgreso, lineSeries, LegendLocation.Bottom);
                else
                    ChartManager.RefreshChart(chart_IngresoEgreso, barSeries, LegendLocation.Bottom);

                base.RefreshCharts();

                RetocarChart();

                this.Enabled = true;
                refreshing = false;
            });
        }
        protected override void SetDefaultValues()
        {
            combo_DatoAMostrar.SelectedIndex = 0;
            base.SetDefaultValues();
        }
        void RetocarChart()
        {
            var montos = TransaccionesAgrupadas.Select(x => x.Monto).ToList();
            var max = (montos.Count > 0) ? Convert.ToDouble(montos.Max()) : 0;
            var min = (montos.Count > 0) ? Convert.ToDouble(montos.Min()) : 0;

            if (combo_DatoAMostrar.SelectedIndex == 3)
            {
                chart_IngresoEgreso.AxisY[0].MinValue = (min > 0) ? 0 : min;
                chart_IngresoEgreso.AxisY[0].MaxValue = (max < 0) ? 0 : max;
            }
            else
            {
                chart_IngresoEgreso.AxisY[0].MinValue = 0;
                chart_IngresoEgreso.AxisY[0].MaxValue = double.NaN;
            }

            //Creo la línea en eje 0

            chart_IngresoEgreso.AxisY[0].Sections.Clear();

            if (combo_DatoAMostrar.SelectedIndex != 3) return;

            double punto_eje_0 = (max > min) ? max : min; //chart_IngresoEgreso.AxisY[0].ActualMaxValue / 200;
            punto_eje_0 = punto_eje_0 / 150;

            chart_IngresoEgreso.AxisY[0].Sections.Add(new AxisSection()
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

                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(chart_IngresoEgreso.Width, chart_IngresoEgreso.Height);
                chart_IngresoEgreso.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                ConversionService.Image_to_PDF(bmp, path, Titulo, true, headers: headers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void Combo_DatoAMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_DatoAMostrar.SelectedIndex == -1) return;
            Titulo = DatosAMostrar[combo_DatoAMostrar.SelectedIndex].ToUpper();
        }
        private void FilterChart_IngresoEgreso_Load(object sender, System.EventArgs e)
        {
        }
        private void FilterChart_IngresoEgreso_VisibleChanged(object sender, System.EventArgs e)
        {
        }
    }
}
