using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.Models
{
    public class Shipment
    {
        [Key]
        public int GUID { get; set; } // primary key 

        [Required]
        [DisplayName("Shipment Date ")]
        public DateTime ShipmentDate { get; set; }

        [DisplayName("Shipment Description")]
        public string ShipmentDescription { get; set; }

        // because it's byte it's already required 
        public byte ClientId { get; set; }

        /*
         * Shipment Client : required
         * Shipment products : required
         */
        public virtual Client Client { get; set; }
        public virtual List<Shipment_Product> Shipment_Products { get; set; }

    }
}
