using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View(_carService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
        public IActionResult Update(int id)
        {
            return View(_carService.FindById(id));
        }

        [HttpPost]
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
        public IActionResult Delete(int id)
        {
            return View(_carService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Car model)
        {
            _carService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_carService.FindById(id));
        }


    }
}
