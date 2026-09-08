using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    /// <summary>
    /// Interfaz generica para estadística, donde T herede de Estadística.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEstadisticaService<T> where T : Domain.Estadistica
    {
        T GetEstadistica();
    }
}
