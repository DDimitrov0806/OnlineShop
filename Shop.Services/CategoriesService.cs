using Shop.Data;
using Shop.Data.Models;
using Shop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ShopDbContext context;
        

        public CategoriesService(ShopDbContext context)
        {
            this.context = context;
            

        }
        public int CreateCategory(string name)
        {
            var category = new Category() { Name = name };

            context.Categories.Add(category);
            context.SaveChanges();

            return category.Id;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
    }
}
