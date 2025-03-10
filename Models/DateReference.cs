using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class DateReference
    {
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Key]
        public int DateId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public double TotalAmount { get; set; } = 0;

        

        [ForeignKey("FoodExpense")]
        public int FoodExpenseId { get; set; }
        public double foodAmount { get; set; } = 0;

        [ForeignKey("OtherExpense")]
        public int OtherExpenseId { get; set; }
        public double otherAmount { get; set; } = 0;

        [ForeignKey("HouseHoldExpenses")]
        public int houseHoldExpenseId { get; set; }
        public double householdAmount { get; set; } = 0;

        [ForeignKey("TravelExpense")]
        public int travelExpenseId { get; set; }

        public double travelAmount { get; set; } = 0;
    }
}
