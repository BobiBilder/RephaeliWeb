using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MasterProject.DAL
{
    public class OrderDB:BaseDB
    {
        SelectSQL selectsql;
        public OrderDB()
        {
            this.selectsql = new SelectSQL();
            selectsql.TableName = "Order";
        }
        public DataTable GetAllOrder()
        {
            selectsql.Sql = "select * from Order";
            return this.Select(this.selectsql);
        }
    }
}