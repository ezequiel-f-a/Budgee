using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Tipos de estadística disponibles.
    /// </summary>
    public enum Tipo_Estadistica
    {
        [Description("Overview")]
        Overview,
        [Description("Ingreso/Egreso")]
        IngresoEgreso,
        [Description("Patrimonio Neto")]
        PatrimonioNeto,
        [Description("Distribución")]
        Distribucion,
        [Description("Holgura de Presupuesto")]
        Presupuesto,
    }
}
