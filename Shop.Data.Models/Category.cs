using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Data.Models
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new List<ProductCategory>();
        }
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
