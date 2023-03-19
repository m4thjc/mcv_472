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

            employees = employeeBusinessLayer.Employees.Select(be => new Employee(be.EmployeeId, be.Name,be.Gender, be.City, be.DepartmentID, be.DateOfBirth)).ToList();

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
            TryUpdateModel(employee);

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

            return View(employee);
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int Id)
        {
            var AllEmployees = GetEmployeeListFromBusinessLayer();
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = AllEmployees.Single(emp => emp.EmployeeId == Id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            //Create a buisness lib employee
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            var employee = employeeBusinessLayer.Employees.Single(emp => emp.EmployeeId == id);

            UpdateModel(employee, new string[] {"EmployeeId", "Gender", "City", "DepartmentId", "DateOfBirth" });
                        
            if (ModelState.IsValid)
            {
                
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }

    }
}