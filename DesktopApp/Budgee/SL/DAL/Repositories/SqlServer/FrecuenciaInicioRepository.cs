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
    /// Repositorio SQL Server de FrecuenciaInicio.
    /// </summary>
    internal class FrecuenciaInicioRepository : IGenericRepository<Domain.FrecuenciaInicio>
    {
        #region Singleton
        private readonly static FrecuenciaInicioRepository _instance;
        public static FrecuenciaInicioRepository Current { get { return _instance; } }
        static FrecuenciaInicioRepository() { _instance = new FrecuenciaInicioRepository(); }
        private FrecuenciaInicioRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.FrecuenciaInicio GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.FrecuenciaInicio.AsNoTracking();
                    return FrecuenciaInicioAdapter.Current.Adapt(
                        db.FrecuenciaInicio.Where(x => x.ID_FrecuenciaInicio == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.FrecuenciaInicio> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.FrecuenciaInicio.AsNoTracking();
                    return db.FrecuenciaInicio.ToList().Select(x => FrecuenciaInicioAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.FrecuenciaInicio> GetAll(Func<Domain.FrecuenciaInicio, bool> filter)
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
        public void Add(Domain.FrecuenciaInicio obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.FrecuenciaInicio.Add(FrecuenciaInicioAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.FrecuenciaInicio obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.FrecuenciaInicio.Single(x => x.ID_FrecuenciaInicio == obj.ID_FrecuenciaInicio);
                    db.Entry(obj_from_db).CurrentValues.SetValues(FrecuenciaInicioAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.FrecuenciaInicio obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.FrecuenciaInicio.AddOrUpdate(FrecuenciaInicioAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.FrecuenciaInicio obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.FrecuenciaInicio.Single(x => x.ID_FrecuenciaInicio == obj.ID_FrecuenciaInicio);
                    db.FrecuenciaInicio.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.FrecuenciaInicio, bool> filter)
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
    }
}
