using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //one to many relationship
        public List<Subcategory> Subcategories { get; set; }

        public Category(String title)
        {
            CategoryTitle = title;
        }

        public Category()
        {

        }
    }

}