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
    /// Servicio de estadística de distribución.
    /// </summary>
    public class EstadisticaDistribucionService : IEstadisticaService<Estadistica_Distribucion>
    {
        #region Singleton
        private readonly static EstadisticaDistribucionService _instance;
        public static EstadisticaDistribucionService Current { get { return _instance; } }
        static EstadisticaDistribucionService() { _instance = new EstadisticaDistribucionService(); }
        private EstadisticaDistribucionService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Estadistica_Distribucion GetEstadistica()
        {
            try
            {
                var transacciones = TransaccionService.Current.GetAll(x => x.Concretada && x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                return new Estadistica_Distribucion(transacciones);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public List<(string Nombre, decimal Monto)> GetGroupedByCuenta(IEnumerable<Transaccion> transacciones, IEnumerable<Transaccion> transacciones_temp = null)
        {
            try
            {
                if (transacciones_temp == null) transacciones_temp = TransaccionService.Current.GetAll(x => x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true).ToList();

                var agrupadas = transacciones.GroupBy(x => x.Cuenta.ID_Cuenta).Select(g => new {
                    g.First().Cuenta.Nombre,
                    Monto = Math.Abs(g.Sum(x => TransaccionService.Current.GetMonto(x, transacciones_temp)))
                }).ToList();

                return agrupadas.Select(x => (x.Nombre, x.Monto)).OrderByDescending(x => x.Monto).ToList();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public List<(string Nombre, decimal Monto)> GetGroupedByCategoria(IEnumerable<Transaccion> transacciones, IEnumerable<Transaccion> transacciones_temp = null)
        {
            try
            {
                if (transacciones_temp == null) transacciones_temp = TransaccionService.Current.GetAll(x => x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true).ToList();

                var sin_categoria = transacciones.Where(x => x.Categoria == null);
                transacciones = transacciones.Where(x => x.Categoria != null);

                var agrupadas = transacciones.GroupBy(x => x.Categoria.ID_Caracteristica).Select(g => new {
                    g.First().Categoria.Nombre,
                    Monto = Math.Abs(g.Sum(x => TransaccionService.Current.GetMonto(x, transacciones_temp)))
                }).ToList();

                agrupadas.Add(new
                {
                    Nombre = "Sin categoría".Translate(),
                    Monto = Math.Abs(sin_categoria.Sum(x => TransaccionService.Current.GetMonto(x, transacciones_temp)))
                });

                return agrupadas.Select(x => (x.Nombre, x.Monto)).OrderByDescending(x => x.Monto).ToList();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public List<(string Nombre, decimal Monto)> GetGroupedByEtiqueta(IEnumerable<Transaccion> transacciones, IEnumerable<Transaccion> transacciones_temp = null)
        {
            try
            {
                if (transacciones_temp == null) transacciones_temp = TransaccionService.Current.GetAll(x => x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario && x.Estado == true).ToList();

                var sin_etiqueta = transacciones.Where(x => x.Etiquetas.Count == 0);
                transacciones = transacciones.Where(x => x.Etiquetas.Count > 0);

                var etiquetasDisponibles = transacciones.SelectMany(x => x.Etiquetas).GroupBy(x => x.ID_Caracteristica).Select(g => g.First()).ToList();

                List<(string Nombre, decimal Monto)> agrupadas = new List<(string Nombre, decimal Monto)>();

                foreach (var etiqueta in etiquetasDisponibles)
                {
                    var transac_filtradas = transacciones.Where(x => x.Etiquetas.Select(y => y.ID_Caracteristica).Contains(etiqueta.ID_Caracteristica));

                    agrupadas.Add((
                        etiqueta.Nombre,
                        Math.Abs(transac_filtradas.Select(x => TransaccionService.Current.GetMonto(x, transacciones_temp)).Sum())));
                }

                agrupadas.Add(("Sin etiqueta".Translate(),
                    Math.Abs(sin_etiqueta.Sum(x => TransaccionService.Current.GetMonto(x, transacciones_temp)))));

                return agrupadas.Select(x => (x.Nombre, x.Monto)).OrderByDescending(x => x.Monto).ToList();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
