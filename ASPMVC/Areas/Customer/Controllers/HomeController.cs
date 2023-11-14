using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPMVC.Models;

namespace ASPMVC.Areas.Customer.Controllers
{
    // [Area("Customer")] specifies that this controller belongs to the "Customer" area.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor that injects an instance of ILogger<HomeController> for logging.
        //Yes, constructors in ASP.NET Core are commonly used for dependency injection.
        //Dependency injection is a design pattern that allows you to inject dependencies or
        //services into a class or component from the outside rather than creating them within the class itself.
        //This pattern promotes modularity, testability, and maintainability of code.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // The following are action methods for handling HTTP requests:

        // IActionResult Index() handles requests to the "Index" action.
        public IActionResult Index()
        {
            return View();
        }

        // IActionResult Privacy() handles requests to the "Privacy" action.
        public IActionResult Privacy()
        {
            return View();
        }

        // IActionResult Error() handles requests to the "Error" action.
        // [ResponseCache] attribute specifies caching behavior.
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

