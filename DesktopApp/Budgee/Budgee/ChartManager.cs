using LiveCharts;
using LiveCharts.Wpf;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace UI
{
    public static class ChartManager
    {
        public static void SetupChart(LiveCharts.WinForms.CartesianChart chart, LiveCharts.Wpf.Axis X_Axis, LiveCharts.Wpf.Axis Y_Axis)
        {
            if (chart.AxisX.Count == 0) chart.AxisX.Add(X_Axis);
            else chart.AxisX[0] = X_Axis;

            if (chart.AxisY.Count == 0) chart.AxisY.Add(Y_Axis);
            else chart.AxisY[0] = Y_Axis;
        }
        public static void SetupChart(LiveCharts.WinForms.PieChart chart, Font font)
        {
            chart.Font = new Font(font.FontFamily, font.Size, font.Style);
            //chart.DataTooltip = null;
        }
        public static void RefreshChart(LiveCharts.WinForms.CartesianChart chart, List<LineSeries> series, LegendLocation? legendLocation = null)
        {
            /*if (chart.Series.Count > 0 && !(chart.Series[0] is LineSeries)) 
            {
                chart.AxisX[0].MinValue = chart.AxisX[0].ActualMinValue;
                chart.AxisX[0].MaxValue = chart.AxisX[0].ActualMaxValue;
            }*/

            chart.Series.Clear();
            var seriesCollection = new SeriesCollection();
            series.ForEach(x=>seriesCollection.Add(x));

            chart.LegendLocation = (legendLocation != null) ? (LegendLocation)legendLocation : chart.LegendLocation;

            chart.Series = seriesCollection;
        }
        public static void RefreshChart(LiveCharts.WinForms.CartesianChart chart, List<ColumnSeries> series, LegendLocation? legendLocation = null)
        {
            /*if (chart.Series.Count > 0 && !(chart.Series[0] is ColumnSeries))
            {
                chart.AxisX[0].MinValue = 0;
                chart.AxisX[0].MaxValue = chart.AxisX[0].Labels.Count;
            }*/

            chart.Series.Clear();
            var seriesCollection = new SeriesCollection();
            series.ForEach(x => seriesCollection.Add(x));

            chart.LegendLocation = (legendLocation != null) ? (LegendLocation)legendLocation : chart.LegendLocation;

            chart.Series = seriesCollection;
        }
        public static void RefreshChart(LiveCharts.WinForms.CartesianChart chart, List<StackedColumnSeries> series, LegendLocation? legendLocation = null)
        {
            if (chart.Series.Count > 0 && !(chart.Series[0] is StackedColumnSeries))
            {
                chart.AxisX[0].MinValue = 0;
                chart.AxisX[0].MaxValue = chart.AxisX[0].Labels.Count;
            }

            chart.Series.Clear();
            var seriesCollection = new SeriesCollection();
            series.ForEach(x => seriesCollection.Add(x));

            chart.LegendLocation = (legendLocation != null) ? (LegendLocation)legendLocation : chart.LegendLocation;

            chart.Series = seriesCollection;
        }
        public static void RefreshChart(LiveCharts.WinForms.PieChart chart, List<PieSeries> series, LegendLocation? legendLocation = null)
        {
            chart.Series.Clear();
            var seriesCollection = new SeriesCollection();
            series.ForEach(x => seriesCollection.Add(x));

            chart.LegendLocation = (legendLocation != null) ? (LegendLocation)legendLocation : chart.LegendLocation;

            chart.Series = seriesCollection;
        }
        public static List<string> GetTimeLabels(IEnumerable<DateTime> dates, bool rellenarVacío = true)
        {
            if (dates.Count() == 0) return new List<string>();
            else if (rellenarVacío)
            {
                return GetTimeLabels(dates.Min(), dates.Max());
            }
            else
            {
                var result = ConversionService.GetDatesGroupedByYearMonth(dates.OrderBy(x => x));
                return result.Select(x => $"{((Enums.Mes)(x.Month - 1)).GetDescription().Translate().Substring(0, 3)} {x.Year}").ToList();
            }
        }
        public static List<string> GetTimeLabels(DateTime fecha_desde, DateTime fecha_hasta)
        {
            var result = ConversionService.GetDatesGroupedByYearMonth(fecha_desde, fecha_hasta);
            return result.Select(x => $"{((Enums.Mes)(x.Month - 1)).GetDescription().Translate().Substring(0, 3)} {x.Year}").ToList();
        }
    }
}
