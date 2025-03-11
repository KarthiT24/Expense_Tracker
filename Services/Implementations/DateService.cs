using Expense_Tracker.Models;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class DateService : IDateService
    {
        private readonly IDateRepository _dateRepository;

        private readonly ILogger _logger;
        public Task<bool> CreateTodayReferenceForUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DateReference>> GetDateAllReferencesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
