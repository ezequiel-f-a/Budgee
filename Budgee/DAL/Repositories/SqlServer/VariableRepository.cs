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
    /// Repositorio SQL Server de Variable.
    /// </summary>
    internal class VariableRepository : IGenericRepository<Domain.Variable>
    {
        #region Singleton
        private readonly static VariableRepository _instance;
        public static VariableRepository Current { get { return _instance; } }
        static VariableRepository() { _instance = new VariableRepository(); }
        private VariableRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Variable GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Variable.AsNoTracking();
                    return VariableAdapter.Current.Adapt(
                        db.Variable.Where(x => x.ID_Variable == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Variable> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Variable.AsNoTracking();
                    return db.Variable.ToList().Select(x => VariableAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Variable> GetAll(Func<Domain.Variable, bool> filter)
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
        public void Add(Domain.Variable obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Lapso != null) SL.BLL.Services.LapsoService.Current.AddOrUpdate(obj.Lapso);

                if (obj.Transaccion != null) TransaccionRepository.Current.AddOrUpdate(obj.Transaccion);

                if (obj.Planificacion != null) PlanificacionRepository.Current.AddOrUpdate(obj.Planificacion);

                if (obj.PlantillaTransaccion != null) PlantillaTransaccionRepository.Current.AddOrUpdate(obj.PlantillaTransaccion);

                if (obj.Cuenta != null) CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                if (obj.Categoria != null) CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.Etiqueta != null) CaracteristicaRepository.Current.AddOrUpdate(obj.Etiqueta);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Variable.Add(VariableAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Variable obj)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Variable.Single(x => x.ID_Variable == obj.ID_Variable);
                    db.Entry(obj_from_db).CurrentValues.SetValues(VariableAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Variable obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                if (obj.Lapso != null) SL.BLL.Services.LapsoService.Current.AddOrUpdate(obj.Lapso);

                if (obj.Transaccion != null) TransaccionRepository.Current.AddOrUpdate(obj.Transaccion);

                if (obj.Planificacion != null) PlanificacionRepository.Current.AddOrUpdate(obj.Planificacion);

                if (obj.PlantillaTransaccion != null) PlantillaTransaccionRepository.Current.AddOrUpdate(obj.PlantillaTransaccion);

                if (obj.Cuenta != null) CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                if (obj.Categoria != null) CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.Etiqueta != null) CaracteristicaRepository.Current.AddOrUpdate(obj.Etiqueta);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Variable.AddOrUpdate(VariableAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Variable obj)
        {
            try
            {
                ExpresionRepository.Current.RemoveAll(x => x.Variables.Select(y => y.ID_Variable).Contains(obj.ID_Variable));
                PresupuestoRepository.Current.RemoveAll(x => x.VariableSupervisada.ID_Variable == obj.ID_Variable);

                using (var db = new Models.BudgeeEntities())
                {
                    var obj_from_db = db.Variable.Single(x => x.ID_Variable == obj.ID_Variable);
                    db.Variable.Remove(obj_from_db);
                    db.SaveChanges();
                }

                SL.BLL.Services.LapsoService.Current.RemoveAll(x => x.ID_Lapso == obj.Lapso?.ID_Lapso);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Variable, bool> filter)
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
