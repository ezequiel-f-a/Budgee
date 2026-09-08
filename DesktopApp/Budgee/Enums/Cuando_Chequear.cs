using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Alternativas de chequeo de presupuesto.
    /// </summary>
    public enum Cuando_Chequear
    {
        [Description("Constantemente")]
        Constantemente,
        [Description("Al Inicio")]
        Al_Inicio,
        [Description("Al Final")]
        Al_Final,
    }
}
