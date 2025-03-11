using Expense_Tracker.Helper;
using Expense_Tracker.Migrations;
using Expense_Tracker.Models;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository.Implementations
{
    public class DateRepository : IDateRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IFoodExpenseService _foodExpenseService;
        private readonly ITravelExpenseService _travelExpenseService;
        private readonly IOtherExpenseService  _otherExpenseService;
        private readonly IHouseHoldExpenseService _householdServie;

        public DateRepository(ApplicationDbContext context, ILogger logger, IFoodExpenseService foodExpenseService, ITravelExpenseService travelExpenseService, IOtherExpenseService otherExpenseService, IHouseHoldExpenseService householdServie)
        {
            _context = context;
            _logger = logger;
            _foodExpenseService = foodExpenseService;
            _travelExpenseService = travelExpenseService;
            _otherExpenseService = otherExpenseService;
            _householdServie = householdServie;
        }

        public async Task<bool> CreateTodayReferenceForUserAsync(int userId)
        {
            try
            {
                _logger.LogInformation("Creating Today Reference for User: Repository Call");
                var duplicateReference = await _context.DateReferences.FirstOrDefaultAsync(x => x.UserId == userId && x.Date == DateTime.Now.Date);
                if (duplicateReference != null)
                    return false;
                var dateReference = new DateReference
                {
                    UserId = userId,
                    Date = DateTime.Now.Date,
                    TotalAmount = 0,
                    foodAmount = 0,
                    travelAmount = 0,
                    otherAmount = 0,
                    householdAmount = 0
                };
                await _context.DateReferences.AddAsync(dateReference);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Creating Today Reference for User: Repository Call "+e.Message );
            }
            return false;
        }

        public async Task<IEnumerable<DateReference>> GetDateAllReferencesAsync(int userId)
        {
            var dateReferencesList = new List<DateReference>();
            try
            {
                dateReferencesList = await _context.DateReferences.Where(u=>u.UserId == userId).ToListAsync();
                return dateReferencesList;
            }
            catch(Exception e)
            {
                _logger.LogError("Error in Getting Date All References: Repository Call " + e.Message);
            }
            return null ;
        }

        public async Task<bool> UpdateAllDateReferences()
        {
            try
            {
                var DateReferences = from dateReference in _context.DateReferences join food in _context.FoodExpenses
                                      on dateReference.Date equals food.date
                                     select dateReference.Date;

            }
            catch(Exception ex)
            {
                _logger.LogError("Error in Updating All Date References: Repository Call " + ex.Message);
            }
            return false;
        }
    }
}
