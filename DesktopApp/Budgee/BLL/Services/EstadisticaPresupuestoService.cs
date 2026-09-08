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
    /// Servicio de estadística de holgura de presupuesto.
    /// </summary>
    public class EstadisticaPresupuestoService : IEstadisticaService<Estadistica_Presupuesto>
    {
        #region Singleton
        private readonly static EstadisticaPresupuestoService _instance;
        public static EstadisticaPresupuestoService Current { get { return _instance; } }
        static EstadisticaPresupuestoService() { _instance = new EstadisticaPresupuestoService(); }
        private EstadisticaPresupuestoService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Estadistica_Presupuesto GetEstadistica()
        {
            try
            {
                var presupuestos = PresupuestoService.Current.GetAll(x => x.Estado == true && x.Habilitado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                return new Estadistica_Presupuesto(presupuestos);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
