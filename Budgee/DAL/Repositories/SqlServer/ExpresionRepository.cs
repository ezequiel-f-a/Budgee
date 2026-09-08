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
    /// Repositorio SQL Server de Expresión.
    /// </summary>
    internal class ExpresionRepository : IGenericRepository<Domain.Expresion>
    {
        #region Singleton
        private readonly static ExpresionRepository _instance;
        public static ExpresionRepository Current { get { return _instance; } }
        static ExpresionRepository() { _instance = new ExpresionRepository(); }
        private ExpresionRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Expresion GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Expresion.AsNoTracking();
                    return ExpresionAdapter.Current.Adapt(
                        db.Expresion.Where(x => x.ID_Expresion == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Expresion> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Expresion.AsNoTracking();
                    return db.Expresion.ToList().Select(x => ExpresionAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Expresion> GetAll(Func<Domain.Expresion, bool> filter)
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
        public void Add(Domain.Expresion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Expresion.Add(ExpresionAdapter.Current.Adapt(obj));

                    AgregarRelacionesVariablesNuevas(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Expresion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesVariables(obj, db);

                    var obj_from_db = db.Expresion.Single(x => x.ID_Expresion == obj.ID_Expresion);
                    db.Entry(obj_from_db).CurrentValues.SetValues(ExpresionAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Expresion obj)
        {
            try
            {
                SL.DAL.Factories.Factory.Current.UsuarioRepository.AddOrUpdate(obj.Usuario);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesVariables(obj, db);

                    db.Expresion.AddOrUpdate(ExpresionAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Expresion obj)
        {
            try
            {
                TransaccionRepository.Current.RemoveAll(x => x.MontoExpresion.ID_Expresion == obj.ID_Expresion);
                PlanificacionRepository.Current.RemoveAll(x => x.MontoExpresion.ID_Expresion == obj.ID_Expresion);
                PlantillaTransaccionRepository.Current.RemoveAll(x => x.MontoExpresion?.ID_Expresion == obj.ID_Expresion);
                PresupuestoRepository.Current.RemoveAll(x => x.CondicionExpresion.ID_Expresion == obj.ID_Expresion);

                using (var db = new Models.BudgeeEntities())
                {
                    EliminarRelacionesVariablesViejas(obj, db);

                    var ID_Variables = db.Expresion_Variable.Where(x => x.ID_Expresion == obj.ID_Expresion).ToList().Select(x => x.ID_Variable);
                    VariableRepository.Current.RemoveAll(x => ID_Variables.Contains(x.ID_Variable));

                    var obj_from_db = db.Expresion.Single(x => x.ID_Expresion == obj.ID_Expresion);
                    db.Expresion.Remove(obj_from_db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Expresion, bool> filter)
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

        private void AgregarRelacionesVariablesNuevas(Domain.Expresion obj, Models.BudgeeEntities db)
        {
            try
            {
                var NEW_Variables = obj.Variables;

                foreach (var variable_new in NEW_Variables)
                {
                    VariableRepository.Current.AddOrUpdate(variable_new);

                    db.Expresion_Variable.Add(new Models.Expresion_Variable()
                    {
                        ID_Expresion = obj.ID_Expresion,
                        ID_Variable = variable_new.ID_Variable
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void EliminarRelacionesVariablesViejas(Domain.Expresion obj, Models.BudgeeEntities db)
        {
            try
            {
                var OLD_RelacionesVariables = db.Expresion_Variable.Where(x => x.ID_Expresion == obj.ID_Expresion);

                foreach (var variable_old in OLD_RelacionesVariables)
                    db.Expresion_Variable.Remove(variable_old);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void ActualizarRelacionesVariables(Domain.Expresion obj, Models.BudgeeEntities db)
        {
            try
            {
                EliminarRelacionesVariablesViejas(obj, db);
                AgregarRelacionesVariablesNuevas(obj, db);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
