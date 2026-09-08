using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 1, 1, 1, 1);
        }
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek)
        {
            while (date.DayOfWeek != startOfWeek)
                date = date.AddDays(-1);

            return new DateTime(date.Year, date.Month, date.Day, 1, 1, 1, 1);
        }
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek endOfWeek)
        {
            while (date.DayOfWeek != endOfWeek)
                date = date.AddDays(1);

            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 1, 1, 1, 1);
        }
        public static DateTime EndOfMonth(this DateTime date)
        {
            var end = date.StartOfMonth().AddMonths(1).AddDays(-1);
            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }
        public static DateTime StartOfTrimester(this DateTime date)
        {
            int count_of_unity = 4; //Hay 4 trimestres
            int months_per_unity = 12 / count_of_unity; //Cada trimestre tiene 3 meses
            int date_part = Convert.ToInt32(Math.Ceiling((double)date.Month / (double)months_per_unity));
            int ending_month = months_per_unity * date_part;
            return new DateTime(date.Year, ending_month, 1, 1, 1, 1, 1).AddMonths(1 - months_per_unity);
        }
        public static DateTime EndOfTrimester(this DateTime date)
        {
            var end = date.StartOfTrimester().AddMonths(3).AddDays(-1);
            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }
        public static DateTime StartOfQuarter(this DateTime date)
        {
            int count_of_unity = 3; //Hay 3 cuatrimestres
            int months_per_unity = 12 / count_of_unity; //Cada cuatrimestre tiene 4 meses
            int date_part = Convert.ToInt32(Math.Ceiling((double)date.Month / (double)months_per_unity));
            int ending_month = months_per_unity * date_part;
            return new DateTime(date.Year, ending_month, 1, 1, 1, 1, 1).AddMonths(1 - months_per_unity);
        }
        public static DateTime EndOfQuarter(this DateTime date)
        {
            var end = date.StartOfQuarter().AddMonths(4).AddDays(-1);
            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }
        public static DateTime StartOfSemester(this DateTime date)
        {
            int count_of_unity = 2; //Hay 2 semestres
            int months_per_unity = 12 / count_of_unity; //Cada semestre tiene 6 meses
            int date_part = Convert.ToInt32(Math.Ceiling((double)date.Month / (double)months_per_unity));
            int ending_month = months_per_unity * date_part;
            return new DateTime(date.Year, ending_month, 1, 1, 1, 1, 1).AddMonths(1 - months_per_unity);
        }
        public static DateTime EndOfSemester(this DateTime date)
        {
            var end = date.StartOfSemester().AddMonths(6).AddDays(-1);
            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }
        public static DateTime StartOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1, 1, 1, 1, 1);
        }
        public static DateTime EndOfYear(this DateTime date)
        {
            var end = date.StartOfYear().AddYears(1).AddDays(-1);
            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
        }
    }
}
