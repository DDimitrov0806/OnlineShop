using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}