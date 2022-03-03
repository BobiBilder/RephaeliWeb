using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.Models
{
    public class Event: NewEvent
    {
        public int OrderID { get; set; }
    }
    public class NewEvent : BaseModel
    {
        public int Invitations { get; set; }
        public string Notes { get; set; }
        public EventType EventType { get; set; }
    }
}