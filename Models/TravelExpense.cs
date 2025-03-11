using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class TravelExpense
    {
        [Key]
        public int travelExpenseId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required, ForeignKey("DateReference"), Column(TypeName = "Date")]
        public DateTime date { get; set; } = DateTime.Now.Date;

        [Required]
        public int month { get; set; } = DateTime.Now.Month;

        [Required]
        public int year { get; set; } = DateTime.Now.Year;

        [Required]
        public string travelTo { get; set; }

        [Required]
        public double amount { get; set; }
    }
}
