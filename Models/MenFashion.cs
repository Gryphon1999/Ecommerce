using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class MenFashion
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }
        public string  Type { get; set; }
        public string Size { get; set; }    
        public string Color { get; set; }   
    }
}