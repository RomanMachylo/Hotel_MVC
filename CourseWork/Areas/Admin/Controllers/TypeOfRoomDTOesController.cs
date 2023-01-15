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
    public class TypeOfRoomDTOesController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Admin/TypeOfRoomDTOes
        public ActionResult Index()
        {
            return View(db.TypeOfRoom.ToList());
        }

        // GET: Admin/TypeOfRoomDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfRoomDTO typeOfRoomDTO = db.TypeOfRoom.Find(id);
            if (typeOfRoomDTO == null)
            {
                return HttpNotFound();
            }
            return View(typeOfRoomDTO);
        }

        // GET: Admin/TypeOfRoomDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeOfRoomDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeOfRoomID,NumberOfRooms,Capacity,Name")] TypeOfRoomDTO typeOfRoomDTO)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfRoom.Add(typeOfRoomDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfRoomDTO);
        }

        // GET: Admin/TypeOfRoomDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfRoomDTO typeOfRoomDTO = db.TypeOfRoom.Find(id);
            if (typeOfRoomDTO == null)
            {
                return HttpNotFound();
            }
            return View(typeOfRoomDTO);
        }

        // POST: Admin/TypeOfRoomDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeOfRoomID,NumberOfRooms,Capacity,Name")] TypeOfRoomDTO typeOfRoomDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfRoomDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfRoomDTO);
        }

        // GET: Admin/TypeOfRoomDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfRoomDTO typeOfRoomDTO = db.TypeOfRoom.Find(id);
            if (typeOfRoomDTO == null)
            {
                return HttpNotFound();
            }
            return View(typeOfRoomDTO);
        }

        // POST: Admin/TypeOfRoomDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfRoomDTO typeOfRoomDTO = db.TypeOfRoom.Find(id);
            db.TypeOfRoom.Remove(typeOfRoomDTO);
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
