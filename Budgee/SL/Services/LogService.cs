using log4net;
using System.Diagnostics;

namespace SL.Services
{
    /// <summary>
    /// Brinda un servicio de loggeo, parametrizable a través del App.Config.
    /// </summary>
    public static class LogService
    {
        public static void Log(string content, LogSeverity severity)
        {
            StackFrame frame = new StackFrame(1);
            Log(content, severity, frame);
        }
        public static void Log(string content, LogSeverity severity, StackFrame frame)
        {
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            string callerType = type.ToString();
            string callerMethod = method.Name;

            string stackTrace = $"[{callerType}]{{{callerMethod}}}({"User"}:{AppData.CurrentUser?.ID_Usuario.ToString() ?? "N/A"})";

            string processed_content = $"{stackTrace}:: {content}";

            ILog logger;
            if (severity == LogSeverity.Info || severity == LogSeverity.Debug)
                logger = log4net.LogManager.GetLogger("InfoLogger");
            else
                logger = log4net.LogManager.GetLogger("ErrorLogger");

            switch (severity)
            {
                case LogSeverity.Info:
                    logger.Info(processed_content);
                    break;
                case LogSeverity.Warn:
                    logger.Warn(processed_content);
                    break;
                case LogSeverity.Error:
                    logger.Error(processed_content);
                    break;
                case LogSeverity.Fatal:
                    logger.Fatal(processed_content);
                    break;
                case LogSeverity.Debug:
                    logger.Debug(processed_content);
                    break;
            }
        }
        public enum LogSeverity
        {
            Info,
            Warn,
            Error,
            Fatal,
            Debug
        }
    }
}
