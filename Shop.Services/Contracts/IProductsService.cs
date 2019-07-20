using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Contracts
{
    public interface IProductsService
    {
        int CreateProduct(string name, string description, decimal price,int category);

        AllProductsViewModel GetAll(); 
    }
}
