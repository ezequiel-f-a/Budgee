using Enums;
using SL.Domain;
using SL.Domain.Security;
using System;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Las variables nos permitirán proporcionar un valor dinámico y muy parametrizable
    /// (e.g.: balance de cuenta X, ingreso global, ganancia neta por categoría X y etiqueta Y del último mes, 
    /// balance de cuenta X en fecha Y).
    /// </summary>
    [Serializable]
    public class Variable
    {
        Guid _ID_Variable;
        string _Nombre_Variable;
        Tipo_Variable _Tipo_Variable;
        Transaccion _Transaccion;
        Planificacion _Planificacion;
        PlantillaTransaccion _PlantillaTransaccion;
        Cuenta _Cuenta;
        Caracteristica _Categoria;
        Caracteristica _Etiqueta;
        Lapso _Lapso;
        DateTime? _Fecha;
        Usuario _Usuario;

        public Variable(Guid iD_Variable, string nombre_Variable, Tipo_Variable tipo_Variable, Transaccion transaccion, Planificacion planificacion, PlantillaTransaccion plantillaTransaccion, Cuenta cuenta, Caracteristica categoria, Caracteristica etiqueta, Lapso lapso, DateTime? fecha, Usuario usuario)
        {
            ID_Variable = iD_Variable;
            Nombre_Variable = nombre_Variable;
            Tipo_Variable = tipo_Variable;
            Transaccion = transaccion;
            Planificacion = planificacion;
            PlantillaTransaccion = plantillaTransaccion;
            Cuenta = cuenta;
            Categoria = categoria;
            Etiqueta = etiqueta;
            Lapso = lapso;
            Fecha = fecha;
            Usuario = usuario;
        }
        [Browsable(false)]
        public Guid ID_Variable { get => _ID_Variable; set => _ID_Variable = value; }
        [DisplayName("Nombre")]
        public string Nombre_Variable { get => _Nombre_Variable; set => _Nombre_Variable = value; }
        [DisplayName("Tipo de Variable")]
        public Tipo_Variable Tipo_Variable { get => _Tipo_Variable; set => _Tipo_Variable = value; }
        [Browsable(false)]
        public Transaccion Transaccion { get => _Transaccion; set => _Transaccion = value; }
        [Browsable(false)]
        public Planificacion Planificacion { get => _Planificacion; set => _Planificacion = value; }
        [Browsable(false)]
        public PlantillaTransaccion PlantillaTransaccion { get => _PlantillaTransaccion; set => _PlantillaTransaccion = value; }
        [Browsable(false)]
        public Cuenta Cuenta { get => _Cuenta; set => _Cuenta = value; }
        [Browsable(false)]
        public Caracteristica Categoria { get => _Categoria; set => _Categoria = value; }
        [Browsable(false)]
        public Caracteristica Etiqueta { get => _Etiqueta; set => _Etiqueta = value; }
        public Lapso Lapso { get => _Lapso; set => _Lapso = value; }
        public DateTime? Fecha { get => _Fecha; set => _Fecha = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }

        public override string ToString()
        {
            return Nombre_Variable;
        }
    }
}
