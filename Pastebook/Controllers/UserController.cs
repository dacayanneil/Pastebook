using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastebook.Controllers
{
    public class UserController : Controller
    {
        UserManager userManger = new UserManager();
        RegistrationViewModel registrationViewModel = new RegistrationViewModel();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            registrationViewModel.CountryList = userManger.RetreiveAllCountry();
            return View(registrationViewModel);
        }

        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            if (userManger.CheckEmailAddress(user.EmailAddress) == 0)
            {
                ModelState.AddModelError("user.EmailAddress", "Email already exists");
            }
            if (ModelState.IsValid)
            {
                userManger.AddUser(user);
                return RedirectToAction("Home", "Content");
            }
            else
            {
                registrationViewModel.CountryList = userManger.RetreiveAllCountry();
                registrationViewModel.User = user;
                return View(registrationViewModel);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {

            if (ModelState.IsValid)
            {
                if(userManger.Login(user) == 1)
                {
                    var currentUser = userManger.RetrieveSpecificUser(user.EmailAddress);
                    Session["currentID"] = currentUser.ID;
                    return RedirectToAction("Home", "Content");
                }
                else
                {
                    return RedirectToAction("Welcome");
                }
            }
            else
            {
                return RedirectToAction("Welcome");
            }
        }

        public JsonResult CheckEmailAddress(string email)
        {
            var process = userManger.CheckEmailAddress(email);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Welcome()
        {
            registrationViewModel.CountryList = userManger.RetreiveAllCountry();
            return View(registrationViewModel);
        }

        public ActionResult UserList()
        {
            var userList = userManger.RetrieveAllUser();
            return View(userList);
        }
    }
}