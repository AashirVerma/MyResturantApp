using ResturantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ResturantApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new ResturantDbEntities())
            {
                bool isvalid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if(isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName,false);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", "Invalid username and Password");
                return View();
            }
            
        }
        public ActionResult Signup()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            using(var context=new ResturantDbEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
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