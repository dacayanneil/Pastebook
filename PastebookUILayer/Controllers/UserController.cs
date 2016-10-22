using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PastebookEFModel;
using PastebookDataAccessLayer;
using PastebookBusinessLogicLayer;

namespace PastebookUILayer.Controllers
{
    public class UserController : Controller
    {
        UserBusinessLogic userBusinessLogic = new UserBusinessLogic();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            UserRegistrationModel userRegistrationModel = new UserRegistrationModel();
            var genericDataAccess = new GenericDataAccess<PB_REF_COUNTRY>();
            userRegistrationModel.CountryList = genericDataAccess.Retrieve();
            return View(userRegistrationModel);
        }

        [HttpPost]
        public ActionResult Registration(UserRegistrationModel userRegistrationModel)
        {
            if (ModelState.IsValid)
            {
                userBusinessLogic.Register(userRegistrationModel.User);
                Session["currentID"] = userBusinessLogic.GetUserIDbyEmail(userRegistrationModel.User.EMAIL_ADDRESS);
                return RedirectToAction("Home", "App");
                //return RedirectToAction("Home", "Content");
            }
            else
            {
                var genericDataAccess = new GenericDataAccess<PB_REF_COUNTRY>();
                userRegistrationModel.CountryList = genericDataAccess.Retrieve();
                return View(userRegistrationModel);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(PB_USER user)
        {
            if (ModelState.IsValid)
            {
                if (userBusinessLogic.Login(user) == 1)
                {
                    var userBusinessLogic = new UserBusinessLogic();
                    Session["currentID"] = userBusinessLogic.GetUserIDbyEmail(user.EMAIL_ADDRESS);
                    return RedirectToAction("Home", "App");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}