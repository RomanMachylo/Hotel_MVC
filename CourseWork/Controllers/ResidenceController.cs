using CourseWork.Models.Data;
using CourseWork.Models.ViewModels.Pages;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace CourseWork.Controllers
{
    [Authorize]
    public class ResidenceController : Controller
    {
        private HotelDb db = new HotelDb();

        // GET: Residence
        public ActionResult Index()
        {
            var residence = db.Residence.Include(r => r.Rooms).Include(r => r.Users).Where(r => r.Users.Username == User.Identity.Name);
            return View(residence.ToList());
        }

        // GET: Residence/Details/5
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

        // GET: Residence/Create
        public ActionResult Create()
        {
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID");
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName");
            return View();
        }

        // POST: Residence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResidenceID,UserID,RoomID,StartDate,EndDate")] ResidenceDTO residenceDTO)
        {
            if (ModelState.IsValid)
            {
                using (HotelDb db = new HotelDb())
                {
                    var roomsIDBooked = db.Residence.Where(r =>
                        ((residenceDTO.StartDate >= r.StartDate) && (residenceDTO.StartDate <= r.EndDate)) ||
                        ((residenceDTO.EndDate >= r.StartDate) && (residenceDTO.EndDate <= r.EndDate)) ||
                        ((residenceDTO.StartDate <= r.StartDate) && (residenceDTO.EndDate >= r.StartDate) && (residenceDTO.EndDate <= r.EndDate)) ||
                        ((residenceDTO.StartDate >= r.StartDate) && (residenceDTO.StartDate <= r.EndDate) && (residenceDTO.EndDate >= r.EndDate)) ||
                        ((residenceDTO.StartDate <= r.StartDate) && (residenceDTO.EndDate >= r.EndDate))
                    ).Select(r => r.RoomID).ToList();

                    if (roomsIDBooked.Contains(residenceDTO.RoomID))
                    {
                        TempData["alertMessage"] = "Sorry, this room is booked for your date. Please, check free rooms. ";
                        return RedirectToAction("Index");
                    }

                    UserDTO dto = db.User.FirstOrDefault(x => x.Username == User.Identity.Name);
                    residenceDTO.UserID = dto.UserID;
                }
                db.Residence.Add(residenceDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", residenceDTO.RoomID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName", residenceDTO.UserID);
            return View(residenceDTO);
        }



        // POST: Residence/SearchResult
        public ActionResult SearchResult(SearchRoomViewModel vm)
        {
            if (vm.StartDate == null || vm.EndDate == null || vm.StartDate > vm.EndDate)
            {
                if (vm.StartDate == null || vm.EndDate == null)
                    TempData["alertMessage"] = "Please, enter your dates.";
                if (vm.StartDate > vm.EndDate)
                    TempData["alertMessage"] = "Wrong Date. Please, try again.";
                return View();
            }

            using (HotelDb db = new HotelDb())
            {
                var roomsBooked = db.Residence.Where(r =>
                    ((vm.StartDate >= r.StartDate) && (vm.StartDate <= r.EndDate)) ||
                    ((vm.EndDate >= r.StartDate) && (vm.EndDate <= r.EndDate)) ||
                    ((vm.StartDate <= r.StartDate) && (vm.EndDate >= r.StartDate) && (vm.EndDate <= r.EndDate)) ||
                    ((vm.StartDate >= r.StartDate) && (vm.StartDate <= r.EndDate) && (vm.EndDate >= r.EndDate)) ||
                    ((vm.StartDate <= r.StartDate) && (vm.EndDate >= r.EndDate))
                );

                var availableRooms = db.Room.Where(r => !roomsBooked.Any(b => b.RoomID == r.RoomID))
                    .Include(x => x.TypeOfRoom).ToList();

                foreach(var room in availableRooms)
                {
                    vm.Room.Add(room);
                }

            }
            return View(vm);
        }

        // GET: Admin/Residence/Delete/5
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

        // POST: Admin/Residence/Delete/5
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
