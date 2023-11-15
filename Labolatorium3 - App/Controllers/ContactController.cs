﻿using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labolatorium3___App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.OrganizationList = CreateOrganizationItemList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            model.OrganizationList = CreateOrganizationItemList();
            return View(model);
        }

        private List<SelectListItem> CreateOrganizationItemList()
        {
            return _contactService.FindAllOrganizations()
                        .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.Id.ToString(),
                            })
                        .Append(new SelectListItem()
                        {
                            Text = "Brak",
                            Value = ""
                        })
                        .ToList();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }


    }
}
