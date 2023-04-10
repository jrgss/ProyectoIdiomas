using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProyectoIdiomas.Models;
using ProyectoIdiomas.Resources;
using System.Diagnostics;

namespace ProyectoIdiomas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<SharedResource> _recursos;
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<SharedResource> res)
        {
            _logger = logger;
            _recursos = res;
        }

        public IActionResult Index()
        {
            var a = _recursos["Bienvenida"];
            ViewData["MensajeBienvenida"] = a.Value;
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