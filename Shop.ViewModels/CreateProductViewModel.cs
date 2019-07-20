using Shop.Data.Models;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.ViewModels
{
    public class CreateProductViewModel
    {
        public CreateProductViewModel()
        {
            Category = new List<Category>();
        }
        

        [StringLength(15, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal? Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Select Category")]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Category { get; set; }
    }
}
