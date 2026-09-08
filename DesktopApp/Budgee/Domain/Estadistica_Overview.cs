using SL.Domain.Security;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Estadística de overview.
    /// No posee gráfico.
    /// Muestra todas las cuentas junto a su balance actual y potencial (el potencial considera transacciones pendientes).
    /// </summary>
    public class Estadistica_Overview : Estadistica
    {
        Usuario _Usuario;
        List<Cuenta> _Cuentas;

        public Estadistica_Overview(Usuario usuario, List<Cuenta> cuentas)
        {
            Usuario = usuario;
            Cuentas = cuentas;
        }

        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        public List<Cuenta> Cuentas { get => _Cuentas; set => _Cuentas = value; }
    }
}
