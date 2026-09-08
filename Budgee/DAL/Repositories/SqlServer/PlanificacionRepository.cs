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
    /// Repositorio SQL Server de Planificación.
    /// </summary>
    internal class PlanificacionRepository : IGenericRepository<Domain.Planificacion>
    {
        #region Singleton
        private readonly static PlanificacionRepository _instance;
        public static PlanificacionRepository Current { get { return _instance; } }
        static PlanificacionRepository() { _instance = new PlanificacionRepository(); }
        private PlanificacionRepository()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Planificacion GetOne(Guid ID)
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Planificacion_Transaccion.AsNoTracking();
                    return PlanificacionAdapter.Current.Adapt(
                        db.Planificacion_Transaccion.Where(x => x.ID_Planificacion_Transaccion == ID).ToList().Single());
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Planificacion> GetAll()
        {
            try
            {
                using (var db = new Models.BudgeeEntities())
                {
                    db.Planificacion_Transaccion.AsNoTracking();
                    return db.Planificacion_Transaccion.ToList().Select(x => PlanificacionAdapter.Current.Adapt(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Domain.Planificacion> GetAll(Func<Domain.Planificacion, bool> filter)
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
        public void Add(Domain.Planificacion obj)
        {
            try
            {
                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                if (obj.FrecuenciaInicio != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.FrecuenciaInicio);

                if (obj.RecordatorioLigado != null)
                {
                    if (!obj.Estado) obj.RecordatorioLigado.Estado = false;

                    RecordatorioRepository.Current.AddOrUpdate(obj.RecordatorioLigado);

                    if (!obj.Estado) obj.RecordatorioLigado = null;
                }

                CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    db.Planificacion_Transaccion.Add(PlanificacionAdapter.Current.Adapt(obj));

                    AgregarRelacionesEtiquetasNuevas(obj, db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Domain.Planificacion obj)
        {
            try
            {
                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                if (obj.FrecuenciaInicio != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.FrecuenciaInicio);

                if (obj.RecordatorioLigado != null)
                {
                    if (!obj.Estado) obj.RecordatorioLigado.Estado = false;

                    RecordatorioRepository.Current.AddOrUpdate(obj.RecordatorioLigado);

                    if (!obj.Estado) obj.RecordatorioLigado = null;
                }

                CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesEtiquetas(obj, db);

                    var obj_from_db = db.Planificacion_Transaccion.Single(x => x.ID_Planificacion_Transaccion == obj.ID_Planificacion);
                    db.Entry(obj_from_db).CurrentValues.SetValues(PlanificacionAdapter.Current.Adapt(obj));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Domain.Planificacion obj)
        {
            try
            {
                if (obj.Categoria != null)
                    CaracteristicaRepository.Current.AddOrUpdate(obj.Categoria);

                if (obj.MontoExpresion != null)
                    ExpresionRepository.Current.AddOrUpdate(obj.MontoExpresion);

                if (obj.FrecuenciaInicio != null)
                    SL.BLL.Services.FrecuenciaInicioService.Current.AddOrUpdate(obj.FrecuenciaInicio);

                if (obj.RecordatorioLigado != null)
                {
                    if (!obj.Estado) obj.RecordatorioLigado.Estado = false;

                    RecordatorioRepository.Current.AddOrUpdate(obj.RecordatorioLigado);

                    if (!obj.Estado) obj.RecordatorioLigado = null;
                }

                CuentaRepository.Current.AddOrUpdate(obj.Cuenta);

                using (var db = new Models.BudgeeEntities())
                {
                    ActualizarRelacionesEtiquetas(obj, db);

                    db.Planificacion_Transaccion.AddOrUpdate(PlanificacionAdapter.Current.Adapt(obj));

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Domain.Planificacion obj)
        {
            try
            {
                VariableRepository.Current.RemoveAll(x => x.Planificacion?.ID_Planificacion == obj.ID_Planificacion);

                using (var db = new Models.BudgeeEntities())
                {
                    EliminarRelacionesEtiquetasViejas(obj, db);

                    var obj_from_db = db.Planificacion_Transaccion.Single(x => x.ID_Planificacion_Transaccion == obj.ID_Planificacion);
                    db.Planificacion_Transaccion.Remove(obj_from_db);
                    db.SaveChanges();
                }

                ExpresionRepository.Current.RemoveAll(x => x.ID_Expresion == obj.MontoExpresion.ID_Expresion);
                RecordatorioRepository.Current.RemoveAll(x => x.ID_Recordatorio == obj.RecordatorioLigado?.ID_Recordatorio);
                SL.BLL.Services.FrecuenciaInicioService.Current.RemoveAll(x => x.ID_FrecuenciaInicio == obj.FrecuenciaInicio.ID_FrecuenciaInicio);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Domain.Planificacion, bool> filter)
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

        private void AgregarRelacionesEtiquetasNuevas(Domain.Planificacion obj, Models.BudgeeEntities db)
        {
            try
            {
                var NEW_Etiquetas = obj.Etiquetas;

                foreach (var etiqueta_new in NEW_Etiquetas)
                {
                    CaracteristicaRepository.Current.AddOrUpdate(etiqueta_new);

                    db.PlanificacionTransaccion_Etiqueta.Add(new Models.PlanificacionTransaccion_Etiqueta()
                    {
                        ID_Planificacion_Transaccion = obj.ID_Planificacion,
                        ID_Etiqueta = etiqueta_new.ID_Caracteristica
                    });
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void EliminarRelacionesEtiquetasViejas(Domain.Planificacion obj, Models.BudgeeEntities db)
        {
            try
            {
                var OLD_RelacionesEtiquetas = db.PlanificacionTransaccion_Etiqueta.Where(x => x.ID_Planificacion_Transaccion == obj.ID_Planificacion);

                foreach (var etiqueta_old in OLD_RelacionesEtiquetas)
                    db.PlanificacionTransaccion_Etiqueta.Remove(etiqueta_old);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        private void ActualizarRelacionesEtiquetas(Domain.Planificacion obj, Models.BudgeeEntities db)
        {
            EliminarRelacionesEtiquetasViejas(obj, db);
            AgregarRelacionesEtiquetasNuevas(obj, db);
        }
    }
}
