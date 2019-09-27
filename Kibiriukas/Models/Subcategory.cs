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

    public class AddSubcategoryViewModel
    {
        // title
        //price
        // description
        //upload fotos
        //phone number
        //address

        [Display(Name = "Select category: ")]
        public List<Category> Categories { get; set; }
        public string CategoryTitle { get; set; }
        public short CategoryId { get; set; }

        [Display(Name="Add new Subcategory: ")]
        [DataType(DataType.Text)]
        public string SubcategoryTitle { get; set; }
        public short SubcategoryId { get; set; }
        
    }

    public class EditSubcategoryViewModel
    {
        //title
        //price
        //description
        //add or remove fotos
        //phone number
        //address
    }

    public class DeleteSubcategoryViewModel
    {
        [Display(Name = "Select subcategory to remove: ")]
        public List<Subcategory> Subcategories { get; set; }
        public string SubcategoryTitle { get; set; }


        [Display(Name = "From Category: ")]
        public List<Category> Categories { get; set; }
        public string CategoryId { get; set; }

        [Required]
        public bool ConfirmDeletion { get; set; }
    }
}