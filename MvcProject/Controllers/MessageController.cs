using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        IMessageService _messageService = new MessageManager(new EfMessageDal());

        public ActionResult Inbox()
        {
            var messages = _messageService.GetMessagesByReceiver("admin@admin.com");
            ViewBag.InboxCount = messages.Count;
            return View(messages);
        }

        public ActionResult Sendbox()
        {
            var messages = _messageService.GetMessagesBySender("admin@admin.com");
            ViewBag.SendboxCount = messages.Count;
            return View(messages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            _messageService.Add(message);
            return RedirectToAction("Sendbox");
        }
    }
}