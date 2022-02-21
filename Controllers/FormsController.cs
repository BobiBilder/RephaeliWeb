using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterProject.BLL;
using MasterProject.ViewModels;
using MasterProject.Models;

namespace MasterProject.Controllers
{
    public class FridaysController : Controller
    {
        // GET: Fridays
        public ActionResult Fridays()
        {
            return View();
        }
    }
    public class WantedController : Controller
    {
        //GET: Wanted
        public ActionResult Wanted()
        {
            return View();
        }
    }
    public class EventRequestsController : Controller
    {
        //GET: EventRequests
        public ActionResult EventRequests()
        {
            OrderBLL eventBLL = new OrderBLL();
            EventRequestViewModel eventRequestViewModel = eventBLL.GetEventTypes();
            return View(eventRequestViewModel);
        }
    }
}