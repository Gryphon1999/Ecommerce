using ECommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {

        private readonly CategoryService CategoryService;
        public HomeController()
        {
            CategoryService = new CategoryService();
        }

        public ActionResult Index()
        {
            var data = CategoryService.GetAllCategories();
            return View(data);
        }

        public ActionResult Banner()
        {
            return PartialView("_Banner");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}