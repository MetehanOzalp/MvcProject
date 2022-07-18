using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        IContactService _contactService = new ContactManager(new EfContactDal());
        IMessageService _messageService = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public ActionResult GetContactDetail(int id)
        {
            var contact = _contactService.GetById(id);
            return View(contact);
        }

        public PartialViewResult ContactSideBar()
        {
            var contacts = _contactService.GetAll();
            var inbox = _messageService.GetMessagesByReceiver("admin@admin.com");
            var sendbox = _messageService.GetMessagesBySender("admin@admin.com");
            ViewBag.ContactCount = contacts.Count;
            ViewBag.InboxCount = inbox.Count;
            ViewBag.SendboxCount = sendbox.Count;
            return PartialView();
        }
    }
}