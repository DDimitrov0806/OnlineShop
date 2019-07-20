using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class Cart
    {
        public Cart()
        {
           CartProducts = new List<CartProduct>();

          // Products = new List<Product>();
        }

        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
