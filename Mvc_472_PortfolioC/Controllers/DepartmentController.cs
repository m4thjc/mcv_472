﻿using System;
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

            List<SelectListItem> selectListItems = new List<SelectListItem>();



            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = department.Name,
                    Value = department.ID.ToString(),
                    Selected = department.IsSelected.HasValue ? (bool)department.IsSelected : false
                };
                selectListItems.Add(selectListItem);
            }



            ViewBag.Departments = selectListItems;// new SelectList(departments, "ID", "Name", "1");

            return View(departments);
        }
    }
}