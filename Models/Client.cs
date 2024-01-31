using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.Models
{
    public class Client
    {
        public int Id { get; set; }  // primary key 

        [Required]// to make the Name field required
        public string Name { get; set; }
        public int Phone { get; set; }

        [Required] // to make the Email field required
        public string Email { get; set; }

        public virtual List<Shipment> Shipments { get; set; }
    }
}
