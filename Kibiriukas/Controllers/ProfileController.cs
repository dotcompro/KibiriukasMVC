using Kibiriukas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace Kibiriukas.Controllers
{
    public class ProfileController : Controller
    {

        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Profile
        public ActionResult Index()
        {
            User user = _context.User.Where(x => x.Email == User.Identity.Name).First();
            return View("Profile", user);
        }

        // GET: Profile/Edit
        public ActionResult EditProfile()
        {
            return Content("edit profile content");
        }

        // GET: Profile/UploadPhoto
        public ActionResult UploadPhoto()
        {
            return Content("upload photo content");
        }
    }
}