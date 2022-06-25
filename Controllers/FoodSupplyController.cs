using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterProject.ViewModels;
using MasterProject.FoodSupplier;

namespace MasterProject.Controllers
{
    public class FoodSupplyController : Controller
    {
        // GET: FoodSupply
        public ActionResult FoodSupplyForm()
        {
            ServiceClient serviceClient = new ServiceClient();
            Food[] food = serviceClient.GetAllFood();
            return View(food);
        }

        [HttpPost]
        public ActionResult AddNewOrder(int[] FoodID)
        {
            ServiceClient serviceClient = new ServiceClient();
            MasterProject.FoodSupplier.Order order = new Order();
            order.buisnessID = "1";
            order.Date = DateTime.Now.ToString("dd/MM/yyyy");
            order.FoodIDs = FoodID;
            order.IsPaid = false;
            if (serviceClient.PutOrder(order))
            {
                TempData["message"] = "ההזמנה נעשתה בהצלחה";
                return RedirectToAction("FoodSupplyForm", "FoodSupply");
            }
            TempData["message"] = "אירעה שגיאה בהזמנה";
            return RedirectToAction("FoodSupplyForm", "FoodSupply");
        }

        public ActionResult MySupplyOrders()
        {
            ServiceClient serviceClient = new ServiceClient();
            SupplierOrderViewModel supplierOrderViewModel = new SupplierOrderViewModel();
            supplierOrderViewModel.orders = serviceClient.GetAllOrders("1");
            supplierOrderViewModel.food = serviceClient.GetAllFood();
            return View(supplierOrderViewModel);
        }

        [HttpPost]
        public ActionResult DeleteOrder(string[] OrderID)
        {
            ServiceClient serviceClient = new ServiceClient();
            if (serviceClient.DeleteOrder(OrderID))
            {
                TempData["message"] = "המחיקה נעשתה בהצלחה";
                return RedirectToAction("FoodSupplyForm", "FoodSupply");
            }
            TempData["message"] = "אירעה שגיאה במחיקה";
            return RedirectToAction("FoodSupplyForm", "FoodSupply");
        }
    }
}
