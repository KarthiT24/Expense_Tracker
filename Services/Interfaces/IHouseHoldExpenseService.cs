using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;

namespace Expense_Tracker.Services.Interfaces
{
    public interface IHouseHoldExpenseService
    {
        Task<bool> AddHouseHoldExpense(HouseHoldExpenseDTO HouseHoldExpenseDTO);
        Task<bool> RemoveHouseHoldExpense(int HouseHoldExpenseId);
        Task<double> GetTotalHouseHoldExpense(int userId, DateTime date);
        Task<IEnumerable<HouseHoldExpenses>> GetAllHouseHoldExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateHouseHoldExpenseById(int HouseHoldExpenseId, HouseHoldExpenses HouseHoldExpense);
    }
}
