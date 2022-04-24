using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterProject.FoodSupplier;

namespace MasterProject.Controllers
{
    public class FoodSupplyController : Controller
    {
        // GET: FoodSupply
        public ActionResult FoodSupplyForm()
        {
            return View(0.0);
        }

        public ActionResult GetFood()
        {
            ServiceClient service = new ServiceClient();
            FoodSupplier.Food[] list = ServiceClient.GetAllFood();
            return View(list);
        }

        public ActionResult PutSupply(int num1, int num2, int action)
        {
            ServiceClient service = new ServiceClient();
            //double sum = 0;
            //switch (action)
            //{
            //    case 1:
            //        sum = service.Plus(num1, num2);
            //        break;
            //    case 2:
            //        sum = service.Minus(num1, num2);
            //        break;
            //    case 3:
            //        sum = service.Multi(num1, num2);
            //        break;
            //    case 4:
            //        sum = service.Divide(num1, num2);
            //        break;
            //}
            return View("FoodSupplyForm"/*, sum*/);
        }
    }
}