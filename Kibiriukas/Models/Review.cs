using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public int ReviewedUserId { get; set; }
        public int ReviewerId { get; set; }
        [ForeignKey("ReviewedUserId")]
        [InverseProperty("OwnReviews")]
        public User ReviewedUser { get; set; }
        [ForeignKey("ReviewerId")]
        [InverseProperty("WrittenReviews")]
        public User Reviewer { get; set; }
    }
}