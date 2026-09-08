using Enums;
using SL.BLL.Contracts;
using SL.DAL.Contracts;
using SL.DAL.Factories;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.BLL.Services
{
    /// <summary>
    /// Servicio del negocio de Usuario.
    /// </summary>
    public class UsuarioService : IGenericBusinessLogic<Domain.Security.Usuario>
    {
        #region Singleton
        private readonly static UsuarioService _instance;
        public static UsuarioService Current { get { return _instance; } }
        static UsuarioService() { _instance = new UsuarioService(); }
        private UsuarioService()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        IGenericRepository<Domain.Security.Usuario> repository = Factory.Current.UsuarioRepository;

        public Usuario GetOne(Guid ID)
        {
            try
            {
                return repository.GetOne(ID);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public IEnumerable<Usuario> GetAll(Func<Usuario, bool> filter)
        {
            try
            {
                return repository.GetAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Add(Usuario obj)
        {
            try
            {
                repository.Add(obj);

                LogService.Log($"Creación de usuario: {obj.ID_Usuario}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Update(Usuario obj)
        {
            try
            {
                repository.Update(obj);

                LogService.Log($"Modificación de usuario: {obj.ID_Usuario}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void AddOrUpdate(Usuario obj)
        {
            try
            {
                repository.AddOrUpdate(obj);

                LogService.Log($"Creación/Modificación de usuario: {obj.ID_Usuario}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Remove(Usuario obj)
        {
            try
            {
                repository.Remove(obj);

                LogService.Log($"Eliminación de usuario: {obj.ID_Usuario}", LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void RemoveAll(Func<Usuario, bool> filter)
        {
            try
            {
                repository.RemoveAll(filter);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }

        public void SetPrivilegios(Usuario obj)
        {
            try
            {
                (repository as dynamic).SetPrivilegios(obj);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Login(Usuario obj)
        {
            try
            {
                AppData.CurrentUser = obj;
                AppData.CurrentLanguage = obj.Configuracion.Idioma ?? AppData.CurrentLanguage;
                SesionTrackService.Current.TrackSesion(obj, Tipo_Track.Inicio_Sesion);

                LogService.Log("Inicio de sesión".Translate(), LogService.LogSeverity.Info);
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public void Logout(Usuario obj)
        {
            try
            {
                SesionTrackService.Current.TrackSesion(obj, Tipo_Track.Cierre_Sesion);

                LogService.Log("Cierre de sesión".Translate(), LogService.LogSeverity.Info);

                AppData.CurrentUser = null;
                AppData.CurrentLanguage = AppData.Config.DefaultLanguage;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
        public bool ValidateUsuario(string username, string password)
        {
            try
            {
                int count = repository.GetAll(x => x.Username == username && x.Password == password).Count();

                if (count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                ex.Handle(this);
                throw;
            }
        }
    }
}
