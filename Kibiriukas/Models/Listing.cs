using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }
        public int UserId { get; set; }
        public short SubcategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public bool Bio { get; set; }
    }
}