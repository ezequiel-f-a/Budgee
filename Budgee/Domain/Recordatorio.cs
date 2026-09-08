using SL.Domain;
using SL.Domain.Security;
using System;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Los recordatorios permiten informar al usuario de determinado evento, ya sea para una fecha y hora dadas 
    /// o bien para una recurrencia especificable con el bloque de datos FrecuenciaInicio.
    /// </summary>
    [Serializable]
    public class Recordatorio
    {
        Guid _ID_Recordatorio;
        string _Descripcion;
        FrecuenciaInicio _FrecuenciaInicio;
        Usuario _Usuario;
        bool _AlarmaWindows;
        bool _NotificacionWindows;
        bool _QuitarAlConcluir;
        bool _Habilitado;
        bool _Estado;

        public Recordatorio(Guid iD_Recordatorio, string descripcion, FrecuenciaInicio frecuenciaInicio, bool alarmaWindows, bool notificacionWindows, bool quitarAlConcluir, bool habilitado, bool estado, Usuario usuario)
        {
            ID_Recordatorio = iD_Recordatorio;
            Descripcion = descripcion;
            FrecuenciaInicio = frecuenciaInicio;
            Usuario = usuario;
            AlarmaWindows = alarmaWindows;
            NotificacionWindows = notificacionWindows;
            QuitarAlConcluir = quitarAlConcluir;
            Habilitado = habilitado;
            Estado = estado;
        }
        [Browsable(false)]
        public Guid ID_Recordatorio { get => _ID_Recordatorio; set => _ID_Recordatorio = value; }
        [DisplayName("Descripción")]
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        [DisplayName("Frecuencia e Inicio")]
        public FrecuenciaInicio FrecuenciaInicio { get => _FrecuenciaInicio; set => _FrecuenciaInicio = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        [Browsable(false)]
        public bool AlarmaWindows { get => _AlarmaWindows; set => _AlarmaWindows = value; }
        [Browsable(false)]
        public bool NotificacionWindows { get => _NotificacionWindows; set => _NotificacionWindows = value; }
        //[Browsable(false)]
        public bool QuitarAlConcluir { get => _QuitarAlConcluir; set => _QuitarAlConcluir = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
        [Browsable(false)]
        public bool Estado { get => _Estado; set => _Estado = value; }

        public override string ToString()
        {
            return $"{Descripcion}";
        }
    }
}
