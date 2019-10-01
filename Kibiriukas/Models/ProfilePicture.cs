using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kibiriukas.Models
{
    public class ProfilePicture
    {
        [Key]
        public int PictureId { get; set; }
        public User Usermodel { get; set; }
        public int UserId { get; set; }
        public byte[] Content { get; set; }
    }
}