using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class FoodExpenseService : IFoodExpenseService

    {
        public Task<bool> AddFoodExpense(FoodExpenseDTO foodExpenseDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FoodExpense>> GetAllFoodExpenseOfTheDay(int userId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetTotalFoodExpense(int userId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFoodExpense(int foodExpenseId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFoodExpenseById(int FoodExpenseId, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
