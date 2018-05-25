﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_homework_EF_Core
{
    public interface ILoggerService
    {
        void RunWithExceptionLogging(Action actionToRun, bool isSilent = false);
        T RunWithExceptionLogging<T>(Func<T> functionToRun, bool isSilent = false);
        void Info(string message);
        void Error(Exception ex);
    }
}
