using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    [Authorize(Roles = "admin")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly ICarService _carService;

        public OwnerController(IOwnerService OwnerService, ICarService CarService)
        {
            _ownerService = OwnerService;
            _carService = CarService;
        }

        [AllowAnonymous]
        public IActionResult Index(int page = 1, int size = 3)
        {
            if (size < 1) return BadRequest();
            return View(_ownerService.FindPage(page, size));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Owner model)
        {
            if(ModelState.IsValid)
            {
                _ownerService.Add(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_ownerService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Owner model)
        {
            if (ModelState.IsValid)
            {
                _ownerService.Update(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_ownerService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Owner model)
        {
            _ownerService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Cars = _carService.FindByOwnerId(id);
            return View(_ownerService.FindById(id));
        }


    }
}
