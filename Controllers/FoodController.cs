using MasterProject.BLL;
using MasterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterProject.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Food()
        {
            FoodBLL foodBll = new FoodBLL();
            FoodViewModel foodViewModel = foodBll.GetFoodAndFoodTypeViewModel();
            return View(foodViewModel);
        }
    }
    public class FoodByFoodTypeController : Controller
    {
        public ActionResult FoodByFoodType(int typeID)
        {
            FoodBLL foodBll = new FoodBLL();
            FoodViewModel foodViewModel = foodBll.GetFoodAndFoodTypeViewModel(typeID);
            return View(foodViewModel);
        }
        public ActionResult GetFoodByType(int typeID)
        {
            FoodBLL foodBLL = new FoodBLL();
            return PartialView(foodBLL.GetFoodByType(typeID));
        }

    }
    public class SpecificFoodController : Controller
    {
        //public ActionResult SpecificFood(int foodID)
        //{
        //    FoodBLL foodBll = new FoodBLL();
        //    SpecificFoodViewModel foodViewModel = foodBll.GetSpecificFood(foodID);
        //    return View(foodViewModel);
        //}
        public ActionResult GetSpecificFood(int foodID)
        {
            FoodBLL foodBLL = new FoodBLL();
            return PartialView(foodBLL.GetSpecificFood(foodID));
        }
    }
}