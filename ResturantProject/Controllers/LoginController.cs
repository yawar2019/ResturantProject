using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResturantProject.Models;

namespace ResturantProject.Controllers
{
    [System.Runtime.InteropServices.Guid("063B46B0-6C03-4F8B-A4DC-BF26E459A6E5")]
    public class LoginController : Controller
    {
        // GET: Home Divya Prakash
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            //Custom cp = new Custom();
            if (ModelState.IsValid)
            {
                using (ResturantProjectEntities db = new ResturantProjectEntities())
                {
                    user.RoleId = 1;

                    db.UsersSet.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.Username + " successfully registered. You may now login with your credential";
            }
            return RedirectToAction("Login");
        }

       

        [HttpPost]
        public ActionResult Login(Users user)
        {
            //Custom cp = new Custom();
            using (ResturantProjectEntities db = new ResturantProjectEntities())
            {
                // user.Password = cp.Encrypt(user.Password);
                var usr = db.UsersSet.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["RoleId"] = usr.RoleId.ToString();
                    return RedirectToAction("Food_Table_Booking", "Food_Table_Booking");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["Username"] = null;
            Session["RoleId"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}