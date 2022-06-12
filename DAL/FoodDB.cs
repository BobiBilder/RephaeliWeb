using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using MasterProject.Models;
namespace MasterProject.DAL
{
    public class FoodDB:BaseDB
    {
        SelectSQL selectsql;
        public FoodDB()
        {
            this.selectsql = new SelectSQL();
            selectsql.TableName = "Food";
        }
        public DataSet GetAllFood()
        {
            List<SelectSQL> selectSQLs = new List<SelectSQL>();
            selectsql.Sql = "select * from Food";
            selectSQLs.Add(selectsql);
            SelectSQL select = new SelectSQL();
            select.Sql = "select * from FoodType";
            select.TableName = "FoodType";
            selectSQLs.Add(select);
            return this.Select(selectSQLs);
        }
        public DataSet GetAllFoodByType(int typeID)
        {
            List<SelectSQL> selectSQLs = new List<SelectSQL>();
            selectsql.Sql = "select * from Food Where FoodTypeID =" + typeID;
            selectSQLs.Add(selectsql);
            SelectSQL select = new SelectSQL();
            select.Sql = "select * from FoodType";
            select.TableName = "FoodType";
            selectSQLs.Add(select);
            return this.Select(selectSQLs);
        }
        public DataSet GetFood(int foodID)
        {
            List<SelectSQL> selectSQLs = new List<SelectSQL>();
            selectsql.Sql = "select * from Food where FoodID =" + foodID;
            selectSQLs.Add(selectsql);
            SelectSQL select = new SelectSQL();
            select.Sql = "select * from FoodType";
            select.TableName = "FoodType";
            selectSQLs.Add(select);
            return this.Select(selectSQLs);
        }

        //public override int AddBaseModel(BaseModel baseModel, OleDbCommand command)
        //{
        //    //Insert to Food
        //    //get foodID
        //    //Insert FoodType
        //    Food food = baseModel as Food;
        //    int rows = 0;
        //    string sql = string.Format(@"Insert into Food(
        //                                 FoodName, FoodDescription, FoodPrice, FoodPicture)
        //                                 values('{0}', '{1}', '{2}', '{3}')",
        //                                 food.FoodName, food.FoodDescription, food.FoodPrice, food.FoodPicture);
        //    command.CommandText = sql;
        //    rows = rows + command.ExecuteNonQuery();
        //    sql = "select @@Identity";
        //    string FoodID = command.ExecuteScalar().ToString();
        //    string typeSQL = string.Format("Insert into FoodType(id, )")
        //}

        public int AddFood(Food food)
        {
            string sql = string.Format(@"Insert into Food(
                                         FoodName, FoodDescription, FoodPrice, FoodPicture, FoodTypeID)
                                         values('{0}', '{1}', '{2}', '{3}', '{4}')",
                                         food.FoodName, food.FoodDescription, food.FoodPrice, food.FoodPicture, food.FoodType.id);
            return this.ChangeData(sql);
        }

        public DataTable GetFoodByType(int typeID)
        {
            if(typeID == 0)
            {
                selectsql.Sql = "select * from Food";
                return this.Select(this.selectsql);
            }
            else
            {
                selectsql.Sql = "select * from Food Where FoodTypeID =" + typeID;
                return this.Select(this.selectsql);
            }
        }
        public DataTable GetSpecificFood(int foodID)
        {
            selectsql.Sql = "select * from Food where FoodID =" + foodID;
            return this.Select(this.selectsql);
        }
    }
}