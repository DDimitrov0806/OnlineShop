using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ViewModels
{
    public class AllProductsViewModel
    {
        public IEnumerable<SingleProductViewModel> Products { get; set; }
    }
}
