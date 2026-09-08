using Enums;
using SL.Domain.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Como su nombre lo indica, sirve de plantilla para la generación de transacciones o planificaciones.
    /// Simplemente se utiliza para rellenar los campos deseados rápidamente.
    /// </summary>
    [Serializable]
    public class PlantillaTransaccion : GenericTransaccion
    {
        Guid _ID_Plantilla_Transaccion;
        string _Descripcion_Transaccion;
        Usuario _Usuario;

        public PlantillaTransaccion(Guid iD_Plantilla_Transaccion, string descripcion, string descripcion_Transaccion, Caracteristica categoria, List<Caracteristica> etiquetas, Expresion expresion, Tipo_Operacion? tipo_Operacion, Usuario usuario, bool estado) : base(descripcion, categoria, etiquetas, expresion, tipo_Operacion, estado)
        {
            ID_PlantillaTransaccion = iD_Plantilla_Transaccion;
            Descripcion_Transaccion = descripcion_Transaccion;
            Usuario = usuario;
        }
        [Browsable(false)]
        public Guid ID_PlantillaTransaccion { get => _ID_Plantilla_Transaccion; set => _ID_Plantilla_Transaccion = value; }
        public new string Descripcion { get => base.Descripcion; set => base.Descripcion = value; }
        [Browsable(false)]
        [DisplayName("Descripción de Transacción")]
        public string Descripcion_Transaccion { get => _Descripcion_Transaccion; set => _Descripcion_Transaccion = value; }
        [Browsable(false)]
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
    }
}
