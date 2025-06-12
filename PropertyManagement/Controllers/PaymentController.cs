using Microsoft.AspNetCore.Mvc;

namespace PropertyManagement.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePayment()
        {
            Repository.MyDbContext _context = new Repository.MyDbContext();
            return View();
        }
    }
}
