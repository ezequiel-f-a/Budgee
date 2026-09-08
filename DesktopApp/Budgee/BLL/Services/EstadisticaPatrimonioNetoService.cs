using BLL.Contracts;
using Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    /// <summary>
    /// Servicio de estadística de patrimonio neto.
    /// </summary>
    public class EstadisticaPatrimonioNetoService : IEstadisticaService<Estadistica_PatrimonioNeto>
    {
        #region Singleton
        private readonly static EstadisticaPatrimonioNetoService _instance;
        public static EstadisticaPatrimonioNetoService Current { get { return _instance; } }
        static EstadisticaPatrimonioNetoService() { _instance = new EstadisticaPatrimonioNetoService(); }
        private EstadisticaPatrimonioNetoService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Estadistica_PatrimonioNeto GetEstadistica()
        {
            try
            {
                var transacciones = TransaccionService.Current.GetAll(x => x.Concretada && x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                return new Estadistica_PatrimonioNeto(transacciones);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public List<(int Año, int Mes, decimal Monto)> GetGroupedBalances(IEnumerable<Transaccion> transacciones, IEnumerable<DateTime> time_range, IEnumerable<Transaccion> transacciones_temp = null)
        {
            try
            {
                if (time_range.Count() == 0) return new List<(int Año, int Mes, decimal Monto)>();

                if (transacciones_temp == null) transacciones_temp = TransaccionService.Current.GetAll(x => x.Concretada && x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                var time_range_grouped = ConversionService.GetDatesGroupedByYearMonth(time_range.Min(), time_range.Max());

                var balances_agrupados = new List<(int Año, int Mes, decimal Monto)>();

                transacciones = transacciones.Where(x => x.Fecha != null);
                var cuentasDisponibles = transacciones.Select(x => x.Cuenta).GroupBy(x => x.ID_Cuenta).Select(g => g.First()).ToList();

                foreach (var año_mes in time_range_grouped)
                    balances_agrupados.Add((año_mes.Year, año_mes.Month, UsuarioService.Current.GetBalanceGlobal(AppData.CurrentUser, GetLastDateFromAñoMes(año_mes), transacciones, cuentasDisponibles)));

                return balances_agrupados.Select(x => (x.Año, x.Mes, x.Monto)).OrderBy(x => x.Año).ThenBy(x => x.Mes).ToList();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private DateTime GetLastDateFromAñoMes((int Año, int Mes) año_mes)
        {
            return new DateTime(año_mes.Año, año_mes.Mes, 1, 23, 59, 59, 999).AddMonths(1).AddDays(-1);
        }
    }
}
