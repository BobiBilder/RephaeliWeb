using MasterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.ViewModels
{
    public class FoodViewModel
    {
        public List<Food> Food { get; set; }
        public List<FoodType> FoodTypes { get; set; }
    }
    public class SpecificFoodViewModel
    {
        public Food food { get; set; }
        public List<FoodType> FoodTypes { get; set; }
    }
    public class AddFoodViewModel
    {
        public List<FoodType> FoodTypes { get; set; }
    }
}