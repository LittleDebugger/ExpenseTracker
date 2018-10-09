using System;

namespace ExpenseTracker.Common.Log.Contract
{
    public interface ILogger
    {
        void Info(string s);

        void Debug(string s);

        void Warn(string s);

        void Error(string s, Exception ex = null);
    }
}
