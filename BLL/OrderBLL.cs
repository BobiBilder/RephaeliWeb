using MasterProject.DAL;
using MasterProject.Models;
using MasterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace MasterProject.BLL
{
    public class OrderBLL
    {
        public EventOrderViewModel GetAllEventOrderViewModel()
        {
            EventDB eventDB = new EventDB();
            DataSet dsEvent = eventDB.GetAllEvent();
            EventOrderViewModel eventOrderViewModel = new EventOrderViewModel();

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                Event events = new Event();
                events.OrderID = int.Parse(dr["OrderID"].ToString());
                events.id = int.Parse(dr["EventID"].ToString());
                events.Invitations = int.Parse(dr["Invitations"].ToString());
                events.Notes = dr["Notes"].ToString();
                events.EventType = new EventType();
                events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.Events.Add(events);
            }

            eventOrderViewModel.Orders = new List<Order>();
            foreach (DataRow dr in dsEvent.Tables["Orders"].Rows)
            {
                Order order = new Order();
                order.IsPayed = bool.Parse(dr["IsPayed"].ToString());
                order.OrderDate = dr["OrderDate"].ToString();
                order.ClientID = int.Parse(dr["ClientID"].ToString());
                order.id = int.Parse(dr["OrderID"].ToString());
                order.OrderTime = dr["OrderTime"].ToString();
                order.IsWorker = bool.Parse(dr["IsWorker"].ToString());
                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Clients = new List<Clients>();
            foreach(DataRow dr in dsEvent.Tables["Clients"].Rows)
            {
                Clients client = new Clients();
                client.FirstName = dr["FirstName"].ToString();
                client.LastName = dr["LastName"].ToString();
                client.Email = dr["Email"].ToString();
                client.id = int.Parse(dr["ClientID"].ToString());
                client.Password = dr["Password"].ToString();
                eventOrderViewModel.Clients.Add(client);
            }

            eventOrderViewModel.employees = new List<Employee>();
            foreach (DataRow dr in dsEvent.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.Email = dr["Email"].ToString();
                employee.id = int.Parse(dr["EmployeeID"].ToString());
                employee.Password = dr["Password"].ToString();
                eventOrderViewModel.employees.Add(employee);
            }

            eventOrderViewModel.EventTypes = new List<EventType>();
            foreach(DataRow dr in dsEvent.Tables["EventTypes"].Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.EventTypes.Add(eventType);
            }

            return eventOrderViewModel;
        }
        private bool helper1(int EventID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.helper1(user);
            bool isOK = true;
            foreach (DataRow dr in dt.Rows)
            {
                isOK = isOK && EventID != int.Parse(dr["EventID"].ToString());
            }
            return isOK;
        }
        private bool helper2(int EventID)
        {
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.helper2();
            foreach (DataRow dr in dt.Rows)
            {
                if(EventID == int.Parse(dr["EventID"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private bool helper2(int EventID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.helper1(user);
            foreach (DataRow dr in dt.Rows)
            {
                if(EventID == int.Parse(dr["EventID"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private List<int> helper3(int orderID)
        {
            List<int> employeesIDs = new List<int>();
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.helper3(orderID);
            foreach(DataRow dr in dt.Rows)
            {
                employeesIDs.Add(int.Parse(dr["EmployeeID"].ToString()));
            }
            return employeesIDs;
        }
        private bool helper4(int orderID, List<Order> orders)
        {
            bool isOK = true;
            foreach(Order order in orders)
            {
                isOK = isOK && orderID != order.id;
            }
            return isOK;
        }
        public EventOrderViewModel GetNotMyEventsViewModel(LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataSet dsEvent = eventDB.GetAllEvent();
            EventOrderViewModel eventOrderViewModel = new EventOrderViewModel();

            eventOrderViewModel.Orders = new List<Order>();
            foreach (DataRow dr in dsEvent.Tables["Orders"].Rows)
            {
                Order order = new Order();
                order.IsPayed = bool.Parse(dr["IsPayed"].ToString());
                order.OrderDate = dr["OrderDate"].ToString();
                order.ClientID = int.Parse(dr["ClientID"].ToString());
                order.id = int.Parse(dr["OrderID"].ToString());
                order.OrderTime = dr["OrderTime"].ToString();
                order.IsWorker = bool.Parse(dr["IsWorker"].ToString());
                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                if (helper1(int.Parse(dr["EventID"].ToString()), user))
                {
                    Event events = new Event();
                    events.OrderID = int.Parse(dr["OrderID"].ToString());
                    events.id = int.Parse(dr["EventID"].ToString());
                    events.Invitations = int.Parse(dr["Invitations"].ToString());
                    events.Notes = dr["Notes"].ToString();
                    events.EventType = new EventType();
                    events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                    eventOrderViewModel.Events.Add(events);
                }
            }

            eventOrderViewModel.Clients = new List<Clients>();
            foreach (DataRow dr in dsEvent.Tables["Clients"].Rows)
            {
                Clients client = new Clients();
                client.FirstName = dr["FirstName"].ToString();
                client.LastName = dr["LastName"].ToString();
                client.Email = dr["Email"].ToString();
                client.id = int.Parse(dr["ClientID"].ToString());
                client.Password = dr["Password"].ToString();
                eventOrderViewModel.Clients.Add(client);
            }

            eventOrderViewModel.employees = new List<Employee>();
            foreach (DataRow dr in dsEvent.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.Email = dr["Email"].ToString();
                employee.id = int.Parse(dr["EmployeeID"].ToString());
                employee.Password = dr["Password"].ToString();
                eventOrderViewModel.employees.Add(employee);
            }

            eventOrderViewModel.EventTypes = new List<EventType>();
            foreach (DataRow dr in dsEvent.Tables["EventTypes"].Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.EventTypes.Add(eventType);
            }

            return eventOrderViewModel;
        }
        public EventOrderViewModel GetMyEventsViewModel(LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataSet dsEvent = eventDB.GetAllEvent();
            EventOrderViewModel eventOrderViewModel = new EventOrderViewModel();

            eventOrderViewModel.Orders = new List<Order>();
            foreach (DataRow dr in dsEvent.Tables["Orders"].Rows)
            {
                Order order = new Order();
                order.IsPayed = bool.Parse(dr["IsPayed"].ToString());
                order.OrderDate = dr["OrderDate"].ToString();
                order.ClientID = int.Parse(dr["ClientID"].ToString());
                order.id = int.Parse(dr["OrderID"].ToString());
                order.OrderTime = dr["OrderTime"].ToString();
                order.IsWorker = bool.Parse(dr["IsWorker"].ToString());
                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                if (helper2(int.Parse(dr["EventID"].ToString()), user))
                {
                    Event events = new Event();
                    events.OrderID = int.Parse(dr["OrderID"].ToString());
                    events.id = int.Parse(dr["EventID"].ToString());
                    events.Invitations = int.Parse(dr["Invitations"].ToString());
                    events.Notes = dr["Notes"].ToString();
                    events.EventType = new EventType();
                    events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                    eventOrderViewModel.Events.Add(events);
                }
            }

            eventOrderViewModel.Clients = new List<Clients>();
            foreach (DataRow dr in dsEvent.Tables["Clients"].Rows)
            {
                Clients client = new Clients();
                client.FirstName = dr["FirstName"].ToString();
                client.LastName = dr["LastName"].ToString();
                client.Email = dr["Email"].ToString();
                client.id = int.Parse(dr["ClientID"].ToString());
                client.Password = dr["Password"].ToString();
                eventOrderViewModel.Clients.Add(client);
            }

            eventOrderViewModel.employees = new List<Employee>();
            foreach (DataRow dr in dsEvent.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.Email = dr["Email"].ToString();
                employee.id = int.Parse(dr["EmployeeID"].ToString());
                employee.Password = dr["Password"].ToString();
                eventOrderViewModel.employees.Add(employee);
            }

            eventOrderViewModel.EventTypes = new List<EventType>();
            foreach (DataRow dr in dsEvent.Tables["EventTypes"].Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.EventTypes.Add(eventType);
            }

            return eventOrderViewModel;
        }
        public EventOrderViewModel GetEventOrderByTypeViewModel(int typeID)
        {
            EventDB eventDB = new EventDB();
            DataSet dsEvent = eventDB.GetAllEventByType(typeID);
            EventOrderViewModel eventOrderViewModel = new EventOrderViewModel();

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                Event events = new Event();
                events.OrderID = int.Parse(dr["OrderID"].ToString());
                events.id = int.Parse(dr["EventID"].ToString());
                events.Invitations = int.Parse(dr["Invitations"].ToString());
                events.Notes = dr["Notes"].ToString();
                events.EventType = new EventType();
                events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.Events.Add(events);
            }

            eventOrderViewModel.Orders = new List<Order>();
            foreach (DataRow dr in dsEvent.Tables["Orders"].Rows)
            {
                Order order = new Order();
                order.IsPayed = bool.Parse(dr["IsPayed"].ToString());
                order.OrderDate = dr["OrderDate"].ToString();
                order.ClientID = int.Parse(dr["ClientID"].ToString());
                order.id = int.Parse(dr["OrderID"].ToString());
                order.OrderTime = dr["OrderTime"].ToString();
                order.IsWorker = bool.Parse(dr["IsWorker"].ToString());

                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Clients = new List<Clients>();
            foreach (DataRow dr in dsEvent.Tables["Clients"].Rows)
            {
                Clients client = new Clients();
                client.FirstName = dr["FirstName"].ToString();
                client.LastName = dr["LastName"].ToString();
                client.Email = dr["Email"].ToString();
                client.id = int.Parse(dr["ClientID"].ToString());
                client.Password = dr["Password"].ToString();
                eventOrderViewModel.Clients.Add(client);
            }

            eventOrderViewModel.employees = new List<Employee>();
            foreach (DataRow dr in dsEvent.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.Email = dr["Email"].ToString();
                employee.id = int.Parse(dr["EmployeeID"].ToString());
                employee.Password = dr["Password"].ToString();
                eventOrderViewModel.employees.Add(employee);
            }

            eventOrderViewModel.EventTypes = new List<EventType>();
            foreach (DataRow dr in dsEvent.Tables["EventTypes"].Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.EventTypes.Add(eventType);
            }

            return eventOrderViewModel;
        }
        public EventOrderViewModel GetAllAssignedEventsViewModel()
        {
            EventDB eventDB = new EventDB();
            DataSet dsEvent = eventDB.GetAllEvent();
            EventOrderViewModel eventOrderViewModel = new EventOrderViewModel();
            eventOrderViewModel.Orders = new List<Order>();
            foreach (DataRow dr in dsEvent.Tables["Orders"].Rows)
            {
                Order order = new Order();
                order.IsPayed = bool.Parse(dr["IsPayed"].ToString());
                order.OrderDate = dr["OrderDate"].ToString();
                order.ClientID = int.Parse(dr["ClientID"].ToString());
                order.id = int.Parse(dr["OrderID"].ToString());
                order.OrderTime = dr["OrderTime"].ToString();
                order.IsWorker = bool.Parse(dr["IsWorker"].ToString());
                order.EmployeeIDs = helper3(order.id);

                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                if (helper2(int.Parse(dr["EventID"].ToString())))
                {
                    Event events = new Event();
                    events.OrderID = int.Parse(dr["OrderID"].ToString());
                    events.id = int.Parse(dr["EventID"].ToString());
                    events.Invitations = int.Parse(dr["Invitations"].ToString());
                    events.Notes = dr["Notes"].ToString();
                    events.EventType = new EventType();
                    events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                    eventOrderViewModel.Events.Add(events);
                }

            }

            eventOrderViewModel.Clients = new List<Clients>();
            foreach (DataRow dr in dsEvent.Tables["Clients"].Rows)
            {
                Clients client = new Clients();
                client.FirstName = dr["FirstName"].ToString();
                client.LastName = dr["LastName"].ToString();
                client.Email = dr["Email"].ToString();
                client.id = int.Parse(dr["ClientID"].ToString());
                client.Password = dr["Password"].ToString();
                eventOrderViewModel.Clients.Add(client);
            }

            eventOrderViewModel.employees = new List<Employee>();
            foreach (DataRow dr in dsEvent.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.Email = dr["Email"].ToString();
                employee.id = int.Parse(dr["EmployeeID"].ToString());
                employee.Password = dr["Password"].ToString();
                eventOrderViewModel.employees.Add(employee);
            }

            eventOrderViewModel.EventTypes = new List<EventType>();
            foreach (DataRow dr in dsEvent.Tables["EventTypes"].Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.EventTypes.Add(eventType);
            }
            return eventOrderViewModel;
        }
        
        public EventOrderViewModel GetMyEvents(LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataSet dsEvent = eventDB.GetMyEvents(user);
            EventOrderViewModel eventOrderViewModel = new EventOrderViewModel();

            eventOrderViewModel.Orders = new List<Order>();
            foreach (DataRow dr in dsEvent.Tables["Orders"].Rows)
            {
                Order order = new Order();
                order.IsPayed = bool.Parse(dr["IsPayed"].ToString());
                order.OrderDate = dr["OrderDate"].ToString();
                order.ClientID = int.Parse(dr["ClientID"].ToString());
                order.id = int.Parse(dr["OrderID"].ToString());
                order.OrderTime = dr["OrderTime"].ToString();
                order.IsWorker = bool.Parse(dr["IsWorker"].ToString());
                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                if (!helper4(int.Parse(dr["OrderID"].ToString()), eventOrderViewModel.Orders))
                {
                    Event events = new Event();
                    events.OrderID = int.Parse(dr["OrderID"].ToString());
                    events.id = int.Parse(dr["EventID"].ToString());
                    events.Invitations = int.Parse(dr["Invitations"].ToString());
                    events.Notes = dr["Notes"].ToString();
                    events.EventType = new EventType();
                    events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                    eventOrderViewModel.Events.Add(events);
                }
            }

            eventOrderViewModel.Clients = new List<Clients>();
            foreach (DataRow dr in dsEvent.Tables["Clients"].Rows)
            {
                Clients client = new Clients();
                client.FirstName = dr["FirstName"].ToString();
                client.LastName = dr["LastName"].ToString();
                client.Email = dr["Email"].ToString();
                client.id = int.Parse(dr["ClientID"].ToString());
                client.Password = dr["Password"].ToString();
                eventOrderViewModel.Clients.Add(client);
            }

            eventOrderViewModel.employees = new List<Employee>();
            foreach (DataRow dr in dsEvent.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.Email = dr["Email"].ToString();
                employee.id = int.Parse(dr["EmployeeID"].ToString());
                employee.Password = dr["Password"].ToString();
                eventOrderViewModel.employees.Add(employee);
            }

            eventOrderViewModel.EventTypes = new List<EventType>();
            foreach (DataRow dr in dsEvent.Tables["EventTypes"].Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventOrderViewModel.EventTypes.Add(eventType);
            }

            return eventOrderViewModel;
        }

        public EventRequestViewModel GetEventTypes()
        {
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.GetAllEventTypes();
            EventRequestViewModel eventRequestViewModel = new EventRequestViewModel();
            eventRequestViewModel.EventTypes = new List<EventType>();
            foreach (DataRow dr in dt.Rows)
            {
                EventType eventType = new EventType();
                eventType.EventTypeName = dr["EventTypeName"].ToString();
                eventType.id = int.Parse(dr["EventTypeID"].ToString());
                eventRequestViewModel.EventTypes.Add(eventType);
            }
            return eventRequestViewModel;
        }

        public bool AssignedWork(int[] EventID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            return eventDB.AssignWork(EventID, user) > 0;
        }
        public bool RemoveWork(int[] EventID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            return eventDB.RemoveWork(EventID, user) > 0;
        }
        public bool NewEvent(OrderEvent order)
        {
            EventDB eventDB = new EventDB();
            return eventDB.ChangeBaseModel(order, 1) > 0;
        }
        public bool DeleteMyEvent(OrderEvent order)
        {
            EventDB eventDB = new EventDB();
            return eventDB.ChangeBaseModel(order, 2) > 0;
        }
        public bool UpdateMyEvent(OrderEvent order)
        {
            EventDB eventDB = new EventDB();
            return eventDB.ChangeBaseModel(order, 3) > 0;
        }
    }
}