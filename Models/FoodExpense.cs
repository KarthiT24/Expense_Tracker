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

        [Required,ForeignKey("DateReference")]
        public DateTime date { get; set; } = DateTime.Now.Date;

        [Required]
        public int month { get; set; } = DateTime.Now.Month;

        [Required]
        public int year { get; set; } = DateTime.Now.Year;

        [Required]
        public double amount { get; set; }
    }
}
