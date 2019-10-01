using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageString { get; set; }
    }
}