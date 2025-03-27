using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace PropertyManagement.Controllers
{
    public class RenterController : Controller
    {
        [HttpPost]
        public IActionResult CreateRenter(Renter renter)
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            ViewBag.PropertyDropdown = _context.Property // Fetch from DB
            .Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.AddressLine // Change to relevant property name
            }).ToList();
            try
            {
                _context.Add(renter);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return View(renter);
        }
        public IActionResult CreateRenter()
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            ViewBag.PropertyDropdown = _context.Property // Fetch from DB
.Select(p => new SelectListItem
{
    Value = p.Id.ToString(),
    Text = p.AddressLine // Change to relevant property name
            }).ToList();
            return View();
        }
        public IActionResult ListRenters()
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            var rentersList = _context.Renters.ToList();
            return View(rentersList);
        }
        [HttpGet]
        public IActionResult RenterProfile(Renter renter)
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            String property = _context.Property.Where(p => p.Id == renter.PropertyId).Select(p => p.AddressLine).ToString();
            var r = _context.Renters.Find(renter.Id);
            return View(r);
        }
    }
}
