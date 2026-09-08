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
    /// Repositorio SQL Server de Lapso.
    /// </summary>
    internal class LapsoRepository : IGenericRepository<Domain.Lapso>
    {
        #region Singleton
        private readonly static LapsoRepository _instance;
        public static LapsoRepository Current { get { return _instance; } }
        static LapsoRepository() { _instance = new LapsoRepository(); }
        private LapsoRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Lapso GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Lapso.AsNoTracking();
                    return LapsoAdapter.Current.Adapt(
                        db.Lapso.Where(x => x.ID_Lapso == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Lapso> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Lapso.AsNoTracking();
                    return db.Lapso.ToList().Select(x => LapsoAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Lapso> GetAll(Func<Domain.Lapso, bool> filter)
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
        public void Add(Domain.Lapso obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Lapso.Add(LapsoAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Lapso obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.Lapso.Single(x => x.ID_Lapso == obj.ID_Lapso);
                    db.Entry(obj_from_db).CurrentValues.SetValues(LapsoAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Lapso obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.Lapso.AddOrUpdate(LapsoAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Lapso obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.Lapso.Single(x => x.ID_Lapso == obj.ID_Lapso);
                    db.Lapso.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Lapso, bool> filter)
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
