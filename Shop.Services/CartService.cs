using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Services.Contracts;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services
{
    public class CartService : ICartService
    {
        private ShopDbContext context;
       
        public CartService(ShopDbContext context)
        {
            this.context = context;
            
        }

        

        public int AddToCart(int productId, string username)
        {

            var product = context.Products.FirstOrDefault(p => p.Id == productId);

            var cart = context.Carts.Include(u => u.User).FirstOrDefault(u => u.User.UserName == username);

            var joinedObject = new CartProduct();

            joinedObject.Product = product;

            if (cart == null)
            {
                var newCart = new Cart { User = context.Users.FirstOrDefault(u => u.UserName == username)};

                cart = newCart;

                context.Carts.Add(newCart);

                joinedObject.Cart = newCart;
            }
            else
            {

                joinedObject.Cart = cart;

               
            }
            if(context.CartProducts.Count(a=>a.CartId==cart.Id && a.ProductId==product.Id)==0)
            {
                context.CartProducts.Add(joinedObject);
                //product.CartProducts.Add(joinedObject);
                //cart.CartProducts.Add(joinedObject);

                context.SaveChanges();

                return cart.Id;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        

        public CartViewModel GetCart(string username)
        {

            var product = context.CartProducts.Include(p => p.Product).Where(c => c.Cart.User.UserName == username).Select(p => new SingleCartProductViewModel
            {
                Name = p.Product.Name,
                Price = p.Product.Price
            }).ToList();

            var model = new CartViewModel
            {
                Cart = product,
                OverallPrice = GetOverallPrice(product)
            };

            return model;
           
        }

        private decimal GetOverallPrice(List<SingleCartProductViewModel> products)
        {
            decimal overallPrice = 0;

            foreach (var product in products)
            {
                overallPrice += product.Price;
            }

            return overallPrice;

        }

        public void ClearCart(string username)
        {
            var cartProducts = context.CartProducts.Where(u => u.Cart.User.UserName == username);

            foreach (var cartProduct in cartProducts)
            {
                context.CartProducts.Remove(cartProduct);
            }

            context.SaveChanges();
        }
    }
}
