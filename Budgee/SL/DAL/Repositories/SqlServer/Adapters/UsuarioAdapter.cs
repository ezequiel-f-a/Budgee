using Enums;
using SL.DAL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.DAL.Repositories.SqlServer.Adapters
{
    /// <summary>
    /// Adapter de Usuario y ConfiguracionUsuario.
    /// </summary>
    internal class UsuarioAdapter : IGenericAdapter<Domain.Security.Usuario, Models.Usuario>
    {
        #region Singleton
        private readonly static UsuarioAdapter _instance;
        public static UsuarioAdapter Current { get { return _instance; } }
        static UsuarioAdapter() { _instance = new UsuarioAdapter(); }
        private UsuarioAdapter()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Domain.Security.Usuario Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
        public Domain.Security.Usuario Adapt(Models.Usuario Entity)
        {
            var privilegios = new List<Domain.Security.Privilegio>();
            Domain.Security.ConfiguracionUsuario config;

            using (var db = new Models.BudgeeSLEntities())
            {
                /*//Primero añado privilegios
                db.Usuario_Familia.AsNoTracking();
                db.Usuario_Patente.AsNoTracking();
                var ID_Familias = db.Usuario_Familia.Where(x => x.ID_Usuario == Entity.ID_Usuario).ToList().Select(x => x.ID_Familia);
                var ID_Patentes = db.Usuario_Patente.Where(x => x.ID_Usuario == Entity.ID_Usuario).ToList().Select(x => x.ID_Patente);

                var Familias = ID_Familias.Select(x => FamiliaRepository.Current.GetOne(x));
                var Patentes = PatenteRepository.Current.GetAll(x => ID_Patentes.Contains(x.ID_Patente)).ToList();

                privilegios.AddRange(Familias);
                privilegios.AddRange(Patentes);*/

                config = AdaptConfiguracionUsuario(
                    db.Configuracion_Usuario.Where(x => x.ID_Configuracion_Usuario == Entity.ID_Configuracion_Usuario).FirstOrDefault());
            }

            return new Domain.Security.Usuario
                (
                    Entity.ID_Usuario,
                    Entity.Nombre_Usuario,
                    Entity.Password_Usuario,
                    privilegios,
                    config,
                    Entity.Estado
                );
        }
        public Models.Usuario Adapt(Domain.Security.Usuario Obj)
        {
            return new Models.Usuario()
            {
                ID_Usuario = Obj.ID_Usuario,
                Nombre_Usuario = Obj.Username,
                Password_Usuario = Obj.Password,
                ID_Configuracion_Usuario = Obj.Configuracion.ID_ConfiguracionUsuario,
                Estado = Obj.Estado
            };
        }
        public Domain.Security.ConfiguracionUsuario AdaptConfiguracionUsuario(Models.Configuracion_Usuario config)
        {
            Domain.FrecuenciaInicio frecRespaldos = null;

            if (config.ID_FrecuenciaInicio_Respaldos != null)
                frecRespaldos = FrecuenciaInicioRepository.Current.GetOne((Guid)config.ID_FrecuenciaInicio_Respaldos);

            return new Domain.Security.ConfiguracionUsuario
                (
                    config.ID_Configuracion_Usuario,
                    config.Idioma.ToEnum(new Idioma()),
                    config.Divisa_Default.ToEnum(new Divisa()),
                    config.Mantener_Sesion_Iniciada,
                    config.Alarmas_Windows,
                    config.Notificaciones_Windows,
                    config.Notificaciones_Presupuestos,
                    config.Notificaciones_Recordatorios,
                    config.Notificaciones_Estadisticas,
                    config.Notificaciones_Expiran,
                    config.Notificaciones_Expiran_Valor,
                    config.Notificaciones_Expiran_Frecuencia.ToEnum(new Frecuencia()),
                    config.Respaldar,
                    frecRespaldos,
                    config.Limite_Respaldos,
                    config.Respaldos_Cantidad_Maxima
                );
        }
        public Models.Configuracion_Usuario AdaptConfiguracionUsuario(Domain.Security.ConfiguracionUsuario config)
        {
            Guid? ID_frecInicio = null;
            if (config.RespaldarFrecuencia != null) ID_frecInicio = config.RespaldarFrecuencia.ID_FrecuenciaInicio;

            return new Models.Configuracion_Usuario()
            {
                ID_Configuracion_Usuario = config.ID_ConfiguracionUsuario,
                Idioma = config.Idioma?.ToString(),
                Divisa_Default = config.DivisaDefault?.ToString(),
                Mantener_Sesion_Iniciada = config.MantenerSesionIniciada,
                Alarmas_Windows = config.AlarmasWindows,
                Notificaciones_Windows = config.NotificacionesWindows,
                Notificaciones_Presupuestos = config.NotificacionesPresupuestos,
                Notificaciones_Recordatorios = config.NotificacionesRecordatorios,
                Notificaciones_Estadisticas = config.NotificacionesEstadisticas,
                Notificaciones_Expiran = config.ExpiranNotificaciones,
                Notificaciones_Expiran_Valor = config.ExpiranNotificacionesValor,
                Notificaciones_Expiran_Frecuencia = config.ExpiranNotificacionesMagnitud?.ToString(),
                Respaldar = config.Respaldar,
                ID_FrecuenciaInicio_Respaldos = ID_frecInicio,
                Limite_Respaldos = config.LimiteRespaldos,
                Respaldos_Cantidad_Maxima = config.CantidadMaximaRespaldosValor
            };
        }
    }
}
