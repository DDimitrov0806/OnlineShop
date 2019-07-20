using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Contracts
{
    public interface ICategoriesService
    {
        int CreateCategory(string name);

        List<Category> GetAll();
    }
}
