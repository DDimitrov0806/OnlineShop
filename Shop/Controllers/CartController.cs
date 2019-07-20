using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.Contracts;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [Authorize]
        public IActionResult AddToCart(int id)
        {
            try
            {
                cartService.AddToCart(id, this.User.Identity.Name);

                return this.RedirectToAction("List","Cart");

            }
            catch (InvalidOperationException)
            {

                return RedirectToAction("AddProduct", "Error");

            }
            

            
        }
        [Authorize]
        public IActionResult List()
        {
                var model = cartService.GetCart(this.User.Identity.Name);

                return this.View(model);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            cartService.ClearCart(User.Identity.Name);

            return RedirectToAction("Index", "Home");
        }

    }
}
