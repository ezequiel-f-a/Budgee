using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Dias de la semana
    /// </summary>
    public enum Dia_de_la_Semana
    {
        [Description("Domingo")]
        Domingo,
        [Description("Lunes")]
        Lunes,
        [Description("Martes")]
        Martes,
        [Description("Miércoles")]
        Miercoles,
        [Description("Jueves")]
        Jueves,
        [Description("Viernes")]
        Viernes,
        [Description("Sábado")]
        Sabado
    }
}
