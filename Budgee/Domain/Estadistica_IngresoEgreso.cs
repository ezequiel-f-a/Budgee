using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Estadística de ingresos y egresos.
    /// Gráfico lineal o columnas.
    /// Muestra los ingresos, egresos, ingresos/egresos o ganancia neta en uná línea de tiempo.
    /// </summary>
    public class Estadistica_IngresoEgreso : Estadistica
    {
        List<Transaccion> _Transacciones;

        public Estadistica_IngresoEgreso(List<Transaccion> transacciones)
        {
            Transacciones = transacciones;
        }

        public List<Transaccion> Transacciones { get => _Transacciones; set => _Transacciones = value; }
    }
}
