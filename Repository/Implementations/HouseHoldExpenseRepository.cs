using Expense_Tracker.Helper;
using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository.Implementations
{
    public class HouseHoldExpenseRepository : IHouseHoldExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        public HouseHoldExpenseRepository(ApplicationDbContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddHouseHoldExpense(HouseHoldExpenseDTO HouseHoldExpenseDTO)
        {
            var result = false;
            try
            {
                _logger.LogInformation("Adding HouseHoldExpense: Repository Invoked");
                var HouseHoldExpense = new HouseHoldExpenses
                {
                    UserId = HouseHoldExpenseDTO.UserId,
                    date = HouseHoldExpenseDTO.date,
                    month = HouseHoldExpenseDTO.month,
                    year = HouseHoldExpenseDTO.year,
                    amount = HouseHoldExpenseDTO.amount
                };
                await _context.HouseholdExpenses.AddAsync(HouseHoldExpense);
                await _context.SaveChangesAsync();
                return !result;

            }
            catch (Exception ex) { 
                _logger.LogError("Error in Adding HouseHoldExpense: Repository Invoked"+ex.Message);
                Console.WriteLine(ex);
            }
            return result;
        }

        public async Task<IEnumerable<HouseHoldExpenses>> GetAllHouseHoldExpenseOfTheDay(int userId, DateTime date)
        {
            var HouseholdExpensesList = new List<HouseHoldExpenses>();
            try
            {
                _logger.LogInformation("Getting All HouseHoldExpense: Repository Invoked");
                HouseholdExpensesList = await _context.HouseholdExpenses.Where(x => x.UserId == userId && x.date == date).ToListAsync();
                return HouseholdExpensesList;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error Fetching HouseHoldExpense: Repository Invoked" + ex.Message);
            }
            return null;
        }

        public async Task<double> GetTotalHouseHoldExpense(int userId, DateTime date)
        {
            try
            {
                _logger.LogInformation("Getting Total HouseHoldExpense: Repository Invoked");
                double totalAmount = await _context.HouseholdExpenses.Where(x => x.UserId == userId && x.date == date).SumAsync(x => x.amount);
                return totalAmount;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Fetching HouseHoldExpense: Repository Invoked" + ex.Message);
            }
            return 0;
        }

        public async Task<bool> RemoveHouseHoldExpense(int HouseHoldExpenseId)
        {
            try
            {
                _logger.LogInformation("Removing HouseHoldExpense: Repository Invoked");
                var HouseHoldExpense = await _context.HouseholdExpenses.FindAsync(HouseHoldExpenseId);
                if (HouseHoldExpense != null) { 
                    _context.HouseholdExpenses.Remove(HouseHoldExpense);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e) {
                _logger.LogInformation("Error Removing HouseHoldExpense: Repository Invoked" + e.Message);
            }
            return false;
        }

        public async Task<bool> UpdateHouseHoldExpenseById(int HouseHoldExpenseId, HouseHoldExpenses HouseHoldExpense)
        {
            try
            {
                _logger.LogInformation("Updating HouseHoldExpense: Repository Invoked");
                var HouseholdExpense = await _context.HouseholdExpenses.FindAsync(HouseHoldExpenseId);
                if (HouseholdExpense != null)
                {
                    HouseholdExpense.amount = HouseHoldExpense.amount;
                    HouseholdExpense.spentFor = HouseHoldExpense.spentFor;
                    _context.HouseholdExpenses.Update(HouseholdExpense);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error Updating HouseHoldExpense: Repository Invoked" + e.Message);
            }
            return false;
        }

       
    }
}
