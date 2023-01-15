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
    public class RoomsDTOesController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Admin/RoomsDTOes
        public ActionResult Index()
        {
            var room = db.Room.Include(r => r.TypeOfRoom);
            return View(room.ToList());
        }

        // GET: Admin/RoomsDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomsDTO roomsDTO = db.Room.Find(id);
            if (roomsDTO == null)
            {
                return HttpNotFound();
            }
            return View(roomsDTO);
        }

        // GET: Admin/RoomsDTOes/Create
        public ActionResult Create()
        {
            ViewBag.TypeOfRoomID = new SelectList(db.TypeOfRoom, "TypeOfRoomID", "TypeOfRoomID");
            return View();
        }

        // POST: Admin/RoomsDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,TypeOfRoomID,PricePerDay")] RoomsDTO roomsDTO)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(roomsDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeOfRoomID = new SelectList(db.TypeOfRoom, "TypeOfRoomID", "TypeOfRoomID", roomsDTO.TypeOfRoomID);
            return View(roomsDTO);
        }

        // GET: Admin/RoomsDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomsDTO roomsDTO = db.Room.Find(id);
            if (roomsDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfRoomID = new SelectList(db.TypeOfRoom, "TypeOfRoomID", "TypeOfRoomID", roomsDTO.TypeOfRoomID);
            return View(roomsDTO);
        }

        // POST: Admin/RoomsDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,TypeOfRoomID,PricePerDay")] RoomsDTO roomsDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomsDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeOfRoomID = new SelectList(db.TypeOfRoom, "TypeOfRoomID", "TypeOfRoomID", roomsDTO.TypeOfRoomID);
            return View(roomsDTO);
        }

        // GET: Admin/RoomsDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomsDTO roomsDTO = db.Room.Find(id);
            if (roomsDTO == null)
            {
                return HttpNotFound();
            }
            return View(roomsDTO);
        }

        // POST: Admin/RoomsDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomsDTO roomsDTO = db.Room.Find(id);
            db.Room.Remove(roomsDTO);
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
