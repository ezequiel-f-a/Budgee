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
    /// Servicio de estadística de ingreso/egreso.
    /// </summary>
    public class EstadisticaIngresoEgresoService : IEstadisticaService<Estadistica_IngresoEgreso>
    {
        #region Singleton
        private readonly static EstadisticaIngresoEgresoService _instance;
        public static EstadisticaIngresoEgresoService Current { get { return _instance; } }
        static EstadisticaIngresoEgresoService() { _instance = new EstadisticaIngresoEgresoService(); }
        private EstadisticaIngresoEgresoService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Estadistica_IngresoEgreso GetEstadistica()
        {
            try
            {
                var transacciones = TransaccionService.Current.GetAll(x => x.Concretada && x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                return new Estadistica_IngresoEgreso(transacciones);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public List<(int Año, int Mes, decimal Monto)> GetGroupedTransacciones(IEnumerable<Transaccion> transacciones, IEnumerable<DateTime> time_range, bool esEgreso = false, IEnumerable<Transaccion> transacciones_temp = null)
        {
            try
            {
                if (time_range.Count() == 0) return new List<(int Año, int Mes, decimal Monto)>();

                if (transacciones_temp == null) transacciones_temp = TransaccionService.Current.GetAll(x => x.Concretada && x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();

                transacciones = transacciones.Where(x => x.Fecha != null);
                var transac_agrupadas =
                    (
                    from t in transacciones
                    group t by new
                    {
                        ((DateTime)t.Fecha).Year,
                        ((DateTime)t.Fecha).Month,
                    }
                    into g
                    select new
                    {
                        Año = g.Key.Year,
                        Mes = g.Key.Month,
                        Monto = g.Sum(x => (esEgreso) ?
                            Math.Abs(TransaccionService.Current.GetMonto(x, transacciones_temp)) :
                            TransaccionService.Current.GetMonto(x, transacciones_temp))
                    }
                    ).ToList();

                var agrupadas_año_mes = transac_agrupadas.Select(x => (x.Año, x.Mes)).ToList();

                var time_range_grouped = ConversionService.GetDatesGroupedByYearMonth(time_range.Min(), time_range.Max());

                foreach (var año_mes in time_range_grouped)
                {
                    if (!agrupadas_año_mes.Contains(año_mes))
                        transac_agrupadas.Add(new { Año = año_mes.Year, Mes = año_mes.Month, Monto = 0m });
                }

                return transac_agrupadas.Select(x => (x.Año, x.Mes, x.Monto)).OrderBy(x => x.Año).ThenBy(x => x.Mes).ToList();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
