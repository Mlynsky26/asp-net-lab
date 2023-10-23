using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    public class CarController : Controller
    {
        static readonly Dictionary<int, Car> _cars = new Dictionary<int, Car>();
        static int id = 1;
        public IActionResult Index()
        {
            return View(_cars);
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
                model.Id = id++;
                _cars[model.Id] = model;
                //zapisanie modelu
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_cars[id]);
        }

        [HttpPost]
        public IActionResult Update(Car model)
        {
            if (ModelState.IsValid)
            {
                _cars[model.Id] = model;
                //zapisanie modelu
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_cars[id]);
        }

        [HttpPost]
        public IActionResult Delete(Car model)
        {
            _cars.Remove(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_cars[id]);
        }


    }
}
