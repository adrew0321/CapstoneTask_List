using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Task_List.Models;

namespace Capstone_Task_List.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Task_ListEntities ORM = new Task_ListEntities();
            ViewBag.Task = ORM.Tasks.ToList();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddUser(User NewUser)
        {
            Task_ListEntities ORM = new Task_ListEntities();

            //send NewUser to DB
            ORM.Users.Add(NewUser);

            //save to DB (Sync)
            ORM.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult AddTask()
        {
            return View();
        }

        public ActionResult TaskComplete(int Task_ID)
        {
            Task_ListEntities ORM = new Task_ListEntities();
            
            //Locates object by Primary Key
            Task TaskCompleted = ORM.Tasks.Find(Task_ID);

            //Sets TaskCompleted to True
            if (TaskCompleted.Task_Complete == false)
            {
                TaskCompleted.Task_Complete = true;
            }
            else
            {
                TaskCompleted.Task_Complete = false;
            }

            //Updates State of Entity into...
            ORM.Entry(TaskCompleted).State = System.Data.Entity.EntityState.Modified;

            //Saves to DB
            ORM.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteTask(int Task_ID)
        {
            Task_ListEntities ORM = new Task_ListEntities();

            //Finds Task to be deleted by looking through the ORM for specified Task_ID
            Task TaskToBeDeleted = ORM.Tasks.Find(Task_ID);

            //Remove Task_ID
            ORM.Tasks.Remove(TaskToBeDeleted);

            //Save Changes to DB
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}