using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public decimal  Price { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }


        public string CategoryName { get; set; }
    }
}