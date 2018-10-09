using ExpenseTracker.Common.Log;
using ExpenseTracker.Common.Log.Contract;

namespace ExpenseTracker.Common
{
    public class LogFactory : ILogFactory
    {
        private NLog.LogFactory _nlogFactory; 

        public LogFactory()
        {
            _nlogFactory = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config");
        }

        public ILogger GetLogger<T>()
        {
            return new Logger(_nlogFactory.GetLogger(typeof(T).FullName));
        }
    }
}
