using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class CategoryViewModel
    {
        
    }

    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name = "Add new category")]
        [DataType(DataType.Text)]
        public string CategoryTitle { get; set; }
        public int CategoryId { get; set; }
    }

    public class DeleteCategoryViewModel
    {
        [Required]
        [Display(Name="Delete category")]
        [DataType(DataType.Text)]
        public string CategoryTitle { get; set; }
    }
}