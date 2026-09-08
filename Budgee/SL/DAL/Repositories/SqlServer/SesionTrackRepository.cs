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
    /// Repositorio SQL Server de SesionTrack.
    /// </summary>
    internal class SesionTrackRepository : IGenericRepository<Domain.Security.SesionTrack>
    {
        #region Singleton
        private readonly static SesionTrackRepository _instance;
        public static SesionTrackRepository Current { get { return _instance; } }
        static SesionTrackRepository() { _instance = new SesionTrackRepository(); }
        private SesionTrackRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.SesionTrack GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.SesionTrack.AsNoTracking();
                    return SesionTrackAdapter.Current.Adapt(
                        db.SesionTrack.Where(x => x.ID_SesionTrack == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.SesionTrack> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    db.SesionTrack.AsNoTracking();
                    return db.SesionTrack.ToList().Select(x => SesionTrackAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Security.SesionTrack> GetAll(Func<Domain.Security.SesionTrack, bool> filter)
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
        public void Add(Domain.Security.SesionTrack obj)
        {
            try
            {
                UsuarioRepository.Current.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeSLEntities())
                {
                    db.SesionTrack.Add(SesionTrackAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Security.SesionTrack obj)
        {
            try
            {
                UsuarioRepository.Current.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.SesionTrack.Single(x => x.ID_SesionTrack == obj.ID_SesionTrack);
                    db.Entry(obj_from_db).CurrentValues.SetValues(SesionTrackAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Security.SesionTrack obj)
        {
            try
            {
                UsuarioRepository.Current.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeSLEntities())
                {
                    db.SesionTrack.AddOrUpdate(SesionTrackAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Security.SesionTrack obj)
        {
            try
            {
                using (var db = new Models.BudgeeSLEntities())
                {
                    var obj_from_db = db.SesionTrack.Single(x => x.ID_SesionTrack == obj.ID_SesionTrack);
                    db.SesionTrack.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Security.SesionTrack, bool> filter)
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
