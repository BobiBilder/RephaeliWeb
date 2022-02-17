using MasterProject.BLL;
using MasterProject.ViewModels;
using MasterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EventOrder
        public ActionResult EventOrders()
        {
            OrderBLL orderBLL = new OrderBLL();
            LoginUser user = Session["User"] as LoginUser;
            EventOrderViewModel eventOrderViewModel;
            if (user.IsManager)
            {
                eventOrderViewModel = orderBLL.GetAllEventOrderViewModel();
            }
            else
            {
                eventOrderViewModel = orderBLL.GetNotMyEventsViewModel(user);
            }
            return View(eventOrderViewModel);
        }
        public ActionResult MyEventOrders()
        {
            OrderBLL orderBLL = new OrderBLL();
            LoginUser user = Session["User"] as LoginUser;
            EventOrderViewModel eventOrderViewModel;
            eventOrderViewModel = orderBLL.GetMyEventsViewModel(user);
            return View(eventOrderViewModel);
        }
        public ActionResult EventOrderByOrderType(int typeID)
        {
            OrderBLL orderBLL = new OrderBLL();
            EventOrderViewModel eventOrderViewModel = orderBLL.GetEventOrderByTypeViewModel(typeID);
            return View(eventOrderViewModel);
        }

        [HttpPost]
        public ActionResult AssignWorkEvent(int[] orderID)
        {
            OrderBLL orderBLL = new OrderBLL();
            LoginUser user = Session["User"] as LoginUser;
            
            if (orderBLL.AssignedWork(orderID, user))
            {
                TempData["message"] = "ההרשמה לעבודה נעשתה בהצלחה";
                return RedirectToAction("EventOrders", "Employee");
            }
            TempData["message"] = "אירעה שגיאה בהרשמה לעבודה";
            return RedirectToAction("EventOrders", "Employee");
        }
        [HttpPost]
        public ActionResult RemoveWorkEvent(int[] orderID)
        {
            OrderBLL orderBLL = new OrderBLL();
            LoginUser user = Session["User"] as LoginUser;

            if (orderBLL.RemoveWork(orderID, user))
            {
                TempData["message"] = "היציאה מהעבודה נעשתה בהצלחה";
                return RedirectToAction("MyEventOrders", "Employee");
            }
            TempData["message"] = "אירעה שגיאה ביציאה מהעבודה";
            return RedirectToAction("MyEventOrders", "Employee");
        }



        public ActionResult AddFoodForm()
        {
            EmployeeBLL employeeBll = new EmployeeBLL();
            AddFoodViewModel addFoodViewModel = employeeBll.GetFoodTypeViewModel();
            return View(addFoodViewModel);
        }
        [HttpPost]
        public ActionResult AddFood(Food food, HttpPostedFileBase FoodPicture, int FoodTypeID)
        {
            string pictureName = System.IO.Path.GetFileName(FoodPicture.FileName);
            FoodPicture.SaveAs(Server.MapPath("~/Content/Images/Food/" + pictureName));
            food.FoodPicture = pictureName;
            food.FoodType = new FoodType();
            food.FoodType.id = FoodTypeID;
            FoodBLL foodBLL = new FoodBLL();
            if (foodBLL.AddFood(food))
            {
                TempData["message"] = "ההוספה נעשתה בהצלחה";
                return RedirectToAction("AddFoodForm", "Employee");
            }
            TempData["message"] = "אירעה שגיאה בהוספה";
            return RedirectToAction("AddFoodForm", "Employee");
        }
    }
}