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
    /// Servicio de estadística de overview.
    /// </summary>
    public class EstadisticaOverviewService : IEstadisticaService<Estadistica_Overview>
    {
        #region Singleton
        private readonly static EstadisticaOverviewService _instance;
        public static EstadisticaOverviewService Current { get { return _instance; } }
        static EstadisticaOverviewService() { _instance = new EstadisticaOverviewService(); }
        private EstadisticaOverviewService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Estadistica_Overview GetEstadistica()
        {
            try
            {
                var cuentas = CuentaService.Current.GetAll(x => x.Estado == true && x.Habilitada == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                return new Estadistica_Overview(AppData.CurrentUser, cuentas);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
