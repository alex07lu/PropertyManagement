using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Repository;
using PropertyManagement.Models;
namespace PropertyManagement.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult CreateProperty()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProperty(Property property)
        {
            MyDbContext _context = new MyDbContext();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(property);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return View(property);
        }
    }
}
