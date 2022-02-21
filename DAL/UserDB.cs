using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MasterProject.DAL
{
    public class UserDB:BaseDB
    {
        SelectSQL selectSql = new SelectSQL();
        public DataTable UserLogin(string IDnum, string userPass, bool isWorker)
        {
            if (isWorker)
            {
                this.selectSql.TableName = "Employee";
                this.selectSql.Sql = @"Select Employee.IDnum, Employee.FirstName, Employee.LastName, Employee.EmployeeID, Employee.PhoneNumber,Employee.IsManager FROM Employee Where IDnum ='" + IDnum + "' AND Password ='" + userPass + "'";
            }
            else
            {
                this.selectSql.TableName = "Clients";
                this.selectSql.Sql = @"Select Clients.IDnum, Clients.FirstName, Clients.LastName, Clients.ClientID, Clients.PhoneNumber FROM Clients Where IDnum ='" + IDnum + "' AND Password ='" + userPass + "'";
            }
            return this.Select(this.selectSql);
        }
    }
}