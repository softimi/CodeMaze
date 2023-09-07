using Contracts;
//using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        //private static ILogger logger = LoggerManager.logger;

        public LoggerManager()
        {

        }

        
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);

        public void LogWarn(string message) => logger.Warn(message);
        

        /*
        public void LogDebug(string message) => logger.LogDebug(message);
        public void LogError(string message) => logger.LogError(message);
        public void LogInfo(string message) => logger.LogInformation(message);
        public void LogWarn(string message) => logger.LogWarning(message);
        */
        
    }
}
