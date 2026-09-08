using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Magnitud de frecuencia de tiempo con las opciones seleccionables de cara a usuario.
    /// </summary>
    public enum FrecuenciaSimplificada
    {
        [Description("Año(s)")]
        Años,
        [Description("Mes(es)")]
        Meses,
        [Description("Semana(s)")]
        Semanas,
        [Description("Día(s)")]
        Dias
    }
}
