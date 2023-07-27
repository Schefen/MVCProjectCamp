using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager _imageFileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = _imageFileManager.GetList();
            return View(files);
        }
    }
}