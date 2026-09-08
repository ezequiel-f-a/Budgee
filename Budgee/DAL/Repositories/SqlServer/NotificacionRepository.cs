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
    /// Repositorio SQL Server de Notificación.
    /// </summary>
    internal class NotificacionRepository : IGenericRepository<Domain.Notificacion>
    {
        #region Singleton
        private readonly static NotificacionRepository _instance;
        public static NotificacionRepository Current { get { return _instance; } }
        static NotificacionRepository() { _instance = new NotificacionRepository(); }
        private NotificacionRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Notificacion GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Notificacion.AsNoTracking();
                    return NotificacionAdapter.Current.Adapt(
                        db.Notificacion.Where(x => x.ID_Notificacion == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Notificacion> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Notificacion.AsNoTracking();
                    return db.Notificacion.ToList().Select(x => NotificacionAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Notificacion> GetAll(Func<Domain.Notificacion, bool> filter)
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
        public void Add(Domain.Notificacion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Recordatorio != null)
                    RecordatorioRepository.Current.AddOrUpdate(obj.Recordatorio);

                if (obj.Presupuesto != null)
                    PresupuestoRepository.Current.AddOrUpdate(obj.Presupuesto);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Notificacion.Add(NotificacionAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Notificacion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Recordatorio != null)
                    RecordatorioRepository.Current.AddOrUpdate(obj.Recordatorio);

                if (obj.Presupuesto != null)
                    PresupuestoRepository.Current.AddOrUpdate(obj.Presupuesto);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Notificacion.Single(x => x.ID_Notificacion == obj.ID_Notificacion);
                    db.Entry(obj_from_db).CurrentValues.SetValues(NotificacionAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Notificacion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Recordatorio != null)
                    RecordatorioRepository.Current.AddOrUpdate(obj.Recordatorio);

                if (obj.Presupuesto != null)
                    PresupuestoRepository.Current.AddOrUpdate(obj.Presupuesto);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Notificacion.AddOrUpdate(NotificacionAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Notificacion obj)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Notificacion.Single(x => x.ID_Notificacion == obj.ID_Notificacion);
                    db.Notificacion.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Notificacion, bool> filter)
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
