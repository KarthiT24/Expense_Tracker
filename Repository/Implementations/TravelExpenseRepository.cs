using Expense_Tracker.Helper;
using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository.Implementations
{
    public class TravelExpenseRepository : ITravelExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        public TravelExpenseRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddTravelExpense(TravelExpenseDTO travelExpenseDTO)
        {
            try
            {
                _logger.LogInformation("Adding TravelExpense: Repository Invoked");
                var travelExpense = new TravelExpense
                {
                    UserId = travelExpenseDTO.UserId,
                    date = travelExpenseDTO.date,
                    month = travelExpenseDTO.month,
                    year = travelExpenseDTO.year,
                    amount = travelExpenseDTO.amount
                };
                await _context.TravelExpenses.AddAsync(travelExpense);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)  {
                _logger.LogError("Error in Adding TravelExpense: Repository Invoked" + e.Message);
            }
            return false;
        }

        public async Task<IEnumerable<TravelExpense>> GetAllTravelExpenseOfTheDay(int userId, DateTime date)
        {
            var TravelExpensesList = new List<TravelExpense>();
            try
            {
                _logger.LogInformation("Getting All TravelExpense: Repository Invoked");
                TravelExpensesList = await _context.TravelExpenses.Where(x => x.UserId == userId && x.date == date).ToListAsync();
                return TravelExpensesList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Fetching TravelExpenses: Repository Invoked" + ex.Message);
            }
            return null;
        }

        public async Task<double> GetTotalTravelExpense(int userId, DateTime date)
        {
            try
            {
                _logger.LogInformation("Getting Total TravelExpense: Repository Invoked");
                double totalAmount = await _context.TravelExpenses.Where(x => x.UserId == userId && x.date == date).SumAsync(x => x.amount);
                return totalAmount;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Fetching TravelExpenses: Repository Invoked" + ex.Message);
            }
            return 0;
        }

        public async Task<bool> RemoveTravelExpense(int travelExpenseId)
        {
            try
            {
                _logger.LogInformation("Removing HouseHoldExpense: Repository Invoked");
                var TravelExpenses = await _context.TravelExpenses.FindAsync(travelExpenseId);
                if (TravelExpenses != null)
                {
                    _context.TravelExpenses.Remove(TravelExpenses);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error Removing HouseHoldExpense: Repository Invoked" + e.Message);
            }
            return false;
        }

        public async Task<bool> UpdateTravelExpenseById(int TravelExpenseId, TravelExpense travelExpense)
        {
            try
            {
                _logger.LogInformation("Updating TravelExpenses: Repository Invoked");
                var TravelExpenses = await _context.TravelExpenses.FindAsync(TravelExpenseId);
                if (TravelExpenses != null)
                {
                    TravelExpenses.amount = travelExpense.amount;
                    TravelExpenses.travelTo = travelExpense.travelTo;
                    _context.TravelExpenses.Update(TravelExpenses);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error Updating TravelExpenses: Repository Invoked" + e.Message);
            }
            return false;
        }
    }
}
