using Kibiriukas.Models;
//using Kibiriukas.ViewModels;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;


namespace Kibiriukas.Controllers
{
    public class HomeController : Controller
    {
        [Route("Index")]
        public ActionResult Index()
        {
            return View("Index");
        }
        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}