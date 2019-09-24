using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Kibiriukas.Models;
using Kibiriukas.ViewModels;

namespace Kibiriukas.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [Route("User")]
        public ActionResult Index()
        {
            return Content(User.Identity.Name);
        }

        public ActionResult Details()
        {
            return View();
        }

    }
}