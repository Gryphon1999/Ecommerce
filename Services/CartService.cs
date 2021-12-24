using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Services
{
    public class CartService
    {
        private readonly AppDbContext context;

        public CartService()
        {
            context = new AppDbContext();
        }


        public List<CartViewModel> ListAllCarts()
        {
            var data = (from a in context.Cart
                        join b in context.Products on a.productID equals b.Id
                        select new CartViewModel()
                        {
                            Id = a.Id,
                            Name =b.Name,
                            Price=b.Price,
                            Quantity=a.Quantity,
                            ImagePath = b.ImagePath,
                            CategoryName = context.Category.Where(wh=>wh.Id ==b.categoryId).Select(wh=>wh.Name).FirstOrDefault(),

                        }).ToList();

            return data;
        }
    }
}