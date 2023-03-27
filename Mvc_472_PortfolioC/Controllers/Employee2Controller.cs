using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;

namespace Mvc_472_PortfolioC.Controllers
{
    public class Employee2Controller : Controller
    {
        // GET: Employee2
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee2/Details/5
        public ActionResult Details(int Id)
        {
            
            Sample2 dbContext = new Sample2();
            var employee = dbContext.Employee2.Single(x => x.Id == Id);
            return View(employee);
        }

        public ActionResult CompanyDetails()
        {
            Company2 company2 = new Company2();
            var test = company2.CompanyDirector;


            return View(company2);
        }

        // GET: Employee2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee2/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee2/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee2/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
