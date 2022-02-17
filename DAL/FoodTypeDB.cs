using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MasterProject.DAL
{
    public class FoodTypeDB:BaseDB
    {
        SelectSQL selectsql;
        public FoodTypeDB()
        {
            this.selectsql = new SelectSQL();
            selectsql.TableName = "FoodType";
        }
        public DataTable GetAllFoodType()
        {
            selectsql.Sql = "select * from FoodType";
            return this.Select(this.selectsql);
        }
    }
}