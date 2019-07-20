using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using Shop.Services.Contracts;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IProductsService productsService;

        public HomeController(IProductsService service)
        {
            productsService = service;
        }


        public IActionResult Index()
        {

            return View(productsService.GetAll());
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
