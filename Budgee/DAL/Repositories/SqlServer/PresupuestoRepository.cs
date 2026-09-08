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
    /// Repositorio SQL Server de Presupuesto.
    /// </summary>
    internal class PresupuestoRepository : IGenericRepository<Domain.Presupuesto>
    {
        #region Singleton
        private readonly static PresupuestoRepository _instance;
        public static PresupuestoRepository Current { get { return _instance; } }
        static PresupuestoRepository() { _instance = new PresupuestoRepository(); }
        private PresupuestoRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Presupuesto GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Presupuesto.AsNoTracking();
                    return PresupuestoAdapter.Current.Adapt(
                        db.Presupuesto.Where(x => x.ID_Presupuesto == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Presupuesto> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Presupuesto.AsNoTracking();
                    return db.Presupuesto.ToList().Select(x => PresupuestoAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Presupuesto> GetAll(Func<Domain.Presupuesto, bool> filter)
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
        public void Add(Domain.Presupuesto obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.VariableSupervisada != null)
                    VariableRepository.Current.AddOrUpdate(obj.VariableSupervisada);

                if (obj.CondicionExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.CondicionExpresion);

                if (obj.LapsoPresupuesto != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.LapsoPresupuesto);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Presupuesto.Add(PresupuestoAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Presupuesto obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.VariableSupervisada != null)
                    VariableRepository.Current.AddOrUpdate(obj.VariableSupervisada);

                if (obj.CondicionExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.CondicionExpresion);

                if (obj.LapsoPresupuesto != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.LapsoPresupuesto);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Presupuesto.Single(x => x.ID_Presupuesto == obj.ID_Presupuesto);
                    db.Entry(obj_from_db).CurrentValues.SetValues(PresupuestoAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Presupuesto obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.VariableSupervisada != null)
                    VariableRepository.Current.AddOrUpdate(obj.VariableSupervisada);

                if (obj.CondicionExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.CondicionExpresion);

                if (obj.LapsoPresupuesto != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.LapsoPresupuesto);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Presupuesto.AddOrUpdate(PresupuestoAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Presupuesto obj)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Presupuesto.Single(x => x.ID_Presupuesto == obj.ID_Presupuesto);
                    db.Presupuesto.Remove(obj_from_db);
                    db.SaveChanges();
                }

                VariableRepository.Current.RemoveAll(x => x.ID_Variable == obj.VariableSupervisada.ID_Variable);
                ExpresionRepository.Current.RemoveAll(x => x.ID_Expresion == obj.CondicionExpresion.ID_Expresion);
                SL.BLL.Services.FrecuenciaInicioService.Current.RemoveAll(x => x.ID_FrecuenciaInicio == obj.LapsoPresupuesto?.ID_FrecuenciaInicio);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Presupuesto, bool> filter)
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
