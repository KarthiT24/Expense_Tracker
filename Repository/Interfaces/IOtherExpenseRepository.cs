using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IOtherExpenseRepository
    {
        Task<bool> AddOtherExpense(OtherExpenseDTO otherExpenseDTO);
        Task<bool> RemoveOtherExpense(int otherExpenseId);
        Task<double> GetTotalOtherExpense(int userId, DateTime date);
        Task<IEnumerable<OtherExpense>> GetAllOtherExpenseOfTheDay(int userId, DateTime date);
        Task<bool> UpdateOtherExpenseById(int otherExpenseId, OtherExpense otherExpense);
    }
}
