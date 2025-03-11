using Expense_Tracker.Helper;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Models;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository.Implementations
{
    public class OtherExpenseRepository : IOtherExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        public OtherExpenseRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddOtherExpense(OtherExpenseDTO OtherExpenseDTO)
        {
            try
            {
                _logger.LogInformation("Adding OtherExpense: Repository Invoked");
                var OtherExpense = new OtherExpense
                {
                    UserId = OtherExpenseDTO.UserId,
                    date = OtherExpenseDTO.date,
                    month = OtherExpenseDTO.month,
                    year = OtherExpenseDTO.year,
                    amount = OtherExpenseDTO.amount
                };
                await _context.OtherExpenses.AddAsync(OtherExpense);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Adding OtherExpense: Repository Invoked" + e.Message);
            }
            return false;
        }

        public async Task<IEnumerable<OtherExpense>> GetAllOtherExpenseOfTheDay(int userId, DateTime date)
        {
            var OtherExpensesList = new List<OtherExpense>();
            try
            {
                _logger.LogInformation("Getting All OtherExpense: Repository Invoked");
                OtherExpensesList = await _context.OtherExpenses.Where(x => x.UserId == userId && x.date == date).ToListAsync();
                return OtherExpensesList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Fetching OtherExpenses: Repository Invoked" + ex.Message);
            }
            return null;
        }

        public async Task<double> GetTotalOtherExpense(int userId, DateTime date)
        {
            try
            {
                _logger.LogInformation("Getting Total OtherExpense: Repository Invoked");
                double totalAmount = await _context.OtherExpenses.Where(x => x.UserId == userId && x.date == date).SumAsync(x => x.amount);
                return totalAmount;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Fetching OtherExpenses: Repository Invoked" + ex.Message);
            }
            return 0;
        }

        public async Task<bool> RemoveOtherExpense(int OtherExpenseId)
        {
            try
            {
                _logger.LogInformation("Removing HouseHoldExpense: Repository Invoked");
                var OtherExpenses = await _context.OtherExpenses.FindAsync(OtherExpenseId);
                if (OtherExpenses != null)
                {
                    _context.OtherExpenses.Remove(OtherExpenses);
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

        public async Task<bool> UpdateOtherExpenseById(int OtherExpenseId, OtherExpense OtherExpense)
        {
            try
            {
                _logger.LogInformation("Updating OtherExpenses: Repository Invoked");
                var OtherExpenses = await _context.OtherExpenses.FindAsync(OtherExpenseId);
                if (OtherExpenses != null)
                {
                    OtherExpenses.amount = OtherExpense.amount;
                    OtherExpenses.expenseName = OtherExpense.expenseName;
                    _context.OtherExpenses.Update(OtherExpenses);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error Updating OtherExpenses: Repository Invoked" + e.Message);
            }
            return false;
        }
    }
}
