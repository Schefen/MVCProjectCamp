using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeaderManager _headerManager = new HeaderManager(new EfHeaderDal());
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public PartialViewResult Index(int id=0)
        {
            var contentList = _contentManager.GetListByHeaderId(id);
            return PartialView(contentList);
        }   
        public ActionResult Headers()
        {
            var headerList = _headerManager.GetList();
            return View(headerList);
        }
    }
}