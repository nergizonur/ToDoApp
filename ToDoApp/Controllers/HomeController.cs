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



     

        public ActionResult Index(string id)
        {
            HttpCookie userCookie = Request.Cookies["UserId"];
            string userId = userCookie.Value;
            return View(databaseContext.Tasks.Where(task=>task.UserId.ToString()==userId).ToList());
        }

        public ActionResult TaskAdd(string taskText)
        {
            HttpCookie userCookie = Request.Cookies["UserId"];
            string userId = userCookie.Value;
            Task task = new Task() { TaskText=taskText.Trim(),UserId=userId};
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
        public ActionResult UpdateTask(string taskId,string taskText)
        {

            foreach (Task task in databaseContext.Tasks)
            {
                if (task.Id == int.Parse(taskId))
                {
                    task.TaskText = taskText.Trim();
                }
            }
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}