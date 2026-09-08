using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Estadística de distribución.
    /// Gráfico de torta.
    /// Lo que se distribuye pueden ser ingresos, egresos o ganancia neta.
    /// Ya sea distribución en cuentas, categorías o etiquetas.
    /// </summary>
    public class Estadistica_Distribucion : Estadistica
    {
        List<Transaccion> _Transacciones;

        public Estadistica_Distribucion(List<Transaccion> transacciones)
        {
            Transacciones = transacciones;
        }

        public List<Transaccion> Transacciones { get => _Transacciones; set => _Transacciones = value; }
    }
}
