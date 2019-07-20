using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.ViewModels
{
   public  class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

    }
}
