using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// Servicio que se encarga de inicializar algunos procesos que requieren ejecución al iniciar sesión.
    /// </summary>
    public static class StartupService
    {
        public static void Startup()
        {
            Thread t1 = new Thread(() => PresupuestoService.Current.Check_PresupuestosExcedidos_ChequeoConstante());
            Thread t2 = new Thread(() => SchedulerService.Current.Startup());
            
            t1.IsBackground = true;
            t2.IsBackground = true;

            t1.Start();
            t2.Start();
            //SchedulerService.Current.Startup(); //PARA DEBUG
        }
    }
}
