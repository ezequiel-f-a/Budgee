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
    /// Servicio del negocio de Familia.
    /// </summary>
    public class FamiliaService : IGenericBusinessLogic<Domain.Security.Familia>
    {
        #region Singleton
        private readonly static FamiliaService _instance;
        public static FamiliaService Current { get { return _instance; } }
        static FamiliaService() { _instance = new FamiliaService(); }
        private FamiliaService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Security.Familia> repository = Factory.Current.FamiliaRepository;

        public Familia GetOne(Guid ID)
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
        public IEnumerable<Familia> GetAll()
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
        public IEnumerable<Familia> GetAll(Func<Familia, bool> filter)
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
        public void Add(Familia obj)
        {
            try
            {
                repository.Add(obj);

                LogService.Log($"Creación de perfil: {obj.ID_Familia}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Familia obj)
        {
            try
            {
                repository.Update(obj);

                LogService.Log($"Modificación de perfil: {obj.ID_Familia}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Familia obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                LogService.Log($"Creación/Modificación de perfil: {obj.ID_Familia}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Familia obj)
        {
            try
            {
                repository.Remove(obj);

                LogService.Log($"Eliminación de perfil: {obj.ID_Familia}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Familia, bool> filter)
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
