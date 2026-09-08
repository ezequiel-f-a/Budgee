using System;

namespace SL.Domain
{
    /// <summary>
    /// Excepción del negocio. Uso únicamente para tipado o herencia.
    /// </summary>
    public class BLL_Exception : Exception
    {
        public BLL_Exception(string message) : base(message)
        {
            Message = message;
        }
        public BLL_Exception(string message, Exception innerException) : base(message, innerException)
        {
            Message = message;
        }
        public new string Message { get; private set; }
    }
}
