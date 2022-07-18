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
    public class HeadingController : Controller
    {
        // GET: Heading
        IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        IWriterService _writerService = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categories = (from c in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = c.Name,
                                                   Value = c.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            List<SelectListItem> writers = (from w in _writerService.GetAll()
                                            select new SelectListItem
                                            {
                                                Text = w.Name + " " + w.SurName,
                                                Value = w.WriterId.ToString()
                                            }).ToList();
            ViewBag.writers = writers;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            _headingService.Add(heading);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var heading = _headingService.GetById(id);
            if (heading != null)
            {
                _headingService.Delete(heading);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var heading = _headingService.GetById(id);
            if (heading != null)
            {
                _headingService.ChangeStatus(heading);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var heading = _headingService.GetById(id);
            if (heading != null)
            {
                List<SelectListItem> categories = (from c in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.Name,
                                                       Value = c.CategoryId.ToString()
                                                   }).ToList();
                ViewBag.categories = categories;
                List<SelectListItem> writers = (from w in _writerService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = w.Name + " " + w.SurName,
                                                    Value = w.WriterId.ToString()
                                                }).ToList();
                ViewBag.writers = writers;
                return View(heading);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("Index");
        }
    }
}