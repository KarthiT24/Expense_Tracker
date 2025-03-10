
namespace Expense_Tracker.Models.DTOs
{
    public class OtherExpenseDTO
    {
        public int UserId { get; set; }
        public string expenseName { get; set; }
        public DateTime date { get; set; } = DateTime.Now.Date;
        public int month { get; set; } = DateTime.Now.Month;
        public int year { get; set; } = DateTime.Now.Year;
        public double amount { get; set; }
    }
}
