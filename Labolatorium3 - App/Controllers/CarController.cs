using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [AllowAnonymous]
        public IActionResult Index(int page = 1, int size = 3, int maker = -1, bool isList = false)
        {
            if (size < 1) return BadRequest();
            ViewBag.Makers = _carService.GetMakers();
            ViewBag.CurrentMaker = maker;
            ViewBag.IsList = isList;
            return View(_carService.FindPage(page, size, maker));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(Car model)
        {
            if(ModelState.IsValid)
            {
                _carService.Add(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            Car? model = _carService.FindById(id);
            if (model is null) return NotFound();
            return View(_carService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Update(Car model)
        {
            if (ModelState.IsValid)
            {
                _carService.Update(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Car? model = _carService.FindById(id);
            if (model is null) return NotFound();
            return View(_carService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Car model)
        {
            _carService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Car? model = _carService.FindById(id);
            if (model is null) return NotFound();
            return View(model);
        }


    }
}
