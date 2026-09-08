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
    /// Repositorio SQL Server de Transacción.
    /// </summary>
    internal class TransaccionRepository : IGenericRepository<Domain.Transaccion>
    {
        #region Singleton
        private readonly static TransaccionRepository _instance;
        public static TransaccionRepository Current { get { return _instance; } }
        static TransaccionRepository() { _instance = new TransaccionRepository(); }
        private TransaccionRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Transaccion GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Transaccion.AsNoTracking();
                    return TransaccionAdapter.Current.Adapt(
                        db.Transaccion.Where(x => x.ID_Transaccion == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Transaccion> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Transaccion.AsNoTracking();
                    return db.Transaccion.ToList().Select(x => TransaccionAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Transaccion> GetAll(Func<Domain.Transaccion, bool> filter)
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
        public void Add(Domain.Transaccion obj)
        {
            try
            {
                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Transaccion.Add(TransaccionAdapter.Current.Adapt(obj));

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
        public void Update(Domain.Transaccion obj)
        {
            try
            {
                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesEtiquetas(obj, db);

                    var obj_from_db = db.Transaccion.Single(x => x.ID_Transaccion == obj.ID_Transaccion);
                    db.Entry(obj_from_db).CurrentValues.SetValues(TransaccionAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Transaccion obj)
        {
            try
            {
                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesEtiquetas(obj, db);

                    db.Transaccion.AddOrUpdate(TransaccionAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Transaccion obj)
        {
            try
            {
                VariableRepository.Current.RemoveAll(x => x.Transaccion?.ID_Transaccion == obj.ID_Transaccion);

                using (var db = new Models.BudgeeEntities())
                {
                    EliminarRelacionesEtiquetasViejas(obj, db);

                    var obj_from_db = db.Transaccion.Single(x => x.ID_Transaccion == obj.ID_Transaccion);
                    db.Transaccion.Remove(obj_from_db);
                    db.SaveChanges();
                }

                ExpresionRepository.Current.RemoveAll(x => x.ID_Expresion == obj.MontoExpresion.ID_Expresion);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Transaccion, bool> filter)
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

        private void AgregarRelacionesEtiquetasNuevas(Domain.Transaccion obj, Models.BudgeeEntities db)
        {
            try
            {
                var NEW_Etiquetas = obj.Etiquetas;

                foreach (var etiqueta_new in NEW_Etiquetas)
                {
                    CaracteristicaRepository.Current.AddOrUpdate(etiqueta_new);

                    db.Transaccion_Etiqueta.Add(new Models.Transaccion_Etiqueta()
                    {
                        ID_Transaccion = obj.ID_Transaccion,
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
        private void EliminarRelacionesEtiquetasViejas(Domain.Transaccion obj, Models.BudgeeEntities db)
        {
            try
            {
                var OLD_RelacionesEtiquetas = db.Transaccion_Etiqueta.Where(x => x.ID_Transaccion == obj.ID_Transaccion);

                foreach (var etiqueta_old in OLD_RelacionesEtiquetas)
                    db.Transaccion_Etiqueta.Remove(etiqueta_old);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void ActualizarRelacionesEtiquetas(Domain.Transaccion obj, Models.BudgeeEntities db)
        {
            EliminarRelacionesEtiquetasViejas(obj, db);
            AgregarRelacionesEtiquetasNuevas(obj, db);
        }
    }
}
