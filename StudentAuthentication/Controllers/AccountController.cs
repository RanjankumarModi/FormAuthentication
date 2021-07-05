using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentAuthentication.Models;
using System.Web.Security;

namespace StudentAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Courses
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using(var context=new SchoolEntities())
            {
                bool isValid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Students");
                }
                ModelState.AddModelError("", "Invalid UserName/Password");
                return View();
            }


        }
        
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User model)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    context.Users.Add(model);
                    context.SaveChanges();

                }
            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Error");
            }
           
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}