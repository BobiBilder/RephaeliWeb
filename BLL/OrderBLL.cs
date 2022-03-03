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
        private bool helper1(int OrderID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.helper1(user);
            bool isOK = true;
            foreach (DataRow dr in dt.Rows)
            {
                isOK = isOK && OrderID != int.Parse(dr["OrderID"].ToString());
            }
            return isOK;
        }
        private bool helper2(int OrderID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            DataTable dt = eventDB.helper1(user);
            foreach (DataRow dr in dt.Rows)
            {
                if(OrderID == int.Parse(dr["OrderID"].ToString()))
                {
                    return true;
                }
            }
            return false;
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
                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                if (helper1(int.Parse(dr["OrderID"].ToString()), user))
                {
                    Event events = new Event();
                    events.OrderID = int.Parse(dr["OrderID"].ToString());
                    events.Invitations = int.Parse(dr["Invitations"].ToString());
                    events.Notes = dr["Notes"].ToString();
                    events.EventType = new EventType();
                    events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                    eventOrderViewModel.Events.Add(events);
                }
                //if (helper2(int.Parse(dr["OrderID"].ToString()), user))
                //{
                //    Event events = new Event();
                //    events.OrderID = int.Parse(dr["OrderID"].ToString());
                //    events.Invitations = int.Parse(dr["Invitations"].ToString());
                //    events.Notes = dr["Notes"].ToString();
                //    events.EventType = new EventType();
                //    events.EventType.id = int.Parse(dr["EventTypeID"].ToString());
                //    eventOrderViewModel.Events.Add(events);
                //}
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
                eventOrderViewModel.Orders.Add(order);
            }

            eventOrderViewModel.Events = new List<Event>();
            foreach (DataRow dr in dsEvent.Tables["Events"].Rows)
            {
                if (helper2(int.Parse(dr["OrderID"].ToString()), user))
                {
                    Event events = new Event();
                    events.OrderID = int.Parse(dr["OrderID"].ToString());
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

        public bool AssignedWork(int[] orderID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            return eventDB.AssignWork(orderID, user) > 0; 
        }
        public bool RemoveWork(int[] orderID, LoginUser user)
        {
            EventDB eventDB = new EventDB();
            return eventDB.RemoveWork(orderID, user) > 0;
        }
        public bool NewEvent(NewEvent newEvent, Order order)
        {
            BaseModel[] baseModels = new BaseModel[] { order, newEvent };
            EventDB eventDB = new EventDB();
            OleDbCommand command = new OleDbCommand();
            return eventDB.AddBaseModel(baseModels, command) > 0;
        }
    }
}