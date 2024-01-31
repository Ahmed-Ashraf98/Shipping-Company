using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key

        [Required] // To make The Name field required
        public string Name { get; set; }

        [Required]// To make The Price field required
        public double Price { get; set; }

        public virtual List<Shipment_Product> Shipment_Products { get; set; }
    }
}
