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

        public ActionResult Index(string id)
        {
            HttpCookie userCookie = Request.Cookies["UserId"];
            string userId = userCookie?.Value;
            List<Task> tasks = databaseContext.Tasks.Where(task => task.UserId.ToString() == userId).ToList();
            return View(tasks);
        }

        public ActionResult TaskAdd(Task task)
        {
            HttpCookie userCookie = Request.Cookies["UserId"];
            string userId = userCookie?.Value;
            task.UserId = userId;
            ModelState.Clear();

            if (TryValidateModel(task, nameof(Task)))
            {
                databaseContext.Tasks.Add(task);
                databaseContext.SaveChanges();
            }
            
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
        public ActionResult UpdateTask(string taskId,string taskText,int orderScore)
        {

            foreach (Task task in databaseContext.Tasks)
            {
                if (task.Id == int.Parse(taskId))
                {
                    task.TaskText = taskText.Trim();
                    task.OrderScore = orderScore;
                }
            }
            databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}