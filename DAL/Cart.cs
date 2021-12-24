using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class Cart
    {
        public int Id { get; set; }

        public int productID { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}