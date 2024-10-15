using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    
    public class HomeController : Controller
    {
        DatabaseContext databaseContext = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(databaseContext.Tasks.ToList());
        }

        public ActionResult TaskAdd(string taskText)
        {
            Task task = new Task() { TaskText=taskText};
            databaseContext.Tasks.Add(task);
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(string taskId)
        {
            
            foreach (Task task in databaseContext.Tasks)
            {
                if (task.Id == int.Parse(taskId))
                {
                    databaseContext.Tasks.Remove(task); 
                }
            }
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}