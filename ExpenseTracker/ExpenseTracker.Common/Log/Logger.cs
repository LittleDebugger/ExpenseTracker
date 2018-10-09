using ExpenseTracker.Common.Log.Contract;
using System;

namespace ExpenseTracker.Common.Log
{
    public class Logger : ILogger
    {
        NLog.Logger _logger;

        public Logger(NLog.Logger logger)
        {
            _logger = logger;
        }

        public void Info(string s)
        {
            _logger.Info(s);
        }

        public void Debug(string s)
        {
            _logger.Debug(s);
        }

        public void Warn(string s)
        {
            _logger.Warn(s);
        }

        public void Error(string s, Exception ex = null)
        {
            if (ex == null)
            {
                _logger.Error(s);
            }
            else
            {
                _logger.Error(ex, s);
            }
        }
    }
}
