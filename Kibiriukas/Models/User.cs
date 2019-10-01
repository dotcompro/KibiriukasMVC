using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetName2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }
        public List<Listing> Listings { get; set; }
        public List<ProfilePicture> ProfilePictures { get; set; }
        public DateTime UserCreated { get; set; }
        public ICollection<Review> OwnReviews { get; set; }
        public ICollection<Review> WrittenReviews { get; set; }
        public string SelfIntroduction { get; set; }
        public ICollection<UserLanguage> Languages { get; set; }

        public User()
        {
            UserCreated = DateTime.Now;
        }
    }
}