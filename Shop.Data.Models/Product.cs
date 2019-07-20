using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            CartProducts = new List<CartProduct>();
        }
        public int Id { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal Price { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }


    }
}
