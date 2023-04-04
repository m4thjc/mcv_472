using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;
using JMBusinessLayer;
using PagedList;

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
       

            return View(employees.ToPagedList(1, 3));
        }

        public ActionResult IndexSearch(string searchby, string search, int? page, string sortby)
        {

            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.SortGenderParameter = sortby == "Gender" ? "Gender desc" : "Gender";

            EmployeeContext employeeContext = new EmployeeContext();
            var  employees = employeeContext.Employees.AsQueryable();

            if (searchby == "Gender")
            {
                employees = employees.Where(x => x.Gender == search || search == "");
            }
            else
            {
                employees = employees.Where(x => search == null || search == "" || x.Name.StartsWith(search));
            }

            switch (sortby)
            {
                case "Name desc":
                    employees = employees.OrderByDescending(x => x.Name);
                    break;
                case "Gender desc":
                    employees = employees.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    employees = employees.OrderBy(x => x.Gender);
                    break;
                default:
                    employees = employees.OrderBy(x => x.Name);
                    break;
            }

            //bool useBuisnessLibrary = false;
            //List<Employee> employees;
            //if (useBuisnessLibrary)
            //{
            //    employees = GetEmployeeListFromBusinessLayer();
            //}
            //else
            //{
            //    EmployeeContext employeeContext = new EmployeeContext();
            //    employees = employeeContext.Employees.ToList();

            //    if(searchBy == "Gender")
            //    {
            //        employees = employees.Where(x => x.Gender == search || search == "").ToList();
            //    }
            //    else
            //    {
            //        employees = employees.Where(x => search == null || search == "" || x.Name.StartsWith(search)).ToList();
            //    }
            //}



            //if (departmentId != null)
            //{
            //    employees = employees.Where(e => e.DepartmentID == departmentId).ToList();
            //}

            return View("~/Views/Employee/Index.cshtml", employees.ToPagedList(page ?? 1, 3));
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
            BuisnessLibEmployee employee = employeeBusinessLayer.Employees.Single(emp => emp.EmployeeId == id);

            UpdateModel<IEmployee>(employee);
                       
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}