using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterProject.Models;

namespace MasterProject.ViewModels
{
    public class EventOrderViewModel
    {
        public List<Clients> Clients { get; set; }
        public List<Employee> employees { get; set; }
        public List<Order> Orders { get; set; }
        public List<Event> Events { get; set; }
        public List<EventType> EventTypes { get; set; }
    }
    public class EventRequestViewModel
    {
        public List<EventType> EventTypes { get; set; }
    }
}