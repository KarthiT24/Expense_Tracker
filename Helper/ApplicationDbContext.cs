using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Helper
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<DateReference> DateReferences { get; set; }

        public DbSet<FoodExpense> FoodExpenses { get; set; }

        public DbSet<OtherExpense> OtherExpenses { get; set; }

        public DbSet<HouseHoldExpenses> HouseholdExpenses { get; set; }

        public DbSet<TravelExpense> TravelExpenses { get; set; }

    }
}
