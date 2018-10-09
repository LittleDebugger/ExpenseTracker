using ExpenseTracker.Common;
using ExpenseTracker.Common.Log.Contract;
using ExpenseTracker.Core.Contract;
using ExpenseTracker.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Core
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private ILogger logger;

        private Type[] _enumTypes;

        public StaticDataProvider(ILogFactory logFactory)
        {
            logger = logFactory.GetLogger<StaticDataProvider>();

            _enumTypes = new Type[]
            {
                typeof(Data.Enums.Currency),
                typeof(Data.Enums.TransactionType)
            };

            string enumsText = string.Join(", ", _enumTypes.Select(e => e.ToString()));
            logger.Info($"Providing StaticData for enums - [ {enumsText} ]");
        }

        public Dictionary<string, IEnumerable<StaticDataItem>> GetStaticData()
        {
            var staticData = new Dictionary<string, IEnumerable<StaticDataItem>>();

            foreach (var enumType in _enumTypes)
            {
                staticData[enumType.Name] = GetEnumValues(enumType);
            }

            return staticData;
        }

        private IEnumerable<StaticDataItem> GetEnumValues(Type enumType)
        {
            Array values = Enum.GetValues(enumType);

            foreach(object value in values)
            {
                yield return new StaticDataItem
                {
                    Id = (int)value,
                    Value = value.ToString()
                };
            }
        }
    }
}
