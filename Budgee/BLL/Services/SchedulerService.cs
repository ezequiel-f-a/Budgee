using BLL.BusinessExceptions;
using Domain;
using Enums;
using SL.BLL.Services;
using SL.Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace BLL.Services
{
    /// <summary>
    /// Servicio que se encarga de ejecutar tareas programadas.
    /// Entre estas tareas encontramos: Planificación de transacciones, chequeo de presupuestos, disparo de recordatorios, 
    /// eliminación de notificaciones expiradas, generación de backups automática y tracking de sesión.
    /// </summary>
    public class SchedulerService
    {
        #region Singleton
        private readonly static SchedulerService _instance;
        public static SchedulerService Current { get { return _instance; } }
        static SchedulerService() { _instance = new SchedulerService(); }
        private SchedulerService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public UniqueList<(Task_Type taskType, dynamic resource)>
            StaticTasks = new UniqueList<(Task_Type, dynamic)>(); //TaskType+object debería ser unique

        public UniqueList<(DateTime programmedDate, Task_Type taskType, dynamic resource)>
            DynamicTasks = new UniqueList<(DateTime, Task_Type, dynamic)>(); //DateTime+TaskType+oject debería ser unique

        private TaskTimer task_StaticToDynamic;
        private TaskTimer task_TaskCollectorCheck;

        private int IncomingTasksRange_Minutes = AppData.Config.IncomingTasksRange_Minutes;
        private int CollectorDelay_ms = AppData.Config.TaskCollectorDelay_ms;

        private DateTime? ultimo_cierre_sesion;
        private DateTime? ultimo_inicio_sesion;

        bool taskCollector_checking = false;

        object flag_thread = new object();

        public void Startup()
        {
            try
            {
                LogService.Log("Inicialización de servicio de tareas programadas (comienzo de proceso)", LogService.LogSeverity.Info);

                //INICIALIZO VARIABLES NECESARIAS
                ultimo_cierre_sesion =
                    SesionTrackService.Current.GetUltimoTrackSesionAnterior(AppData.CurrentUser)?.FechaProceso;

                ultimo_inicio_sesion =
                    SesionTrackService.Current.GetUltimoTrackSesion(AppData.CurrentUser, Tipo_Track.Inicio_Sesion)?.FechaProceso;

                //AL INICIALIZARSE, SE TRAE TODAS LAS TASKS PENDIENTES, QUE PUDIERON HABER QUEDADO EN EL 
                //AIRE CON LA APLICACIÓN APAGADA (e.g.: Expirar Notif., Recordatorio),
                //AL IGUAL QUE AQUELLAS PERMANENTES (e.g.: Track de Sesión, Generar Backups)
                Retrieve_Tasks();

                //AHORA QUE YA OBTUVIMOS NUESTRA LISTA ESTÁTICA DE TAREAS, GENERAREMOS LA DINÁMICA,
                //QUE POSEERÁ, EN VEZ DE FRECUENCIA E INICIO, UNA FECHA PROGRAMADA
                StaticToDynamicBatch();

                //TAMBIÉN INICIAREMOS UN THREAD QUE SE ENCARGARÁ CADA 30 MIN DE LLEVARSE TAREAS DE LA 
                //LISTA ESTÁTICA A LA DINÁMICA.
                Start_StaticToDynamic_Thread();

                //POR ÚLTIMO, INICIAREMOS OTRO THREAD QUE SE ENCARGARÁ CADA 0,5s DE VERIFICAR SI LLEGÓ EL MOMENTO DE
                //EJECUTAR Y DESPACHAR LA PRIMERA TAREA EN LA LISTA DINÁMICA. Watcher y Timer.
                Start_TaskCollector_Thread();

                LogService.Log("Inicialización de servicio de tareas programadas (fin de proceso)", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Stop()
        {
            lock (flag_thread)
            {
                task_StaticToDynamic.Stop();
                task_TaskCollectorCheck.Stop();

                StaticTasks.Clear();
                DynamicTasks.Clear();

                ultimo_cierre_sesion = null;
                ultimo_inicio_sesion = null;
            }
        }
        private void Retrieve_Tasks()
        {
            try
            {
                LogService.Log("Obtención de tareas programadas (comienzo de proceso)", LogService.LogSeverity.Info);

                //DESDE ACÁ ME TRAIGO TODAS LAS TASKS, CON RESPONSABILIDAD MODULADA EN MÉTODOS
                Retrieve_Tasks_ForGenerateTransaccionesFromPlanificaciones();
                Retrieve_Tasks_ForTriggerRecordatorios();
                Retrieve_Tasks_ForExpirarNotificaciones();
                Retrieve_Tasks_ForCheckPresupuestos();
                Retrieve_Tasks_ForGenerateBackups();
                Retrieve_Tasks_ForTrackSesion();

                LogService.Log("Obtención de tareas programadas (fin de proceso)", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Retrieve_Tasks_ForGenerateTransaccionesFromPlanificaciones()
        {
            try
            {
                //PRIMERO ME TRAIGO TODAS LAS PLANIFICACIONES ACTIVAS
                var active_planificaciones =
                    PlanificacionService.Current.GetAll(x => x.Estado && x.Habilitado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario);

                //AHORA, LAS PLANIFICACIONES "EVENTUALES", LAS FILTRO SI POSEEN FECHA ANTERIOR AL ÚLTIMO CIERRE SESIÓN
                if (ultimo_cierre_sesion != null)
                {
                    active_planificaciones = active_planificaciones
                    .Where(x =>
                    x.FrecuenciaInicio.FrecuenciaMagnitud != null
                    ||
                    (x.FrecuenciaInicio.FrecuenciaMagnitud == null && FrecuenciaInicioService.Current.GetDefaultDate(x.FrecuenciaInicio, DateTime.Now) > ultimo_cierre_sesion));
                }

                //AHORA, AGREGO LAS TAREAS RESPECTIVAS A LISTA ESTÁTICA Y DINÁMICA
                foreach (var planificacion in active_planificaciones)
                    AddStaticTask(Task_Type.Generate_Transaccion, planificacion);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Retrieve_Tasks_ForTriggerRecordatorios()
        {
            try
            {
                //PRIMERO ME TRAIGO TODOS LOS RECORDATORIOS ACTIVOS
                var active_recordatorios =
                    RecordatorioService.Current.GetAll(x => x.Estado && x.Habilitado && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario);

                //AHORA, LOS RECORDATORIOS "EVENTUALES", LOS FILTRO SI POSEEN FECHA ANTERIOR AL ÚLTIMO CIERRE SESIÓN
                if (ultimo_cierre_sesion != null)
                {
                    active_recordatorios = active_recordatorios
                    .Where(x =>
                    x.FrecuenciaInicio.FrecuenciaMagnitud != null
                    ||
                    (x.FrecuenciaInicio.FrecuenciaMagnitud == null && FrecuenciaInicioService.Current.GetDefaultDate(x.FrecuenciaInicio, DateTime.Now) > ultimo_cierre_sesion));
                }

                //AHORA, AGREGO LAS TAREAS RESPECTIVAS A LISTA ESTÁTICA Y DINÁMICA
                foreach (var recordatorio in active_recordatorios)
                    AddStaticTask(Task_Type.Trigger_Recordatorio, recordatorio);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Retrieve_Tasks_ForExpirarNotificaciones()
        {
            try
            {
                //PRIMERO ME TRAIGO TODAS LAS NOTIFICACIONES ACTIVAS
                var active_notificaciones =
                    NotificacionService.Current.GetAll(x => x.Estado && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario);

                //AHORA, AGREGO LAS TAREAS RESPECTIVAS A LISTA ESTÁTICA Y DINÁMICA
                foreach (var notificacion in active_notificaciones)
                    AddStaticTask(Task_Type.Delete_NotificacionExpirada, notificacion);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Retrieve_Tasks_ForCheckPresupuestos()
        {
            try
            {
                //PRIMERO ME TRAIGO TODOS LOS PRESUPUESTOS ACTIVOS, HABILITADOS, Y QUE SE CHEQUEAN EN INICIO O FIN
                var active_presupuestos =
                    PresupuestoService.Current.GetAll(x => x.Estado && x.Habilitado && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario);

                active_presupuestos = active_presupuestos.Where(x => x.CuandoChequear == Cuando_Chequear.Al_Inicio || x.CuandoChequear == Cuando_Chequear.Al_Final);

                foreach (var presupuesto in active_presupuestos)
                    AddStaticTask(Task_Type.Check_Presupuesto, presupuesto);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Retrieve_Tasks_ForGenerateBackups()
        {
            try
            {
                AddStaticTask(Task_Type.Generate_Backup, null);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Retrieve_Tasks_ForTrackSesion()
        {
            try
            {
                AddStaticTask(Task_Type.Track_Sesion, null);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdateTask(Task_Type taskType, dynamic resource)
        {
            var tasks = StaticTasks.Where(x => 
                x.taskType == taskType && 
                GetResourceID(x.taskType, x.resource) == GetResourceID(taskType, resource));

            if (tasks.Count() == 0) AddTask(taskType, resource);
            else UpdateTask(taskType, resource);
        }
        private void AddStaticTask(Task_Type taskType, dynamic resource)
        {
            try
            {
                //LogService.Log($"SchedulerService - Task Add: {taskType} ({resource})", LogService.LogSeverity.Debug);

                StaticTasks.Add((taskType, resource));
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddTask(Task_Type taskType, dynamic resource)
        {
            try
            {
                //LogService.Log($"SchedulerService - Task Add: {taskType} ({resource})", LogService.LogSeverity.Debug);
                
                StaticTasks.Add((taskType, resource));
                StaticToDynamic(taskType, resource);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveTask(Task_Type taskType, dynamic resource)
        {
            try
            {
                //LogService.Log($"SchedulerService - Task Remove: {taskType} ({resource})", LogService.LogSeverity.Debug);
                StaticTasks.RemoveAll(x =>
                    x.taskType == taskType &&
                    GetResourceID(x.taskType, x.resource) == GetResourceID(taskType, resource));

                DynamicTasks.RemoveAll(x => 
                    x.taskType == taskType &&
                    GetResourceID(x.taskType, x.resource) == GetResourceID(taskType, resource));
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void UpdateTask(Task_Type taskType, dynamic resource)
        {
            try
            {
                //LogService.Log($"SchedulerService - Task Update: {taskType} ({resource})", LogService.LogSeverity.Debug);
                RemoveTask(taskType, resource);
                AddTask(taskType, resource);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void StaticToDynamic(Task_Type taskType, dynamic resource)
        {
            lock (flag_thread)
            {
                try
                {
                    //Establezco el DateTime.Now para que no varíe a lo largo del método
                    var now = DateTime.Now;

                    //Me traigo la frecuencia e inicio de la task
                    FrecuenciaInicio frecuenciaInicio = GetFrecuenciaInicio_ForTask(taskType, resource);

                    //Si la frecuencia e inicio es nula, no tiene sentido pasar el task a dinamico, ya que no se podrá procesar
                    if (frecuenciaInicio == null) return;

                    DateTime? startRange = null;

                    //Usamos la fecha de ultimo proceso para obtener las siguientes
                    if (frecuenciaInicio.FechaUltimoProceso != null)
                    {
                        //Primero obtengo la fecha teorica de la fecha último proceso, ya que
                        //al esta no ser exacta (aunque sea por milisegundos), el next date no va a considerar
                        //el valor de frecuencia, sin mencionar que a lo largo del tiempo se perdería precisión

                        var fecha_teorica = FrecuenciaInicioService.Current.GetPreviousDate(frecuenciaInicio, (DateTime)frecuenciaInicio.FechaUltimoProceso);

                        if(fecha_teorica != null)
                            startRange = FrecuenciaInicioService.Current.GetNextDate(frecuenciaInicio, (DateTime)fecha_teorica);
                    }

                    //Si el tipo de tarea es notif expirada, mi rango comienza desde que se emitió la notificación
                    if (taskType == Task_Type.Delete_NotificacionExpirada && resource.FechaEmision != null)
                        startRange = FrecuenciaInicioService.Current.GetNextDate(frecuenciaInicio, (DateTime)resource.FechaEmision);

                    //Si el tipo de tarea es track sesion, sólamente puedo generar track a futuro
                    else if (taskType == Task_Type.Track_Sesion)
                        startRange = now;

                    //Si fecha ult. proc. es nula y no se dio ninguno de los casos siguientes a ese:
                    //Tomo el último cierre de sesion como pivot, y si no existe, tomaré el inicio de sesión actual,
                    //y si por algún motivo no existe, tomaré la fecha y hora actual
                    if (startRange == null) startRange = ultimo_cierre_sesion ?? ultimo_inicio_sesion ?? DateTime.Now;

                    //Me traigo todas las fechas y horas en función a la frecuencia e inicio y el rango
                    List<DateTime> dates_in_range = FrecuenciaInicioService.Current.GetDates_InRange(
                                    frecuenciaInicio,
                                    (DateTime)startRange,
                                    DateTime.Now.AddMinutes(IncomingTasksRange_Minutes)).ToList();

                    //Si es backup, de los que ya tuvieron que haberse ejecutado solo necesito uno, ya que
                    //no tiene sentido generar varios con la misma información
                    if (taskType == Task_Type.Generate_Backup)
                    {
                        DateTime? firstFromPast = null;

                        var datesFromPast = dates_in_range.Where(x => x <= now);
                        if (datesFromPast.Count() > 0) firstFromPast = datesFromPast.OrderByDescending(x => x).First();

                        dates_in_range.RemoveAll(x => x <= now);
                        if (firstFromPast != null) dates_in_range.Add((DateTime)firstFromPast);
                    }

                    //Si es notif expirada, solo necesito la mas vieja (ya que la notif se elimina una única vez)
                    if (taskType == Task_Type.Delete_NotificacionExpirada)
                    {
                        DateTime? lastFromPast = null;

                        var datesFromPast = dates_in_range.Where(x => x <= now);
                        if (datesFromPast.Count() > 0) lastFromPast = datesFromPast.OrderBy(x => x).First();

                        dates_in_range.RemoveAll(x => x <= now);
                        if (lastFromPast != null) dates_in_range.Add((DateTime)lastFromPast);
                    }

                    //Si no hay fechas en rango, no tiene sentido seguir
                    if (dates_in_range.Count() == 0) return;

                    //Agrego todas las tareas a la lista dinamica
                    foreach (var date in dates_in_range)
                        DynamicTasks.Add((date, taskType, resource));

                    //Reordeno la lista dinamica por fecha programada descendente
                    DynamicTasks =
                        new UniqueList<(DateTime, Task_Type, dynamic)>
                        (DynamicTasks.OrderBy(x => x.programmedDate).ToList());
                }
                catch (Exception ex)
                {
                    ex.Handle(this);
                    throw;
                }
            }
        }
        private void StaticToDynamicBatch()
        {
            LogService.Log("Static to Dynamic Batch (inicio de proceso)", LogService.LogSeverity.Debug);

            DynamicTasks.Clear();

            foreach (var item in StaticTasks)
                StaticToDynamic(item.taskType, item.resource);

            LogService.Log("Static to Dynamic Batch (fin de proceso)", LogService.LogSeverity.Debug);
        }
        private void StaticToDynamicBatch(Task_Type taskType)
        {
            DynamicTasks.RemoveAll(x => x.taskType == taskType);

            foreach (var item in StaticTasks.Where(x => x.taskType == taskType))
                StaticToDynamic(item.taskType, item.resource);
        }
        public void UpdateTasksProgrammedDate()
        {
            StaticToDynamicBatch();
        }
        public void UpdateTasksProgrammedDate(Task_Type taskType)
        {
            StaticToDynamicBatch(taskType);
        }
        private FrecuenciaInicio GetFrecuenciaInicio_ForTask(Task_Type taskType, dynamic resource)
        {
            try
            {
                FrecuenciaInicio frecuenciaInicio;

                switch (taskType)
                {
                    case Task_Type.Generate_Transaccion:
                        {
                            if (!(resource is Planificacion)) throw new ResourceDoesNotMatchTaskException();
                            else frecuenciaInicio = resource.FrecuenciaInicio;
                            break;
                        }
                    case Task_Type.Trigger_Recordatorio:
                        {
                            if (!(resource is Recordatorio)) throw new ResourceDoesNotMatchTaskException();
                            else frecuenciaInicio = resource.FrecuenciaInicio;
                            break;
                        }
                    case Task_Type.Check_Presupuesto:
                        {
                            if (!(resource is Presupuesto)) throw new ResourceDoesNotMatchTaskException();
                            else frecuenciaInicio = resource.LapsoPresupuesto;
                            break;
                        }
                    case Task_Type.Delete_NotificacionExpirada:
                        {
                            if (!(resource is Notificacion)) throw new ResourceDoesNotMatchTaskException();
                            else
                            {
                                Frecuencia? frecuencia_magnitud = AppData.CurrentUser.Configuracion.ExpiranNotificacionesMagnitud;
                                int? frecuencia_valor = AppData.CurrentUser.Configuracion.ExpiranNotificacionesValor;
                                Notificacion notificacion = resource;

                                if (notificacion.FechaEmision != null && frecuencia_magnitud != null && frecuencia_valor != null)
                                {
                                    frecuenciaInicio = new FrecuenciaInicio(
                                        (Frecuencia)frecuencia_magnitud,
                                        (int)frecuencia_valor,
                                        (DateTime)notificacion.FechaEmision,
                                        Guid.NewGuid(),
                                        AppData.CurrentUser.ID_Usuario);
                                }
                                else
                                    frecuenciaInicio = null;
                            }
                            break;
                        }
                    case Task_Type.Generate_Backup:
                        {
                            if (!(resource == null)) throw new ResourceDoesNotMatchTaskException();
                            else frecuenciaInicio = AppData.CurrentUser.Configuracion.RespaldarFrecuencia;
                            break;
                        }
                    case Task_Type.Track_Sesion:
                        {
                            if (!(resource == null)) throw new ResourceDoesNotMatchTaskException();
                            else
                            {
                                Frecuencia frecuencia_magnitud = AppData.Config.FrecuenciaTrackSesion_Magnitud;
                                int frecuencia_valor = AppData.Config.FrecuenciaTrackSesion_Valor;
                                TimeSpan inicio = new TimeSpan(00, 00, 00); //Empieza en el segundo 0

                                frecuenciaInicio = new FrecuenciaInicio(
                                    frecuencia_magnitud,
                                    frecuencia_valor,
                                    inicio,
                                    Guid.NewGuid(),
                                    AppData.CurrentUser.ID_Usuario);
                            }
                            break;
                        }
                    default: throw new UnknownTaskException();
                }
                return frecuenciaInicio;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Start_StaticToDynamic_Thread()
        {
            try
            {
                Action staticToDynamic = () => StaticToDynamicBatch();

                int IncomingTasksRange_ms = IncomingTasksRange_Minutes * 60 * 1000;

                //Tiene que traerse tareas antes de que ya no queden tareas de la camada anterior
                int StaticToDynamic_ms = IncomingTasksRange_ms * 5 / 10;

                if (task_StaticToDynamic != null) task_StaticToDynamic.Stop();

                task_StaticToDynamic = new TaskTimer(staticToDynamic, StaticToDynamic_ms);
                task_StaticToDynamic.Start(start_after_delay: true);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void Start_TaskCollector_Thread()
        {
            try
            {
                Action taskCollectorCheck = () => TaskCollector_Check();

                if (task_TaskCollectorCheck != null) task_TaskCollectorCheck.Stop();

                task_TaskCollectorCheck = new TaskTimer(taskCollectorCheck, CollectorDelay_ms);
                task_TaskCollectorCheck.Start(true);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void TaskCollector_Check()
        {
            if (taskCollector_checking) return;

            lock (flag_thread)
            {
                taskCollector_checking = true;

                try
                {
                    //LogService.Log($"SchedulerService - Task Collector Check (comienzo de proceso)", LogService.LogSeverity.Debug);

                    if (DynamicTasks[0].programmedDate <= DateTime.Now)
                    {
                        List<(DateTime programmedDate, Task_Type taskType, dynamic resource)> ToDo =
                            new List<(DateTime, Task_Type, dynamic)>();

                        //Me traigo las tasks cuya fecha y hora programada sea igual o inferior a la actual
                        foreach (var task in DynamicTasks)
                        {
                            if (task.programmedDate <= DateTime.Now)
                                ToDo.Add(task);
                            else break;
                        }

                        //Remuevo las tasks a ejecutar de la lista dinámica
                        //También elimino de la lista estática aquellas que sean de única ejecución
                        foreach (var task in ToDo)
                        {
                            DynamicTasks.Remove(task);
                            if (TaskEsUnicaEjecucion(task.taskType, task.resource)) StaticTasks.Remove((task.taskType, task.resource));
                        }

                        //Ejecuto las tasks
                        foreach (var task in ToDo)
                            Execute_Task(task.taskType, task.resource);
                    }

                    //LogService.Log($"SchedulerService - Task Collector Check (fin de proceso)", LogService.LogSeverity.Debug);
                }
                catch (Exception ex)
                {
                    ex.Handle(this);
                    throw;
                }

                taskCollector_checking = false;
            }
        }
        private void Execute_Task(Task_Type taskType, dynamic resource)
        {
            try
            {
                //LogService.Log($"SchedulerService - Task Exec: {taskType} ({resource})", LogService.LogSeverity.Debug);
                //return;

                switch (taskType)
                {
                    case Task_Type.Generate_Transaccion:
                        {
                            if((resource as Planificacion).Habilitado && (resource as Planificacion).Estado)
                                PlanificacionService.Current.GenerateTransaccionPendiente(resource);

                            break;
                        }
                    case Task_Type.Trigger_Recordatorio:
                        {
                            if ((resource as Recordatorio).Habilitado && (resource as Recordatorio).Estado)
                                RecordatorioService.Current.TriggerRecordatorio(resource);

                            break;
                        }
                    case Task_Type.Check_Presupuesto:
                        {
                            if ((resource as Presupuesto).Habilitado && (resource as Presupuesto).Estado && (resource as Presupuesto).CuandoChequear != Cuando_Chequear.Constantemente)
                                PresupuestoService.Current.Check_PresupuestoExcedido(resource);

                            break;
                        }
                    case Task_Type.Delete_NotificacionExpirada:
                        {
                            if (AppData.CurrentUser.Configuracion.ExpiranNotificaciones && (resource as Notificacion).Estado)
                            {
                                resource.Estado = false;
                                NotificacionService.Current.Update(resource);
                            }
                            break;
                        }
                    case Task_Type.Generate_Backup:
                        {
                            if (AppData.CurrentUser.Configuracion.Respaldar)
                            {
                                if (BackupService.BackupEstaAlLimite(AppData.CurrentUser)) BackupService.DeleteOldestBackup(AppData.CurrentUser);

                                BackupService.GenerateScheduledBackup(AppData.CurrentUser);
                            }
                            break;
                        }
                    case Task_Type.Track_Sesion:
                        {
                            SesionTrackService.Current.TrackSesion(AppData.CurrentUser, Tipo_Track.Background_Track_Sesion);
                            break;
                        }
                    default: throw new UnknownTaskException();
                }

                UpdateUltimaFechaProceso(taskType, resource);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private bool TaskEsUnicaEjecucion(Task_Type taskType, dynamic resource)
        {
            switch (taskType)
            {
                case Task_Type.Generate_Transaccion: return ((resource as Planificacion).FrecuenciaInicio.FrecuenciaMagnitud == null);
                case Task_Type.Trigger_Recordatorio: return ((resource as Recordatorio).FrecuenciaInicio.FrecuenciaMagnitud == null);
                case Task_Type.Check_Presupuesto: return ((resource as Presupuesto).LapsoPresupuesto.FrecuenciaMagnitud == null);
                case Task_Type.Delete_NotificacionExpirada: return true;
                case Task_Type.Generate_Backup: return false;
                case Task_Type.Track_Sesion: return false;
                default: return false;
            }
        }
        private void UpdateUltimaFechaProceso(Task_Type taskType, dynamic resource)
        {
            try
            {
                var now = DateTime.Now;

                switch (taskType)
                {
                    case Task_Type.Generate_Transaccion:
                        (resource as Planificacion).FrecuenciaInicio.FechaUltimoProceso = now;
                        FrecuenciaInicioService.Current.Update((resource as Planificacion).FrecuenciaInicio);
                        break;
                    case Task_Type.Trigger_Recordatorio:
                        (resource as Recordatorio).FrecuenciaInicio.FechaUltimoProceso = now;
                        FrecuenciaInicioService.Current.Update((resource as Recordatorio).FrecuenciaInicio);
                        break;
                    case Task_Type.Check_Presupuesto:
                        (resource as Presupuesto).LapsoPresupuesto.FechaUltimoProceso = now;
                        FrecuenciaInicioService.Current.Update((resource as Presupuesto).LapsoPresupuesto);
                        break;
                    case Task_Type.Generate_Backup:
                        AppData.CurrentUser.Configuracion.RespaldarFrecuencia.FechaUltimoProceso = now;
                        FrecuenciaInicioService.Current.Update(AppData.CurrentUser.Configuracion.RespaldarFrecuencia);
                        break;
                    case Task_Type.Delete_NotificacionExpirada: return;
                    case Task_Type.Track_Sesion: return;
                    default: throw new UnknownTaskException();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private Guid? GetResourceID(Task_Type taskType, dynamic resource)
        {
            if (resource == null) return null;

            switch (taskType)
            {
                case Task_Type.Generate_Transaccion: return (resource as Planificacion).ID_Planificacion;
                case Task_Type.Trigger_Recordatorio: return (resource as Recordatorio).ID_Recordatorio;
                case Task_Type.Check_Presupuesto: return (resource as Presupuesto).ID_Presupuesto;
                case Task_Type.Delete_NotificacionExpirada: return (resource as Notificacion).ID_Notificacion;
                case Task_Type.Generate_Backup: return null;
                case Task_Type.Track_Sesion: return null;
                default: return null;
            }
        }

        public enum Task_Type
        {
            Generate_Transaccion,
            Trigger_Recordatorio,
            Check_Presupuesto,
            Delete_NotificacionExpirada,
            Generate_Backup,
            Track_Sesion
        }
    }
}