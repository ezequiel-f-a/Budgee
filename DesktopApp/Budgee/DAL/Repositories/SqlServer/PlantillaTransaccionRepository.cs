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
    /// Repositorio SQL Server de Plantilla de Transacción.
    /// </summary>
    internal class PlantillaTransaccionRepository : IGenericRepository<Domain.PlantillaTransaccion>
    {
        #region Singleton
        private readonly static PlantillaTransaccionRepository _instance;
        public static PlantillaTransaccionRepository Current { get { return _instance; } }
        static PlantillaTransaccionRepository() { _instance = new PlantillaTransaccionRepository(); }
        private PlantillaTransaccionRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.PlantillaTransaccion GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Plantilla_Transaccion.AsNoTracking();
                    return PlantillaTransaccionAdapter.Current.Adapt(
                        db.Plantilla_Transaccion.Where(x => x.ID_Plantilla_Transaccion == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.PlantillaTransaccion> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Plantilla_Transaccion.AsNoTracking();
                    return db.Plantilla_Transaccion.ToList().Select(x => PlantillaTransaccionAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.PlantillaTransaccion> GetAll(Func<Domain.PlantillaTransaccion, bool> filter)
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
        public void Add(Domain.PlantillaTransaccion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Plantilla_Transaccion.Add(PlantillaTransaccionAdapter.Current.Adapt(obj));

                    AgregarRelacionesEtiquetasNuevas(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.PlantillaTransaccion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesEtiquetas(obj, db);

                    var obj_from_db = db.Plantilla_Transaccion.Single(x => x.ID_Plantilla_Transaccion == obj.ID_PlantillaTransaccion);
                    db.Entry(obj_from_db).CurrentValues.SetValues(PlantillaTransaccionAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.PlantillaTransaccion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesEtiquetas(obj, db);

                    db.Plantilla_Transaccion.AddOrUpdate(PlantillaTransaccionAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.PlantillaTransaccion obj)
        {
            try
            {
                VariableRepository.Current.RemoveAll(x => x.PlantillaTransaccion?.ID_PlantillaTransaccion == obj.ID_PlantillaTransaccion);

                using (var db = new Models.BudgeeEntities())
                {
                    EliminarRelacionesEtiquetasViejas(obj, db);

                    var obj_from_db = db.Plantilla_Transaccion.Single(x => x.ID_Plantilla_Transaccion == obj.ID_PlantillaTransaccion);
                    db.Plantilla_Transaccion.Remove(obj_from_db);
                    db.SaveChanges();
                }

                ExpresionRepository.Current.RemoveAll(x => x.ID_Expresion == obj.MontoExpresion?.ID_Expresion);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.PlantillaTransaccion, bool> filter)
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

        private void AgregarRelacionesEtiquetasNuevas(Domain.PlantillaTransaccion obj, Models.BudgeeEntities db)
        {
            try
            {
                var NEW_Etiquetas = obj.Etiquetas;

                foreach (var etiqueta_new in NEW_Etiquetas)
                {
                    CaracteristicaRepository.Current.AddOrUpdate(etiqueta_new);

                    db.PlantillaTransaccion_Etiqueta.Add(new Models.PlantillaTransaccion_Etiqueta()
                    {
                        ID_Plantilla_Transaccion = obj.ID_PlantillaTransaccion,
                        ID_Etiqueta = etiqueta_new.ID_Caracteristica
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void EliminarRelacionesEtiquetasViejas(Domain.PlantillaTransaccion obj, Models.BudgeeEntities db)
        {
            try
            {
                var OLD_RelacionesEtiquetas = db.PlantillaTransaccion_Etiqueta.Where(x => x.ID_Plantilla_Transaccion == obj.ID_PlantillaTransaccion);

                foreach (var etiqueta_old in OLD_RelacionesEtiquetas)
                    db.PlantillaTransaccion_Etiqueta.Remove(etiqueta_old);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void ActualizarRelacionesEtiquetas(Domain.PlantillaTransaccion obj, Models.BudgeeEntities db)
        {
            EliminarRelacionesEtiquetasViejas(obj, db);
            AgregarRelacionesEtiquetasNuevas(obj, db);
        }
    }
}
