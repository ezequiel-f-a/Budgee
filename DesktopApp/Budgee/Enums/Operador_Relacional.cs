using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Operador relacional utilizable para la condición de los presupuestos.
    /// </summary>
    public enum Operador_Relacional
    {
        [Description("Mayor a")]
        Mayor_a,
        [Description("Menor a")]
        Menor_a,
        [Description("Mayor o Igual a")]
        Mayor_o_Igual_a,
        [Description("Menor o Igual a")]
        Menor_o_Igual_a,
        [Description("Igual a")]
        Igual_a,
        [Description("Diferente de")]
        Diferente_de
    }
}
