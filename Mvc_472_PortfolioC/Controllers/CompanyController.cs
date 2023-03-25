using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;

namespace Mvc_472_PortfolioC.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var company = new Company("JohnsCompany");
            ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
            ViewBag.CompanyName = company.CompanyName;
            return View();
        }

        public ActionResult Index1()
        {
            var company = new Company("JohnsCompany");
            return View(company);
        }
    }
}