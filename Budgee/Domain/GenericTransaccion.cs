using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Abstracción de transacción.
    /// </summary>
    [Serializable]
    public abstract class GenericTransaccion
    {
        string _Descripcion;
        Caracteristica _Categoria;
        List<Caracteristica> _Etiquetas;
        Expresion _Expresion;
        Tipo_Operacion? _TipoOperacion;
        bool _Estado;

        protected GenericTransaccion(string descripcion, Caracteristica categoria, List<Caracteristica> etiquetas, Expresion expresion, Tipo_Operacion? tipoOperacion, bool estado)
        {
            Descripcion = descripcion;
            Categoria = categoria;
            Etiquetas = etiquetas;
            MontoExpresion = expresion;
            TipoOperacion = tipoOperacion;
            Estado = estado;
        }
        [DisplayName("Descripción")]
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        [DisplayName("Categoría")]
        public Caracteristica Categoria { get => _Categoria; set => _Categoria = value; }
        [Browsable(false)]
        public List<Caracteristica> Etiquetas { get => _Etiquetas; set => _Etiquetas = value; }
        [DisplayName("Tipo de Operación")]
        public Tipo_Operacion? TipoOperacion { get => _TipoOperacion; set => _TipoOperacion = value; }
        [DisplayName("Monto")]
        public Expresion MontoExpresion { get => _Expresion; set => _Expresion = value; }
        [Browsable(false)]
        public bool Estado { get => _Estado; set => _Estado = value; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
