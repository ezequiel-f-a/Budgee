using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budgee_Setup_Custom
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0 || args[0] == "-i")
                CustomInstaller.CustomInstall();

            else if (args[0] == "-u")
                CustomInstaller.CustomUninstall();
        }
    }
}
