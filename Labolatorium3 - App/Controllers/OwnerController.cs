using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    [Authorize(Roles = "admin, user")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            Owner? model = _ownerService.FindById(id);
            if (model is null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Owner? model = _ownerService.FindById(id);
            if (model is null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Owner model)
        {
            _ownerService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Owner? model = _ownerService.FindById(id);
            if (model is null) return NotFound();
            ViewBag.Cars = _carService.FindByOwnerId(id);
            return View(model);
        }


    }
}
