using Chama.Core.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Services
{
    public class LoggerManagerService : ILoggerManagerService
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManagerService()
        {
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogTrace(string message)
        {
            logger.Trace(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
