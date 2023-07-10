using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header

        HeaderManager _headerManager = new HeaderManager(new EfHeaderDal());
        public ActionResult Index()
        {
            var headerValues = _headerManager.GetList();
            return View(headerValues);
        }
    }
}