using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;
using JMBusinessLayer;

namespace Mvc_472_PortfolioC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int? departmentId)
        {
            bool useBuisnessLibrary = false;
            List<Employee> employees;
            if (useBuisnessLibrary)
            {
                employees = GetEmployeeListFromBusinessLayer();
            }
            else
            {
                EmployeeContext employeeContext = new EmployeeContext();
                employees = employeeContext.Employees.ToList();
            }

            

            if(departmentId != null)
            {
                employees = employees.Where(e => e.DepartmentID == departmentId).ToList();
            }
       

            return View(employees);
        }

        public List<Employee> GetEmployeeListFromBusinessLayer()
        {
            List<Employee> employees;

            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

            employees = employeeBusinessLayer.Employees.Select(be => new Employee(be.EmployeeId, be.Name,be.Gender, be.City, be.DepartmentID)).ToList();

            return employees;
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            BuisnessLibEmployee employee = new BuisnessLibEmployee();
            UpdateModel(employee);

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Where(x=> x.EmployeeId == id).FirstOrDefault();


            //Employee Employee = new Employee()
            //{
            //    EmployeeId = 101,
            //    Name = "John",
            //    Gender = "Male",
            //    City = "London"
            //};

            return View(employee);
        }
    }
}