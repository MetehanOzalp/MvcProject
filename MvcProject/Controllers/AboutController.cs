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
    public class AboutController : Controller
    {
        // GET: About
        IAboutService _aboutService = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var abouts = _aboutService.GetAll();
            return View(abouts);
        }

        [HttpPost]
        public ActionResult Add(About about)
        {
            _aboutService.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutAddPartial()
        {
            return PartialView();
        }
    }
}