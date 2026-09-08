using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    /// <summary>
    /// Interfaz generica para acceso general de repositorio.
    /// Tiene el propósito de realizar operaicones globales, como eliminar todos los elementos pertenecientes a un usuario.
    /// </summary>
    public interface IGeneralRepository
    {
        void RemoveAll(SL.Domain.Security.Usuario Usuario);
    }
}
