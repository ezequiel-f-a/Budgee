using SL.Domain;
using SL.Services.Extensions;
using System;

namespace SL.Services
{
    /// <summary>
    /// Permite la gestión y manejo de excepciones, loggeando a su vez información de las mismas.
    /// </summary>
    public static class ExceptionService
    {
        private static string DALComponent = AppData.Config.DALComponent;
        private static string BLLComponent = AppData.Config.BLLComponent;
        private static string UIComponent = AppData.Config.UIComponent;
        private static string SLComponent = AppData.Config.SLComponent;

        /// <summary>
        /// Handle para clases instanciables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        public static void Handle(Exception ex, object sender, int StackFrame = 4)
        {
            string assemblyName = sender.GetType().Assembly.GetName().Name;
            Handle(assemblyName, ex, StackFrame);
        }
        /// <summary>
        /// Handle para clases estáticas
        /// </summary>
        /// <param name="senderType"></param>
        /// <param name="ex"></param>
        public static void Handle(Exception ex, Type senderType, int StackFrame = 4)
        {
            string assemblyName = senderType.Assembly.GetName().Name;
            Handle(assemblyName, ex, StackFrame);
        }
        private static void Handle(string assemblyName, Exception ex, int StackFrame)
        {
            if (assemblyName == UIComponent)
                UIHandle(ex, StackFrame);
            else if (assemblyName == BLLComponent)
                BLLHandle(ex, StackFrame);
            else if (assemblyName == DALComponent)
                DALHandle(ex, StackFrame);
            else if (assemblyName == SLComponent)
                SLHandle(ex, StackFrame);
            else
                throw new Exception("No se reconoce el ensamblado".Translate());
        }
        private static void UIHandle(Exception ex, int StackFrame)
        {
            WritePolicy(ex, StackFrame); //Logeo en caso de que por algún motivo, se requiera handlear desde la UI
        }
        private static void BLLHandle(Exception ex, int StackFrame)
        {
            if (ex.InnerException != null && ex is DAL_Exception)
            {
                throw new BLL_Exception("Error relacionado con la base de datos".Translate(), ex); //Envuelvo y relanzo a UI, ya que el registro lo realizo la excepcion en DAL
            }
            else if (ex.InnerException != null && ex is BLL_Exception)
            {
                throw ex; //Relanzo a UI, ya que el loggeo lo realizo la otra excepcion de BLL
            }
            else
            {
                WritePolicy(ex, StackFrame); //Si no proviene de DAL, es que no se logeo, por lo que debe logearse

                if (ex is BLL_Exception)
                    throw ex; //Como la excepcion esta controlada, solo relanza
                else
                    throw new BLL_Exception("Ha ocurrido un error inesperado".Translate(), ex); //Advierte que la excepcion no esta controlada
            }
        }
        private static void DALHandle(Exception ex, int StackFrame)
        {
            if (ex.InnerException != null && ex is DAL_Exception)
            {
                throw ex;//Relanzo a BLL, ya que el loggeo lo realizo la otra excepcion de DAL
            }
            else
            {
                WritePolicy(ex, StackFrame); //Siempre registro errores de DAL, ya que no hay un ensamblado inferior que registre antes

                if (ex is DAL_Exception) //Si esta controlada, solo relanzo a la BLL
                    throw ex;
                else
                    throw new DAL_Exception("Error inesperado relacionado con la base de datos".Translate(), ex); //Si no esta controlada, debe ser envuelta y relanzada
            }
        }
        private static void SLHandle(Exception ex, int StackFrame)
        {
            var frame = new System.Diagnostics.StackFrame(StackFrame - 1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            string callerType = type.ToString();

            if (callerType.StartsWith(SLComponent + ".Services"))
                BLLHandle(ex, StackFrame + 1);
            else if (callerType.StartsWith(SLComponent + ".BLL"))
                BLLHandle(ex, StackFrame + 1);
            else if (callerType.StartsWith(SLComponent + ".DAL"))
                DALHandle(ex, StackFrame + 1);
            else
            {
                WritePolicy(ex, StackFrame - 1);
                throw new Exception("Ha ocurrido un error inesperado".Translate(), ex);
            }
        }
        private static void WritePolicy(Exception ex, int StackFrame)
        {
            //LogService.Log(ex.Message, LogService.LogSeverity.Error, new System.Diagnostics.StackFrame(StackFrame));
            LogService.Log(ex.GetFullMessage(false).Replace("\n", " ").Replace("\r", " "), LogService.LogSeverity.Error, new System.Diagnostics.StackFrame(StackFrame));
        }
    }
}
