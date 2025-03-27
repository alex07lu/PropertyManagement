using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Models
{
    public enum ExpenseType
    {
        Maitenance,
        Utilities,
        Taxes,
        Travel
    }
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExpenseType ExpenseType { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
