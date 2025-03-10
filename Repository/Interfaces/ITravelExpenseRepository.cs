using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface ITravelExpenseRepository
    {
        Task<bool> AddTravelExpense(TravelExpenseDTO travelExpenseDTO);
        Task<bool> RemoveTravelExpense(int travelExpenseId);
        Task<double> GetTotalTravelExpense(int userId, DateTime date);
        Task<IEnumerable<TravelExpense>> GetAllTravelExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateTravelExpenseById(int TravelExpenseId, TravelExpenseDTO travelExpenseDTO);
    }
}
