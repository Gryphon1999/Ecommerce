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
    public class ProductController : Controller
    {

        private readonly ProductService productService;
        private readonly CategoryService categoryService;

        public ProductController()
        {
            productService = new ProductService();
            categoryService = new CategoryService();
        }
        #region CRUD

       

        // GET: Product
        public ActionResult Index()
        {

            var data = productService.GetAllProduct();
            return View(data);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var model = new ProductViewModel()
            {
                categories = categoryService.ListAllCategories(),
            };

            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productVM)
        {
            try
            {
                var path = @"~/Category/" + productVM.ImgPath.FileName + Path.GetExtension(productVM.ImgPath.FileName);
                productVM.ImagePath = path;
                productVM.ImgPath.SaveAs(Server.MapPath(@"~/Category/" + productVM.ImgPath.FileName + Path.GetExtension(productVM.ImgPath.FileName)));

                bool result = productService.AddProduct(productVM);

                if (result)
                {
                    return RedirectToAction("Index");
                }

                return View(productVM);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var data = productService.GetProductByID(id);
            
            return View(data);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel productVM)
        {
            bool data = productService.EditProduct(id, productVM);
            return RedirectToAction("Index");
        }

        // POST: Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                bool data = productService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region Category
        public ActionResult GetProduct(int categoryID)
        {
            var data = productService.ListAllProductForCategory(categoryID);

            return View(data);
        }
        #endregion

        #region ProductDetail
        public ActionResult ProductDetail(int productID)
        {
            var data = productService.GetProductByID(productID);

            return View(data);
        }
        #endregion

        #region AddCart
        public ActionResult AddCart(string productID)
        {
            bool result = productService.AddProductToCart(productID);

            if(result)
            {
                return Json("added");
            }


            return Json("error");
        }
        #endregion
    }
}
