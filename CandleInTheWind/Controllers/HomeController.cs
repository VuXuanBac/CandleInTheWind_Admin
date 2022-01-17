using CandleInTheWind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CandleInTheWind.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(IDistributedCache cache, ILogger<HomeController> logger)
            : base(cache)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (HasNotSignIn())
                return RedirectToAction("Login", "Authentication", new { message = "Fail!" });
            return View();
        }

        public IActionResult Privacy()
        {
            if (HasNotSignIn())
                return RedirectToAction("Login", "Authentication", new { message = "Fail!" });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (HasNotSignIn())
                return RedirectToAction("Login", "Authentication", new { message = "Fail!" });
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
