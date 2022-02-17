using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.Models
{
    public class Food:BaseModel
    {
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public double FoodPrice { get; set; }
        public string FoodPicture { get; set; }
        public FoodType FoodType { get; set; }
    }
}