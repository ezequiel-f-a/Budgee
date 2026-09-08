using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Magnitud de frecuencia de tiempo.
    /// </summary>
    public enum Frecuencia
    {
        [Description("Año(s)")]
        Años,
        [Description("Mes(es)")]
        Meses,
        [Description("Semana(s)")]
        Semanas,
        [Description("Día(s)")]
        Dias,
        [Description("Hora(s)")]
        Horas,
        [Description("Minuto(s)")]
        Minutos,
        [Description("Segundo(s)")]
        Segundos,
        [Description("Milisegundo(s)")]
        Milisegundos
    }
}
