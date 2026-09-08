using Enums;
using SL.Domain.Security;
using System;

namespace SL.Domain
{
    /// <summary>
    /// Lapso que comprende un periodo de tiempo. Puede ser un intervalo (entre dos fechas) o un periodo de tiempo a partir
    /// de la fecha actual (e.g.: este día, esta semana, este mes, este cuatrimestre)
    /// </summary>
    [Serializable]
    public class Lapso
    {
        Guid _ID_Lapso;
        Tipo_Lapso _TipoLapso;
        DateTime? _FechaDesde;
        DateTime? _FechaHasta;
        Usuario _Usuario;

        public Lapso(Guid iD_Lapso, Tipo_Lapso tipoLapso, DateTime? fechaDesde, DateTime? fechaHasta, Usuario usuario)
        {
            ID_Lapso = iD_Lapso;
            TipoLapso = tipoLapso;
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            Usuario = usuario;
        }

        public Guid ID_Lapso { get => _ID_Lapso; set => _ID_Lapso = value; }
        public Tipo_Lapso TipoLapso { get => _TipoLapso; set => _TipoLapso = value; }
        public DateTime? FechaDesde { get => _FechaDesde; set => _FechaDesde = value; }
        public DateTime? FechaHasta { get => _FechaHasta; set => _FechaHasta = value; }
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
    }
}
