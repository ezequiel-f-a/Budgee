using BLL.Services;
using Domain;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    /// <summary>
    /// Interfaz generica de transacciones para servicios del negocio, donde T herede de una transacción genérica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericTransaccionService<T> : IGenericBusinessLogic<T> where T : Domain.GenericTransaccion
    {
        protected IGenericRepository<T> repository;

        public virtual T GetOne(Guid ID)
        {
            try
            {
                return repository.GetOne(ID);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            try
            {
                return repository.GetAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual void Add(T obj)
        {
            try
            {
                repository.Add(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual void Remove(T obj)
        {
            try
            {
                repository.Remove(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual void RemoveAll(Func<T, bool> filter)
        {
            try
            {
                repository.RemoveAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual void Update(T obj)
        {
            try
            {
                repository.Update(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public virtual void AddOrUpdate(T obj)
        {
            try
            {
                repository.AddOrUpdate(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public decimal GetMonto(T obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                if (obj.MontoExpresion == null) return 0;

                decimal transaccionMonto = ExpresionService.Current.GetResult(obj.MontoExpresion, transacciones);

                if (obj.TipoOperacion == Enums.Tipo_Operacion.Egreso)
                    return transaccionMonto * (-1);
                else return transaccionMonto;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
