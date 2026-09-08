using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Las transacciones son el centro de la contabilidad de la aplicación.
    /// Estas pueden estar en estado "pendiente" o "concretado". Las pendientes no tienen influencia sobre
    /// el balance, ingresos, chequeo de presupuestos, etc.
    /// </summary>
    [Serializable]
    public class Transaccion : GenericTransaccion
    {
        Guid _ID_Transaccion;
        DateTime? _Fecha;
        Cuenta _Cuenta;
        bool _Concretada;

        public Transaccion(Guid iD_Transaccion, DateTime? fecha, Cuenta cuenta, bool concretada, string descripcion, Caracteristica categoria, List<Caracteristica> etiquetas, Expresion expresion, Tipo_Operacion? tipo_Operacion, bool estado) : base(descripcion, categoria, etiquetas, expresion, tipo_Operacion, estado)
        {
            ID_Transaccion = iD_Transaccion;
            Fecha = fecha;
            Cuenta = cuenta;
            Concretada = concretada;
        }
        [Browsable(false)]
        public Guid ID_Transaccion { get => _ID_Transaccion; set => _ID_Transaccion = value; }
        public DateTime? Fecha { get => _Fecha; set => _Fecha = value; }
        public new string Descripcion { get => base.Descripcion; set => base.Descripcion = value; }
        public Cuenta Cuenta { get => _Cuenta; set => _Cuenta = value; }
        [Browsable(false)]
        public bool Concretada { get => _Concretada; set => _Concretada = value; }
    }
}
