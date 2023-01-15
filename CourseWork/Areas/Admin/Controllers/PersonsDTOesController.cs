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
    public class PersonsDTOesController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Admin/PersonsDTOes
        public ActionResult Index()
        {
            return View(db.Person.ToList());
        }

        // GET: Admin/PersonsDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsDTO personsDTO = db.Person.Find(id);
            if (personsDTO == null)
            {
                return HttpNotFound();
            }
            return View(personsDTO);
        }

        // GET: Admin/PersonsDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PersonsDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,Surname,Name,Patronymic,Birthday")] PersonsDTO personsDTO)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(personsDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personsDTO);
        }

        // GET: Admin/PersonsDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsDTO personsDTO = db.Person.Find(id);
            if (personsDTO == null)
            {
                return HttpNotFound();
            }
            return View(personsDTO);
        }

        // POST: Admin/PersonsDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,Surname,Name,Patronymic,Birthday")] PersonsDTO personsDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personsDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personsDTO);
        }

        // GET: Admin/PersonsDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsDTO personsDTO = db.Person.Find(id);
            if (personsDTO == null)
            {
                return HttpNotFound();
            }
            return View(personsDTO);
        }

        // POST: Admin/PersonsDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonsDTO personsDTO = db.Person.Find(id);
            db.Person.Remove(personsDTO);
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
