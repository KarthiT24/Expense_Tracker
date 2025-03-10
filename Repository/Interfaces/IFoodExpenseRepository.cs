using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IFoodExpenseRepository
    {
        Task<bool> AddFoodExpense(FoodExpenseDTO foodExpenseDTO);
        Task<bool> RemoveFoodExpense(int foodExpenseId);
        Task<double> GetTotalFoodExpense(int userId, DateTime date);
        Task<IEnumerable<FoodExpense>> GetAllFoodExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateFoodExpenseById(int FoodExpenseId, double amount);
    }
}
