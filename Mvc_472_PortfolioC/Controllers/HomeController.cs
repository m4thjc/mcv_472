﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_472_PortfolioC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception("Something went wrong");
            return View();
        }

        [ChildActionOnly]
        public ActionResult Countries(List<string> countryNames)
        {
            countryNames = countryNames ?? new List<string>() { "test", "d" };

            return View(countryNames);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}