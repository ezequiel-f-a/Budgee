using Enums;
using SL.Domain;
using SL.Domain.Security;
using System;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Los presupuestos permiten controlar el flujo de transacciones, dando la posibilidad de informar al usuario
    /// cuando se presente una condición específica (e.g.: balance de cuenta X superior a Y, ingreso global superior
    /// a Y, ganancia neta por categoría X y etiqueta Y del último mes inferior o igual a balance de cuenta Z en fecha W).
    /// El chequeo del flujo de transacciones puede ser constante, al finalizar el presupuesto o al iniciar.
    /// </summary>
    [Serializable]
    public class Presupuesto
    {
        Guid _ID_Presupuesto;
        string _Descripcion;
        Variable _VariableSupervisada;
        Expresion _CondicionExpresion;
        Operador_Relacional _OperadorRelacional;
        FrecuenciaInicio _LapsoPresupuesto;
        Cuando_Chequear _CuandoChequear;
        bool _AlarmaWindows;
        bool _NotificacionWindows;
        bool _Habilitado;
        bool _Estado;
        Usuario _Usuario;

        public Presupuesto(Guid iD_Presupuesto, string descripcion, Variable variableSupervisada, Expresion condicionExpresion, Operador_Relacional operadorRelacional, FrecuenciaInicio lapsoPresupuesto, Cuando_Chequear cuandoChequear, bool alarmaWindows, bool notificacionWindows, bool habilitado, bool estado, Usuario usuario)
        {
            ID_Presupuesto = iD_Presupuesto;
            Descripcion = descripcion;
            VariableSupervisada = variableSupervisada;
            CondicionExpresion = condicionExpresion;
            OperadorRelacional = operadorRelacional;
            LapsoPresupuesto = lapsoPresupuesto;
            CuandoChequear = cuandoChequear;
            Usuario = usuario;
            AlarmaWindows = alarmaWindows;
            NotificacionWindows = notificacionWindows;
            Habilitado = habilitado;
            Estado = estado;
        }
        [Browsable(false)]
        public Guid ID_Presupuesto { get => _ID_Presupuesto; set => _ID_Presupuesto = value; }
        [DisplayName("Descripción")]
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        [DisplayName("Variable Supervisada")]
        public Variable VariableSupervisada { get => _VariableSupervisada; set => _VariableSupervisada = value; }
        [DisplayName("...")]
        public Operador_Relacional OperadorRelacional { get => _OperadorRelacional; set => _OperadorRelacional = value; }
        [DisplayName("Condición")]
        public Expresion CondicionExpresion { get => _CondicionExpresion; set => _CondicionExpresion = value; }
        [DisplayName("Lapso de Presupuesto")]
        public FrecuenciaInicio LapsoPresupuesto { get => _LapsoPresupuesto; set => _LapsoPresupuesto = value; }
        [DisplayName("Cuando Chequear")]
        public Cuando_Chequear CuandoChequear { get => _CuandoChequear; set => _CuandoChequear = value; }
        [Browsable(false)]
        public bool AlarmaWindows { get => _AlarmaWindows; set => _AlarmaWindows = value; }
        [Browsable(false)]
        public bool NotificacionWindows { get => _NotificacionWindows; set => _NotificacionWindows = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
        [Browsable(false)]
        public bool Estado { get => _Estado; set => _Estado = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
