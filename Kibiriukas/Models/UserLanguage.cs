using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class UserLanguage
    {
        [Key]
        public int UserLanguageId { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
        public Language language { get; set; }
        public int LanguageId { get; set; }
    }
}