using BudgetPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BudgetPlannerAPI.Data
{
    public class BudgetPlannerContext : DbContext
    {
        public BudgetPlannerContext(DbContextOptions<BudgetPlannerContext> options) : base(options) {

            Users = Set<User>();
            Incomes = Set<Income>();
            Expenses = Set<Expense>();

        }

        public DbSet<User> Users { get; private set; }
        public DbSet<Income> Incomes { get; private set; }
        public DbSet<Expense> Expenses { get; private set; }
    }
}
