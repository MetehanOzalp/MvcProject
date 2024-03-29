﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        IContentService _contentService = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contents = _contentService.GetContentsByHeadingId(id);
            return View(contents);
        }
    }
}