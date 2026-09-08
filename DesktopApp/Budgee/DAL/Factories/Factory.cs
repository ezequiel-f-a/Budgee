using DAL.Contracts;
using DAL.Repositories.SqlServer;
using SL.DAL.Contracts;
using SL.Services;
using System;

namespace DAL.Factories
{
    /// <summary>
    /// Factory que centraliza el acceso a datos, abstrayendo de que forma se realiza el acceso a datos.
    /// </summary>
    public class Factory
    {
        #region Singleton
        private readonly static Factory _instance;
        public static Factory Current { get { return _instance; } }
        static Factory() { _instance = new Factory(); }
        private Factory()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public IGenericRepository<Domain.Cuenta> CuentaRepository { get { return GetRepository(nameof(CuentaRepository)); } }
        public IGenericRepository<Domain.Caracteristica> CaracteristicaRepository { get { return GetRepository(nameof(CaracteristicaRepository)); } }
        public IGenericRepository<Domain.Notificacion> NotificacionRepository { get { return GetRepository(nameof(NotificacionRepository)); } }
        public IGenericRepository<Domain.Recordatorio> RecordatorioRepository { get { return GetRepository(nameof(RecordatorioRepository)); } }
        public IGenericRepository<Domain.Presupuesto> PresupuestoRepository { get { return GetRepository(nameof(PresupuestoRepository)); } }
        public IGenericRepository<Domain.Expresion> ExpresionRepository { get { return GetRepository(nameof(ExpresionRepository)); } }
        public IGenericRepository<Domain.Variable> VariableRepository { get { return GetRepository(nameof(VariableRepository)); } }
        public IGenericRepository<Domain.Transaccion> TransaccionRepository { get { return GetRepository(nameof(TransaccionRepository)); } }
        public IGenericRepository<Domain.Planificacion> PlanificacionRepository { get { return GetRepository(nameof(PlanificacionRepository)); } }
        public IGenericRepository<Domain.PlantillaTransaccion> PlantillaTransaccionRepository { get { return GetRepository(nameof(PlantillaTransaccionRepository)); } }

        public IGeneralRepository GeneralRepository { get { return GetRepository(nameof(GeneralRepository)); } }

        private dynamic GetRepository(string repository)
        {
            string basepath = AppData.Config.Repositories;

            var repo =
                Type.GetType($"{basepath}.{repository}").
                GetProperty("Current").
                GetValue(null);

            return repo;
        }
    }
}
