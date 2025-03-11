using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Expense_Tracker.Models.DTOs
{
    public class HouseHoldExpenseDTO
    {
        public int UserId { get; set; }

        [Column(TypeName= "Date")]
        public DateTime date { get; set; } = DateTime.Now.Date;
        public int month { get; set; } = DateTime.Now.Month;
        public int year { get; set; } = DateTime.Now.Year;
        public string spentFor { get; set; }
        public double amount { get; set; }
    }
}
