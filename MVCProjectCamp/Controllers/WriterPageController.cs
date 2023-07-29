using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterPageController : Controller
    {
        // GET: WriterPage
        HeaderManager _headerManager = new HeaderManager(new EfHeaderDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading()
        {
            var values = _headerManager.GetListByWriter();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList() //DropDownList
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Header header)
        {
            header.HeaderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            header.WriterId = 4;
            header.HeaderStatus = true;
            _headerManager.HeaderAdd(header);
            return RedirectToAction("MyHeading");
        }
        public ActionResult EditHeader(int id)
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList() //DropDownList
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headerValue = _headerManager.GetById(id);
            return View(headerValue);
        }
        [HttpPost]
        public ActionResult EditHeader(Header header)
        {
            _headerManager.HeaderUpdate(header);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeader(int id)
        {
            var headerValue = _headerManager.GetById(id);
            headerValue.HeaderStatus = false;
            _headerManager.HeaderDelete(headerValue);
            return RedirectToAction("MyHeading");
        }

    }
}

      //< customErrors mode = "On" >

      //    < error statusCode = "404" redirect = "/ErrorPage/Page404/" ></ error >

      //</ customErrors >