using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
//using Kibiriukas.ViewModels;
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

        public CategoryCollectionViewModel getCategoryCollection()
        {
 
            CategoryCollectionViewModel categoryCollection = new CategoryCollectionViewModel();
            categoryCollection.CategoryList = new List<Category>(); // kategoriju empty object
            foreach (Category category in _context.Categories.ToList())
            {
                category.Subcategories = _context.Subcategories.ToList().Where(x => x.Category_CategoryId == category.CategoryId).ToList();
                categoryCollection.CategoryList.Add(category);
            }

            return categoryCollection;
        }

        // GET: Category
        public ActionResult Index()
        {
            CategoryCollectionViewModel categoryCollection = getCategoryCollection();          
            return View(categoryCollection);
        }


    }
}

