using System.Collections.Generic;
using ExpenseTracker.Data.DTOs;

namespace ExpenseTracker.Core.Contract
{
    public interface IStaticDataProvider
    {
        Dictionary<string, IEnumerable<StaticDataItem>> GetStaticData();
    }
}