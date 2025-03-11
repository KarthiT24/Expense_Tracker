using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models.DTOs
{
    public class FoodExpenseDTO
    {
        public int UserId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime date { get; set; } = DateTime.Now.Date;
        public int month { get; set; } = DateTime.Now.Month;
        public int year { get; set; } = DateTime.Now.Year;
        public double amount { get; set; }
    }
}