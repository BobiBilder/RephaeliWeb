using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MasterProject.DAL
{
    public class EmployeeDB: BaseDB
    {
        SelectSQL selectsql;
        public EmployeeDB()
        {
            this.selectsql = new SelectSQL();
            selectsql.TableName = "Employee";
        }
        public DataTable GetAllEmployees()
        {
            selectsql.Sql = "select * from Employee";
            return this.Select(this.selectsql);
        }
    }
}