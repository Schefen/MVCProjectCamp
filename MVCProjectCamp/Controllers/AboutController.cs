using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = _aboutManager.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }
    }
}