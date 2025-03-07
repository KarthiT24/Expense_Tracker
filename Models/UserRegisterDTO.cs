using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }

        [EmailAddress, Required]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
