using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class TravelExpenseService : ITravelExpenseService
    {
        private readonly ITravelExpenseRepository _repo;

        private readonly ILogger _logger;

        public TravelExpenseService(ITravelExpenseRepository repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> AddTravelExpense(TravelExpenseDTO TravelExpenseDTO)
        {
            _logger.LogInformation("Adding travel expense: Service Invoked");
            return await _repo.AddTravelExpense(TravelExpenseDTO);

        }

        public async Task<IEnumerable<TravelExpense>> GetAllTravelExpenseOfTheDay(int userId, DateTime date)
        {
            _logger.LogInformation("Fetching all travel expenses of the day: Service Invoked");
            return await _repo.GetAllTravelExpenseOfTheDay(userId, date);
        }

        public async Task<double> GetTotalTravelExpense(int userId, DateTime date)
        {
            _logger.LogInformation("Fetching total travel expenses: Service Invoked");
            return await _repo.GetTotalTravelExpense(userId, date);
        }

        public async Task<bool> RemoveTravelExpense(int TravelExpenseId)
        {
            _logger.LogInformation("Removing travel expense: Service Invoked");
            return await _repo.RemoveTravelExpense(TravelExpenseId);
        }

        public async Task<bool> UpdateTravelExpenseById(int TravelExpenseId, TravelExpense TravelExpense)
        {
            _logger.LogInformation("Updating travel expense: Service Invoked");
            return await _repo.UpdateTravelExpenseById(TravelExpenseId, TravelExpense);
        }
    }
}
