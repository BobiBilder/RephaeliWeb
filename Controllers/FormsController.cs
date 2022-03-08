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
        
        [HttpPost]
        public ActionResult EventForm(string EventTypeID, string Invitations, string year, string month, string day, string notes)
        {
            string date = day + "/" + month + "/" + year;
            OrderEvent order = new OrderEvent();
            LoginUser user = Session["User"] as LoginUser;
            order.ClientID = user.id;
            order.IsPayed = false;
            order.OrderDate = date;
            order.OrderTime = DateTime.Now.ToString("HH:mm");
            order.Event = new NewEvent();
            order.Event.EventType = new EventType();
            order.Event.EventType.id = int.Parse(EventTypeID);
            order.Event.Invitations = int.Parse(Invitations);
            order.Event.Notes = notes;
            OrderBLL eventBLL = new OrderBLL();
            if (eventBLL.NewEvent(order))
            {
                TempData["message"] = "ההזמנת האירוע התקבלה בהצלחה";
                return RedirectToAction("HomePage", "Home");
            }
            TempData["message"] = "אירעה שגיאה בהזמנת האירוע";
            return RedirectToAction("HomePage", "Home");
        }

    }
}