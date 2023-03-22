using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;

namespace Mvc_472_PortfolioC.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
             
            List<Department> departments = employeeContext.Departments.ToList();

            ViewBag.Departments = new SelectList(departments, "ID", "Name");

            return View(departments);
        }
    }
}