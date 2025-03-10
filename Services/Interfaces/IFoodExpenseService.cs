using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;

namespace Expense_Tracker.Services.Interfaces
{
    public interface IFoodExpenseService
    {
        Task<bool> AddFoodExpense(FoodExpenseDTO foodExpenseDTO);
        Task<bool> RemoveFoodExpense(int foodExpenseId);
        Task<double> GetTotalFoodExpense(int userId, DateTime date);
        Task<IEnumerable<FoodExpense>> GetAllFoodExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateFoodExpenseById(int FoodExpenseId, double amount);
    }
}
