using Enums;
using SL.Domain.Security;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Domain
{
    /// <summary>
    /// Propiedad asignable a transacciones.
    /// Puede tratarse de categorías (sólo una por transacción) o etiquetas (varias por transacción).
    /// </summary>
    [Serializable]
    public class Caracteristica
    {
        Guid _ID_Caracteristica;
        string _Nombre;
        Tipo_Caracteristica _Tipo_Caracteristica;
        Color? _Color;
        Usuario _Usuario;
        bool _Estado;

        public Caracteristica(Guid iD_Caracteristica, string nombre, Tipo_Caracteristica tipo_Caracteristica, Color? color, Usuario usuario, bool estado)
        {
            ID_Caracteristica = iD_Caracteristica;
            Nombre = nombre;
            Tipo_Caracteristica = tipo_Caracteristica;
            Color = color;
            Usuario = usuario;
            Estado = estado;
        }
        [Browsable(false)]
        public Guid ID_Caracteristica { get => _ID_Caracteristica; set => _ID_Caracteristica = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        [Browsable(false)]
        public Tipo_Caracteristica Tipo_Caracteristica { get => _Tipo_Caracteristica; set => _Tipo_Caracteristica = value; }
        public Color? Color { get => _Color; set => _Color = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        [Browsable(false)]
        public bool Estado { get => _Estado; set => _Estado = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
