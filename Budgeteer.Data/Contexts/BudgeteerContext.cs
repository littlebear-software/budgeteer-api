
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Budgeteer.Data.Models;

namespace Budgeteer.Data.Contexts
{
    public class BudgeteerContext : DbContext
    {
        public BudgeteerContext() { }
        public BudgeteerContext(DbContextOptions<BudgeteerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dining", Color = "#9DBC98" },
                new Category { Id = 2, Name = "Entertainment", Color = "#BB6464" },
                new Category { Id = 3, Name = "Automotive", Color = "#7BD3EA" },
                new Category { Id = 4, Name = "Groceries", Color = "#FDFFAE" },
                new Category { Id = 5, Name = "Utilities", Color = "#A9F4F2" },
                new Category { Id = 6, Name = "Debts", Color = "#F4A9EA" }
            );
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}