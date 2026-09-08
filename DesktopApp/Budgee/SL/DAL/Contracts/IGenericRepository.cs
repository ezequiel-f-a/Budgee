using System;
using System.Collections.Generic;

namespace SL.DAL.Contracts
{
    /// <summary>
    /// Interfaz generica para repositorios, donde T es la entidad de dominio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void AddOrUpdate(T obj);
        void Remove(T obj);
        void RemoveAll(Func<T, bool> filter);
        T GetOne(Guid ID);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> filter);
    }
}
