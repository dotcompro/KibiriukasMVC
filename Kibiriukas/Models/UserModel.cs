using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //regex for email
        private string Email { get; set; }
        private DateTime DateOfBirth { get; set; }
        //regex for phone number
        public string PhoneNumber { get; set; }

        public string StreetName { get; set; }
        public string StreetName2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }

        public List<Listing> Listing { get; set; }

    }
}