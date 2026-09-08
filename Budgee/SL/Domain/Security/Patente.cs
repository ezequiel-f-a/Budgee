using System;

namespace SL.Domain.Security
{
    /// <summary>
    /// Permisos de la aplicación.
    /// Con estos se acceden a ciertas características de la aplicación dependiendo de cual se tenga.
    /// </summary>
    [Serializable]
    public class Patente : Privilegio
    {
        Guid _ID_Patente;
        string _Definicion;

        public Patente(Guid iD_Patente, string nombre, string definicion) : base(nombre)
        {
            ID_Patente = iD_Patente;
            Definicion = definicion;
        }
        [System.ComponentModel.Browsable(false)]
        public Guid ID_Patente { get => _ID_Patente; set => _ID_Patente = value; }
        public new string Nombre { get => base.Nombre; set => base.Nombre = value; } //Orden de gridView
        public string Definicion { get => _Definicion; set => _Definicion = value; }
    }
}
