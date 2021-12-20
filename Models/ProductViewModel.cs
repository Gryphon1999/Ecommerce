using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify name")]
        [StringLength(50, ErrorMessage = "Name length cannot exceed than 50")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }


        public string Description { get; set; }

        [Range(100, 100000, ErrorMessage ="Price must be between 10 and 1000000")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LaunchDate { get; set; }
    }
}