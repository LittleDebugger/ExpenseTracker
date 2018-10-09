using ExpenseTracker.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        { }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 1, Description = "CHF" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 2, Description = "USD" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 3, Description = "GBP" });

            modelBuilder.Entity<TransactionType>().HasData(new TransactionType { Id = 1, Description = "Food" });
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType { Id = 2, Description = "Drinks" });
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType { Id = 3, Description = "Other" });
        }
    }
}