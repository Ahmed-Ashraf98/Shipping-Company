using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.Models
{
    public class Shipment_Product
    {

        public int Id { get; set; }

        public int ShipmentId { get; set; } // foreign key 

        public int ProductId { get; set; } // foreign key


        public virtual Shipment Shipment { get; set; }
        public virtual Product Product { get; set; }
    }
}
