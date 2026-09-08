using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Tipos de operación asignables a las transacciones.
    /// </summary>
    public enum Tipo_Operacion
    {
        [Description("Ingreso")]
        Ingreso,
        [Description("Egreso")]
        Egreso,
        [Description("Variable")]
        Variable
    }
}
