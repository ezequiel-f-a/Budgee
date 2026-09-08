using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Presupuesto.
    /// </summary>
    internal class PresupuestoAdapter : IGenericAdapter<Domain.Presupuesto, Models.Presupuesto>
    {
        #region Singleton
        private readonly static PresupuestoAdapter _instance;
        public static PresupuestoAdapter Current { get { return _instance; } }
        static PresupuestoAdapter() { _instance = new PresupuestoAdapter(); }
        private PresupuestoAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Presupuesto Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Presupuesto Adapt(Models.Presupuesto Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            Domain.Variable var_supervisada = null;
            if (Entity.ID_Variable_Supervisada != null)
                var_supervisada = VariableRepository.Current.GetOne(Entity.ID_Variable_Supervisada);

            Domain.Expresion condicion = null;
            if (Entity.ID_Condicion_Expresion != null)
                condicion = ExpresionRepository.Current.GetOne((Guid)Entity.ID_Condicion_Expresion);

            SL.Domain.FrecuenciaInicio frecuenciaInicio = null;
            if (Entity.ID_Lapso_Frecuencia != null)
                frecuenciaInicio = SL.BLL.Services.FrecuenciaInicioService.Current.GetOne((Guid)Entity.ID_Lapso_Frecuencia);

            return new Domain.Presupuesto(
                Entity.ID_Presupuesto,
                Entity.Descripcion,
                var_supervisada,
                condicion,
                (Operador_Relacional)Entity.Operador_Relacional.ToEnum(new Operador_Relacional()),
                frecuenciaInicio,
                (Cuando_Chequear)Entity.Cuando_Chequear.ToEnum(new Cuando_Chequear()),
                Entity.Establecer_Alarma_Windows,
                Entity.Establecer_Notif_Windows,
                Entity.Habilitado,
                Entity.Estado,
                usuario
                );
        }
        public Models.Presupuesto Adapt(Domain.Presupuesto Obj)
        {
            return new Models.Presupuesto()
            {
                ID_Presupuesto = Obj.ID_Presupuesto,
                Descripcion = Obj.Descripcion,
                ID_Variable_Supervisada = Obj.VariableSupervisada.ID_Variable,
                ID_Condicion_Expresion = Obj.CondicionExpresion.ID_Expresion,
                Operador_Relacional = Obj.OperadorRelacional.ToString(),
                ID_Lapso_Frecuencia = Obj.LapsoPresupuesto?.ID_FrecuenciaInicio,
                Cuando_Chequear = Obj.CuandoChequear.ToString(),
                ID_Usuario = Obj.Usuario.ID_Usuario,
                Establecer_Alarma_Windows = Obj.AlarmaWindows,
                Establecer_Notif_Windows = Obj.NotificacionWindows,
                Habilitado = Obj.Habilitado,
                Estado = Obj.Estado
            };
        }
    }
}
