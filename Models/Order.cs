using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.Models
{
    public class Order:BaseModel
    {
        public int ClientID { get; set; }
        public bool IsWorker { get; set; }
        public string OrderDate { get; set; }
        public List<int> EmployeeIDs { get; set; }
        public bool IsPayed { get; set; }
        public string OrderTime { get; set; }
    }

    public class OrderEvent : Order
    {
        public NewEvent Event { get; set; }
    }
    public class OrderFood : Order
    {
        List<Food> food;
    }
}