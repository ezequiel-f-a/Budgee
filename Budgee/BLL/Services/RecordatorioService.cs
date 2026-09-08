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
    /// Servicio del negocio de Recordatorio.
    /// </summary>
    public class RecordatorioService : IGenericBusinessLogic<Domain.Recordatorio>
    {
        #region Singleton
        private readonly static RecordatorioService _instance;
        public static RecordatorioService Current { get { return _instance; } }
        static RecordatorioService() { _instance = new RecordatorioService(); }
        private RecordatorioService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Recordatorio> repository = Factory.Current.RecordatorioRepository;

        public Recordatorio GetOne(Guid ID)
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
        public IEnumerable<Recordatorio> GetAll()
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
        public IEnumerable<Recordatorio> GetAll(Func<Recordatorio, bool> filter)
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
        public void Add(Recordatorio obj)
        {
            try
            {
                //FALTA
                if (obj.NotificacionWindows)
                {
                    //Agregar notificacion
                }
                if (obj.AlarmaWindows)
                {
                    //Agregar alarma
                }

                repository.Add(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Trigger_Recordatorio, obj);

                LogService.Log($"Creación de recordatorio: {obj.ID_Recordatorio}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Recordatorio obj)
        {
            try
            {
                //FALTA
                if (!obj.NotificacionWindows)
                {
                    //Actualizar notificacion
                }
                if (!obj.AlarmaWindows)
                {
                    //Actualizar alarma
                }

                repository.Update(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Trigger_Recordatorio, obj);

                LogService.Log($"Modificación de recordatorio: {obj.ID_Recordatorio}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Recordatorio obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Trigger_Recordatorio, obj);

                LogService.Log($"Creación/Modificación de recordatorio: {obj.ID_Recordatorio}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Recordatorio obj)
        {
            try
            {
                //FALTA
                if (obj.NotificacionWindows)
                {
                    //Remover notificacion
                }
                if (obj.AlarmaWindows)
                {
                    //Remover alarma
                }

                repository.Remove(obj);

                SchedulerService.Current.RemoveTask(SchedulerService.Task_Type.Trigger_Recordatorio, obj);

                LogService.Log($"Eliminación de recordatorio: {obj.ID_Recordatorio}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Recordatorio, bool> filter)
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

        public void TriggerRecordatorio(Recordatorio obj)
        {
            try
            {
                var notif = new Notificacion(Guid.NewGuid(), $"{"Recordatorio".Translate()} - {obj.Descripcion}", DateTime.Now, Enums.Procedencia_Notificacion.Recordatorio, null, obj, null, obj.Usuario, false, true);
                NotificacionService.Current.TriggerNotificacion(notif);

                if(obj.FrecuenciaInicio.FrecuenciaMagnitud == null)
                {
                    obj.Habilitado = false;

                    if (obj.QuitarAlConcluir)
                        obj.Estado = false;

                    Update(obj);
                }

                LogService.Log($"Recordatorio disparado: {obj.ID_Recordatorio}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
