using System;

namespace SL.Domain
{    /// <summary>
     /// Excepción de interfaz de usuario. Uso únicamente para tipado o herencia.
     /// </summary>
    public class UI_Exception : Exception
    {
        public UI_Exception(string message) : base(message)
        {
            Message = message;
        }
        public UI_Exception(string message, Exception innerException) : base(message, innerException)
        {
            Message = message;
        }
        public new string Message { get; private set; }
    }
}
