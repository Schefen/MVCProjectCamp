using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        ContactValidator _contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = _contactManager.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _contactManager.GetById(id);
            return View(contactValues);
        }

    }
}