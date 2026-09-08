using DAL.Factories;
using Domain;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Presupuesto.
    /// </summary>
    public class PresupuestoService : IGenericBusinessLogic<Domain.Presupuesto>
    {
        #region Singleton
        private readonly static PresupuestoService _instance;
        public static PresupuestoService Current { get { return _instance; } }
        static PresupuestoService() { _instance = new PresupuestoService(); }
        private PresupuestoService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Presupuesto> repository = Factory.Current.PresupuestoRepository;

        List<(Guid ID_Presupuesto, decimal ValorActual)> presupuestos_old;

        public Presupuesto GetOne(Guid ID)
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
        public IEnumerable<Presupuesto> GetAll()
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
        public IEnumerable<Presupuesto> GetAll(Func<Presupuesto, bool> filter)
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
        public void Add(Presupuesto obj)
        {
            try
            {
                if (obj.CuandoChequear == Enums.Cuando_Chequear.Constantemente)
                    new Thread(() => Check_PresupuestoExcedido(obj)).Start();

                repository.Add(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Check_Presupuesto, obj);

                LogService.Log($"Creación de presupuesto: {obj.ID_Presupuesto}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Presupuesto obj)
        {
            try
            {
                if (obj.CuandoChequear == Enums.Cuando_Chequear.Constantemente)
                    new Thread(() => Check_PresupuestoExcedido(obj)).Start();

                repository.Update(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Check_Presupuesto, obj);

                LogService.Log($"Modificación de presupuesto: {obj.ID_Presupuesto}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Presupuesto obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                SchedulerService.Current.AddOrUpdateTask(SchedulerService.Task_Type.Check_Presupuesto, obj);

                LogService.Log($"Creación/Modificación de presupuesto: {obj.ID_Presupuesto}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Presupuesto obj)
        {
            try
            {
                repository.Remove(obj);

                SchedulerService.Current.RemoveTask(SchedulerService.Task_Type.Check_Presupuesto, obj);

                LogService.Log($"Eliminación de presupuesto: {obj.ID_Presupuesto}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Presupuesto, bool> filter)
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

        public void Check_PresupuestosExcedidos_ChequeoConstante(IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                var presupuestos = GetAll(x => x.CuandoChequear == Enums.Cuando_Chequear.Constantemente && x.Habilitado && x.Estado && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario);
                if (transacciones == null) transacciones = transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                foreach (var presupuesto in presupuestos)
                    Check_PresupuestoExcedido(presupuesto, transacciones);

                presupuestos_old = presupuestos.Select(x => (
                    x.ID_Presupuesto,
                    VariableService.Current.GetValue(x.VariableSupervisada))).ToList();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Check_PresupuestoExcedido(Presupuesto obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                bool excedido = false;
                if (transacciones == null) transacciones = transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                var valor_variableSupervisada = VariableService.Current.GetValue(obj.VariableSupervisada, transacciones);
                var valor_condicion = ExpresionService.Current.GetResult(obj.CondicionExpresion, transacciones);

                switch (obj.OperadorRelacional)
                {
                    case Enums.Operador_Relacional.Mayor_a:
                        if (valor_variableSupervisada > valor_condicion) excedido = true; break;
                    case Enums.Operador_Relacional.Menor_a:
                        if (valor_variableSupervisada < valor_condicion) excedido = true; break;
                    case Enums.Operador_Relacional.Mayor_o_Igual_a:
                        if (valor_variableSupervisada >= valor_condicion) excedido = true; break;
                    case Enums.Operador_Relacional.Menor_o_Igual_a:
                        if (valor_variableSupervisada <= valor_condicion) excedido = true; break;
                    case Enums.Operador_Relacional.Igual_a:
                        if (valor_variableSupervisada == valor_condicion) excedido = true; break;
                    case Enums.Operador_Relacional.Diferente_de:
                        if (valor_variableSupervisada != valor_condicion) excedido = true; break;
                }

                if (excedido)
                    if (!Check_MismoValorQueAntes(obj) && !Check_Notificado(obj))
                        Trigger_PresupuestoExcedido(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Trigger_PresupuestoExcedido(Presupuesto obj)
        {
            try
            {
                var notif = new Notificacion(Guid.NewGuid(), $"{"Presupuesto excedido".Translate()} - {obj.Descripcion}", DateTime.Now, Enums.Procedencia_Notificacion.Presupuesto, obj, null, null, obj.Usuario, false, true);
                NotificacionService.Current.TriggerNotificacion(notif);

                //FALTA
                if (obj.AlarmaWindows)
                {
                    //Trigger System Alarm
                }
                if (obj.NotificacionWindows)
                {
                    //Trigger System Notif
                }

                LogService.Log($"Presupuesto excedido: {obj.ID_Presupuesto}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private bool Check_MismoValorQueAntes(Presupuesto presupuesto)
        {
            try
            {

                if (presupuestos_old == null) return false;

                if (presupuestos_old.Select(x => x.ID_Presupuesto).Contains(presupuesto.ID_Presupuesto))
                {
                    var valor_old = presupuestos_old.Where(x => x.ID_Presupuesto == presupuesto.ID_Presupuesto).First().ValorActual;
                    var valor_new = VariableService.Current.GetValue(presupuesto.VariableSupervisada);

                    if (valor_new == valor_old) return true;
                    else return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private bool Check_Notificado(Presupuesto presupuesto)
        {
            try
            {
                //Me traigo notifs que posean ese presupuesto
                var notifs_presupuesto = NotificacionService.Current.GetAll(x => x.Presupuesto != null && x.Presupuesto.ID_Presupuesto == presupuesto.ID_Presupuesto);
                
                //Si hay notifs que no fueron vistas pero existen, ya fue notificado
                if (notifs_presupuesto.Where(x => !x.Visto && x.Estado).Count() > 0) return true;

                //Caso contrario, debo verificar, para aquellas con "Cuando Chequear" en "Al Inicio" o "Al Final",
                //Si ya fueron notificadas para el último caso de presupuesto excedido
                if(presupuesto.CuandoChequear != Enums.Cuando_Chequear.Constantemente)
                {
                    //Si no hay notifs con ese presupuesto, nunca se notificó
                    if (notifs_presupuesto.Where(x => x.FechaEmision != null).Count() == 0) return false;
                    else
                    {
                        DateTime fecha_ultima_notif = (DateTime)notifs_presupuesto
                            .Where(x => x.FechaEmision != null)
                            .OrderByDescending(x => x.FechaEmision)
                            .First().FechaEmision;

                        var previous_programmed_check = SL.BLL.Services.FrecuenciaInicioService.Current.GetPreviousDate(
                            presupuesto.LapsoPresupuesto,
                            DateTime.Now.AddMilliseconds(1));//Le agrego un milisegundo para que entre la fecha y hr actual

                        if (previous_programmed_check == null) return true;

                        if (fecha_ultima_notif > previous_programmed_check) return true;
                        else return false;
                    }
                }

                //Si ninguna de estas condiciones se cumplio, no fue notificado
                return false;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
