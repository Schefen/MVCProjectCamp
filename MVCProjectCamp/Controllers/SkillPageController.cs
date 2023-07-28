using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class SkillPageController : Controller
    {
        // GET: SkillPage
        SkillManager _skillManager = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var values = _skillManager.GetList();
            return View(values);
        }
    }
}