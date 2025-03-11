using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class OtherExpenseService : IOtherExpenseService
    {
        private readonly IOtherExpenseRepository _repo;

        private readonly ILogger _logger;

        public OtherExpenseService(IOtherExpenseRepository repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> AddOtherExpense(OtherExpenseDTO otherExpenseDTO)
        {
            _logger.LogInformation("Adding other expense: Service Invoked");
            return await _repo.AddOtherExpense(otherExpenseDTO);

        }

        public async Task<IEnumerable<OtherExpense>> GetAllOtherExpenseOfTheDay(int userId, DateTime date)
        {
            _logger.LogInformation("Getting all other expenses of the day: Service Invoked");
            return await _repo.GetAllOtherExpenseOfTheDay(userId, date);
        }

        public async Task<double> GetTotalOtherExpense(int userId, DateTime date)
        {
            _logger.LogInformation("Fetching total other expenses: Service Invoked");
            return await _repo.GetTotalOtherExpense(userId, date);
        }

        public async Task<bool> RemoveOtherExpense(int otherExpenseId)
        {
            _logger.LogInformation("Removing other expense: Service Invoked");
            return await _repo.RemoveOtherExpense(otherExpenseId);
        }

        public async Task<bool> UpdateOtherExpenseById(int otherExpenseId, OtherExpense otherExpense)
        {
            _logger.LogInformation("Updating other expense: Service Invoked");
            return await _repo.UpdateOtherExpenseById(otherExpenseId, otherExpense);
        }
    }
}
