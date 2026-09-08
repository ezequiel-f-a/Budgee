using Enums;
using SL.Domain.Security;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SL.Services
{
    /// <summary>
    /// Se encarga de alojar variables globales tales como el usuario actual que se encuentra en sesión, el idioma actual,
    /// y cualquier variable que provenga del App.Config.
    /// </summary>
    public static class AppData
    {
        public static Usuario CurrentUser { get; set; }
        public static Idioma CurrentLanguage { get { return _CurrentLanguage; } set {_CurrentLanguage = value; } }
        private static Idioma _CurrentLanguage = Config.DefaultLanguage;
        public static class Config
        {
            public static Dictionary<Idioma, string> Languages = new Dictionary<Idioma, string>()
            {
                { Idioma.Español, ConfigurationManager.AppSettings[Idioma.Español.ToString()] },
                { Idioma.English, ConfigurationManager.AppSettings[Idioma.English.ToString()] }
            };
            public static Idioma DefaultLanguage { get { return (Idioma)ConfigurationManager.AppSettings[nameof(DefaultLanguage)].ToEnum(new Idioma()); } }
            public static Divisa DefaultCurrency { get { return (Divisa)ConfigurationManager.AppSettings[nameof(DefaultCurrency)].ToEnum(new Divisa()); } }
            public static string Repositories { get { return ConfigurationManager.AppSettings[nameof(Repositories)]; } }
            public static string RepositoriesSL { get { return ConfigurationManager.AppSettings[nameof(RepositoriesSL)]; } }
            public static string UIComponent { get { return ConfigurationManager.AppSettings[nameof(UIComponent)]; } }
            public static string BLLComponent { get { return ConfigurationManager.AppSettings[nameof(BLLComponent)]; } }
            public static string DALComponent { get { return ConfigurationManager.AppSettings[nameof(DALComponent)]; } }
            public static string SLComponent { get { return ConfigurationManager.AppSettings[nameof(SLComponent)]; } }
            public static string BackupPath { get { return ConfigurationManager.AppSettings[nameof(BackupPath)]; } }
            public static string HelpPath_Español { get { return ConfigurationManager.AppSettings[nameof(HelpPath_Español)]; } }
            public static string HelpPath_English { get { return ConfigurationManager.AppSettings[nameof(HelpPath_English)]; } }
            public static int IncomingTasksRange_Minutes { get { return Convert.ToInt32(ConfigurationManager.AppSettings[nameof(IncomingTasksRange_Minutes)]); } }
            public static Frecuencia FrecuenciaTrackSesion_Magnitud { get { return (Frecuencia)ConfigurationManager.AppSettings[nameof(FrecuenciaTrackSesion_Magnitud)].ToEnum(new Frecuencia()); } }
            public static int FrecuenciaTrackSesion_Valor { get { return Convert.ToInt32(ConfigurationManager.AppSettings[nameof(FrecuenciaTrackSesion_Valor)]); } }
            public static int TaskCollectorDelay_ms { get { return Convert.ToInt32(ConfigurationManager.AppSettings[nameof(TaskCollectorDelay_ms)]); } }
            public static int NotificationCollectorDelay_ms { get { return Convert.ToInt32(ConfigurationManager.AppSettings[nameof(NotificationCollectorDelay_ms)]); } }
            public static class ConnectionStrings
            {
                public static string BudgeeConnection { get { return ConfigurationManager.AppSettings["MainConString"]; } }
            }
        }
    }
}
