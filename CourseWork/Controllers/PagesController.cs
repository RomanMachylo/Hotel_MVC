using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CourseWork.Controllers
{
    public class PagesController : Controller
    {
        private HotelDb db = new HotelDb();
        // GET: Index/(page)
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {

            return View("About");
        }

        public ActionResult Rooms()
        {
            var room = db.Room.Include(r => r.TypeOfRoom);
            return View("Rooms", room.ToList());
        }

        public ActionResult Gallery()
        {

            return View("Gallery");
        }

        // GET: Staff
        public ActionResult Staff()
        {
            var Employees = db.Employee.Include(r => r.Persons).Include(r => r.Positions);
            return View(Employees.ToList());
        }

        // GET: Pages/Contact
        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }

        //// POST: Pages/Contact
        //[HttpPost]
        //public ActionResult Contact(UserViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View("Contact", model);

        //    if (!model.Password.Equals(model.ConfirmPassword))
        //    {
        //        ModelState.AddModelError("", "Password do not match!");
        //        return View("CreateAccount", model);
        //    }

        //    using (HotelDb db = new HotelDb())
        //    {
        //        if (db.User.Any(x => x.Username.Equals(model.Username)))
        //        {
        //            ModelState.AddModelError("", $"Username {model.Username} is taken!");
        //            model.Username = "";
        //            return View("CreateAccount", model);
        //        }

        //        UserDTO userDTO = new UserDTO()
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            EmailAdress = model.EmailAdress,
        //            Username = model.Username,
        //            Password = model.Password
        //        };

        //        db.User.Add(userDTO);
        //        db.SaveChanges();

        //        int id = userDTO.UserID;
        //        UserRoleDTO userRoleDTO = new UserRoleDTO()
        //        {
        //            UserID = id,
        //            RoleID = 2
        //        };

        //        db.UserRole.Add(userRoleDTO);
        //        db.SaveChanges();
        //    }

        //    TempData["SM"] = "You are now registered and can login.";

        //    return RedirectToAction("Login");
        //}

    }
}