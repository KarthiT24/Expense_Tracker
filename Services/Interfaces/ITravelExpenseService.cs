using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;

namespace Expense_Tracker.Services.Interfaces
{
    public interface ITravelExpenseService
    {
        Task<bool> AddTravelExpense(TravelExpenseDTO travelExpenseDTO);
        Task<bool> RemoveTravelExpense(int travelExpenseId);
        Task<double> GetTotalTravelExpense(int userId, DateTime date);
        Task<IEnumerable<TravelExpense>> GetAllTravelExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateTravelExpenseById(int TravelExpenseId, TravelExpenseDTO travelExpenseDTO);
    }
}
