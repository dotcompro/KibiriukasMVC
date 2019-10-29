using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kibiriukas.Models;

namespace Kibiriukas.ViewModels
{
    public class ProfileViewModel
    {
        public User user { get; set; }
        public List<Language> languages { get; set; }
        public bool modelIsValid { get; set; }
    }
}