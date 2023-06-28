using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var WriterValues = _writerManager.GetList();
            return View(WriterValues);
        }
    }
}