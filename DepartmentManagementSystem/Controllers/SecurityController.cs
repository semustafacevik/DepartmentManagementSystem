using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentManagementSystem.Models.EntityFramework;
using System.Web.Security;

namespace DepartmentManagementSystem.Controllers
{
    public class SecurityController : Controller
    {
        DepartmentManagementDBEntities db = new DepartmentManagementDBEntities();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(tblUser user)
        {
            var userInDB = db.tblUser.FirstOrDefault(m => m.u_Name == user.u_Name && m.u_Password == user.u_Password);

            if (userInDB != null)
            {
                FormsAuthentication.SetAuthCookie(userInDB.u_Name, false);
                return RedirectToAction("Index", "Department");
            }

            else
            {
                ViewBag.Message = "XXXXX";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}