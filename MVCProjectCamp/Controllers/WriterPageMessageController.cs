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
    public class WriterPageMessageController : Controller
    {
        // GET: WriterPageMessage
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageList = _messageManager.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = _messageManager.GetListSendbox();
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

    }
}