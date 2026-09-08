using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Procedencias posibles de una notificación.
    /// </summary>
    public enum Procedencia_Notificacion
    {
        [Description("Presupuesto")]
        Presupuesto,
        [Description("Recordatorio")]
        Recordatorio,
        [Description("Estadística")]
        Estadistica,
    }
}
