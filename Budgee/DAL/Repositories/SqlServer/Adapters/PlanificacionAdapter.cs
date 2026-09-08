using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Planificación.
    /// </summary>
    internal class PlanificacionAdapter : IGenericAdapter<Domain.Planificacion, Models.Planificacion_Transaccion>
    {
        #region Singleton
        private readonly static PlanificacionAdapter _instance;
        public static PlanificacionAdapter Current { get { return _instance; } }
        static PlanificacionAdapter() { _instance = new PlanificacionAdapter(); }
        private PlanificacionAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Planificacion Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Planificacion Adapt(Models.Planificacion_Transaccion Entity)
        {
            Domain.Cuenta cuenta = CuentaRepository.Current.GetOne(Entity.ID_Cuenta);

            Domain.Caracteristica categoria = null;
            if (Entity.ID_Categoria != null)
                categoria = CaracteristicaRepository.Current.GetOne((Guid)Entity.ID_Categoria);

            Domain.Expresion expresion = null;
            if (Entity.ID_Monto_Expresion != null)
                expresion = ExpresionRepository.Current.GetOne((Guid)Entity.ID_Monto_Expresion);

            Domain.Recordatorio recordatorio = null;
            if (Entity.ID_RecordatorioLigado != null)
                recordatorio = RecordatorioRepository.Current.GetOne((Guid)Entity.ID_RecordatorioLigado);

            SL.Domain.FrecuenciaInicio frecuenciaInicio = null;
            if (Entity.ID_FrecuenciaInicio != null)
                frecuenciaInicio = SL.BLL.Services.FrecuenciaInicioService.Current.GetOne(Entity.ID_FrecuenciaInicio);

            var etiquetas = new List<Domain.Caracteristica>();

            using (var db = new Models.BudgeeEntities())
            {
                db.PlanificacionTransaccion_Etiqueta.AsNoTracking();
                var ID_Etiquetas = db.PlanificacionTransaccion_Etiqueta.Where(x => x.ID_Planificacion_Transaccion == Entity.ID_Planificacion_Transaccion).ToList()
                    .Select(x => x.ID_Etiqueta);

                etiquetas = ID_Etiquetas.Select(x => CaracteristicaRepository.Current.GetOne(x)).ToList();
            }

            return new Domain.Planificacion(
                Entity.ID_Planificacion_Transaccion,
                Entity.Descripcion_Planificacion,
                Entity.Descripcion_Transaccion,
                categoria,
                etiquetas,
                expresion,
                (Tipo_Operacion)Entity.Tipo_Operacion.ToEnum(new Tipo_Operacion()),
                cuenta,
                frecuenciaInicio,
                recordatorio,
                Entity.Quitar_Al_Concluir,
                Entity.Habilitado,
                Entity.Estado
                );
        }
        public Models.Planificacion_Transaccion Adapt(Domain.Planificacion Obj)
        {
            return new Models.Planificacion_Transaccion()
            {
                ID_Planificacion_Transaccion = Obj.ID_Planificacion,
                Descripcion_Planificacion = Obj.Descripcion,
                Descripcion_Transaccion = Obj.Descripcion_Transaccion,
                ID_Categoria = Obj.Categoria?.ID_Caracteristica,
                ID_Monto_Expresion = Obj.MontoExpresion.ID_Expresion,
                Tipo_Operacion = Obj.TipoOperacion?.ToString(),
                ID_Cuenta = Obj.Cuenta.ID_Cuenta,
                ID_FrecuenciaInicio = Obj.FrecuenciaInicio.ID_FrecuenciaInicio,
                ID_RecordatorioLigado = Obj.RecordatorioLigado?.ID_Recordatorio,
                Quitar_Al_Concluir = Obj.QuitarAlConcluir,
                Habilitado = Obj.Habilitado,
                Estado = Obj.Estado
            };
        }
    }
}
