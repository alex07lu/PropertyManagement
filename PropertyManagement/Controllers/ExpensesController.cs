using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace PropertyManagement.Controllers
{
//    [Authorize]
    public class ExpensesController : Controller
    {
        Repository.MyDbContext _context = new Repository.MyDbContext();
        [HttpPost]
        public IActionResult CreateExpense(Expense expense)
        {
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
                    ViewBag.Info = expense;
                   // string jsonString = JsonSerializer.Serialize(expense);
                   // Expense tempExpense = JsonSerializer.Deserialize<Expense>(jsonString)!;
                // ViewBag.result = tempExpense;
                    ViewBag.Property = expense.GetPropertyNameByPropertyId(expense.PropertyId);

            }
            catch (Exception ex)
                {
                    Console.Write($"An error occurred: {ex.Message}");
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

/*                        Repository.MyDbContext _context = new Repository.MyDbContext();
            var rentersList = _context.Renters.ToList();
            return View(rentersList);*/
            return View(new Expense());
        }


        public async Task<IActionResult> ListExpenses(string search)
        {
            if (_context.Expense == null)
            {
                return Problem("Expense is null.");
            }

            var expenseList = from e in _context.Expense
                         select e;

            if (!String.IsNullOrEmpty(search))
            {
                expenseList = expenseList.Where(e => e.Name!.ToUpper().Contains(search.ToUpper()));
            }
            return View(expenseList);
        }
    }
}
