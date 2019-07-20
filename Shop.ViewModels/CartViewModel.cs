using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<SingleCartProductViewModel> Cart { get; set; }

        public decimal OverallPrice { get; set; }
    }
}
