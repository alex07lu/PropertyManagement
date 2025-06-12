using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Models
{
    public enum ExpenseType
    {
        Other,
        Maitenance,
        Utilities,
        Taxes,
        Travel,
        Insurance
    }

    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExpenseType ExpenseType { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
        public double Cost { get; set; }
        public int? PropertyId { get; set; }

        public string GetPropertyNameByPropertyId(int? propertyId)
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            var query = _context.Property.Select(p => new
            {
                Id = p.Id,
                AddressLine = p.AddressLine,
            }).Distinct();
            return query.FirstOrDefault(p => p.Id == propertyId).AddressLine;
        }

    }
}
