using Microsoft.AspNetCore.Mvc;
using Shop.Services.Contracts;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private IProductsService productsService;

        private ICategoriesService categoriesService;

        public ProductController(IProductsService productsService,ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProductViewModel();

            viewModel.Category = categoriesService.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(string name,string description,decimal price,int CategoryId)
        {
            this.productsService.CreateProduct(name, description, price, CategoryId);

            return this.RedirectToAction("Index", "Home");
        }

    }
}
