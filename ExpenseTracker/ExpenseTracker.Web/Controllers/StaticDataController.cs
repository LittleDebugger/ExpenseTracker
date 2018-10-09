using System.Collections.Generic;
using ExpenseTracker.Core.Contract;
using ExpenseTracker.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticDataController : ControllerBase
    {
        private readonly IStaticDataProvider _staticDataProvider;

        public StaticDataController(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<StaticDataItem>>> Get()
        {
            return _staticDataProvider.GetStaticData();
        }
    }
}
