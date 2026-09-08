using Enums;
using System;

namespace SL.Domain.Security
{
    /// <summary>
    /// Bloque de datos de tracking de sesión de usuario.
    /// </summary>
    [Serializable]
    public class SesionTrack
    {
        Guid _ID_SesionTrack;
        Tipo_Track _TipoTrack;
        DateTime _FechaProceso;
        Usuario _Usuario;

        public SesionTrack(Guid iD_SesionTrack, Tipo_Track tipoTrack, DateTime fechaProceso, Usuario usuario)
        {
            ID_SesionTrack = iD_SesionTrack;
            TipoTrack = tipoTrack;
            FechaProceso = fechaProceso;
            Usuario = usuario;
        }

        public Tipo_Track TipoTrack { get => _TipoTrack; set => _TipoTrack = value; }
        public DateTime FechaProceso { get => _FechaProceso; set => _FechaProceso = value; }
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        public Guid ID_SesionTrack { get => _ID_SesionTrack; set => _ID_SesionTrack = value; }
    }
}
