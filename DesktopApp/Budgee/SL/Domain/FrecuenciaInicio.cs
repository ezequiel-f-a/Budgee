using Enums;
using SL.Domain.Security;
using System;

namespace SL.Domain
{
    /// <summary>
    /// Bloque de datos que puede poseer tanto una fecha en particular como una frecuencia con cierta magnitud y valor
    /// (e.g.: Lunes cada 2 semanas, último día todos los meses, todos los días a las 18hs).
    /// </summary>
    [Serializable]
    public class FrecuenciaInicio
    {
        Guid _ID_FrecuenciaInicio;
        Frecuencia? _FrecuenciaMagnitud;
        int? _FrecuenciaValor;
        int? _Año;
        int? _Mes;
        Dia_del_Mes? _DiaDelMes;
        Dia_de_la_Semana? _DiaDeLaSemana;
        TimeSpan _Horario;
        DateTime? _FechaUltimoProceso;
        Guid _ID_Usuario;

        public FrecuenciaInicio(Guid iD_FrecuenciaInicio, Frecuencia? frecuenciaMagnitud, int? frecuenciaValor, int? año, int? mes, Dia_del_Mes? diaDelMes, Dia_de_la_Semana? diaDeLaSemana, TimeSpan horario, DateTime? fechaUltimoProceso, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            FrecuenciaMagnitud = frecuenciaMagnitud;
            FrecuenciaValor = frecuenciaValor;
            Año = año;
            Mes = mes;
            DiaDelMes = diaDelMes;
            DiaDeLaSemana = diaDeLaSemana;
            Horario = horario;
            FechaUltimoProceso = fechaUltimoProceso;
            ID_Usuario = id_usuario;
        } //Completo (para trabajar con DB)

        public FrecuenciaInicio(DateTime fecha, Guid iD_FrecuenciaInicio, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            Año = fecha.Year;
            Mes = fecha.Month;
            DiaDelMes = GetDiaDelMes_From_Date(fecha);
            Horario = fecha.TimeOfDay;
            ID_Usuario = id_usuario;

            Validate_FrecuenciaConsistentWithData();
        } //Eventual
        public FrecuenciaInicio(Frecuencia frecuencia_magnitud, int frecuencia_valor, int mes, Dia_del_Mes dia_del_mes, TimeSpan horario, Guid iD_FrecuenciaInicio, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            FrecuenciaMagnitud = frecuencia_magnitud;
            FrecuenciaValor = frecuencia_valor;
            Mes = mes;
            DiaDelMes = dia_del_mes;
            Horario = horario;
            ID_Usuario = id_usuario;

            Validate_FrecuenciaConsistentWithData();
        } //Anual
        public FrecuenciaInicio(Frecuencia frecuencia_magnitud, int frecuencia_valor, Dia_del_Mes dia_del_mes, TimeSpan horario, Guid iD_FrecuenciaInicio, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            FrecuenciaMagnitud = frecuencia_magnitud;
            FrecuenciaValor = frecuencia_valor;
            DiaDelMes = dia_del_mes;
            Horario = horario;
            ID_Usuario = id_usuario;

            Validate_FrecuenciaConsistentWithData();
        } //Mensual
        public FrecuenciaInicio(Frecuencia frecuencia_magnitud, int frecuencia_valor, Dia_de_la_Semana dia_de_la_semana, TimeSpan horario, Guid iD_FrecuenciaInicio, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            FrecuenciaMagnitud = frecuencia_magnitud;
            FrecuenciaValor = frecuencia_valor;
            DiaDeLaSemana = dia_de_la_semana;
            Horario = horario;
            ID_Usuario = id_usuario;

            Validate_FrecuenciaConsistentWithData();
        } //Semanal
        public FrecuenciaInicio(Frecuencia frecuencia_magnitud, int frecuencia_valor, TimeSpan horario, Guid iD_FrecuenciaInicio, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            FrecuenciaMagnitud = frecuencia_magnitud;
            FrecuenciaValor = frecuencia_valor;
            Horario = horario;
            ID_Usuario = id_usuario;

            Validate_FrecuenciaConsistentWithData();
        } //Diaria, por Hora, Minutos, Segundos y Milisegundos
        public FrecuenciaInicio(Frecuencia frecuencia_magnitud, int frecuencia_valor, DateTime inicio, Guid iD_FrecuenciaInicio, Guid id_usuario)
        {
            ID_FrecuenciaInicio = iD_FrecuenciaInicio;
            ID_Usuario = id_usuario;

            FrecuenciaMagnitud = frecuencia_magnitud;
            FrecuenciaValor = frecuencia_valor;

            //Año = inicio.Year; //Si tiene frecuencia nunca va a tener año, solo para fechas

            switch (frecuencia_magnitud)
            {
                case Frecuencia.Años:
                    Mes = inicio.Month;
                    DiaDelMes = GetDiaDelMes_From_Date(inicio);
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Meses:
                    DiaDelMes = GetDiaDelMes_From_Date(inicio);
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Semanas:
                    DiaDeLaSemana = (Dia_de_la_Semana)inicio.DayOfWeek;
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Dias:
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Horas:
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Minutos:
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Segundos:
                    Horario = inicio.TimeOfDay;
                    break;
                case Frecuencia.Milisegundos:
                    Horario = inicio.TimeOfDay;
                    break;
            }

            Validate_FrecuenciaConsistentWithData();
        } //Abstracta, se encarga de decidir en función a un datetime

        private void Validate_FrecuenciaConsistentWithData()
        {
            switch (this.FrecuenciaMagnitud)
            {
                case null: if (Año == null || Mes == null || DiaDelMes == null) throw new Exception("La frecuencia no coincide con sus parámetros"); break;
                case Frecuencia.Años: if (Mes == null || DiaDelMes == null) throw new Exception("La frecuencia no coincide con sus parámetros"); break;
                case Frecuencia.Meses: if (DiaDelMes == null) throw new Exception("La frecuencia no coincide con sus parámetros"); break;
                case Frecuencia.Semanas: if (DiaDeLaSemana == null) throw new Exception("La frecuencia no coincide con sus parámetros"); break;
                case Frecuencia.Dias: break;
                case Frecuencia.Horas: break;
                case Frecuencia.Minutos: break;
                case Frecuencia.Segundos: break;
                case Frecuencia.Milisegundos: break;
            }
        }
        static int GetDay_From_DiaDelMes(Dia_del_Mes dia_del_mes, int Mes, int Año)
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
        static Dia_del_Mes GetDiaDelMes_From_Date(DateTime fecha)
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

        public Guid ID_FrecuenciaInicio { get => _ID_FrecuenciaInicio; set => _ID_FrecuenciaInicio = value; }
        public Frecuencia? FrecuenciaMagnitud { get => _FrecuenciaMagnitud; set => _FrecuenciaMagnitud = value; }
        public int? FrecuenciaValor { get => _FrecuenciaValor; set => _FrecuenciaValor = value; }
        public int? Año { get => _Año; set => _Año = value; }
        public int? Mes { get => _Mes; set => _Mes = value; }
        public Dia_del_Mes? DiaDelMes { get => _DiaDelMes; set => _DiaDelMes = value; }
        public Dia_de_la_Semana? DiaDeLaSemana { get => _DiaDeLaSemana; set => _DiaDeLaSemana = value; }
        public TimeSpan Horario { get => _Horario; set => _Horario = value; }
        public DateTime? FechaUltimoProceso { get => _FechaUltimoProceso; set => _FechaUltimoProceso = value; }
        public Guid ID_Usuario { get => _ID_Usuario; set => _ID_Usuario = value; }
    }
}
