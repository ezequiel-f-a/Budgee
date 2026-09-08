using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Tipos de variable utilizables en expresiones o en la variable supervisada de un presupuesto.
    /// </summary>
    public enum Tipo_Variable
    {
        [Description("Monto")]
        Monto,
        [Description("Ingreso")]
        Ingreso,
        [Description("Egreso")]
        Egreso,
        [Description("Ganancia Neta")]
        Ganancia_Neta,
        [Description("Balance")]
        Balance,
        [Description("Ingreso Potencial")]
        Ingreso_Potencial,
        [Description("Egreso Potencial")]
        Egreso_Potencial,
        [Description("Ganancia Neta Potencial")]
        Ganancia_Neta_Potencial,
        [Description("Balance Potencial")]
        Balance_Potencial
    }
}
