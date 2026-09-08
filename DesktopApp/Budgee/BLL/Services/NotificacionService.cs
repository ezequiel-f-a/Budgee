using DAL.Factories;
using Domain;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Notificación.
    /// </summary>
    public class NotificacionService : IGenericBusinessLogic<Domain.Notificacion>
    {
        #region Singleton
        private readonly static NotificacionService _instance;
        public static NotificacionService Current { get { return _instance; } }
        static NotificacionService() { _instance = new NotificacionService(); }
        private NotificacionService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Notificacion> repository = Factory.Current.NotificacionRepository;

        public Notificacion GetOne(Guid ID)
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
        public IEnumerable<Notificacion> GetAll()
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
        public IEnumerable<Notificacion> GetAll(Func<Notificacion, bool> filter)
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
        public void Add(Notificacion obj)
        {
            try
            {
                repository.Add(obj);
                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Delete_NotificacionExpirada, obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Notificacion obj)
        {
            try
            {
                repository.Update(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Delete_NotificacionExpirada, obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Notificacion obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Delete_NotificacionExpirada, obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Notificacion obj)
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
        public void RemoveAll(Func<Notificacion, bool> filter)
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

        public void TriggerNotificacion(Notificacion obj)
        {
            try
            {
                var config = AppData.CurrentUser.Configuracion;

                if(obj.Procedencia == Enums.Procedencia_Notificacion.Presupuesto && config.NotificacionesPresupuestos)
                    repository.Add(obj);
                else if (obj.Procedencia == Enums.Procedencia_Notificacion.Recordatorio && config.NotificacionesRecordatorios)
                    repository.Add(obj);
                else if (obj.Procedencia == Enums.Procedencia_Notificacion.Estadistica && config.NotificacionesEstadisticas)
                    repository.Add(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
