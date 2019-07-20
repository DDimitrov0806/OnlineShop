using Microsoft.AspNetCore.Mvc;
using Shop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoriesService service;

        public CategoryController(ICategoriesService service)
        {
            this.service = service;

        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            this.service.CreateCategory(name);
            return this.RedirectToAction("Index", "Home");
        }

    }
}
