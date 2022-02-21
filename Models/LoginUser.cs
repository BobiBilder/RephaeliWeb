using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.Models
{
    public class LoginUser: BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDnum { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsWorker { get; set; }
        public bool IsManager { get; set; }
    }
}