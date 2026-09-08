using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Estadística de patrimonio neto.
    /// Gráfico lineal o columnas.
    /// Muestra el patrimoño neto en una línea de tiempo.
    /// </summary>
    public class Estadistica_PatrimonioNeto : Estadistica
    {
        List<Transaccion> _Transacciones;

        public Estadistica_PatrimonioNeto(List<Transaccion> transacciones)
        {
            Transacciones = transacciones;
        }

        public List<Transaccion> Transacciones { get => _Transacciones; set => _Transacciones = value; }
    }
}
