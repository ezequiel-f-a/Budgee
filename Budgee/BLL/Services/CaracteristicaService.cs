using DAL.Factories;
using Domain;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Característica.
    /// </summary>
    public class CaracteristicaService : IGenericBusinessLogic<Domain.Caracteristica>
    {
        #region Singleton
        private readonly static CaracteristicaService _instance;
        public static CaracteristicaService Current { get { return _instance; } }
        static CaracteristicaService() { _instance = new CaracteristicaService(); }
        private CaracteristicaService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Caracteristica> repository = Factory.Current.CaracteristicaRepository;

        public Caracteristica GetOne(Guid ID)
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
        public IEnumerable<Caracteristica> GetAll()
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
        public IEnumerable<Caracteristica> GetAll(Func<Caracteristica, bool> filter)
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
        public void Add(Caracteristica obj)
        {
            try
            {
                repository.Add(obj);

                LogService.Log($"Creación de característica: {obj.ID_Caracteristica}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Caracteristica obj)
        {
            try
            {
                repository.Update(obj);

                LogService.Log($"Modificación de característica: {obj.ID_Caracteristica}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Caracteristica obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                if (!obj.Estado) (repository as dynamic).SetReferencesNull(obj);

                LogService.Log($"Creación/Modificación de característica: {obj.ID_Caracteristica}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Caracteristica obj)
        {
            try
            {
                repository.Remove(obj);

                LogService.Log($"Eliminación de característica: {obj.ID_Caracteristica}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Caracteristica, bool> filter)
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
    }
}
