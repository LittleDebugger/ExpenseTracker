using ExpenseTracker.Repository.Entities;
using System.Collections.Generic;

namespace ExpenseTracker.Repository.Contract
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAll();

        Expense Get(int id);

        void Add(Expense expense);

        void Delete(int id);

        void Update(Expense expense);
    }
}
