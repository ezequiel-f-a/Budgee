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
    /// Repositorio SQL Server de Cuenta.
    /// </summary>
    internal class CuentaRepository : IGenericRepository<Domain.Cuenta>
    {
        #region Singleton
        private readonly static CuentaRepository _instance;
        public static CuentaRepository Current { get { return _instance; } }
        static CuentaRepository() { _instance = new CuentaRepository(); }
        private CuentaRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Cuenta GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Cuenta.AsNoTracking();
                    return CuentaAdapter.Current.Adapt(
                        db.Cuenta.Where(x => x.ID_Cuenta == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Cuenta> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Cuenta.AsNoTracking();
                    return db.Cuenta.ToList().Select(x => CuentaAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Cuenta> GetAll(Func<Domain.Cuenta, bool> filter)
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
        public void Add(Domain.Cuenta obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Cuenta.Add(CuentaAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Cuenta obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                //UpdateEstadoComposiciones(obj);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Cuenta.Single(x => x.ID_Cuenta == obj.ID_Cuenta);
                    db.Entry(obj_from_db).CurrentValues.SetValues(CuentaAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Cuenta obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                //UpdateEstadoComposiciones(obj);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Cuenta.AddOrUpdate(CuentaAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Cuenta obj)
        {
            try
            {
                TransaccionRepository.Current.RemoveAll(x => x.Cuenta.ID_Cuenta == obj.ID_Cuenta);
                PlanificacionRepository.Current.RemoveAll(x => x.Cuenta.ID_Cuenta == obj.ID_Cuenta);
                VariableRepository.Current.RemoveAll(x => x.Cuenta?.ID_Cuenta == obj.ID_Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Cuenta.Single(x => x.ID_Cuenta == obj.ID_Cuenta);
                    db.Cuenta.Remove(obj_from_db);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Cuenta, bool> filter)
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

        void UpdateEstadoComposiciones(Domain.Cuenta obj)
        {
            try
            {
                bool estado = obj.Estado;

                TransaccionRepository.Current.GetAll(x => x.Cuenta.ID_Cuenta == obj.ID_Cuenta && x.Estado == !estado).ToList().ForEach(x =>
                {
                    x.Estado = estado;
                    TransaccionRepository.Current.Update(x);
                });

                PlanificacionRepository.Current.GetAll(x => x.Cuenta.ID_Cuenta == obj.ID_Cuenta && x.Estado == !estado).ToList().ForEach(x =>
                {
                    x.Estado = estado;
                    PlanificacionRepository.Current.Update(x);
                });
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
