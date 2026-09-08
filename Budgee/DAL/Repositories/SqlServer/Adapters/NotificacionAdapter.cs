using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Notificación.
    /// </summary>
    internal class NotificacionAdapter : IGenericAdapter<Domain.Notificacion, Models.Notificacion>
    {
        #region Singleton
        private readonly static NotificacionAdapter _instance;
        public static NotificacionAdapter Current { get { return _instance; } }
        static NotificacionAdapter() { _instance = new NotificacionAdapter(); }
        private NotificacionAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Notificacion Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Notificacion Adapt(Models.Notificacion Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            Domain.Presupuesto presupuesto = null;
            if (Entity.ID_Presupuesto != null)
                presupuesto = PresupuestoRepository.Current.GetOne((Guid)Entity.ID_Presupuesto);

            Domain.Recordatorio recordatorio = null;
            if (Entity.ID_Recordatorio != null)
                recordatorio = RecordatorioRepository.Current.GetOne((Guid)Entity.ID_Recordatorio);

            return new Domain.Notificacion(
                Entity.ID_Notificacion,
                Entity.Informacion,
                Entity.Fecha_Emision,
                (Procedencia_Notificacion)Entity.Procedencia.ToEnum(new Procedencia_Notificacion()),
                presupuesto,
                recordatorio,
                Entity.Tipo_Estadistica.ToEnum(new Tipo_Estadistica()),
                usuario,
                Entity.Visto,
                Entity.Estado
                );
        }
        public Models.Notificacion Adapt(Domain.Notificacion Obj)
        {
            return new Models.Notificacion()
            {
                ID_Notificacion = Obj.ID_Notificacion,
                Informacion = Obj.Informacion,
                Fecha_Emision = Obj.FechaEmision,
                Procedencia = Obj.Procedencia.ToString(),
                ID_Presupuesto = Obj.Presupuesto?.ID_Presupuesto,
                ID_Recordatorio = Obj.Recordatorio?.ID_Recordatorio,
                Tipo_Estadistica = Obj.Estadistica?.ToString(),
                ID_Usuario = Obj.Usuario.ID_Usuario,
                Visto = Obj.Visto,
                Estado = Obj.Estado
            };
        }
    }
}
