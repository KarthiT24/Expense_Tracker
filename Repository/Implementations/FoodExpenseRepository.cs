using Expense_Tracker.Helper;
using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Expense_Tracker.Repository.Implementations
{
    public class FoodExpenseRepository : IFoodExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFoodExpense(FoodExpenseDTO foodExpenseDTO)
        {
            try
            {
                var foodExpense = new FoodExpense
                {
                    UserId = foodExpenseDTO.UserId,
                    date = foodExpenseDTO.date,
                    month = foodExpenseDTO.month,
                    year = foodExpenseDTO.year,
                    amount = foodExpenseDTO.amount
                };
                await _context.FoodExpenses.AddAsync(foodExpense);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        public async Task<IEnumerable<FoodExpense>> GetAllFoodExpenseOfTheDay(int userId, DateTime date)
        {
            var FoodExpenses = new List<FoodExpense>();
            try
            {
                FoodExpenses = await _context.FoodExpenses.Where(x => x.UserId == userId && x.date == date).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return FoodExpenses;
        }

        public async Task<double> GetTotalFoodExpense(int userId, DateTime date)
        {
            try
            {
                var totalFoodExpense = await _context.FoodExpenses.Where(x => x.UserId == userId && x.date == date).SumAsync(x => x.amount);
                return totalFoodExpense;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public async Task<bool> RemoveFoodExpense(int foodExpenseId)
        {
            try
            {
                var FoodExpense = await _context.FoodExpenses.FindAsync(foodExpenseId);
                if (FoodExpense != null)
                {
                     _context.FoodExpenses.Remove(FoodExpense);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e) { 
                Console.WriteLine(e);
            }
            return false;
        }

        public async Task<bool> UpdateFoodExpenseById(int FoodExpenseId, double amount)
        {
            try
            {
                var FoodExpense = await _context.FoodExpenses.FindAsync(FoodExpenseId);
                if (FoodExpense != null) {
                    FoodExpense.amount = amount;
                    _context.FoodExpenses.Update(FoodExpense);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}
