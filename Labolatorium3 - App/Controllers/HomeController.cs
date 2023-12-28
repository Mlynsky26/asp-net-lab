using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Labolatorium3___App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime? lastVisitDate = Response.HttpContext.Items[LastVisitCookie.CookieName] as DateTime?;
            if(lastVisitDate is null)
            {
                ViewBag.LastVisitDate = Response.HttpContext.Items[LastVisitCookie.CookieName].ToString();
            }
            else
            {
                ViewBag.LastVisitDate = lastVisitDate?.Date.ToString("yyyy-MM-dd");
            }
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