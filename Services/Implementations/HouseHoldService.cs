using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class HouseHoldService : IHouseHoldExpenseService
    {
  

        private readonly ILogger _logger;

        private readonly IHouseHoldExpenseRepository _repo;

        public HouseHoldService(IHouseHoldExpenseRepository _repo, ILogger logger)
        {
            this._repo = _repo;
            _logger = logger;
        }

        public async Task<bool> AddHouseHoldExpense(HouseHoldExpenseDTO HouseHoldExpenseDTO)
        {
            _logger.LogInformation("Adding HouseHoldExpense: Service Invoked");
            return await _repo.AddHouseHoldExpense(HouseHoldExpenseDTO);
        }

        public async Task<IEnumerable<HouseHoldExpenses>> GetAllHouseHoldExpenseOfTheDay(int userId, DateTime date)
        {
            _logger.LogInformation("Getting All HouseHoldExpense: Service Invoked");
            return await _repo.GetAllHouseHoldExpenseOfTheDay(userId, date);
        }

        public async Task<double> GetTotalHouseHoldExpense(int userId, DateTime date)
        {
            _logger.LogInformation("Getting Total HouseHoldExpense: Service Invoked");
            return await _repo.GetTotalHouseHoldExpense(userId, date);
        }

        public async Task<bool> RemoveHouseHoldExpense(int HouseHoldExpenseId)
        {
            _logger.LogInformation("Removing HouseHoldExpense: Service Invoked");
            return await _repo.RemoveHouseHoldExpense(HouseHoldExpenseId);
        }

        public async Task<bool> UpdateHouseHoldExpenseById(int HouseHoldExpenseId, HouseHoldExpenses HouseHoldExpense)
        {
            _logger.LogInformation("Updating HouseHoldExpense: Service Invoked");
            return await _repo.UpdateHouseHoldExpenseById(HouseHoldExpenseId, HouseHoldExpense);
        }
    }
}
