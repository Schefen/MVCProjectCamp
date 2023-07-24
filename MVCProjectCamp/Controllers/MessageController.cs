using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager _messageManager = new MessageManager(new EfMessageDal());
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
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost] 
        
        public ActionResult NewMessage(Message message)
        {
            return View();
        }

    }
}