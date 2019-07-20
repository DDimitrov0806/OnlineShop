using Shop.Data;
using Shop.Data.Models;
using Shop.Services.Contracts;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services
{
    public class ProductsService : IProductsService
    {
        private ShopDbContext context;

        public ProductsService(ShopDbContext context)
        {
            this.context = context;
        }
      
        public int CreateProduct(string name, string description, decimal price,int categoryId)
        {
           


            var product = new Product()
            {
                Name = name,
                Description = description,
                Price = price
            };
            
            var category = new Category() { Name = context.Categories.FirstOrDefault(ca => ca.Id == categoryId).Name };

            var productCategory = new ProductCategory()
            {
                Product = product,
                CategoryId = categoryId
            };

            context.ProductCategories.Add(productCategory);

            context.Products.Add(product);
            
            context.SaveChanges();

            

            return product.Id;


        }

        public AllProductsViewModel GetAll()
        {
            var products = context
                .Products
                .Select(p => new SingleProductViewModel()
            {
                Id=p.Id,
                Name = p.Name,
                Description=p.Description,
                Price=p.Price

            });

            var model = new AllProductsViewModel() { Products = products };

            return model;
            
        }
    }
}
