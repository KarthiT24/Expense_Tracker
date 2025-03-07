using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string UserEmail { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }    
    }
}
