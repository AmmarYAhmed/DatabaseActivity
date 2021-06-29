using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;

        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegistrationViewModel());
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel container = new ShippingContainerRegistrationViewModel()
            {
                Id = student.Id,
                Weight = student.Weight,
                Destination = student.Destination
            };
            return View(container);
        }
        public async Task<IActionResult> UpDate(ShippingContainerRegistrationViewModel model)
        {
            ShippingContainer container = new ShippingContainer()
            {
                Id = model.Id,
                Weight = model.Weight,
                Destination = model.Destination
            };
            await ShippingContainerService.Update(container);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(student);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Register(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShippingContainer student = new ShippingContainer()
                {
                    Id = model.Id,
                    Weight = model.Weight,
                    Destination = model.Destination
                };
                var varstudent = await ShippingContainerService.Create(student);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel student1 = new ShippingContainerRegistrationViewModel()
            {
                Id = student.Id,
                Weight = student.Weight,
                Destination = student.Destination,
            };
            return View(student1);
        }

    }
}