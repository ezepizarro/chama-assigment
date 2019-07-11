﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Interfaces
{
    public interface ILoggerManagerService
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogTrace(string message);
    }
}
