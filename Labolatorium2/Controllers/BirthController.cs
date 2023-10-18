using Microsoft.AspNetCore.Mvc;

namespace Labolatorium2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Birth model)
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
