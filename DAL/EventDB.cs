using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MasterProject.Models;
using System.Data.OleDb;

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
            
            SelectSQL select4 = new SelectSQL();
            select4.Sql = "select * from Employee";
            select4.TableName = "Employees";
            selectSQLs.Add(select4);

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
            select.Sql = "select EmployeeEvent.EventID from EmployeeEvent WHERE EmployeeID = " + user.id;
            select.TableName = "EventIDs";
            return this.Select(select);
        }
        public DataTable helper2()
        {
            SelectSQL select = new SelectSQL();
            select.Sql = "select EmployeeEvent.EventID from EmployeeEvent";
            select.TableName = "EventIDs";
            return this.Select(select);
        }
        public DataTable helper3(int orderID)
        {
            SelectSQL select = new SelectSQL();
            select.Sql = "select EmployeeEvent.EmployeeID from EmployeeEvent where EventID in (select [Event].EventID from [Event] where OrderID = " + orderID + ")";
            select.TableName = "EmployeeIDs";
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

            SelectSQL select4 = new SelectSQL();
            select4.Sql = "select * from Employee";
            select4.TableName = "Employees";
            selectSQLs.Add(select4);

            return this.Select(selectSQLs);

        }
        public DataSet GetMyEvents(LoginUser user)
        {
            List<SelectSQL> selectSQLs = new List<SelectSQL>();
            selectsql.Sql = "select * from [Event]";
            selectSQLs.Add(selectsql);

            SelectSQL select1 = new SelectSQL();
            if (user.IsWorker)
            {
                select1.Sql = "select * from [Order] where ClientID = " + user.id + " and IsWorker = -1";
            }
            else
            {
                select1.Sql = "select * from [Order] where ClientID = " + user.id + " and IsWorker = 0";
            }
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

            SelectSQL select4 = new SelectSQL();
            select4.Sql = "select * from Employee";
            select4.TableName = "Employees";
            selectSQLs.Add(select4);

            return this.Select(selectSQLs);
        }

        public int AssignWork(int[] EventID, LoginUser user)
        {
            List<string> sqls = new List<string>();
            foreach (int eventsID in EventID)
            {
                string sql = string.Format(@"insert into EmployeeEvent(EmployeeID, EventID)
                                           values({0} , {1})",
                                           user.id, eventsID);
                sqls.Add(sql);
            }
            return this.ChangeData(sqls);
        }
        public int RemoveWork(int[] EventID, LoginUser user)
        {
            List<string> sqls = new List<string>();
            foreach (int eventsID in EventID)
            {
                string sql = string.Format(@"Delete from EmployeeEvent where EmployeeID in ({0}) and EventID in ({1}) ",
                                           user.id, eventsID);
                sqls.Add(sql);
            }
            return this.ChangeData(sqls);
        }


        public override int AddModel(BaseModel baseModels)
        {
            OrderEvent order = baseModels as OrderEvent;
            int rows = 0;
            string orderSQL = string.Format(@"Insert into [Order](
                                         ClientID, OrderDate, IsPayed, OrderTime, IsWorker)
                                         values({0}, '{1}', {2}, '{3}', {4})",
                                         order.ClientID, order.OrderDate, order.IsPayed, order.OrderTime, order.IsWorker);
            command.CommandText = orderSQL;
            rows = rows + command.ExecuteNonQuery();
            orderSQL = "select @@Identity";
            command.CommandText = orderSQL;
            string orderID = command.ExecuteScalar().ToString();
            string eventSQL = string.Format(@"Insert into [Event](
                                             OrderID, Invitations, EventTypeID, Notes)
                                             values('{0}', {1}, {2}, '{3}')",
                                             orderID, order.Event.Invitations, order.Event.EventType.id, order.Event.Notes);
            command.CommandText = eventSQL;
            rows = rows + command.ExecuteNonQuery();
            return rows;
        }
        public override int DeleteModel(BaseModel baseModels)
        {
            OrderEvent order = baseModels as OrderEvent;
            int rows = 0;
            string employeeSQL = string.Format(@"Delete from EmployeeEvent where EventID = ", order.Event.id);
            command.CommandText = employeeSQL;
            rows = rows + command.ExecuteNonQuery();
            string eventSQL = string.Format(@"Delete from [Event] where OrderID = ", order.id);
            command.CommandText = eventSQL;
            rows = rows + command.ExecuteNonQuery();
            string orderSQL = string.Format(@"Delete from [Order] where OrderID = ", order.id);
            command.CommandText = orderSQL;
            rows = rows + command.ExecuteNonQuery();
            return rows;
        }
        public override int UpdateModel(BaseModel baseModels)
        {
            OrderEvent order = baseModels as OrderEvent;
            int rows = 0;
            string orderSQL = string.Format(@"update [Order]
                                             set OrderDate = '"+ order.OrderDate + "'" +
                                             "where OrderID = " + order.id);
            command.CommandText = orderSQL;
            rows = rows + command.ExecuteNonQuery();
            string eventSQL = string.Format(@"update [Event]
                                             set Invitations = " + order.Event.Invitations + " , EventTypeID = " + order.Event.EventType.id + " , Notes = '" + order.Event.Notes + "'" +
                                             "where OrderID = " + order.id);
            command.CommandText = eventSQL;
            rows = rows + command.ExecuteNonQuery();
            return rows;
        }
    }
}