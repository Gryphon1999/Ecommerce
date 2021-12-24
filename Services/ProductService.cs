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
                        Price = item.Price,
                        ImagePath = item.ImagePath,
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
                model.categoryId = productVM.CategoryId;
                model.ImagePath = productVM.ImagePath;    

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
                model.Id = data.Id;
                model.Name = data.Name;
                model.Description = data.Description;
                model.LaunchDate = DateTime.Now;
                model.Price = data.Price;
                model.ImagePath = data.ImagePath;
             
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
                //model.ImageFile = productVM.ImageFile;
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


        public List<ProductViewModel> ListAllProductForCategory(int categoryID)
        {
            var data = context.Products.Where(wh=>wh.categoryId == categoryID).ToList();

            var model = new List<ProductViewModel>();
            if(data!=null)
            {
                foreach(var item in data)
                {
                    model.Add(new ProductViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        ImagePath = item.ImagePath,
                        CategoryName = context.Category.Where(wh => wh.Id == categoryID).FirstOrDefault().Name,
                    });
                }
            }

            return model;
        }

        public bool AddProductToCart(string productID)
        {
            if (!string.IsNullOrEmpty(productID))
            {
                var cart = new Cart()
                {
                    productID =Convert.ToInt32(productID),
                    CreatedDate = DateTime.Now,
                    Quantity = 1,
                };


                context.Cart.Add(cart);
                context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}