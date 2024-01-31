using Shipping_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.ViewModels
{
    public class ShipmentViewModel
    {
        public List<int> ProductIds { get; set; }

        public Shipment Shipment { get; set; }
    }
}
