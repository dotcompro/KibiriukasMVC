using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kibiriukas.Models;
using Kibiriukas.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace Kibiriukas.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random() // visa content perduodi i vews/random.
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
                new Customer {Name = "Customer 3"},
                new Customer {Name = "Customer 4"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            // return View(movie);  i random view perduodamas instance of the Movie, that was created.
        }


        // all actions results methods are actions. Find it in Route.Config.cs 


        // [Route()....] priklauso po juo einanciam ActionResult
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
       
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}