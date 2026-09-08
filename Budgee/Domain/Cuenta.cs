using Enums;
using SL.Domain.Security;
using System;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Elemento básico de contabilidad propio de cada usuario.
    /// Un usuario puede poseer varias cuentas.
    /// </summary>
    [Serializable]
    public class Cuenta
    {
        Guid _ID_Cuenta;
        string _Nombre;
        Divisa _Divisa;
        Usuario _Usuario;
        bool _AdmiteFondosNegativos;
        bool _Habilitada;
        bool _Estado;

        public Cuenta(Guid iD_Cuenta, string nombre, Divisa divisa, Usuario usuario, bool admiteFondosNegativos, bool habilitada, bool estado)
        {
            ID_Cuenta = iD_Cuenta;
            Nombre = nombre;
            Divisa = divisa;
            Usuario = usuario;
            AdmiteFondosNegativos = admiteFondosNegativos;
            Habilitada = habilitada;
            Estado = estado;
        }
        [Browsable(false)]
        public Guid ID_Cuenta { get => _ID_Cuenta; set => _ID_Cuenta = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public Divisa Divisa { get => _Divisa; set => _Divisa = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        [DisplayName("Admite Fondos Negativos")]
        public bool AdmiteFondosNegativos { get => _AdmiteFondosNegativos; set => _AdmiteFondosNegativos = value; }
        public bool Habilitada { get => _Habilitada; set => _Habilitada = value; }
        [Browsable(false)]
        public bool Estado { get => _Estado; set => _Estado = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
