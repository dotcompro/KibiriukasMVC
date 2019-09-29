using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class Subcategory
    {
        [Key]
        public short SubcategoryId { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "homey")]
        public string SubcategoryTitle { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }

}