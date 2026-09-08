using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Elementos a los que puede apuntar una variable.
    /// </summary>
    public enum Variable_Target
    {
        [Description("Transacción")]
        Transaccion,
        [Description("Planificación")]
        Planificacion,
        [Description("Plantilla")]
        Plantilla,
        [Description("Cuenta")]
        Cuenta,
        [Description("Categoría")]
        Categoria,
        [Description("Etiqueta")]
        Etiqueta
    }
}
