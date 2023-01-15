using CourseWork.Models.Data;
using CourseWork.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CourseWork.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {

            return RedirectToAction("Login");
        }

        // GET: account/create-account
        [ActionName("create-account")]
        [HttpGet]
        public ActionResult CreateAccount()
        {

            return View("CreateAccount");
        }

        // POST: account/create-account
        [ActionName("create-account")]
        [HttpPost]
        public ActionResult CreateAccount(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View("CreateAccount", model);

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ModelState.AddModelError("", "Password do not match!");
                return View("CreateAccount", model);
            }

            using(HotelDb db = new HotelDb())
            {
                if(db.User.Any(x => x.Username.Equals(model.Username)))
                {
                    ModelState.AddModelError("", $"Username {model.Username} is taken!");
                    model.Username = "";
                    return View("CreateAccount", model);
                }

                UserDTO userDTO = new UserDTO()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAdress = model.EmailAdress,
                    Username = model.Username,
                    Password = model.Password
                };

                db.User.Add(userDTO);
                db.SaveChanges();

                int id = userDTO.UserID;
                UserRoleDTO userRoleDTO = new UserRoleDTO() 
                {
                    UserID = id,
                    RoleID = 2
                };

                db.UserRole.Add(userRoleDTO);
                db.SaveChanges();
            }

            TempData["SM"] = "You are now registered and can login.";

            return RedirectToAction("Login");
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            // Check for user's authorization 
            string userName = User.Identity.Name;

            if (!string.IsNullOrEmpty(userName))
                return RedirectToAction("user-profile");

            return View();
        }

        // POST: Account/Lpgin
        [HttpPost]
        public ActionResult Login(LoginUserViewModel model)
        {
            // Check for valid 
            if (!ModelState.IsValid)
                return View(model);
            bool isValid = false;

            using(HotelDb db = new HotelDb())
            {
                if (db.User.Any(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password)))
                    isValid = true;

                if (!isValid)
                {
                    ModelState.AddModelError("", "Invalid username or password!");
                    return View(model);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return Redirect(FormsAuthentication.GetRedirectUrl(model.Username, model.RememberMe));
                }
            }
        }

        // GET: /account/logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult UserNavPartial()
        {
            string userName = User.Identity.Name;

            UserNavPartialViewModel model;

            using(HotelDb db = new HotelDb())
            {
                UserDTO dto = db.User.FirstOrDefault(x => x.Username == userName);
                model = new UserNavPartialViewModel()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };
            }

            return PartialView(model);
        }


    }
}