using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Contracts
{
    public interface ICartService
    {
        int AddToCart(int productId, string username);

        CartViewModel GetCart(string username);

        void ClearCart(string username);

        //decimal GetOverallPrice(List<SingleCartProductViewModel> products);

        // List<SingleCartProductViewModel> GetCart(string username);
    }
}
