using Enums;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.DAL.Factories;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;

namespace SL.BLL.Services
{
    /// <summary>
    /// Servicio del negocio de FrecuenciaInicio.
    /// </summary>
    public class FrecuenciaInicioService : IGenericBusinessLogic<Domain.FrecuenciaInicio>
    {
        #region Singleton
        private readonly static FrecuenciaInicioService _instance;
        public static FrecuenciaInicioService Current { get { return _instance; } }
        static FrecuenciaInicioService() { _instance = new FrecuenciaInicioService(); }
        private FrecuenciaInicioService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.FrecuenciaInicio> repository = Factory.Current.FrecuenciaInicioRepository;

        public FrecuenciaInicio GetOne(Guid ID)
        {
            try
            {
                return repository.GetOne(ID);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<FrecuenciaInicio> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<FrecuenciaInicio> GetAll(Func<FrecuenciaInicio, bool> filter)
        {
            try
            {
                return repository.GetAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Add(FrecuenciaInicio obj)
        {
            try
            {
                repository.Add(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(FrecuenciaInicio obj)
        {
            try
            {
                repository.Update(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(FrecuenciaInicio obj)
        {
            try
            {
                repository.AddOrUpdate(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(FrecuenciaInicio obj)
        {
            try
            {
                repository.Remove(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<FrecuenciaInicio, bool> filter)
        {
            try
            {
                repository.RemoveAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public int GetDay_From_DiaDelMes(Dia_del_Mes dia_del_mes, int Mes, int Año)
        {
            if (dia_del_mes == Dia_del_Mes.Ultimo)
            {
                return DateTime.DaysInMonth(Año, Mes);
            }
            else if (dia_del_mes == Dia_del_Mes.Penultimo)
            {
                return DateTime.DaysInMonth(Año, Mes) - 1;
            }
            else if (dia_del_mes == Dia_del_Mes.Antepenultimo)
            {
                return DateTime.DaysInMonth(Año, Mes) - 2;
            }
            else
            {
                int index = (int)dia_del_mes;
                return index + 1;
            }

        }
        public Dia_del_Mes GetDiaDelMes_From_Date(DateTime fecha)
        {
            if (fecha.Day == DateTime.DaysInMonth(fecha.Year, fecha.Month))
                return Dia_del_Mes.Ultimo;
            else if (fecha.Day + 1 == DateTime.DaysInMonth(fecha.Year, fecha.Month))
                return Dia_del_Mes.Penultimo;
            else if (fecha.Day + 2 == DateTime.DaysInMonth(fecha.Year, fecha.Month))
                return Dia_del_Mes.Antepenultimo;
            else
                return (Dia_del_Mes)fecha.Day - 1;
        }
        public DateTime? GetNextDate(FrecuenciaInicio frecuenciaInicio, DateTime fecha_referencia)
        {
            DateTime fecha = GetDefaultDate(frecuenciaInicio, fecha_referencia);

            if (fecha < fecha_referencia)
            {
                switch (frecuenciaInicio.FrecuenciaMagnitud)
                {
                    case Frecuencia.Milisegundos: fecha = fecha.AddMilliseconds(1); break;
                    case Frecuencia.Segundos: fecha = fecha.AddSeconds(1); break;
                    case Frecuencia.Minutos: fecha = fecha.AddMinutes(1); break;
                    case Frecuencia.Horas: fecha = fecha.AddHours(1); break;
                    case Frecuencia.Dias: fecha = fecha.AddDays(1); break;
                    case Frecuencia.Semanas: fecha = fecha.AddDays(7); break;
                    case Frecuencia.Meses:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddMonths(1),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                    case Frecuencia.Años:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddYears(1),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                }
            }

            if (fecha == fecha_referencia)
            {
                switch (frecuenciaInicio.FrecuenciaMagnitud)
                {
                    case Frecuencia.Milisegundos: fecha = fecha.AddMilliseconds((int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Segundos: fecha = fecha.AddSeconds((int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Minutos: fecha = fecha.AddMinutes((int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Horas: fecha = fecha.AddHours((int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Dias: fecha = fecha.AddDays((int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Semanas: fecha = fecha.AddDays(7 * (int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Meses:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddMonths((int)frecuenciaInicio.FrecuenciaValor),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                    case Frecuencia.Años:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddYears((int)frecuenciaInicio.FrecuenciaValor),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                }
            }

            if (fecha > fecha_referencia)
                return fecha;
            else
                return null;
        } // <---------------
        public DateTime? GetPreviousDate(FrecuenciaInicio frecuenciaInicio, DateTime fecha_referencia)
        {
            DateTime fecha = GetDefaultDate(frecuenciaInicio, fecha_referencia);

            if (fecha > fecha_referencia)
            {
                switch (frecuenciaInicio.FrecuenciaMagnitud)
                {
                    case Frecuencia.Milisegundos: fecha = fecha.AddMilliseconds(-1); break;
                    case Frecuencia.Segundos: fecha = fecha.AddSeconds(-1); break;
                    case Frecuencia.Minutos: fecha = fecha.AddMinutes(-1); break;
                    case Frecuencia.Horas: fecha = fecha.AddHours(-1); break;
                    case Frecuencia.Dias: fecha = fecha.AddDays(-1); break;
                    case Frecuencia.Semanas: fecha = fecha.AddDays(-7); break;
                    case Frecuencia.Meses:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddMonths(-1),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                    case Frecuencia.Años:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddYears(-1),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                }
            }

            if (fecha == fecha_referencia)
            {
                switch (frecuenciaInicio.FrecuenciaMagnitud)
                {
                    case Frecuencia.Milisegundos: fecha = fecha.AddMilliseconds(-(int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Segundos: fecha = fecha.AddSeconds(-(int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Minutos: fecha = fecha.AddMinutes(-(int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Horas: fecha = fecha.AddHours(-(int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Dias: fecha = fecha.AddDays(-(int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Semanas: fecha = fecha.AddDays(7 * -(int)frecuenciaInicio.FrecuenciaValor); break;
                    case Frecuencia.Meses:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddMonths(-(int)frecuenciaInicio.FrecuenciaValor),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                    case Frecuencia.Años:
                        {
                            fecha = GetFixedDate_ByDiaDelMes(
                                fecha.AddYears(-(int)frecuenciaInicio.FrecuenciaValor),
                                (Dia_del_Mes)frecuenciaInicio.DiaDelMes);
                            break;
                        }
                }
            }

            if (fecha < fecha_referencia)
                return fecha;
            else
                return null;
        }
        public DateTime? GetClosestDate(FrecuenciaInicio frecuenciaInicio, DateTime fecha_referencia)
        {
            DateTime? defaultDate = GetDefaultDate(frecuenciaInicio, fecha_referencia);
            DateTime? previousDate = GetPreviousDate(frecuenciaInicio, fecha_referencia);

            if (defaultDate == null)
                return previousDate;
            else if (previousDate == null)
                return defaultDate;
            else
            {
                DateTime defaultNotNull = (DateTime)defaultDate;
                DateTime previousNotNull = (DateTime)previousDate;

                var distancia_default = Math.Abs(fecha_referencia.Ticks - defaultNotNull.Ticks);
                var distancia_previous = Math.Abs(fecha_referencia.Ticks - previousNotNull.Ticks);

                if (distancia_default < distancia_previous)
                    return defaultNotNull;
                else
                    return previousNotNull;
            }
        }
        public DateTime GetDefaultDate(FrecuenciaInicio frecuenciaInicio, DateTime fecha_referencia)
        {
            int año = fecha_referencia.Year;
            int mes = fecha_referencia.Month;
            int diaMes = fecha_referencia.Day;
            int hora = fecha_referencia.Hour;
            int minuto = fecha_referencia.Minute;
            int segundo = fecha_referencia.Second;
            int milisegundo = fecha_referencia.Millisecond;

            switch (frecuenciaInicio.FrecuenciaMagnitud)
            {
                case Frecuencia.Milisegundos:
                    {
                        break;
                    }
                case Frecuencia.Segundos:
                    {
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case Frecuencia.Minutos:
                    {
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case Frecuencia.Horas:
                    {
                        minuto = frecuenciaInicio.Horario.Minutes;
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case Frecuencia.Dias:
                    {
                        hora = frecuenciaInicio.Horario.Hours;
                        minuto = frecuenciaInicio.Horario.Minutes;
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case Frecuencia.Semanas:
                    {
                        DateTime nextWeekday = GetNextWeekday(fecha_referencia, (DayOfWeek)frecuenciaInicio.DiaDeLaSemana);
                        mes = nextWeekday.Month;
                        diaMes = nextWeekday.Day;
                        hora = frecuenciaInicio.Horario.Hours;
                        minuto = frecuenciaInicio.Horario.Minutes;
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case Frecuencia.Meses:
                    {
                        diaMes = GetDay_From_DiaDelMes((Dia_del_Mes)frecuenciaInicio.DiaDelMes, mes, año);
                        hora = frecuenciaInicio.Horario.Hours;
                        minuto = frecuenciaInicio.Horario.Minutes;
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case Frecuencia.Años:
                    {
                        mes = (int)frecuenciaInicio.Mes;
                        diaMes = GetDay_From_DiaDelMes((Dia_del_Mes)frecuenciaInicio.DiaDelMes, mes, año);
                        hora = frecuenciaInicio.Horario.Hours;
                        minuto = frecuenciaInicio.Horario.Minutes;
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
                case null:
                    {
                        año = (int)frecuenciaInicio.Año;
                        mes = (int)frecuenciaInicio.Mes;
                        diaMes = GetDay_From_DiaDelMes((Dia_del_Mes)frecuenciaInicio.DiaDelMes, mes, año);
                        hora = frecuenciaInicio.Horario.Hours;
                        minuto = frecuenciaInicio.Horario.Minutes;
                        segundo = frecuenciaInicio.Horario.Seconds;
                        milisegundo = frecuenciaInicio.Horario.Milliseconds;
                        break;
                    }
            }

            return new DateTime(año, mes, diaMes, hora, minuto, segundo, milisegundo);
        }
        public IEnumerable<DateTime> GetDates_InRange(FrecuenciaInicio frecuenciaInicio, DateTime start, DateTime end)
        {
            List<DateTime> datesInRange = new List<DateTime>();

            DateTime defaultDate = GetDefaultDate(frecuenciaInicio, start);

            while (defaultDate < end)
            {
                if (defaultDate >= start)
                    datesInRange.Add(defaultDate);

                DateTime? temp = GetNextDate(frecuenciaInicio, defaultDate);

                if (temp != null)
                    defaultDate = (DateTime)temp;
                else break;
            }

            return datesInRange;
        }
        public DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
        public DateTime GetPreviousWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek - 7) % 7;
            return start.AddDays(daysToAdd);
        }
        private DateTime GetFixedDate_ByDiaDelMes(DateTime date, Dia_del_Mes diaDelMes)
        {
            return new DateTime(
                                date.Year,
                                date.Month,
                                GetDay_From_DiaDelMes(
                                    diaDelMes,
                                    date.Month,
                                    date.Year),
                                date.Hour,
                                date.Minute,
                                date.Second,
                                date.Millisecond);
        }

        public string GetDescription(FrecuenciaInicio obj)
        {
            if (obj.FrecuenciaMagnitud != null)
            {
                return
                    $"" +
                    $"{"Cada".Translate()} " +
                    $"{obj.FrecuenciaValor} " +
                    $"{((Frecuencia)obj.FrecuenciaMagnitud).GetDescription().Translate()}" +
                    $", {GetDescriptionInicio(obj)}" +
                    $"";
            }
            else
            {
                return GetDescriptionInicio(obj);
            }
        }
        private string GetDescriptionInicio(FrecuenciaInicio obj)
        {
            string inicio = null; //= $"{"Inicio".Translate()}: ";

            if (obj.Año != null)
                inicio += $"{"Año".Translate()}: {obj.Año}";

            if (obj.Mes != null)
            {
                inicio = SumarComaSiNecesita(inicio);
                inicio += $"{"Mes".Translate()}: {((Mes)(obj.Mes - 1)).GetDescription().Translate()}";
            }

            if (obj.DiaDelMes != null)
            {
                inicio = SumarComaSiNecesita(inicio);
                inicio += $"{"Día".Translate()}: {((Dia_del_Mes)obj.DiaDelMes).GetDescription().Translate()}";
            }

            if (obj.DiaDeLaSemana != null)
            {
                inicio = SumarComaSiNecesita(inicio);
                inicio += $"{"Día".Translate()}: {((Dia_del_Mes)obj.DiaDeLaSemana).GetDescription().Translate()}";
            }

            if (obj.Horario != null)
            {
                inicio = SumarComaSiNecesita(inicio);
                inicio += $"{"Horario".Translate()}: {obj.Horario.ToString("hh\\:mm\\:ss")}";
            }

            return inicio;
        }
        private string SumarComaSiNecesita(string text)
        {
            if (text == null || text.Length == 0) return text;
            else if (text.Length == 1) return text + ", ";
            else if (text.Length > 1 && text.Substring(text.Length - 2) != ", ") return text + ", ";
            else return text;
        }
    }
}
