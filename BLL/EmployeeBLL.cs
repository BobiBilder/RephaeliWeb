using MasterProject.DAL;
using MasterProject.Models;
using MasterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MasterProject.BLL
{
    public class EmployeeBLL
    {
        public AddFoodViewModel GetFoodTypeViewModel()
        {
            FoodTypeDB foodTypeDB = new FoodTypeDB();
            DataTable dt = foodTypeDB.GetAllFoodType();
            AddFoodViewModel addFoodViewModel = new AddFoodViewModel();
            addFoodViewModel.FoodTypes = new List<FoodType>();
            foreach (DataRow dr in dt.Rows)
            {
                FoodType foodType = new FoodType();
                foodType.FoodTypeName = dr["FoodTypeName"].ToString();
                foodType.id = int.Parse(dr["FoodTypeID"].ToString());
                addFoodViewModel.FoodTypes.Add(foodType);
            }
            return addFoodViewModel;
        }
    }
}