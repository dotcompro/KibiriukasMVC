using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class ManipulateSubcategoryModel
    {
        public List<Category> Categories { get; set; }
        public string CategoryId { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public int SubcategoryId { get; set; }
    }
}