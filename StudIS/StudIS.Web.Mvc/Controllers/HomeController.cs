﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudIS.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Boolean error = false)
        {
            if ((String)Session["userType"] == "Student")
                return RedirectToAction("Index", "Student");
            else if ((String)Session["userType"] == "Lecturer")
                return RedirectToAction("Index", "Lecturer");


            return View(error);
        }
    }
}