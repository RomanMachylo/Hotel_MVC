using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseWork.Models.Data;

namespace CourseWork.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeDTOesController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Admin/EmployeeDTOes
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: Admin/EmployeeDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDTO = db.Employee.Find(id);
            if (employeeDTO == null)
            {
                return HttpNotFound();
            }
            return View(employeeDTO);
        }

        // GET: Admin/EmployeeDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EmployeeDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,PersonID,PositionID,PhoneNumber")] EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employeeDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDTO);
        }

        // GET: Admin/EmployeeDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDTO = db.Employee.Find(id);
            if (employeeDTO == null)
            {
                return HttpNotFound();
            }
            return View(employeeDTO);
        }

        // POST: Admin/EmployeeDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,PersonID,PositionID,PhoneNumber")] EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDTO);
        }

        // GET: Admin/EmployeeDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDTO = db.Employee.Find(id);
            if (employeeDTO == null)
            {
                return HttpNotFound();
            }
            return View(employeeDTO);
        }

        // POST: Admin/EmployeeDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDTO employeeDTO = db.Employee.Find(id);
            db.Employee.Remove(employeeDTO);
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
