using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class FoodExpense
    {
        [Key]
        public int foodExpenseId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime date { get; set; } = DateTime.Now;
        public int month { get; set; } = DateTime.Now.Month;
        public int year { get; set; } = DateTime.Now.Year;

        [Required]
        public double amount { get; set; }
    }
}
