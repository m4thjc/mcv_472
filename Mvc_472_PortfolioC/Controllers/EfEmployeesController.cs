using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_472_PortfolioC.Models;

namespace Mvc_472_PortfolioC.Controllers
{
    public class EfEmployeesController : Controller
    {
        private SampleEntities db = new SampleEntities();

        // GET: EfEmployees
        public ActionResult Index()
        {
            var efEmployees = db.EfEmployees.Include(e => e.EfDepartment);
            return View(efEmployees.ToList());
        }

        // GET: EfEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EfEmployee efEmployee = db.EfEmployees.Find(id);
            if (efEmployee == null)
            {
                return HttpNotFound();
            }
            return View(efEmployee);
        }

        // GET: EfEmployees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.EfDepartments, "Id", "Name");
            return View();
        }

        // POST: EfEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Gender,City,DepartmentId,EmployeeId,DateOfBirth")] EfEmployee efEmployee)
        {
            if (ModelState.IsValid)
            {
                db.EfEmployees.Add(efEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.EfDepartments, "Id", "Name", efEmployee.DepartmentId);
            return View(efEmployee);
        }

        // GET: EfEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EfEmployee efEmployee = db.EfEmployees.Find(id);
            if (efEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.EfDepartments, "Id", "Name", efEmployee.DepartmentId);
            return View(efEmployee);
        }

        // POST: EfEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Gender,City,DepartmentId,EmployeeId,DateOfBirth")] EfEmployee efEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(efEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.EfDepartments, "Id", "Name", efEmployee.DepartmentId);
            return View(efEmployee);
        }

        // GET: EfEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EfEmployee efEmployee = db.EfEmployees.Find(id);
            if (efEmployee == null)
            {
                return HttpNotFound();
            }
            return View(efEmployee);
        }

        // POST: EfEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EfEmployee efEmployee = db.EfEmployees.Find(id);
            db.EfEmployees.Remove(efEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
