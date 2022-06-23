using MasterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterProject.FoodSupplier;

namespace MasterProject.ViewModels
{
    public class SupplierOrderViewModel
    {
        public MasterProject.FoodSupplier.Order[] orders { get; set; }
        public MasterProject.FoodSupplier.Food[] food { get; set; }
    }
}