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
    /// Repositorio SQL Server de Patente.
    /// </summary>
    internal class PatenteRepository : IGenericRepository<Domain.Security.Patente>
    {
        #region Singleton
        private readonly static PatenteRepository _instance;
        public static PatenteRepository Current { get { return _instance; } }
        static PatenteRepository() { _instance = new PatenteRepository(); }
        private PatenteRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.Patente GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Patente.AsNoTracking();
                    return PatenteAdapter.Current.Adapt(
                        db.Patente.Where(x => x.ID_Patente == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.Patente> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Patente.AsNoTracking();
                    return db.Patente.ToList().Select(x => PatenteAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.Patente> GetAll(Func<Domain.Security.Patente, bool> filter)
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
        public void Add(Domain.Security.Patente obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Patente.Add(PatenteAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Security.Patente obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.Patente.Single(x => x.ID_Patente == obj.ID_Patente);
                    db.Entry(obj_from_db).CurrentValues.SetValues(PatenteAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Security.Patente obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Patente.AddOrUpdate(PatenteAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Security.Patente obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.Patente.Single(x => x.ID_Patente == obj.ID_Patente);
                    db.Patente.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Security.Patente, bool> filter)
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
