using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.Models
{
    public class Employee: LoginUser
    {
       
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
}