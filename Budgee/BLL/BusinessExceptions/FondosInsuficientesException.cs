using SL.Services;

namespace BLL.BusinessExceptions
{
    /// <summary>
    /// Excepción que sucede cuando el balance de una cuenta que no admite fondos negativos, se vuelve negativo.
    /// </summary>
    public class FondosInsuficientesException : SL.Domain.BLL_Exception
    {
        public FondosInsuficientesException() : base("Realizar esta operación derivaría en un balance negativo para la cuenta correspondiente.\nEl balance considerado es aquel de la fecha de la transacción")
        {

        }
    }
}
