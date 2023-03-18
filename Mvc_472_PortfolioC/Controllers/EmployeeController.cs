using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;

namespace Mvc_472_PortfolioC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int? departmentId)
        {
            List<Employee> employee;

            EmployeeContext employeeContext = new EmployeeContext();

            if(departmentId != null)
            {
                employee = employeeContext.Employees.Where(e => e.DepartmentID == departmentId).ToList();
            }
            else
            {
                employee = employeeContext.Employees.ToList();
            }
            


            //Employee Employee = new Employee()
            //{
            //    EmployeeId = 101,
            //    Name = "John",
            //    Gender = "Male",
            //    City = "London"
            //};

            return View(employee);
        }

        //public ActionResult Index(int departmentId)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    List<Employee> employee = employeeContext.Employees.Where(e => e.DepartmentID == departmentId).ToList();


        //    //Employee Employee = new Employee()
        //    //{
        //    //    EmployeeId = 101,
        //    //    Name = "John",
        //    //    Gender = "Male",
        //    //    City = "London"
        //    //};

        //    return View(employee);
        //}

        // GET: Employee

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