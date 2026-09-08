using BLL.BusinessExceptions;
using BLL.Contracts;
using DAL.Factories;
using Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using SL.Services;
using System.Threading;
using SL.Services.Extensions;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Transacción.
    /// </summary>
    public class TransaccionService : GenericTransaccionService<Domain.Transaccion>
    {
        #region Singleton
        private readonly static TransaccionService _instance;
        public static TransaccionService Current { get { return _instance; } }
        static TransaccionService() { _instance = new TransaccionService(); }
        private TransaccionService()
        {
            //Implent here the initialization of your singleton
            repository = Factory.Current.TransaccionRepository;
        }
        #endregion
        public override void Add(Transaccion obj)
        {
            try
            {
                List<Transaccion> transacciones = null;

                if (obj.Concretada && obj.Estado)
                {
                    transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                    //Chequeo fondos negativos
                    if (!obj.Cuenta.AdmiteFondosNegativos)
                        if (Check_FondosNegativos(obj, transacciones))
                            throw new FondosInsuficientesException();
                }

                if (obj.Concretada && obj.MontoExpresion != null && obj.MontoExpresion.Tipo_Expresion == Enums.Tipo_Expresion.Calculada)
                    FijarMonto(obj);

                base.Add(obj);

                //Chequeo de presupuestos
                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                new Thread(() => PresupuestoService.Current.Check_PresupuestosExcedidos_ChequeoConstante(transacciones)).Start();

                LogService.Log($"Creación de transacción: {obj.ID_Transaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void Update(Transaccion obj)
        {
            try
            {
                List<Transaccion> transacciones = null;
                //Chequeo de fondos negativos
                if (!obj.Cuenta.AdmiteFondosNegativos)
                {
                    var obj_from_db = GetOne(obj.ID_Transaccion);
                    if (!(!obj.Estado && !obj_from_db.Estado))
                    {
                        bool chequear = false;
                        if (obj.Concretada) chequear = true;
                        else if (!obj.Concretada && obj_from_db.Concretada) chequear = true;

                        if (chequear)
                        {
                            transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                            if (Check_FondosNegativos(obj, transacciones))
                                throw new FondosInsuficientesException();
                        }
                    }
                }

                if (obj.Concretada && obj.MontoExpresion != null && obj.MontoExpresion.Tipo_Expresion == Enums.Tipo_Expresion.Calculada)
                    FijarMonto(obj);

                base.Update(obj);

                //Chequeo de presupuestos
                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                new Thread(() => PresupuestoService.Current.Check_PresupuestosExcedidos_ChequeoConstante(transacciones)).Start();

                LogService.Log($"Modificación de transacción: {obj.ID_Transaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void AddOrUpdate(Transaccion obj)
        {
            try
            {
                List<Transaccion> transacciones = null;
                //Chequeo de fondos negativos
                if (!obj.Cuenta.AdmiteFondosNegativos)
                {
                    Transaccion obj_from_db = GetAll(x => x.ID_Transaccion == obj.ID_Transaccion).FirstOrDefault();

                    if (obj_from_db != null)
                    {
                        if (!(!obj.Estado && !obj_from_db.Estado))
                        {
                            bool chequear = false;
                            if (obj.Concretada) chequear = true;
                            else if (!obj.Concretada && obj_from_db.Concretada) chequear = true;

                            if (chequear)
                            {
                                transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                                if (Check_FondosNegativos(obj, transacciones))
                                    throw new FondosInsuficientesException();
                            }
                        }
                    }
                    else if (obj.Concretada && obj.Estado)
                    {
                        transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                        //Chequeo fondos negativos
                        if (!obj.Cuenta.AdmiteFondosNegativos)
                            if (Check_FondosNegativos(obj, transacciones))
                                throw new FondosInsuficientesException();
                    }
                }

                if (obj.Concretada && obj.MontoExpresion != null && obj.MontoExpresion.Tipo_Expresion == Enums.Tipo_Expresion.Calculada)
                    FijarMonto(obj);

                base.AddOrUpdate(obj);

                //Chequeo de presupuestos
                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                new Thread(() => PresupuestoService.Current.Check_PresupuestosExcedidos_ChequeoConstante(transacciones)).Start();

                LogService.Log($"Creación/Modificación de transacción: {obj.ID_Transaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void Remove(Transaccion obj)
        {
            try
            {
                List<Transaccion> transacciones = null;

                if (obj.Concretada && obj.Estado && !obj.Cuenta.AdmiteFondosNegativos)
                {
                    transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                    if (Check_FondosNegativos(obj, transacciones))
                        throw new FondosInsuficientesException();
                }

                base.Remove(obj);

                //Chequeo de presupuestos
                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                new Thread(() => PresupuestoService.Current.Check_PresupuestosExcedidos_ChequeoConstante(transacciones)).Start();

                LogService.Log($"Eliminación de transacción: {obj.ID_Transaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public void ConcretarTransaccion(Transaccion obj)
        {
            obj.Concretada = true;
            Update(obj);
        }
        public bool Check_FondosNegativos(Transaccion obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                decimal monto = (obj.Estado && obj.Concretada && obj.Fecha <= DateTime.Now) ? GetMonto(obj) : 0;

                decimal balance;

                if (obj.Fecha == null)
                    balance = CuentaService.Current.GetBalance(obj.Cuenta);
                else balance = CuentaService.Current.GetBalance(obj.Cuenta, (DateTime)obj.Fecha);

                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                transacciones = transacciones.Where(x => x.Concretada);

                if (transacciones.Select(x => x.ID_Transaccion).Contains(obj.ID_Transaccion))
                    balance -= GetMonto(transacciones.Where(x => x.ID_Transaccion == obj.ID_Transaccion).First());

                decimal nuevoBalance = balance + monto;

                return (nuevoBalance < 0);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void FijarMonto(Transaccion obj)
        {
            try
            {
                ExpresionService.Current.FijarValor(obj.MontoExpresion);

                var montoFijo = Convert.ToDecimal(obj.MontoExpresion.Definicion);

                if (montoFijo >= 0)
                    obj.TipoOperacion = Enums.Tipo_Operacion.Ingreso;
                else
                    obj.TipoOperacion = Enums.Tipo_Operacion.Egreso;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
