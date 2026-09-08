using System;
using System.Collections.Generic;

namespace SL.Domain.Security
{
    /// <summary>
    /// Perfiles/Roles de la aplicación.
    /// Pueden poseer permisos (por lo que aquel que posea el perfil poseera los permisos), o anidar otros
    /// perfiles (cuyos permisos también serán propios de el perfil que lo anida).
    /// </summary>
    [Serializable]
    public class Familia : Privilegio
    {
        Guid _ID_Familia;
        List<Privilegio> _Privilegios;

        public Familia(string nombre, Guid iD_Familia, List<Privilegio> privilegios) : base(nombre)
        {
            ID_Familia = iD_Familia;
            Privilegios = privilegios;
        }
        [System.ComponentModel.Browsable(false)]
        public Guid ID_Familia { get => _ID_Familia; set => _ID_Familia = value; }
        public List<Privilegio> Privilegios { get => _Privilegios; set => _Privilegios = value; }
    }
}
