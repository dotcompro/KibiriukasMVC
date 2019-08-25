using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class Subcategory
    {
        public short SubcategoryId { get; set; }
        [Required]
        [StringLength(255)]
        public string SobcategoryTitle { get; set; }
        public int Category_CategoryId { get; set; }
    }
}