using DAL.Factories;
using Domain;
using Enums;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Cuenta.
    /// </summary>
    public class CuentaService : IGenericBusinessLogic<Domain.Cuenta>
    {
        #region Singleton
        private readonly static CuentaService _instance;
        public static CuentaService Current { get { return _instance; } }
        static CuentaService() { _instance = new CuentaService(); }
        private CuentaService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Cuenta> repository = Factory.Current.CuentaRepository;

        public Cuenta GetOne(Guid ID)
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
        public IEnumerable<Cuenta> GetAll()
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
        public IEnumerable<Cuenta> GetAll(Func<Cuenta, bool> filter)
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
        public void Add(Cuenta obj)
        {
            try
            {
                repository.Add(obj);

                LogService.Log($"Creación de cuenta: {obj.ID_Cuenta}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Cuenta obj)
        {
            try
            {
                repository.Remove(obj);

                LogService.Log($"Eliminación de cuenta: {obj.ID_Cuenta}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Cuenta, bool> filter)
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
        public void Update(Cuenta obj)
        {
            try
            {
                //FALTA
                /*var cuenta_from_db = repository.GetOne(obj.ID_Cuenta);
                if (obj.Divisa != cuenta_from_db.Divisa)
                    ReadjustAllValuesByDivisa(obj, cuenta_from_db.Divisa, obj.Divisa);*/

                repository.Update(obj);

                LogService.Log($"Modificación de cuenta: {obj.ID_Cuenta}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Cuenta obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                LogService.Log($"Creación/Modificación de cuenta: {obj.ID_Cuenta}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public decimal GetBalance(Cuenta obj, DateTime fecha, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                transacciones = transacciones.Where(x => x.Cuenta.ID_Cuenta == obj.ID_Cuenta);
                transacciones = transacciones.Where(x => x.Fecha <= fecha && x.Concretada == true);

                IEnumerable<decimal> montosPositivos =
                    transacciones
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Ingreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones)));

                IEnumerable<decimal> montosNegativos =
                    transacciones
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Egreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones)));

                IEnumerable<decimal> montosCalculados =
                    transacciones
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Variable)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones)));

                decimal sumPositivo = (montosPositivos.Count() > 0) ? montosPositivos.Sum() : 0m;
                decimal sumNegativo = (montosNegativos.Count() > 0) ? montosNegativos.Sum() : 0m;
                decimal sumCalculado = (montosCalculados.Count() > 0) ? montosCalculados.Sum() : 0m;

                decimal resultado = sumPositivo - sumNegativo + sumCalculado;
                return resultado;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public decimal GetBalance(Cuenta obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                return GetBalance(obj, DateTime.Now, transacciones);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public decimal GetBalancePotencial(Cuenta obj, IEnumerable<Transaccion> transacciones = null)
        {
            try
            {
                if (transacciones == null) transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                transacciones = transacciones.Where(x => x.Cuenta.ID_Cuenta == obj.ID_Cuenta);

                IEnumerable<decimal> montosPositivos =
                    transacciones
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Ingreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones)));

                IEnumerable<decimal> montosNegativos =
                    transacciones
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Egreso)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones)));

                IEnumerable<decimal> montosCalculados =
                    transacciones
                    .Where(x => x.TipoOperacion == Tipo_Operacion.Variable)
                    .Select(x => Convert.ToDecimal(ExpresionService.Current.GetResult(x.MontoExpresion, transacciones)));

                decimal sumPositivo = (montosPositivos.Count() > 0) ? montosPositivos.Sum() : 0m;
                decimal sumNegativo = (montosNegativos.Count() > 0) ? montosNegativos.Sum() : 0m;
                decimal sumCalculado = (montosCalculados.Count() > 0) ? montosCalculados.Sum() : 0m;

                decimal resultado = sumPositivo - sumNegativo + sumCalculado;
                return resultado;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public void ReadjustAllValuesByDivisa(Cuenta obj, Divisa old_divisa, Divisa new_divisa)
        {
            //FALTA
            //Hay que modificar valores en
            //transacciones, planificaciones, plantillas, presupuestos y expresiones.
            throw new NotImplementedException();
        }
    }
}
