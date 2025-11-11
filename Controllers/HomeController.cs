using BattleFight.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BattleFight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Acerca()
        {
            return View();
        }
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.NombreUsuario = userName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
