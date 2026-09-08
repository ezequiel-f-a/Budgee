using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;

namespace SL.DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de SesionTrack.
    /// </summary>
    internal class SesionTrackAdapter : IGenericAdapter<Domain.Security.SesionTrack, Models.SesionTrack>
    {
        #region Singleton
        private readonly static SesionTrackAdapter _instance;
        public static SesionTrackAdapter Current { get { return _instance; } }
        static SesionTrackAdapter() { _instance = new SesionTrackAdapter(); }
        private SesionTrackAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.SesionTrack Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Security.SesionTrack Adapt(Models.SesionTrack Entity)
        {
            return new Domain.Security.SesionTrack(
                Entity.ID_SesionTrack,
                (Tipo_Track)Entity.TipoTrack.ToEnum(new Tipo_Track()),
                Entity.Fecha_Proceso,
                UsuarioAdapter.Current.Adapt(Entity.Usuario));
        }
        public Models.SesionTrack Adapt(Domain.Security.SesionTrack Obj)
        {
            return new Models.SesionTrack()
            {
                ID_SesionTrack = Obj.ID_SesionTrack,
                TipoTrack = Obj.TipoTrack.ToString(),
                Fecha_Proceso = Obj.FechaProceso,
                ID_Usuario = Obj.Usuario.ID_Usuario
            };
        }
    }
}
