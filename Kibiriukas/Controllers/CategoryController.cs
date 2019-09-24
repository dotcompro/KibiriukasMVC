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

        public CategoryCollectionViewModel getCategoryCollection()
        {
            CategoryCollectionViewModel categoryCollection = new CategoryCollectionViewModel();
            categoryCollection.CategoryList = new List<Category>();
            foreach (Category category in _context.Categories.ToList())
            {
                category.Subcategories = _context.Subcategories.ToList().Where(x => x.CategoryId == category.CategoryId).ToList();
                categoryCollection.CategoryList.Add(category);
            }
            return categoryCollection;
        }

        // GET: Category
        [Route("Category")]
        public ActionResult Index()
        {
            CategoryCollectionViewModel categoryCollection = getCategoryCollection();
            return View(categoryCollection);
        }

        public ActionResult Details(string Id)
        {
            //jei string = category, tai vienam puslapy rodo tik tos grupes subs.
            //jei string = subcategory, tai puslapy rodo tik tos subs listings
            return Content("this content is detail method " + Id);
        }


        [AllowAnonymous]
        public ActionResult AddCategory()
        {
            return View("AddCategory");
        }

        bool found = false;

        [HttpPost]
        public async Task<ActionResult> AddCategory (String categoryTitle)
        {
            Category newCategory = new Category(categoryTitle);

            bool categoryAlreadyExists = _context.Categories.Any(x => x.CategoryTitle == categoryTitle);

            if (!categoryAlreadyExists)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
        }



        public ActionResult EditCategory()
        {
            return View();
        }






        [AllowAnonymous]
        public ActionResult DeleteCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCategory(DeleteCategoryViewModel model)
        {
            var categorytitle = model.CategoryTitle; //model.CategoryTitle yra string

            _context = new ApplicationDbContext();
            var newModel = getCategoryCollection();
            foreach (Category category in newModel.CategoryList)
            {
                if (category.CategoryTitle == categorytitle)
                {
                    found = true;
                    _context.Categories.Remove(category);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }




    }
}
