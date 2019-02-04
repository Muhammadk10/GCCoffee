using Lab23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

     
namespace Lab23.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return View(db.UserRegistraion.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(userRegistration account)
        {
            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.UserRegistraion.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();

                ViewBag.Message = account.FirstName + " " + account.LastName + "successfully registered.";
            }
            

            {
                return View();
            }
        }

        public ActionResult Login()
        { 

        {
            return View();
        }
    }


    [HttpPost]
        public ActionResult Login(userRegistration user)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var usr = db.UserRegistraion.Single(u => u.UserID ==  u.UserID && u.Password == user.Password);
                if (user != null)
                {
                    Session["UserID"] = user.UserID.ToString();
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("Loggedin");
                }
                else
                {
                    ModelState.AddModelError(" ", "Username or Password is wrong.");
                }
            }
            return View();
        }


        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
    }

