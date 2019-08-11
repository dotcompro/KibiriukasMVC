using Kibiriukas.Models;
using Kibiriukas.ViewModels;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult UserDetails(int id)
        {
            User Vygintas = getUsers().Where(x => x.Id == id).FirstOrDefault();

            return View(Vygintas);
        }


        public ViewResult Users()
        {
            var user = getUsers();
            return View(user);
        }

        private IEnumerable<User> getUsers() // method which supports a simple iteration over a collection of specified type.
        {
            return new List<User>
            {
                new User
                {
                    Id = 1001, Username = "movieJunkie", FirstName = "Vygintas", LastName = "Kavaliauskas",
                    Email = "t.kava@hotmail.com"
                },
                new User
                {
                    Id = 1002, Username = "linuxx", FirstName = "Domas", LastName = "Marakesh",
                    Email = "linusasM@hotmail.com"
                }
            };
        }

    }
}