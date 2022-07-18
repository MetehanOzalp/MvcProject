using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        IWriterService _writerService = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var categoryCount = _categoryService.GetAll().Count();
            var headingCountByCategoryName = _headingService.GetByCategoryName("Dizi").Count();
            var writerCount = _writerService.GetWritersByWithTheLetterInName("a").Count();
            var mostRecurringCategoryName = _headingService.GetMostRecurringCategory();
            var difference = _categoryService.GetDifferenceBetweenTrueAndFalse();
            ViewBag.categoryCount = categoryCount;
            ViewBag.headingCountByCategoryName = headingCountByCategoryName;
            ViewBag.writerCount = writerCount;
            ViewBag.mostRecurringCategoryName = mostRecurringCategoryName;
            ViewBag.difference = difference;
            return View();
        }
    }
}