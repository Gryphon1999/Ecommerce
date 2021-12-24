using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Services
{
    public class CategoryService
    {
        private readonly AppDbContext context;

        public CategoryService()
        {
          context = new AppDbContext();
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var data = context.Category.ToList();

            var model = new List<CategoryViewModel>();

            if (data != null)
            {
                foreach (var item in data)
                {
                    model.Add(new CategoryViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CreatedDate = item.CreatedDate,
                        ImagePath = item.ImagePath,
                    });
                }
            }

            return model;
        }

       public bool CreateCategory(CategoryViewModel CategoryVM)
        {
            try
            {
                if (CategoryVM != null)
                {
                    var mdl = new Category();


                   // mdl.Id = 1;
                    mdl.Name = CategoryVM.Name;
                    mdl.CreatedDate = DateTime.Now;
                    mdl.ImagePath = CategoryVM.ImagePath;

                    context.Category.Add(mdl);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            

            return false;
        }

        public IEnumerable<SelectListItem> ListAllCategories()
        {
            return context.Category.ToList().Select(wh => new SelectListItem()
            {
                Text = wh.Name,
                Value = wh.Id.ToString()
            });
        }
    }
}