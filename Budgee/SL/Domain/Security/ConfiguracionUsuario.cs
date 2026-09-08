using Enums;
using SL.Services;
using System;

namespace SL.Domain.Security
{
    /// <summary>
    /// Preferencias del usuario.
    /// </summary>
    [Serializable]
    public class ConfiguracionUsuario
    {
        Guid _ID_ConfiguracionUsuario;
        Idioma? _Idioma;
        Divisa? _DivisaDefault;
        bool _MantenerSesionIniciada;
        bool _AlarmasWindows;
        bool _NotificacionesWindows;
        bool _NotificacionesPresupuestos;
        bool _NotificacionesRecordatorios;
        bool _NotificacionesEstadisticas;
        bool _ExpiranNotificaciones;
        int? _ExpiranNotificacionesValor;
        Frecuencia? _ExpiranNotificacionesMagnitud;
        bool _Respaldar;
        FrecuenciaInicio _RespaldarFrecuencia;
        bool _LimiteRespaldos;
        int? _CantidadMaximaRespaldosValor;

        public ConfiguracionUsuario(Guid iD_ConfiguracionUsuario, Idioma? idioma, Divisa? divisaDefault, bool mantenerSesionIniciada, bool alarmasWindows, bool notificacionesWindows, bool notificacionesPresupuestos, bool notificacionesRecordatorios, bool notificacionesEstadisticas, bool expiranNotificaciones, int? expiranNotificacionesValor, Frecuencia? expiranNotificacionesMagnitud, bool respaldar, FrecuenciaInicio respaldarFrecuencia, bool limiteRespaldos, int? cantidadMaximaRespaldosValor)
        {
            ID_ConfiguracionUsuario = iD_ConfiguracionUsuario;
            Idioma = idioma;
            DivisaDefault = divisaDefault;
            MantenerSesionIniciada = mantenerSesionIniciada;
            AlarmasWindows = alarmasWindows;
            NotificacionesWindows = notificacionesWindows;
            NotificacionesPresupuestos = notificacionesPresupuestos;
            NotificacionesRecordatorios = notificacionesRecordatorios;
            NotificacionesEstadisticas = notificacionesEstadisticas;
            ExpiranNotificaciones = expiranNotificaciones;
            ExpiranNotificacionesValor = expiranNotificacionesValor;
            ExpiranNotificacionesMagnitud = expiranNotificacionesMagnitud;
            Respaldar = respaldar;
            RespaldarFrecuencia = respaldarFrecuencia;
            LimiteRespaldos = limiteRespaldos;
            CantidadMaximaRespaldosValor = cantidadMaximaRespaldosValor;
        }
        public ConfiguracionUsuario(Guid ID_Usuario)
        {
            ID_ConfiguracionUsuario = Guid.NewGuid();
            Idioma = AppData.Config.DefaultLanguage;
            DivisaDefault = AppData.Config.DefaultCurrency;
            MantenerSesionIniciada = false;
            AlarmasWindows = true;
            NotificacionesWindows = true;
            NotificacionesPresupuestos = true;
            NotificacionesRecordatorios = true;
            NotificacionesEstadisticas = true;
            ExpiranNotificaciones = false;
            ExpiranNotificacionesValor = null;
            ExpiranNotificacionesMagnitud = null;
            Respaldar = true;
            RespaldarFrecuencia = new FrecuenciaInicio(Frecuencia.Meses, 1, new DateTime(1, 1, 1), Guid.NewGuid(), ID_Usuario);
            LimiteRespaldos = false;
            CantidadMaximaRespaldosValor = null;
        }

        public Guid ID_ConfiguracionUsuario { get => _ID_ConfiguracionUsuario; set => _ID_ConfiguracionUsuario = value; }
        public Idioma? Idioma { get => _Idioma; set => _Idioma = value; }
        public Divisa? DivisaDefault { get => _DivisaDefault; set => _DivisaDefault = value; }
        public bool MantenerSesionIniciada { get => _MantenerSesionIniciada; set => _MantenerSesionIniciada = value; }
        public bool AlarmasWindows { get => _AlarmasWindows; set => _AlarmasWindows = value; }
        public bool NotificacionesWindows { get => _NotificacionesWindows; set => _NotificacionesWindows = value; }
        public bool NotificacionesPresupuestos { get => _NotificacionesPresupuestos; set => _NotificacionesPresupuestos = value; }
        public bool NotificacionesRecordatorios { get => _NotificacionesRecordatorios; set => _NotificacionesRecordatorios = value; }
        public bool NotificacionesEstadisticas { get => _NotificacionesEstadisticas; set => _NotificacionesEstadisticas = value; }
        public bool ExpiranNotificaciones { get => _ExpiranNotificaciones; set => _ExpiranNotificaciones = value; }
        public int? ExpiranNotificacionesValor { get => _ExpiranNotificacionesValor; set => _ExpiranNotificacionesValor = value; }
        public Frecuencia? ExpiranNotificacionesMagnitud { get => _ExpiranNotificacionesMagnitud; set => _ExpiranNotificacionesMagnitud = value; }
        public bool Respaldar { get => _Respaldar; set => _Respaldar = value; }
        public FrecuenciaInicio RespaldarFrecuencia { get => _RespaldarFrecuencia; set => _RespaldarFrecuencia = value; }
        public bool LimiteRespaldos { get => _LimiteRespaldos; set => _LimiteRespaldos = value; }
        public int? CantidadMaximaRespaldosValor { get => _CantidadMaximaRespaldosValor; set => _CantidadMaximaRespaldosValor = value; }
    }
}
