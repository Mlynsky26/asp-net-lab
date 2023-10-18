using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Labolatorium2.Controllers
{
    public class CalculatorController : Controller
    {
        public enum Operators
        {
            ADD, SUB, MUL, DIV
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }

        public IActionResult Form()
        {
            return View();
        }
    }
}
