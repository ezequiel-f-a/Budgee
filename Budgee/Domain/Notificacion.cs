using Enums;
using SL.Domain.Security;
using System;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Notificación que será disparada por la aplicación.
    /// Poseen una procedencia, lo cual facilita acceder a más detalles de la notificación si se desea.
    /// </summary>
    [Serializable]
    public class Notificacion
    {
        Guid _ID_Notificacion;
        string _Informacion;
        DateTime? _FechaEmision;
        Procedencia_Notificacion _Procedencia;
        Presupuesto _Presupuesto;
        Recordatorio _Recordatorio;
        Tipo_Estadistica? _Estadistica;
        Usuario _Usuario;
        bool _Visto;
        bool _Estado;

        public Notificacion(Guid iD_Notificacion, string informacion, DateTime? fecha_Emision, Procedencia_Notificacion procedencia, Presupuesto presupuesto, Recordatorio recordatorio, Tipo_Estadistica? estadistica, Usuario usuario, bool visto, bool estado)
        {
            ID_Notificacion = iD_Notificacion;
            Informacion = informacion;
            FechaEmision = fecha_Emision;
            Procedencia = procedencia;
            Presupuesto = presupuesto;
            Recordatorio = recordatorio;
            Estadistica = estadistica;
            Usuario = usuario;
            Visto = visto;
            Estado = estado;
        }
        [Browsable(false)]
        public Guid ID_Notificacion { get => _ID_Notificacion; set => _ID_Notificacion = value; }
        [DisplayName("Información")]
        public string Informacion { get => _Informacion; set => _Informacion = value; }
        [DisplayName("Fecha de emisión")]
        public DateTime? FechaEmision { get => _FechaEmision; set => _FechaEmision = value; }
        public Procedencia_Notificacion Procedencia { get => _Procedencia; set => _Procedencia = value; }
        [Browsable(false)]
        public Presupuesto Presupuesto { get => _Presupuesto; set => _Presupuesto = value; }
        [Browsable(false)]
        public Recordatorio Recordatorio { get => _Recordatorio; set => _Recordatorio = value; }
        [Browsable(false)]
        public Tipo_Estadistica? Estadistica { get => _Estadistica; set => _Estadistica = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        [Browsable(false)]
        public bool Visto { get => _Visto; set => _Visto = value; }
        [Browsable(false)]
        public bool Estado { get => _Estado; set => _Estado = value; }

        public override string ToString()
        {
            return $"{Informacion} [{FechaEmision}]";
        }
    }
}
