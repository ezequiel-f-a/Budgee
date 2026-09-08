using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services.Extensions
{
    public static class ExceptionExtensions
    {
        public static void Handle(this Exception ex, object sender)
        {
            ExceptionService.Handle(ex, sender, 5);
        }
        public static void Handle(this Exception ex, Type senderType)
        {
            ExceptionService.Handle(ex, senderType, 5);
        }
        public static string GetFullMessage(this Exception ex, bool translate = true)
        {
            if (ex.InnerException == null) return ex.Message;

            List<Exception> exs = new List<Exception>();
            RecursiveGetMessage(ex, exs);

            string FullMessage = null;
            for (int i = 0; i < exs.Count; i++)
            {
                FullMessage += $"[{i + 1}] {((translate) ? exs[i].Message.Translate() : exs[i].Message)}";
                if (i < exs.Count - 1) FullMessage += "\n";
            }
            return FullMessage;
        }
        private static void RecursiveGetMessage(Exception ex, List<Exception> resultado)
        {
            resultado.Add(ex);

            if (ex.InnerException != null)
                RecursiveGetMessage(ex.InnerException, resultado);
        }
    }
}
