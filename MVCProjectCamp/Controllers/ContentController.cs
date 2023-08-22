using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            var values = _contentManager.GetList(p);
            return View(values);
        }

        public ActionResult ContentByHeader(int id)
        {
            var contentValues = _contentManager.GetListByHeaderId(id);
            return View(contentValues);
        }
    }
}