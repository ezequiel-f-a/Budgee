using Enums;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Permite la planificación de una transacción, ya sea para una fecha y hora dadas o bien para
    /// una recurrencia especificable con el bloque de datos FrecuenciaInicio.
    /// Puede ligarse a un recordatorio para que este se dispare cuando llegue el momento de generar la transacción.
    /// </summary>
    [Serializable]
    public class Planificacion : GenericTransaccion
    {
        Guid _ID_Planificacion;
        string _Descripcion_Transaccion;
        Cuenta _Cuenta;
        FrecuenciaInicio _FrecuenciaInicio;
        Recordatorio _RecordatorioLigado;
        bool _QuitarAlConcluir;
        bool _Habilitado;

        public Planificacion(Guid iD_Planificacion, string descripcion, string descripcion_Transaccion, Caracteristica categoria, List<Caracteristica> etiquetas, Expresion expresion, Tipo_Operacion? tipo_Operacion, Cuenta cuenta, FrecuenciaInicio frecuenciaInicio, Recordatorio recordatorioLigado, bool quitarAlConcluir, bool habilitado, bool estado) : base(descripcion, categoria, etiquetas, expresion, tipo_Operacion, estado)
        {
            ID_Planificacion = iD_Planificacion;
            Descripcion_Transaccion = descripcion_Transaccion;
            Cuenta = cuenta;
            FrecuenciaInicio = frecuenciaInicio;
            RecordatorioLigado = recordatorioLigado;
            QuitarAlConcluir = quitarAlConcluir;
            Habilitado = habilitado;
        }
        [Browsable(false)]
        public Guid ID_Planificacion { get => _ID_Planificacion; set => _ID_Planificacion = value; }
        public new string Descripcion { get => base.Descripcion; set => base.Descripcion = value; }
        [Browsable(false)]
        [DisplayName("Descripción de Transacción")]
        public string Descripcion_Transaccion { get => _Descripcion_Transaccion; set => _Descripcion_Transaccion = value; }
        [DisplayName("Frecuencia e Inicio")]
        public FrecuenciaInicio FrecuenciaInicio { get => _FrecuenciaInicio; set => _FrecuenciaInicio = value; }
        [Browsable(false)]
        public Recordatorio RecordatorioLigado { get => _RecordatorioLigado; set => _RecordatorioLigado = value; }
        public Cuenta Cuenta { get => _Cuenta; set => _Cuenta = value; }
        public new Caracteristica Categoria { get => base.Categoria; set => base.Categoria = value; }
        [Browsable(false)]
        public bool QuitarAlConcluir { get => _QuitarAlConcluir; set => _QuitarAlConcluir = value; }
        public new Tipo_Operacion? TipoOperacion { get => base.TipoOperacion; set => base.TipoOperacion = value; }
        public new Expresion MontoExpresion { get => base.MontoExpresion; set => base.MontoExpresion = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
    }
}
