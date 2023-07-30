using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}