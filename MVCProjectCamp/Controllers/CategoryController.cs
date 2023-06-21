using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager catManager = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var CategoryValues = catManager.GetAllBL();
            return View(CategoryValues);
        } 
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            catManager.CategoryAddBL(category);
            return RedirectToAction("GetCategoryList");
        }
    }
}