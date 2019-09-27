using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Kibiriukas.Models;
using Kibiriukas.ViewModels;

namespace Kibiriukas.Controllers
{
    public class SubcategoryController : CategoryController
    {

        private ApplicationDbContext _context;

        public SubcategoryController() // this is constructor of instance of the database
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult AddSubcategory()
        {
            ManipulateSubcategoryModel mscm = new ManipulateSubcategoryModel();
            mscm.Categories = _context.Categories.ToList();




            //mscm.Subcategories = _context.Subcategories.Where(x => x.CategoryId == mscm.Categories[0].CategoryId).ToList();
            return View(mscm);

            //CategoryCollectionViewModel categoryCollectionList = base.getCategoryCollection();
            //AddSubcategoryViewModel categoryList = new AddSubcategoryViewModel();
            //categoryList.Categories = categoryCollectionList.CategoryList;
            //return View(categoryList);
        }

        public ActionResult DeleteSubcategory()
        {
            ManipulateSubcategoryModel mscm = new ManipulateSubcategoryModel();
            mscm.Categories = _context.Categories.Include("Subcategories").ToList();
            mscm.Subcategories = _context.Categories.FirstOrDefault().Subcategories.ToList();
            mscm.SubcategoryId = _context.Categories.FirstOrDefault().Subcategories.FirstOrDefault().SubcategoryId;
            return View(mscm);

            //DeleteSubcategoryViewModel deleteviewModel = new DeleteSubcategoryViewModel();
            //CategoryCollectionViewModel categoryCollection = base.getCategoryCollection();
            ////deleteviewModel.Subcategories = categoryCollection.CategoryList;
            //return View(deleteviewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddSubcategory(AddSubcategoryViewModel categoryList)
        {

            categoryList.CategoryId = categoryList.CategoryId;
            categoryList.CategoryTitle = _context.Categories.Where(x => x.CategoryId == categoryList.CategoryId).FirstOrDefault().CategoryTitle;
            //return Content("just added " + categoryList.SubcategoryTitle + " to the category " + categoryList.CategoryTitle + " and category ID " + categoryList.CategoryId);
            Subcategory subcategory = new Subcategory
            {
                SubcategoryTitle = categoryList.SubcategoryTitle,
                CategoryId = categoryList.CategoryId
            };

            bool subcategoryExists =_context.Subcategories.Any(x => x.SubcategoryTitle == subcategory.SubcategoryTitle);
            if (!subcategoryExists)
            {
                _context.Subcategories.Add(subcategory);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public ActionResult GetDropDown2Data(int categoryId)
        {
            List<Subcategory> subcategoryList = new List<Subcategory>();
            subcategoryList = _context.Subcategories.Where(x => x.CategoryId == categoryId).ToList();
            return Json(subcategoryList, JsonRequestBehavior.AllowGet);
        }




    }
}