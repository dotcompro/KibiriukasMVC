using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Kibiriukas.Models;
using Kibiriukas.ViewModels;
using Microsoft.Owin.Security.Google;

namespace Kibiriukas.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        //public CategoryCollectionViewModel getCategoryCollection()
        //{
        //    //CategoryCollectionViewModel categoryCollection = new CategoryCollectionViewModel();
        //    //categoryCollection.CategoryList = new List<Category>();
        //    //foreach (Category category in _context.Categories.ToList())
        //    //{
        //    //    category.Subcategories = _context.Subcategories.ToList().Where(x => x.CategoryId == category.CategoryId).ToList();
        //    //    categoryCollection.CategoryList.Add(category);
        //    //}
        //    //return categoryCollection;
        //}

        //// GET: Category
        //[Route("Category")]
        //public ActionResult Index()
        //{
        //    CategoryCollectionViewModel categoryCollection = getCategoryCollection();
        //    return View(categoryCollection);
        //}

        public ActionResult Details(string Id)
        {
            //jei string = category, tai vienam puslapy rodo tik tos grupes subs.
            //jei string = subcategory, tai puslapy rodo tik tos subs listings
            return Content("this content is detail method " + Id);
        }
    }
}
