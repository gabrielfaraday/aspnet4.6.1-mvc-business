using log4net;
using System.Threading.Tasks;

namespace MvcAppExample.CrossCutting.AsyncServices
{
    public static class LoggingManager
    {
        public static void DebugLog(ILog logger, string message)
        {
            Task.Run(() => logger.Debug(message));
        }

        public static void ErrorLog(ILog logger, string message)
        {
            Task.Run(() => logger.Error(message));
        }

        public static void FatalLog(ILog logger, string message)
        {
            Task.Run(() => logger.Fatal(message));
        }

        public static void InfoLog(ILog logger, string message)
        {
            Task.Run(() => logger.Info(message));
        }

        public static void WarnLog(ILog logger, string message)
        {
            Task.Run(() => logger.Warn(message));
        }
    }
}
