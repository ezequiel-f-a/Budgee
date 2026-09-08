using System;

namespace SL.Domain.Security
{
    /// <summary>
    /// Abstracción para perfiles y permisos de la aplicación.
    /// </summary>
    [Serializable]
    public class Privilegio
    {
        string _Nombre;

        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public Privilegio(string nombre)
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
