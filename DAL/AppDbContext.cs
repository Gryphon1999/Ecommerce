using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<MenFashion> menFashions { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Cart> Cart {get;set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       // public System.Data.Entity.DbSet<ECommerce.Models.CategoryViewModel> CategoryViewModels { get; set; }
    }
}