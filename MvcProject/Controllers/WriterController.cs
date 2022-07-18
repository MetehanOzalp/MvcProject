using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        IWriterService _writerService = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var writers = _writerService.GetAll();
            return View(writers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index");
            }
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var writer = _writerService.GetById(id);
            if (writer != null)
            {
                _writerService.Delete(writer);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var writer = _writerService.GetById(id);
            if (writer != null)
            {
                return View(writer);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("Index");
            }
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }
}