using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IHouseHoldExpenseRepository
    {
        Task<bool> AddHouseHoldExpense(HouseHoldExpenseDTO HouseHoldExpenseDTO);
        Task<bool> RemoveHouseHoldExpense(int HouseHoldExpenseId);
        Task<int> GetTotalHouseHoldExpense(int userId, DateTime date);
        Task<IEnumerable<HouseHoldExpenses>> GetAllHouseHoldExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateHouseHoldExpenseById(int HouseHoldExpenseId, HouseHoldExpenseDTO HouseHoldExpenseDTO);
    }
}
