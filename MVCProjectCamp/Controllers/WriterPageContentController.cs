using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterPageContentController : Controller
    {
        // GET: WriterPageContent
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string p)
        {
            Context context = new Context();
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault();
            var contentValues = _contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }   
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            Context context = new Context();
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            _contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}