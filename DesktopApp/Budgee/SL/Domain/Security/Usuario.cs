using System;
using System.Collections.Generic;
using System.Linq;

namespace SL.Domain.Security
{
    /// <summary>
    /// Usuario de la aplicación.
    /// </summary>
    [Serializable]
    public class Usuario
    {
        Guid _ID_Usuario;
        string _Username;
        string _Password;
        ConfiguracionUsuario _Configuracion;
        List<Privilegio> _Privilegios;
        bool _Estado;

        public Usuario(Guid iD_Usuario, string username, string password, List<Privilegio> privilegios, ConfiguracionUsuario configuracion, bool estado)
        {
            ID_Usuario = iD_Usuario;
            Username = username;
            Password = password;
            Privilegios = privilegios;
            Configuracion = configuracion;
            Estado = estado;
        }
        public Usuario(Guid iD_Usuario, string username, string password, ConfiguracionUsuario configuracion, bool estado)
        {
            ID_Usuario = iD_Usuario;
            Username = username;
            Password = password;
            Privilegios = null;
            Configuracion = configuracion;
            Estado = estado;
        }

        public Guid ID_Usuario { get => _ID_Usuario; set => _ID_Usuario = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
        public List<Privilegio> Privilegios { get => _Privilegios; set => _Privilegios = value; }
        public ConfiguracionUsuario Configuracion { get => _Configuracion; set => _Configuracion = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }

        public List<Familia> Perfiles
        {
            get
            {
                var listadoAux = new List<Familia>();
                GetPerfiles(Privilegios, listadoAux);
                return listadoAux;
            }
        }
        public List<Patente> Permisos
        {
            get
            {
                var listadoAux = new List<Patente>();
                GetPermisos(Privilegios, listadoAux);
                return listadoAux;
            }
        }
        public List<Patente> PermisosSinPerfil
        {
            get
            {
                return Privilegios.Where(x => x is Patente).Cast<Patente>().ToList();
            }
        }

        private void GetPermisos(List<Privilegio> privilegios, List<Patente> resultados)
        {
            foreach (var privilegio in privilegios)
            {
                if (privilegio is Patente)
                {
                    resultados.Add(privilegio as Patente);
                }
                if (privilegio is Familia)
                {
                    GetPermisos((privilegio as Familia).Privilegios, resultados);
                }
            }
        }
        private void GetPerfiles(List<Privilegio> privilegios, List<Familia> resultados)
        {
            foreach (var privilegio in privilegios)
            {
                if (privilegio is Familia)
                {
                    resultados.Add(privilegio as Familia);
                    GetPerfiles((privilegio as Familia).Privilegios, resultados);
                }
            }
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
