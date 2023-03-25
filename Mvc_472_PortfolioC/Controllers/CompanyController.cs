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

        [HttpGet]
        [ActionName("Index1")]
        public ActionResult Index1Get()
        {
            var company = new Company("JohnsCompany");
            return View(company);
        }

        [HttpPost]
        [ActionName("Index1")]
        public string Index1(Company company)
        {
            if (string.IsNullOrEmpty(company.SelectedDepartment))
            {
                return "You did not select any departments";
            }
            else
            {
                return "You selected department with ID = " + company.SelectedDepartment ; 
            }
        }


    }
}