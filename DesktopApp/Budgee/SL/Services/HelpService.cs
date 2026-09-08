using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services
{
    /// <summary>
    /// Brinda servicios relacionados al Help Provider de la aplicación
    /// </summary>
    public static class HelpService
    {
        public static string GetHelpFilePath()
        {
            switch (AppData.CurrentLanguage)
            {
                case Enums.Idioma.Español: return AppData.Config.HelpPath_Español;
                case Enums.Idioma.English: return AppData.Config.HelpPath_English;
                default: return null;
            }
        }
    }
}
