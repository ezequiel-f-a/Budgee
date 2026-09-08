using Domain;
using SL.Domain.Security;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Usuario.
    /// </summary>
    public class UsuarioService
    {
        #region Singleton
        private readonly static UsuarioService _instance;
        public static UsuarioService Current { get { return _instance; } }
        static UsuarioService() { _instance = new UsuarioService(); }
        private UsuarioService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public decimal GetBalanceGlobal(Usuario obj, DateTime fecha, IEnumerable<Transaccion> transacciones = null, IEnumerable<Cuenta> cuentas = null)
        {
            try
            {
                if (cuentas == null) cuentas = CuentaService.Current.GetAll(x => x.Usuario.ID_Usuario == obj.ID_Usuario);
                var balances = cuentas.Select(x => CuentaService.Current.GetBalance(x, fecha, transacciones));
                return (balances.Count() > 0) ? balances.Sum() : 0;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public decimal GetBalanceGlobal(Usuario obj, IEnumerable<Transaccion> transacciones = null, IEnumerable<Cuenta> cuentas = null)
        {
            try
            {
                return GetBalanceGlobal(obj, DateTime.Now, transacciones, cuentas);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public decimal GetBalanceGlobalPotencial(Usuario obj, IEnumerable<Transaccion> transacciones = null, IEnumerable<Cuenta> cuentas = null)
        {
            try
            {
                if (cuentas == null) cuentas = CuentaService.Current.GetAll(x => x.Usuario.ID_Usuario == obj.ID_Usuario);
                var balances = cuentas.Select(x => CuentaService.Current.GetBalancePotencial(x, transacciones));
                return (balances.Count() > 0) ? balances.Sum() : 0;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
