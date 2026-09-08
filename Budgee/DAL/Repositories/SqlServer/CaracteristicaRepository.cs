using DAL.Repositories.SqlServer.Adapters;
using SL.DAL.Contracts;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repositories.SqlServer
{
    /// <summary>
    /// Repositorio SQL Server de Característica.
    /// </summary>
    internal class CaracteristicaRepository : IGenericRepository<Domain.Caracteristica>
    {
        #region Singleton
        private readonly static CaracteristicaRepository _instance;
        public static CaracteristicaRepository Current { get { return _instance; } }
        static CaracteristicaRepository() { _instance = new CaracteristicaRepository(); }
        private CaracteristicaRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Caracteristica GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Caracteristica.AsNoTracking();
                    return CaracteristicaAdapter.Current.Adapt(
                        db.Caracteristica.Where(x => x.ID_Caracteristica == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Caracteristica> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Caracteristica.AsNoTracking();
                    return db.Caracteristica.ToList().Select(x => CaracteristicaAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Caracteristica> GetAll(Func<Domain.Caracteristica, bool> filter)
        {
            try
            {
                return GetAll().Where(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Add(Domain.Caracteristica obj)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Caracteristica.Add(CaracteristicaAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
            SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);
        }
        public void Update(Domain.Caracteristica obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Estado == false)
                    SetReferencesNull(obj);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Caracteristica.Single(x => x.ID_Caracteristica == obj.ID_Caracteristica);
                    db.Entry(obj_from_db).CurrentValues.SetValues(CaracteristicaAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Caracteristica obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Estado == false)
                    SetReferencesNull(obj);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Caracteristica.AddOrUpdate(CaracteristicaAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Caracteristica obj)
        {
            try
            {
                SetReferencesNull(obj);

                VariableRepository.Current.RemoveAll
                        (x => x.Categoria?.ID_Caracteristica == obj.ID_Caracteristica || x.Etiqueta?.ID_Caracteristica == obj.ID_Caracteristica);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Caracteristica.Single(x => x.ID_Caracteristica == obj.ID_Caracteristica);
                    db.Caracteristica.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Caracteristica, bool> filter)
        {
            try
            {
                foreach (var item in GetAll(filter))
                    Remove(item);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public void SetReferencesNull(Domain.Caracteristica obj)
        {
            try
            {
                if (obj.Tipo_Caracteristica == Enums.Tipo_Caracteristica.Categoria)
                {
                    var transacciones = TransaccionRepository.Current.GetAll(x => x.Categoria?.ID_Caracteristica == obj.ID_Caracteristica).ToList();
                    transacciones.ForEach(x => x.Categoria = null);
                    transacciones.ForEach(x => TransaccionRepository.Current.Update(x));

                    var planificaciones = PlanificacionRepository.Current.GetAll(x => x.Categoria?.ID_Caracteristica == obj.ID_Caracteristica).ToList();
                    planificaciones.ForEach(x => x.Categoria = null);
                    planificaciones.ForEach(x => PlanificacionRepository.Current.Update(x));

                    var plantillas = PlantillaTransaccionRepository.Current.GetAll(x => x.Categoria?.ID_Caracteristica == obj.ID_Caracteristica).ToList();
                    plantillas.ForEach(x => x.Categoria = null);
                    plantillas.ForEach(x => PlantillaTransaccionRepository.Current.Update(x));
                }
                else if (obj.Tipo_Caracteristica == Enums.Tipo_Caracteristica.Etiqueta)
                {
                    using (var db = new Models.BudgeeEntities())
                    {
                        var relacionesTransaccion = db.Transaccion_Etiqueta.Where(x => x.ID_Etiqueta == obj.ID_Caracteristica).ToList();
                        relacionesTransaccion.ForEach(x => db.Transaccion_Etiqueta.Remove(x));

                        var relacionesPlanificacion = db.PlanificacionTransaccion_Etiqueta.Where(x => x.ID_Etiqueta == obj.ID_Caracteristica).ToList();
                        relacionesPlanificacion.ForEach(x => db.PlanificacionTransaccion_Etiqueta.Remove(x));

                        var relacionesPlantilla = db.PlantillaTransaccion_Etiqueta.Where(x => x.ID_Etiqueta == obj.ID_Caracteristica).ToList();
                        relacionesPlantilla.ForEach(x => db.PlantillaTransaccion_Etiqueta.Remove(x));

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
