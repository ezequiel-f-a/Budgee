using SL.Services;

namespace BLL.BusinessExceptions
{
    /// <summary>
    /// Excepción de SchedulerService que informa cuando el tipo de tarea seleccionado no posee un manejo en el servicio.
    /// </summary>
    public class UnknownTaskException : SL.Domain.BLL_Exception
    {
        public UnknownTaskException() : base("El tipo de tarea no es reconocido")
        {

        }
    }
}
