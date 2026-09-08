using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Divisas utilizables en la aplicación.
    /// </summary>
    public enum Divisa
    {
        [Description("ARS")]
        ARS,
        [Description("USD")]
        USD,
        [Description("EUR")]
        EUR,
        [Description("BTC")]
        BTC
    }
}
