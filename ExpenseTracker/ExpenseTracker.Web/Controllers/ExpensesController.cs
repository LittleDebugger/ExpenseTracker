using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Common;
using ExpenseTracker.Common.Log.Contract;
using ExpenseTracker.Repository.Contract;
using ExpenseTracker.Repository.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        private ILogger logger;

        public ExpensesController(
            IExpenseRepository expenseRepository,
            ILogFactory logFactory)
        {
            logger = logFactory.GetLogger<ExpensesController>();
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> Get()
        {
            return _expenseRepository.GetAll().ToArray();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Expense expense)
        {
            logger.Info($"Creating Expense {expense}");
            _expenseRepository.Add(expense);
            return true;
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<bool> Put([FromBody] Expense expense)
        {
            logger.Info($"Updating Expense {expense}");
            _expenseRepository.Update(expense);
            return true;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.Info($"Deleting Expense with Id: {id}");
            _expenseRepository.Delete(id);
        }
    }
}
