using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class FoodExpenseService : IFoodExpenseService
    {
        private readonly IFoodExpenseRepository _foodExpenseRepository;

        private readonly ILogger _logger;
        public FoodExpenseService(IFoodExpenseRepository foodExpenseRepository,ILogger logger)
        {
            _foodExpenseRepository = foodExpenseRepository;
            _logger = logger;
        }   
        public async Task<bool> AddFoodExpense(FoodExpenseDTO foodExpenseDTO)
        {
            _logger.LogInformation("Adding Food Expense: Service Call");
            return await _foodExpenseRepository.AddFoodExpense(foodExpenseDTO);
        }

        public async Task<IEnumerable<FoodExpense>> GetAllFoodExpenseOfTheDay(int userId, DateTime date)
        {
            try
            {
                _logger.LogInformation("Getting All Food Expense of the Day: Service Call");
                var result = await _foodExpenseRepository.GetAllFoodExpenseOfTheDay(userId, date);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Getting All Food Expense of the Day: Service Call");
                Console.WriteLine(e);
            }
            return null;
        }

        public async Task<double> GetTotalFoodExpense(int userId, DateTime date)
        {
            try
            {
                _logger.LogInformation("Getting Total Food Expense: Service Call");
                var totalFoodExpense = await _foodExpenseRepository.GetTotalFoodExpense(userId, date);
                return totalFoodExpense;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Getting Total Food Expense: Service Call");
                Console.WriteLine(e);
            }
            return 0;
        }

        public async Task<bool> RemoveFoodExpense(int foodExpenseId)
        {
            _logger.LogInformation("Removing Food Expense: Service Call");
            return await _foodExpenseRepository.RemoveFoodExpense(foodExpenseId);
        }

        public async Task<bool> UpdateFoodExpenseById(int FoodExpenseId, double amount)
        {
            _logger.LogInformation("Updating Food Expense: Service Call");
            return await _foodExpenseRepository.UpdateFoodExpenseById(FoodExpenseId, amount);
        }
    }
}
