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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                _categoryService.Add(category);
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
            var category = _categoryService.GetById(id);
            if (category != null)
            {
                _categoryService.Delete(category);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            if (category != null)
            {
                return View(category);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                _categoryService.Update(category);
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