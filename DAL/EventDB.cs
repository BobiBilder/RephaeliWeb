using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MasterProject.Models;

namespace MasterProject.DAL
{
    public class EventDB:BaseDB
    {
        SelectSQL selectsql;
        public EventDB()
        {
            this.selectsql = new SelectSQL();
            selectsql.TableName = "Events";
        }

        public DataSet GetAllEvent()
        {
            List<SelectSQL> selectSQLs = new List<SelectSQL>();
            selectsql.Sql = "select * from [Event]";
            selectSQLs.Add(selectsql);

            SelectSQL select1 = new SelectSQL();
            select1.Sql = "select * from [Order]";
            select1.TableName = "Orders";
            selectSQLs.Add(select1);

            SelectSQL select2 = new SelectSQL();
            select2.Sql = "select * from Clients";
            select2.TableName = "Clients";
            selectSQLs.Add(select2);

            SelectSQL select3 = new SelectSQL();
            select3.Sql = "select * from [EventType]";
            select3.TableName = "EventTypes";
            selectSQLs.Add(select3);
            return this.Select(selectSQLs);
        }
        public DataTable GetAllEventTypes()
        {
            SelectSQL selectType = new SelectSQL();
            selectType.Sql = "select * from [EventType]";
            selectType.TableName = "EventTypes";
            return this.Select(selectType);
        }

        public DataTable helper1(LoginUser user)
        {
            SelectSQL select= new SelectSQL();
            select.Sql = "select EmployeeEvent.OrderID from EmployeeEvent WHERE EmployeeID = " + user.id;
            select.TableName = "OrderIDs";
            return this.Select(select);
        }
        public DataSet GetAllEventByType(int typeID)
        {
            List<SelectSQL> selectSQLs = new List<SelectSQL>();
            selectsql.Sql = "select * from [Event] Where EventTypeID =" + typeID;
            selectSQLs.Add(selectsql);

            SelectSQL select1 = new SelectSQL();
            select1.Sql = "select * from [Order]";
            select1.TableName = "Orders";
            selectSQLs.Add(select1);

            SelectSQL select2 = new SelectSQL();
            select2.Sql = "select * from Clients";
            select2.TableName = "Clients";
            selectSQLs.Add(select2);

            SelectSQL select3 = new SelectSQL();
            select3.Sql = "select * from [EventType]";
            select3.TableName = "EventTypes";
            selectSQLs.Add(select3);
            return this.Select(selectSQLs);
        }
        


        public int AssignWork(int[] orderID, LoginUser user)
        {
            List<string> sqls = new List<string>();
            foreach (int ordersID in orderID)
            {
                string sql = string.Format(@"insert into EmployeeEvent(EmployeeID, OrderID)
                                           values({0} , {1})",
                                           user.id, ordersID);
                sqls.Add(sql);
            }
            return this.ChangeData(sqls);
        }
        public int RemoveWork(int[] orderID, LoginUser user)
        {
            List<string> sqls = new List<string>();
            foreach (int ordersID in orderID)
            {
                string sql = string.Format(@"Delete from EmployeeEvent where EmployeeID in ({0}) and OrderID in ({1}) ",
                                           user.id, ordersID);
                sqls.Add(sql);
            }
            return this.ChangeData(sqls);
        }
    }
}