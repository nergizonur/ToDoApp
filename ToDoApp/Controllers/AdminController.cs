using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DatabaseContext databaseContext = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveColor(OrderColor color)
        {
            if (!databaseContext.Colors.Any(c => c.OrderScore == color.OrderScore))
            {
                databaseContext.Colors.Add(color);
                databaseContext.SaveChanges();
            }
            else
            {
                databaseContext.Colors.Where(c => c.OrderScore == color.OrderScore).ToList()[0].ColorCode = color.ColorCode;
                databaseContext.SaveChanges();
            }
            return View("Index");
        }
    }
}