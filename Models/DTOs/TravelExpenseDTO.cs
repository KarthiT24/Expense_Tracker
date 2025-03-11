
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models.DTOs
{
    public class TravelExpenseDTO
    {
        public int UserId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime date { get; set; } = DateTime.Now.Date;
        public int month { get; set; } = DateTime.Now.Month;
        public int year { get; set; } = DateTime.Now.Year;
        public string travelTo { get; set; }
        public double amount { get; set; }
    }
}