using Expense_Tracker.Models;

namespace Expense_Tracker.Services.Interfaces
{
    public interface IDateService
    {
        Task<IEnumerable<DateReference>> GetDateAllReferencesAsync(); // for rendering cards of overview date template

        Task<bool> CreateTodayReferenceForUserAsync(int userId); //for maintaining daily reference for each user

    }
}
