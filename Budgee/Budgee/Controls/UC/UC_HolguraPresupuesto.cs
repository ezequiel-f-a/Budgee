using BLL.Contracts;
using BLL.Services;
using Domain;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using SL.BLL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;

namespace UI.Controls.UC
{
    public partial class UC_HolguraPresupuesto : UserControl
    {
        Estadistica_Presupuesto estadistica;
        IEnumerable<Transaccion> transacciones_temp;
        bool refreshing = false;
        public UC_HolguraPresupuesto()
        {
            InitializeComponent();
            SetupAll();
        }
        void GetEstadistica()
        {
            try
            {
                estadistica = EstadisticaPresupuestoService.Current.GetEstadistica();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void SetupAll()
        {
            this.BackColor = UI_Config.BackColor_Tab;
            grid_Presupuestos.BackgroundColor = UI_Config.BackColor_DarkBackground;
            panel_Presupuesto.BackColor = System.Drawing.Color.White;//UI_Config.BackColor_DarkBackground;
            lbl_DetalleValue.Font = new Font(UI_Config.Font_Default_Primary.FontFamily, 12f, FontStyle.Regular);
            lbl_PresupuestoValue.Font = new Font(UI_Config.Font_Default_Primary.FontFamily, 12f, FontStyle.Regular);
            CheckForIllegalCrossThreadCalls = false;

            SetupChart();
        }
        void SetupChart()
        {
            int font_size = 12;

            chartBar_Presupuesto.BackColor = System.Drawing.Color.White;

            var x_labels = new string[] { "Presupuestado".Translate(), "Actual".Translate() };

            var x_axis = new LiveCharts.Wpf.Axis
            {
                Title = "",
                FontSize = font_size,
                FontFamily = new System.Windows.Media.FontFamily(UI_Config.Font_Default_Primary.FontFamily.Name),
                Labels = x_labels,
            };
            var y_axis = new LiveCharts.Wpf.Axis
            {
                Title = "",
                FontSize = font_size,
                FontFamily = new System.Windows.Media.FontFamily(UI_Config.Font_Default_Primary.FontFamily.Name),
                MinValue = 0,
                MaxValue = 100,
                LabelFormatter = x => x.ToString("#.##"),
            };

            ChartManager.SetupChart(chartBar_Presupuesto, x_axis, y_axis);
        }
        void RefreshData()
        {
            estadistica.Presupuestos = PresupuestoService.Current.GetAll(x => x.Habilitado == true && x.Estado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderBy(x => x.Descripcion).ToList();
            new Thread(() => { RefreshGrid(); }).Start();
        }
        void RefreshGrid()
        {
            if (refreshing) return;

            refreshing = true;

            try
            {
                grid_Presupuestos.DataSource = null;

                transacciones_temp = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                grid_Presupuestos.SelectionChanged -= grid_Presupuestos_SelectionChanged;

                grid_Presupuestos.DataSource = estadistica.Presupuestos.Select(x => new {
                    x.Descripcion,
                    Presupuestado = $"{ExpresionService.Current.GetResult(x.CondicionExpresion, transacciones_temp)}",
                    Actual = $"{VariableService.Current.GetValue(x.VariableSupervisada, transacciones_temp)}"
                }).OrderBy(x => x.Descripcion).ToList();

                grid_Presupuestos.SetupLanguageForDataGridView();

                grid_Presupuestos.ClearSelection();

                grid_Presupuestos.SelectionChanged += grid_Presupuestos_SelectionChanged;

                RefreshPresupuestoSeleccionado(null);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }

            refreshing = false;
        }
        void RefreshPresupuestoSeleccionado(Presupuesto presupuesto_seleccionado)
        {
            lbl_PresupuestoTitle.Font = null;
            lbl_PresupuestoValue.Text = $"{ (presupuesto_seleccionado == null ? "N/A" : presupuesto_seleccionado.Descripcion) }";

            string detalle = "";
            if (presupuesto_seleccionado == null) detalle += "N/A";
            else
            {
                detalle += VariableService.Current.GetDescription(presupuesto_seleccionado.VariableSupervisada);
                detalle += $" {presupuesto_seleccionado.OperadorRelacional.GetDescription().Translate()} ";
                detalle += presupuesto_seleccionado.CondicionExpresion.Definicion;
            }
            lbl_DetalleValue.Text = detalle;

            if (presupuesto_seleccionado != null)
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate { RefreshChart(presupuesto_seleccionado); });
            else Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate { ClearChart(); });
        }
        void RefreshChart(Presupuesto presupuesto)
        {
            try
            {
                decimal presupuestado = ExpresionService.Current.GetResult(presupuesto.CondicionExpresion, transacciones_temp);
                decimal actual = VariableService.Current.GetValue(presupuesto.VariableSupervisada, transacciones_temp);

                double column_padding = 5;

                var series = new ColumnSeries()
                {
                    Title = "Valor".Translate(),
                    ColumnPadding = column_padding,
                    Fill = System.Windows.Media.Brushes.Gray,
                    Values = new ChartValues<decimal>(new List<decimal>() { presupuestado, actual })
                };

                chartBar_Presupuesto.AxisY[0].MaxValue = double.NaN;

                if (presupuestado < 0 || actual < 0) chartBar_Presupuesto.AxisY[0].MinValue = double.NaN;
                else chartBar_Presupuesto.AxisY[0].MinValue = 0;

                ChartManager.RefreshChart(chartBar_Presupuesto, new List<ColumnSeries>() { series }, LegendLocation.None);

                RecolorChartBars(series, presupuestado, actual, presupuesto.OperadorRelacional);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void ClearChart() 
        {
            chartBar_Presupuesto.Series.Clear();
            chartBar_Presupuesto.AxisY[0].MinValue = 0;
            chartBar_Presupuesto.AxisY[0].MaxValue = 100;
        }
        void RecolorChartBars(ColumnSeries series, decimal presupuestado, decimal actual, Enums.Operador_Relacional relacion)
        {
            byte alpha = 255;

            SolidColorBrush color_presupuesto = new SolidColorBrush(System.Windows.Media.Color.FromArgb(alpha, 47, 170, 255));

            CartesianMapper<decimal> mapper = Mappers.Xy<decimal>()
                .X((value, index) => index)
                .Y(value => Convert.ToDouble(value))
                .Fill((value, index) => index == 0 ? color_presupuesto : GetValorActualColor(alpha, presupuestado, actual, relacion));

            series.Configuration = mapper;
        }
        SolidColorBrush GetValorActualColor(byte alpha, decimal presupuestado, decimal actual, Enums.Operador_Relacional relacion)
        {
            var rojo = new SolidColorBrush(System.Windows.Media.Color.FromArgb(alpha, 219, 41, 51));
            var naranja = new SolidColorBrush(System.Windows.Media.Color.FromArgb(alpha, 219, 118, 41));
            var amarillo = new SolidColorBrush(System.Windows.Media.Color.FromArgb(alpha, 219, 196, 41));
            var verde = new SolidColorBrush(System.Windows.Media.Color.FromArgb(alpha, 49, 219, 41));

            double porcentaje_completado;

            if (presupuestado == 0 && actual == 0) porcentaje_completado = 1;
            else if (presupuestado == 0) porcentaje_completado = 0;
            else if (presupuestado < 0 && actual > 0) porcentaje_completado = double.PositiveInfinity;
            else if (presupuestado > 0 && actual < 0) porcentaje_completado = double.NegativeInfinity;
            else if (actual < 0 && presupuestado < 0) porcentaje_completado = 1 / Convert.ToDouble(actual / presupuestado);
            else porcentaje_completado = Convert.ToDouble(actual / presupuestado);

            SolidColorBrush color_actual = null;

            switch (relacion)
            {
                case Enums.Operador_Relacional.Mayor_a:
                    if (porcentaje_completado > 1) color_actual = rojo;
                    else if (porcentaje_completado > 0.9) color_actual = naranja;
                    else if (porcentaje_completado > 0.8) color_actual = amarillo;
                    else color_actual = verde;
                    break;
                case Enums.Operador_Relacional.Menor_a:
                    if (porcentaje_completado < 1) color_actual = rojo;
                    else if (porcentaje_completado < (1 / 0.9)) color_actual = naranja;
                    else if (porcentaje_completado < (1 / 0.8)) color_actual = amarillo;
                    else color_actual = verde;
                    break;
                case Enums.Operador_Relacional.Mayor_o_Igual_a:
                    if (porcentaje_completado >= 1) color_actual = rojo;
                    else if (porcentaje_completado >= 0.9) color_actual = naranja;
                    else if (porcentaje_completado >= 0.8) color_actual = amarillo;
                    else color_actual = verde;
                    break;
                case Enums.Operador_Relacional.Menor_o_Igual_a:
                    if (porcentaje_completado <= 1) color_actual = rojo;
                    else if (porcentaje_completado <= 1.1) color_actual = naranja;
                    else if (porcentaje_completado <= 1.2) color_actual = amarillo;
                    else color_actual = verde;
                    break;
                case Enums.Operador_Relacional.Igual_a:
                    if (porcentaje_completado == 1) color_actual = verde;
                    else color_actual = rojo;
                    break;
                case Enums.Operador_Relacional.Diferente_de:
                    if (porcentaje_completado != 1) color_actual = verde;
                    else color_actual = rojo;
                    break;
                default:
                    break;
            }

            return color_actual;
        }
        private void grid_Presupuestos_SelectionChanged(object sender, EventArgs e)
        {
            var presupuesto = (grid_Presupuestos.SelectedRows.Count == 1) ? estadistica.Presupuestos[grid_Presupuestos.CurrentCell.RowIndex] : null;
            RefreshPresupuestoSeleccionado(presupuesto);
        }
        private void but_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                var sv = new SaveFileDialog()
                {
                    Title = "Guardar como".Translate(),
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter =
                                $"{"Libro de Excel".Translate()} (.xlsx) | *.xlsx|" +
                                $"CSV | *.csv|" +
                                $"PDF | *.pdf"
                };

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    string path = sv.FileName;

                    string extension = Path.GetExtension(path);

                    var dt = ConversionService.DataGridView_ToDataTable(grid_Presupuestos);

                    var headers = new string[] { $"{"Fecha".Translate()}: {DateTime.Now}" };

                    if (extension == ".xlsx") ConversionService.DataTable_to_XLSX_WithHeaders(dt, path, headers);

                    if (extension == ".csv") ConversionService.DataTable_to_CSV_WithHeaders(dt, path, headers);

                    if (extension == ".pdf") ConversionService.DataTable_to_PDF(dt, path,
                        title: "Holgura de Presupuesto".Translate().ToUpper(),
                        centered_title: true,
                        headers: headers,
                        centered_columns: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void UC_Overview_SizeChanged(object sender, EventArgs e)
        {
            grid_Presupuestos.Size = new Size(grid_Presupuestos.Width, ClientSize.Height - grid_Presupuestos.Location.Y - 25);
        }
        private void UC_Overview_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            if (estadistica == null) GetEstadistica();
            ClearChart();
            RefreshData();
        }
    }
}
