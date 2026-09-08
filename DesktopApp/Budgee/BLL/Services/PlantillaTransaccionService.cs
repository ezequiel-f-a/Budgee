using BLL.Contracts;
using DAL.Factories;
using SL.Services;
using SL.Services.Extensions;
using System;

namespace BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Plantilla de Transacción.
    /// </summary>
    public class PlantillaTransaccionService : GenericTransaccionService<Domain.PlantillaTransaccion>
    {
        #region Singleton
        private readonly static PlantillaTransaccionService _instance;
        public static PlantillaTransaccionService Current { get { return _instance; } }
        static PlantillaTransaccionService() { _instance = new PlantillaTransaccionService(); }
        private PlantillaTransaccionService()
        {
            //Implent here the initialization of your singleton
            repository = Factory.Current.PlantillaTransaccionRepository;
        }
        #endregion
        public override void Add(Domain.PlantillaTransaccion obj)
        {
            try
            {
                base.Add(obj);

                LogService.Log($"Creación de plantilla: {obj.ID_PlantillaTransaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void Update(Domain.PlantillaTransaccion obj)
        {
            try
            {
                base.Update(obj);

                LogService.Log($"Modificación de plantilla: {obj.ID_PlantillaTransaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void AddOrUpdate(Domain.PlantillaTransaccion obj)
        {
            try
            {
                base.AddOrUpdate(obj);

                LogService.Log($"Creación/Modificación de plantilla: {obj.ID_PlantillaTransaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public override void Remove(Domain.PlantillaTransaccion obj)
        {
            try
            {
                base.Remove(obj);

                LogService.Log($"Eliminación de plantilla: {obj.ID_PlantillaTransaccion}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
