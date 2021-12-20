using ECommerce.DAL;
using ECommerce.Models;
using ECommerce.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductService productService;

        public ProductController()
        {
            productService = new ProductService();
        }


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
            var model = new ProductViewModel();

            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productVM)
        {
            try
            {
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
            var data = productService.EditProduct(id, productVM);
            return RedirectToAction("Index");
        }

        // POST: Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = productService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
