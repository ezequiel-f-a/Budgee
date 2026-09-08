using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgee_Setup_Custom
{
    internal static class CustomInstaller
    {
        internal static void CustomInstall()
        {
            try
            {
                //string CurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string script_uninstall = Properties.Resources.uninstall; //File.ReadAllText(Path.Combine(CurrentPath, "script_uninstall.sql"));
                SqlHelper.ExecuteNonQuery(script_uninstall, System.Data.CommandType.Text);

                string script_part1 = Properties.Resources.install_part1; //File.ReadAllText(Path.Combine(CurrentPath, "script_install_part1.sql"));
                SqlHelper.ExecuteNonQuery(script_part1, System.Data.CommandType.Text);

                string script_part2 = Properties.Resources.install_part2; //File.ReadAllText(Path.Combine(CurrentPath, "script_install_part2.sql"));
                SqlHelper.ExecuteNonQuery(script_part2, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                try
                {
                    using (var sw = new StreamWriter(@"C:\Logs\error_log.txt", true))
                        sw.WriteLine($"[{DateTime.Now}] {ex.Message}");
                }
                catch { }
            }
        }
        internal static void CustomUninstall()
        {
            try
            {
                //string CurrentPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string script_uninstall = Properties.Resources.uninstall; //File.ReadAllText(Path.Combine(CurrentPath, "script_uninstall.sql"));
                SqlHelper.ExecuteNonQuery(script_uninstall, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                try
                {
                    using (var sw = new StreamWriter(@"C:\Logs\error_log.txt", true))
                        sw.WriteLine($"[{DateTime.Now}] {ex.Message}");
                }
                catch { }
            }
        }
    }
}
