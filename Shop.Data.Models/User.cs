using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Carts = new List<Cart>();
        }

        public ICollection<Cart> Carts { get; set; }
    }
}
