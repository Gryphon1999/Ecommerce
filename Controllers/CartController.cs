using ECommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController()
        {
            cartService = new CartService(); 
        }


        // GET: Cart
        public ActionResult Index()
        {
            var data = cartService.ListAllCarts();
            return View(data);
        }
    }
}