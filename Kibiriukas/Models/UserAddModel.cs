using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{

    // sitas visai niekur nenaudojamas. istrinti visus userAddModels


    public class UserAddModel
    {
        [Key]
        public int AddId { get; set; }
        [Required]
        public string AddTitle { get; set; }
        public string AddDescription { get; set; }
        public bool IsAddActive { get; set; }
        public float AddPrice { get; set; }
        public int UserId { get; set; }
        public int AddSubcategoryId { get; set; } // turi sutapti su subcategory ID ir su category ID
    }


}