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
    public class ResidenceDTOesController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Admin/ResidenceDTOes
        public ActionResult Index()
        {
            Response.Headers.Add("Refresh", "5");
            var residence = db.Residence.Include(r => r.Rooms).Include(r => r.Users);
            return View(residence.ToList());
        }

        // GET: Admin/ResidenceDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidenceDTO residenceDTO = db.Residence.Find(id);
            if (residenceDTO == null)
            {
                return HttpNotFound();
            }
            return View(residenceDTO);
        }

        // GET: Admin/ResidenceDTOes/Create
        public ActionResult Create()
        {
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID");
            ViewBag.UserID = new SelectList(db.User, "UserID", "Username");
            return View();
        }

        // POST: Admin/ResidenceDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResidenceID,UserID,RoomID,StartDate,EndDate")] ResidenceDTO residenceDTO)
        {
            if (ModelState.IsValid)
            {
                db.Residence.Add(residenceDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", residenceDTO.RoomID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "Username", residenceDTO.UserID);
            return View(residenceDTO);
        }

        // GET: Admin/ResidenceDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidenceDTO residenceDTO = db.Residence.Find(id);
            if (residenceDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", residenceDTO.RoomID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "Username", residenceDTO.UserID);
            return View(residenceDTO);
        }

        // POST: Admin/ResidenceDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResidenceID,UserID,RoomID,StartDate,EndDate")] ResidenceDTO residenceDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residenceDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", residenceDTO.RoomID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "Username", residenceDTO.UserID);
            return View(residenceDTO);
        }

        // GET: Admin/ResidenceDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidenceDTO residenceDTO = db.Residence.Find(id);
            if (residenceDTO == null)
            {
                return HttpNotFound();
            }
            return View(residenceDTO);
        }

        // POST: Admin/ResidenceDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResidenceDTO residenceDTO = db.Residence.Find(id);
            db.Residence.Remove(residenceDTO);
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
