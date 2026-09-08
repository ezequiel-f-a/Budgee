using System;

namespace SL.Domain
{
    /// <summary>
    /// Excepción del acceso a datos. Uso únicamente para tipado o herencia.
    /// </summary>
    public class DAL_Exception : Exception
    {
        public DAL_Exception(string message) : base(message)
        {
            Message = message;
        }
        public DAL_Exception(string message, Exception innerException) : base(message, innerException)
        {
            Message = message;
        }
        public new string Message { get; private set; }
    }
}
