using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header

        HeaderManager _headerManager = new HeaderManager(new EfHeaderDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headerValues = _headerManager.GetList();
            return View(headerValues);
        }
        [HttpGet]
        public ActionResult AddHeader()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList() //DropDownList
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value =x.CategoryId.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in _writerManager.GetList() 
                                                select new SelectListItem 
                                                { 
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeader(Header header)
        {
            header.HeaderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headerManager.HeaderAdd(header);
            return RedirectToAction("Index");
        }

    }
}