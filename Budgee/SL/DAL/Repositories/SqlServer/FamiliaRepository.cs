using SL.DAL.Contracts;
using SL.DAL.Repositories.SqlServer.Adapters;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SL.DAL.Repositories.SqlServer
{
    /// <summary>
    /// Repositorio SQL Server de Familia.
    /// </summary>
    internal class FamiliaRepository : IGenericRepository<Domain.Security.Familia>
    {
        #region Singleton
        private readonly static FamiliaRepository _instance;
        public static FamiliaRepository Current { get { return _instance; } }
        static FamiliaRepository() { _instance = new FamiliaRepository(); }
        private FamiliaRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.Familia GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Familia.AsNoTracking();
                    return FamiliaAdapter.Current.Adapt(
                        db.Familia.Where(x => x.ID_Familia == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.Familia> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Familia.AsNoTracking();
                    return db.Familia.ToList().Select(x => FamiliaAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.Familia> GetAll(Func<Domain.Security.Familia, bool> filter)
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
        public void Add(Domain.Security.Familia obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Familia.Add(FamiliaAdapter.Current.Adapt(obj));

                    //Aparte de agregar la familia, debo generar las relaciones en tablas intermedias
                    //Tanto de familia a familia, como de familia a patente
                    AgregarRelacionesPrivilegiosNuevos(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Security.Familia obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.Familia.Single(x => x.ID_Familia == obj.ID_Familia);
                    db.Entry(obj_from_db).CurrentValues.SetValues(FamiliaAdapter.Current.Adapt(obj));

                    //Aparte de actualizar la familia, debo actualizar las relaciones en tablas intermedias
                    //Tanto de familia a familia, como de familia a patente
                    ActualizarRelacionesPrivilegios(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Security.Familia obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Familia.AddOrUpdate(FamiliaAdapter.Current.Adapt(obj));

                    ActualizarRelacionesPrivilegios(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Security.Familia obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    //Antes de eliminarla, debo eliminar sus relaciones
                    //Primero elimino las relaciones con sus privilegios
                    EliminarRelacionesPrivilegiosViejos(obj, db);

                    //Ahora desligo la familia de los usuarios o familias que la puedan poseer
                    EliminarRelacionesPoseedores(obj, db);

                    var obj_from_db = db.Familia.Single(x => x.ID_Familia == obj.ID_Familia);
                    db.Familia.Remove(obj_from_db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Security.Familia, bool> filter)
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

        private void AgregarRelacionesPrivilegiosNuevos(Domain.Security.Familia obj, Models.BudgeeSLEntities db)
        {
            try
            {
                var NEW_FamiliasHijas = obj.Privilegios.Where(x => x is Domain.Security.Familia).Cast<Domain.Security.Familia>();
                var NEW_Patentes = obj.Privilegios.Where(x => x is Domain.Security.Patente).Cast<Domain.Security.Patente>();

                foreach (var familia_new in NEW_FamiliasHijas)
                {
                    FamiliaRepository.Current.AddOrUpdate(familia_new);

                    db.Familia_Familia.Add(new Models.Familia_Familia()
                    {
                        ID_Familia_Padre = obj.ID_Familia,
                        ID_Familia_Hija = familia_new.ID_Familia
                    });
                }
                foreach (var patente_new in NEW_Patentes)
                {
                    PatenteRepository.Current.AddOrUpdate(patente_new);

                    db.Familia_Patente.Add(new Models.Familia_Patente()
                    {
                        ID_Familia = obj.ID_Familia,
                        ID_Patente = patente_new.ID_Patente
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void EliminarRelacionesPrivilegiosViejos(Domain.Security.Familia obj, Models.BudgeeSLEntities db)
        {
            try
            {
                var OLD_FamiliasHijas = db.Familia_Familia.Where(x => x.ID_Familia_Padre == obj.ID_Familia);
                var OLD_Patentes = db.Familia_Patente.Where(x => x.ID_Familia == obj.ID_Familia);

                foreach (var familia_old in OLD_FamiliasHijas)
                    db.Familia_Familia.Remove(familia_old);

                foreach (var patente_old in OLD_Patentes)
                    db.Familia_Patente.Remove(patente_old);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void ActualizarRelacionesPrivilegios(Domain.Security.Familia obj, Models.BudgeeSLEntities db)
        {
            EliminarRelacionesPrivilegiosViejos(obj, db);
            AgregarRelacionesPrivilegiosNuevos(obj, db);
        }
        private void EliminarRelacionesPoseedores(Domain.Security.Familia obj, Models.BudgeeSLEntities db)
        {
            try
            {
                var RelacionFamiliasPadres = db.Familia_Familia.Where(x => x.ID_Familia_Hija == obj.ID_Familia);
                var RelacionesConUsuarios = db.Usuario_Familia.Where(x => x.ID_Familia == obj.ID_Familia);

                foreach (var familia in RelacionFamiliasPadres)
                    db.Familia_Familia.Remove(familia);

                foreach (var relacionUsuario in RelacionesConUsuarios)
                    db.Usuario_Familia.Remove(relacionUsuario);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
