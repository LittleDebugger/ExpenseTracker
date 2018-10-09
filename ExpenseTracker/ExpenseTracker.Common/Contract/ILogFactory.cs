using ExpenseTracker.Common.Log.Contract;

namespace ExpenseTracker.Common
{
    public interface ILogFactory
    {
        ILogger GetLogger<T>();
    }
}
