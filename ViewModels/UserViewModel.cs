using MasterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterProject.ViewModels
{
    public class UserViewModel
    {
        List<Clients> clients { get; set; }
        List<Employee> employees { get; set; }
    }
}