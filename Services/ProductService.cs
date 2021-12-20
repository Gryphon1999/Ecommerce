using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.Services
{
    public class ProductService
    {
        private readonly AppDbContext context;

        public ProductService()
        {
            context = new AppDbContext();
        }


        public List<ProductViewModel> GetAllProduct()
        {
            var data = context.Products.ToList();

            var productVM = new List<ProductViewModel>();

            if (data != null)
            {
                foreach (var item in data)
                {
                    productVM.Add(new ProductViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        LaunchDate = item.LaunchDate,
                        Price = 1000,
                    });
                }
            }

            return productVM;
        }

        public bool AddProduct(ProductViewModel productVM)
        {
            var model = new Product();
            if (productVM != null)
            {
                model.Name = productVM.Name;
                model.Description = productVM.Description;
                model.LaunchDate = DateTime.Now;
                model.Price = productVM.Price;

                context.Products.Add(model);
                context.SaveChanges();

                return true;
            }
            return false;
           
        }

        public ProductViewModel GetProductByID(int id)
        {
            var data = context.Products.Where(wh => wh.Id == id).FirstOrDefault();

            var model = new ProductViewModel();
            if(data != null)
            {

                model.Name = data.Name;
                model.Description = data.Description;
                model.LaunchDate = DateTime.Now;
                model.Price = data.Price;
                
            }
            return model;
        }

        public bool EditProduct(int id,ProductViewModel productVM)
        {
            var model = context.Products.Find(id);
            if (model != null)
            {
                model.Name = productVM.Name;
                model.Description = productVM.Description;
                model.LaunchDate = DateTime.Now;
                model.Price = productVM.Price;
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            var model = context.Products.Where(md => md.Id == id).FirstOrDefault();
            if (model!=null)
            {
                context.Products.Remove(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}