using ECommerce.DAL;
using ECommerce.Models;
using ECommerce.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private static string impPath = "CategoryImages";
        private readonly CategoryService CategoryService;
        private readonly AppDbContext db;

        public CategoryController(AppDbContext context)
        {
            db=context;
        }
        public CategoryController()
        {
            CategoryService = new CategoryService();
        }

        // GET: Category
        public ActionResult Index()
        {
            var mdl = CategoryService.GetAllCategories();
            return View(mdl);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var mdl = new CategoryViewModel();
            return View(mdl);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                //
                bool imageStatus = IsDirectoryCreated();

                if (imageStatus)
                {
                  

                    var path = @"~/Category/" + model.ImgPath.FileName + Path.GetExtension(model.ImgPath.FileName);
                    model.ImagePath = path;
                    model.ImgPath.SaveAs(Server.MapPath(@"~/Category/" + model.ImgPath.FileName + Path.GetExtension(model.ImgPath.FileName)));

                    bool result = CategoryService.CreateCategory(model);

                    if(result)
                    {
                        return RedirectToAction("Index");
                    }

                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        private bool IsDirectoryCreated()
        {
            try
            {
                if (!Directory.Exists(impPath))
                {
                    Directory.CreateDirectory(Server.MapPath(impPath));

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           

            return false;
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Category.Find(id);
            return View(data);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category model)
        {
            try
            {
                // TODO: Add update logic here
                var data = db.Category.Find(id);
                if (data == null)
                {
                    data.Name = model.Name;
                    data.CreatedDate = model.CreatedDate;
                    data.ImagePath = model.ImagePath;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Category.Find(id);
            return View(data);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                // TODO: Add delete logic here
                db.Category.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
