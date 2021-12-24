using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please specify name")]
        [StringLength(50, ErrorMessage ="Name length cannot exceed than 50")]
        [Display(Name ="Full Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }

        public int categoryId { get; set; }

        public string ImagePath { get; set; }

    }
}