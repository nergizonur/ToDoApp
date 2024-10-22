using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        DatabaseContext databaseContext = new DatabaseContext();
        public ActionResult Login()
        {
            return View();
        }



        public ActionResult LoginUser(string email, string password)
        {
            foreach (User user in databaseContext.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    HttpCookie cookie = new HttpCookie("UserId", user.Id.ToString())
                    {
                        Expires = DateTime.Now.AddDays(7)
                    };
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                    
                }
            }

            ViewBag.ErrorMessage = "Geçersiz e-posta veya şifre.";
            return View("Login"); 
        }



        public ActionResult Register()
        {
            return View();
        }




        public ActionResult RegisterUser(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
            {
                ViewBag.ErrorCode = 1;
                return View("Register");
            }

            var allEmails = databaseContext.Users.Select(u => u.Email).ToList();
            if (allEmails.Contains(user.Email))
            { 
                ViewBag.ErrorCode = 2;
                return View("Register");
            }

            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();

            ViewBag.ErrorCode = -1;
            return View("Register");
        }


    }
}