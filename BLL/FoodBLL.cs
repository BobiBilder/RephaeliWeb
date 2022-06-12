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
    public class FoodBLL
    {
        public FoodViewModel GetFoodAndFoodTypeViewModel()
        {
            FoodDB foodDB = new FoodDB();
            DataSet dsFood = foodDB.GetAllFood();
            FoodViewModel foodViewModel = new FoodViewModel();
            foodViewModel.Food = new List<Food>();
            DataView dv = dsFood.Tables["Food"].DefaultView;
            dv.Sort = "FoodName";
            DataTable dtSorted = dv.ToTable();
            foreach (DataRow dr in dtSorted.Rows)
            {
                Food food = new Food();
                food.FoodName = dr["FoodName"].ToString();
                food.FoodPrice = double.Parse(dr["FoodPrice"].ToString());
                food.FoodPicture = dr["FoodPicture"].ToString();
                food.FoodDescription = dr["FoodDescription"].ToString();
                food.id = int.Parse(dr["FoodID"].ToString());
                foodViewModel.Food.Add(food);
            }
            foodViewModel.FoodTypes = new List<FoodType>();
            foreach (DataRow dr in dsFood.Tables["FoodType"].Rows)
            {
                FoodType foodType = new FoodType();
                foodType.FoodTypeName = dr["FoodTypeName"].ToString();
                foodType.id = int.Parse(dr["FoodTypeID"].ToString());
                foodViewModel.FoodTypes.Add(foodType);
            }
            return foodViewModel;
        }
        public FoodViewModel GetFoodAndFoodTypeViewModel(int typeID)
        {
            FoodDB foodDB = new FoodDB();
            DataSet dsFood = foodDB.GetAllFoodByType(typeID);
            FoodViewModel foodViewModel = new FoodViewModel();
            foodViewModel.Food = new List<Food>();
            DataView dv = dsFood.Tables["Food"].DefaultView;
            dv.Sort = "FoodName";
            DataTable dtSorted = dv.ToTable();
            foreach (DataRow dr in dtSorted.Rows)
            {
                Food food = new Food();
                food.FoodName = dr["FoodName"].ToString();
                food.FoodPrice = double.Parse(dr["FoodPrice"].ToString());
                food.FoodPicture = dr["FoodPicture"].ToString();
                food.FoodDescription = dr["FoodDescription"].ToString();
                food.id = int.Parse(dr["FoodID"].ToString());
                foodViewModel.Food.Add(food);
            }
            foodViewModel.FoodTypes = new List<FoodType>();
            foreach (DataRow dr in dsFood.Tables["FoodType"].Rows)
            {
                FoodType foodType = new FoodType();
                foodType.FoodTypeName = dr["FoodTypeName"].ToString();
                foodType.id = int.Parse(dr["FoodTypeID"].ToString());
                foodViewModel.FoodTypes.Add(foodType);
            }
            return foodViewModel;
        }//not so needed??
        //public SpecificFoodViewModel GetSpecificFood(int foodID)
        //{
        //    FoodDB foodDB = new FoodDB();
        //    DataSet dsFood = foodDB.GetFood(foodID);
        //    SpecificFoodViewModel foodViewModel = new SpecificFoodViewModel();
        //    foodViewModel.food = new Food();
        //    foreach (DataRow dr in dsFood.Tables["Food"].Rows)
        //    {
        //        foodViewModel.food.FoodName = dr["FoodName"].ToString();
        //        foodViewModel.food.FoodPrice = double.Parse(dr["FoodPrice"].ToString());
        //        foodViewModel.food.FoodPicture = dr["FoodPicture"].ToString();
        //        foodViewModel.food.FoodDescription = dr["FoodDescription"].ToString();
        //        foodViewModel.food.id = int.Parse(dr["FoodID"].ToString());
        //        foodViewModel.food.FoodType = new FoodType();
        //        foodViewModel.food.FoodType.id = int.Parse(dr["FoodTypeID"].ToString());
        //    }
        //    foodViewModel.FoodTypes = new List<FoodType>();
        //    foreach (DataRow dr in dsFood.Tables["FoodType"].Rows)
        //    {
        //        FoodType foodType = new FoodType();
        //        foodType.FoodTypeName = dr["FoodTypeName"].ToString();
        //        foodType.id = int.Parse(dr["FoodTypeID"].ToString());
        //        foodViewModel.FoodTypes.Add(foodType);
        //    }
        //    return foodViewModel;
        //}

        public bool AddFood(Food food)
        {
            FoodDB foodDB = new FoodDB();
            return foodDB.AddFood(food) > 0;
        }

        public List<Food> GetFoodByType(int typeID)
        {
            FoodDB foodDB = new FoodDB();
            DataTable dt = foodDB.GetFoodByType(typeID);
            List<Food> lFood = new List<Food>();
            DataView dv = dt.DefaultView;
            dv.Sort = "FoodName";
            DataTable dtSorted = dv.ToTable();
            foreach (DataRow dr in dtSorted.Rows)
            {
                Food food = new Food();
                food.FoodName = dr["FoodName"].ToString();
                food.FoodPrice = double.Parse(dr["FoodPrice"].ToString());
                food.FoodPicture = dr["FoodPicture"].ToString();
                food.FoodDescription = dr["FoodDescription"].ToString();
                food.id = int.Parse(dr["FoodID"].ToString());
                lFood.Add(food);
            }
            return lFood;
        }
        public Food GetSpecificFood(int foodID)
        {
            FoodDB foodDB = new FoodDB();
            DataTable dt = foodDB.GetSpecificFood(foodID);
            Food food = new Food();
            foreach (DataRow dr in dt.Rows)
            {
                food.FoodName = dr["FoodName"].ToString();
                food.FoodPrice = double.Parse(dr["FoodPrice"].ToString());
                food.FoodPicture = dr["FoodPicture"].ToString();
                food.FoodDescription = dr["FoodDescription"].ToString();
                food.id = int.Parse(dr["FoodID"].ToString());
            }
            return food;
        }
    }
}