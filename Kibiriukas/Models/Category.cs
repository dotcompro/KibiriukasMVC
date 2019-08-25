using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Kibiriukas.ViewModels;

namespace Kibiriukas.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(255)]
        public string CategoryTitle { get; set; }
        public List<Subcategory> Subcategories { get; set; } // this has one-to-many relationship: 1 category with many subs

        
    }

}