using SL.Services;

namespace BLL.BusinessExceptions
{
    /// <summary>
    /// Excepción de SchedulerService que informa cuando el recurso asignado de una tarea no es propio de el tipo de tarea.
    /// </summary>
    public class ResourceDoesNotMatchTaskException : SL.Domain.BLL_Exception
    {
        public ResourceDoesNotMatchTaskException() : base("El recurso no coincide con la tarea")
        {

        }
    }
}
