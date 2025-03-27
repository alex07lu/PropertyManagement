using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PropertyManagement.Controllers
{
    public class ExpensesController : Controller
    {
        [HttpPost]
        public IActionResult CreateExpense(Expense expense)
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            ViewBag.EnumDropdown = Enum.GetValues(typeof(ExpenseType))
            .Cast<ExpenseType>()
            .Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            });
            ViewBag.PropertyDropdown = _context.Property // Fetch from DB
            .Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.AddressLine // Change to relevant property name
            }).ToList();
                String expenseString = String.Empty;
                try
                {
                    _context.Add(expense);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            return View(expense);
        }
        public IActionResult CreateExpense()
        {
            ViewBag.EnumDropdown = Enum.GetValues(typeof(ExpenseType))
            .Cast<ExpenseType>()
            .Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            });
            using (var context = new Repository.MyDbContext())
            {
                ViewBag.PropertyDropdown = context.Property // Fetch from DB
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.AddressLine // Change to relevant property name
                }).ToList();
            }
            return View(new Expense());
        }
    }
}
