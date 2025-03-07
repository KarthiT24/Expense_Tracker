using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class OtherExpense
    {
        [Key]
        public int expenseId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string expenseName { get; set; }

        public DateTime date { get; set; } = DateTime.Now;
        public int month { get; set; } = DateTime.Now.Month;
        public int year { get; set; } = DateTime.Now.Year;

        [Required]
        public double amount { get; set; }

    }
}
