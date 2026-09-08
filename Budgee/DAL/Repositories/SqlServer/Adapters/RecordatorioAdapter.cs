using SL.DAL.Contracts;
using System;
using System.Linq;

namespace DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Recordatorio.
    /// </summary>
    internal class RecordatorioAdapter : IGenericAdapter<Domain.Recordatorio, Models.Recordatorio>
    {
        #region Singleton
        private readonly static RecordatorioAdapter _instance;
        public static RecordatorioAdapter Current { get { return _instance; } }
        static RecordatorioAdapter() { _instance = new RecordatorioAdapter(); }
        private RecordatorioAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Recordatorio Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Recordatorio Adapt(Models.Recordatorio Entity)
        {
            var usuario =
                SL.BLL.Services.UsuarioService.Current.GetOne(Entity.ID_Usuario);

            SL.Domain.FrecuenciaInicio frecuenciaInicio = null;
            if (Entity.ID_FrecuenciaInicio != null)
                frecuenciaInicio = SL.BLL.Services.FrecuenciaInicioService.Current.GetOne(Entity.ID_FrecuenciaInicio);

            return new Domain.Recordatorio(
                Entity.ID_Recordatorio,
                Entity.Descripcion,
                frecuenciaInicio,
                Entity.Establecer_Alarma_Windows,
                Entity.Establecer_Notif_Windows,
                Entity.Quitar_Al_Concluir,
                Entity.Habilitado,
                Entity.Estado,
                usuario
                );
        }
        public Models.Recordatorio Adapt(Domain.Recordatorio Obj)
        {
            return new Models.Recordatorio()
            {
                ID_Recordatorio = Obj.ID_Recordatorio,
                Descripcion = Obj.Descripcion,
                ID_FrecuenciaInicio = Obj.FrecuenciaInicio.ID_FrecuenciaInicio,
                ID_Usuario = Obj.Usuario.ID_Usuario,
                Establecer_Alarma_Windows = Obj.AlarmaWindows,
                Establecer_Notif_Windows = Obj.NotificacionWindows,
                Quitar_Al_Concluir = Obj.QuitarAlConcluir,
                Habilitado = Obj.Habilitado,
                Estado = Obj.Estado
            };
        }
    }
}
