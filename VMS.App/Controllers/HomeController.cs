using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using VMS.App.Models;
using VMS.Infrastructure.Model;

namespace VMS.App.Controllers
{
    public class HomeController : Controller
    {
        // static user credentials
        protected const string Email = "admin@gmail.com";
        protected const string Password = "123456";

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var userEmail = loginModel.Email;
            var userPassword = loginModel.Password;

            if (Email == userEmail & Password == userPassword)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Message = "Email and password don't match!";
                return View("Index", loginModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
