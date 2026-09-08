using Enums;
using SL.Domain.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Bloque de datos que almacena un valor constante o expresión algebraica válida para el cálculo de un valor.
    /// </summary>
    [Serializable]
    public class Expresion
    {
        Guid _ID_Expresion;
        string _Definicion;
        List<Variable> _Variables;
        Tipo_Expresion _Tipo_Expresion;
        Usuario _Usuario;

        public Expresion(Guid iD_Expresion, string definicion, List<Variable> variables, Tipo_Expresion tipo_Expresion, Usuario usuario)
        {
            ID_Expresion = iD_Expresion;
            Definicion = definicion;
            Variables = variables;
            Tipo_Expresion = tipo_Expresion;
            Usuario = usuario;
        }
        [Browsable(false)]
        public Guid ID_Expresion { get => _ID_Expresion; set => _ID_Expresion = value; }
        [DisplayName("Definición")]
        public string Definicion { get => _Definicion; set => _Definicion = value; }
        [Browsable(false)]
        public List<Variable> Variables { get => _Variables; set => _Variables = value; }
        [DisplayName("Tipo de Expresión")]
        public Tipo_Expresion Tipo_Expresion { get => _Tipo_Expresion; set => _Tipo_Expresion = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }

        public override string ToString()
        {
            return Definicion;
        }
    }
}
