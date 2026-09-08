using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.DAL.Factories;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;

namespace SL.BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Patente.
    /// </summary>
    public class PatenteService : IGenericBusinessLogic<Domain.Security.Patente>
    {
        #region Singleton
        private readonly static PatenteService _instance;
        public static PatenteService Current { get { return _instance; } }
        static PatenteService() { _instance = new PatenteService(); }
        private PatenteService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Security.Patente> repository = Factory.Current.PatenteRepository;

        public Patente GetOne(Guid ID)
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
        public IEnumerable<Patente> GetAll()
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
        public IEnumerable<Patente> GetAll(Func<Patente, bool> filter)
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
        public void Add(Patente obj)
        {
            try
            {
                repository.Add(obj);

                LogService.Log($"Creación de perfil: {obj.ID_Patente}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Patente obj)
        {
            try
            {
                repository.Update(obj);

                LogService.Log($"Modificación de perfil: {obj.ID_Patente}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Patente obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                LogService.Log($"Creación/Modificación de perfil: {obj.ID_Patente}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Patente obj)
        {
            try
            {
                repository.Remove(obj);

                LogService.Log($"Eliminación de perfil: {obj.ID_Patente}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Patente, bool> filter)
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
