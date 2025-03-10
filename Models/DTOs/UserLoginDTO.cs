using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models.DTOs
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
