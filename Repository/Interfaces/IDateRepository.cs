using Expense_Tracker.Models;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IDateRepository
    {
        Task<IEnumerable<DateReference>> GetDateAllReferencesAsync(int userId); // for rendering cards of overview date template

        Task<bool> CreateTodayReferenceForUserAsync(int userId); //for maintaining daily reference for each user

        Task<bool> UpdateAllDateReferences();
    }
}
