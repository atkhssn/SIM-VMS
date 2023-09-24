using Microsoft.AspNetCore.Mvc;

namespace VMS.App.Controllers
{
    public class TripExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TollDetails()
        {
            return View();
        }
    }
}
