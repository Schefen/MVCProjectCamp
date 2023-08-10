using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterPageMessageController : Controller
    {
        // GET: WriterPageMessage
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
			string p = (string)Session["WriterMail"];
			var messageList = _messageManager.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
			string p = (string)Session["WriterMail"];
			var messageList = _messageManager.GetListSendbox(p);
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = _messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = _messageManager.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]

        public ActionResult NewMessage(Message message)
        {
			string sender = (string)Session["WriterMail"];
			ValidationResult results = _messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.MessageSender = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}