using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImgPath { get; set; }
    }
}