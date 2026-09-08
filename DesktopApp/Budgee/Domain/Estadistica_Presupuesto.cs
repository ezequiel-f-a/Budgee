using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Estadística de holgura de presupuesto.
    /// Gráfico de columnas.
    /// Muestra, para determinado presupuesto seleccionado, su valor presupuestado en contraposición a su valor actual.
    /// </summary>
    public class Estadistica_Presupuesto : Estadistica
    {
        List<Presupuesto> _Presupuestos;
        public Estadistica_Presupuesto(List<Presupuesto> presupuestos)
        {
            Presupuestos = presupuestos;
        }

        public List<Presupuesto> Presupuestos { get => _Presupuestos; set => _Presupuestos = value; }
    }
}
