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
    public class PositionDTOesController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Admin/PositionDTOes
        public ActionResult Index()
        {
            return View(db.Position.ToList());
        }

        // GET: Admin/PositionDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionDTO positionDTO = db.Position.Find(id);
            if (positionDTO == null)
            {
                return HttpNotFound();
            }
            return View(positionDTO);
        }

        // GET: Admin/PositionDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PositionDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionID,Name,Salary")] PositionDTO positionDTO)
        {
            if (ModelState.IsValid)
            {
                db.Position.Add(positionDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(positionDTO);
        }

        // GET: Admin/PositionDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionDTO positionDTO = db.Position.Find(id);
            if (positionDTO == null)
            {
                return HttpNotFound();
            }
            return View(positionDTO);
        }

        // POST: Admin/PositionDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionID,Name,Salary")] PositionDTO positionDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positionDTO);
        }

        // GET: Admin/PositionDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionDTO positionDTO = db.Position.Find(id);
            if (positionDTO == null)
            {
                return HttpNotFound();
            }
            return View(positionDTO);
        }

        // POST: Admin/PositionDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PositionDTO positionDTO = db.Position.Find(id);
            db.Position.Remove(positionDTO);
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
