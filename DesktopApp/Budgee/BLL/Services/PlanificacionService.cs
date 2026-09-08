using BLL.Contracts;
using DAL.Factories;
using Domain;
using SL.Services;
using SL.Services.Extensions;
using System;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Planificación.
    /// </summary>
    public class PlanificacionService : GenericTransaccionService<Domain.Planificacion>
    {
        #region Singleton
        private readonly static PlanificacionService _instance;
        public static PlanificacionService Current { get { return _instance; } }
        static PlanificacionService() { _instance = new PlanificacionService(); }
        private PlanificacionService()
        {
            //Implent here the initialization of your singleton
            repository = Factory.Current.PlanificacionRepository;
        }
        #endregion

        public override void Add(Domain.Planificacion obj)
        {
            try
            {
                base.Add(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Generate_Transaccion, obj);

                LogService.Log($"Creación de planificación: {obj.ID_Planificacion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void Update(Domain.Planificacion obj)
        {
            try
            {
                base.Update(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Generate_Transaccion, obj);

                LogService.Log($"Modificación de planificación: {obj.ID_Planificacion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void AddOrUpdate(Domain.Planificacion obj)
        {
            try
            {
                base.AddOrUpdate(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Generate_Transaccion, obj);

                LogService.Log($"Creación/Modificación de planificación: {obj.ID_Planificacion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void Remove(Domain.Planificacion obj)
        {
            try
            {
                base.Remove(obj);

                SchedulerService.Current.RemoveTask(SchedulerService.Task_Type.Generate_Transaccion, obj);

                LogService.Log($"Eliminación de planificación: {obj.ID_Planificacion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public void GenerateTransaccionPendiente(Domain.Planificacion obj)
        {
            try
            {
                var transaccion = new Domain.Transaccion(
                    Guid.NewGuid(),
                    DateTime.Now,
                    obj.Cuenta,
                    false,
                    obj.Descripcion_Transaccion,
                    obj.Categoria,
                    obj.Etiquetas,
                    obj.MontoExpresion,
                    obj.TipoOperacion,
                    true);

                TransaccionService.Current.Add(transaccion);

                if (obj.FrecuenciaInicio.FrecuenciaMagnitud == null)
                {
                    obj.Habilitado = false;

                    if (obj.QuitarAlConcluir)
                        obj.Estado = false;

                    Update(obj);
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
