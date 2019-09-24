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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //regex for email
        private string Email { get; set; }
        private DateTime DateOfBirth { get; set; }
        //regex for phone number
        public string PhoneNumber { get; set; }
        public bool IsValidUser { get; set; }
        

        // reuketu prideti List<Model> UserListing list prie Db user

    }
}