using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Repository.Contract;
using ExpenseTracker.Repository.Entities;

namespace ExpenseTracker.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ExpenseTrackerContext _context;

        public ExpenseRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public void Add(Expense expense)
        {
            _context.Add(expense);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteExpense = new Expense
            {
                Id = id
            };

            _context.Expenses.Remove(deleteExpense);
            _context.SaveChanges();
        }

        public Expense Get(int id)
        {
            return _context.Expenses.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses;
        }

        public void Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            _context.SaveChanges();
        }
    }
}
