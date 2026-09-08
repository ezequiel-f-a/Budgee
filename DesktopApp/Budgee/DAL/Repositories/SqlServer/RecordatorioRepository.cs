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
    /// Repositorio SQL Server de Recordatorio.
    /// </summary>
    internal class RecordatorioRepository : IGenericRepository<Domain.Recordatorio>
    {
        #region Singleton
        private readonly static RecordatorioRepository _instance;
        public static RecordatorioRepository Current { get { return _instance; } }
        static RecordatorioRepository() { _instance = new RecordatorioRepository(); }
        private RecordatorioRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Recordatorio GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Recordatorio.AsNoTracking();
                    return RecordatorioAdapter.Current.Adapt(
                        db.Recordatorio.Where(x => x.ID_Recordatorio == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Recordatorio> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Recordatorio.AsNoTracking();
                    return db.Recordatorio.ToList().Select(x => RecordatorioAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Recordatorio> GetAll(Func<Domain.Recordatorio, bool> filter)
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
        public void Add(Domain.Recordatorio obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.FrecuenciaInicio != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.FrecuenciaInicio);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Recordatorio.Add(RecordatorioAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Recordatorio obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.FrecuenciaInicio != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.FrecuenciaInicio);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Recordatorio.Single(x => x.ID_Recordatorio == obj.ID_Recordatorio);
                    db.Entry(obj_from_db).CurrentValues.SetValues(RecordatorioAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Recordatorio obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.FrecuenciaInicio != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.FrecuenciaInicio);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Recordatorio.AddOrUpdate(RecordatorioAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Recordatorio obj)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Recordatorio.Single(x => x.ID_Recordatorio == obj.ID_Recordatorio);
                    db.Recordatorio.Remove(obj_from_db);
                    db.SaveChanges();
                }

                SL.BLL.Services.FrecuenciaInicioService.Current.RemoveAll(x => x.ID_FrecuenciaInicio == obj.FrecuenciaInicio.ID_FrecuenciaInicio);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Recordatorio, bool> filter)
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
