using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationApp.Models;

namespace RegistrationApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
           RegUser user = new RegUser();
            return View(user);
        }

        [HttpPost]
        public ActionResult AddOrEdit(RegUser user)
        {
            using (RegDBEntities dbmodel = new RegDBEntities())
            {
                if(dbmodel.RegUsers.Any(x=> x.Username == user.Username))
                {
                    ViewBag.DublicateMessage = "This Username already exist";
                    return View("AddOrEdit", user);
                }
                dbmodel.RegUsers.Add(user);
                dbmodel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Your registration is succesful";
            return View("AddOrEdit", new RegUser());
        }
    }
}