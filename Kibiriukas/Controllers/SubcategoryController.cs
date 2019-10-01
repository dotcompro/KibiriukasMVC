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


        //[HttpPost]
        //public ActionResult GetDropDown2Data(int categoryId)
        //{
        //    //List<Subcategory> subcategoryList = new List<Subcategory>();
        //    //subcategoryList = _context.Subcategories.Where(x => x.CategoryId == categoryId).ToList();
        //    //return Json(subcategoryList, JsonRequestBehavior.AllowGet);
        //}
    }
}