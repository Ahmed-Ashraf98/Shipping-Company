using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping_Company.Data;
using Shipping_Company.Models;
using Shipping_Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shipping_Company.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShipmentAPIController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/<ShipmentAPIController>
        [HttpGet]
        public IActionResult GetShipments()
        {

            var myShipments = _context.Shipments
                .Include(x => x.Client).Include(w=>w.Shipment_Products).ThenInclude(e=>e.Product);
                

            //var myShipments2 = _context.Shipments_Products
            //    .Include(x => x.Shipment).ThenInclude(w=>w.Shipment_Products)
            //    ;
            //.ThenInclude(w=>w.Client).ThenInclude(w=>w.Shipments)

            return Ok(myShipments);
        }

        // GET api/<ShipmentAPIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shipment = _context.Shipments.Include(c => c.Client).SingleOrDefault(c => c.GUID == id);
            if (shipment != null)
            {
                return Ok(shipment);
            }
            return NotFound();
        }

        // POST api/<ShipmentAPIController>
        [HttpPost]
        public IActionResult Post(ShipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var myShipment = model.Shipment;
                _context.Shipments.Add(myShipment);
                _context.SaveChanges();
                foreach(var id in model.ProductIds)
                {
                    Console.WriteLine(id);
                    Console.WriteLine(model.Shipment.GUID);

                    Shipment_Product sp = new Shipment_Product(){ProductId=id , ShipmentId = model.Shipment.GUID };
                    _context.Shipments_Products.Add(sp);
                    _context.SaveChanges();

                }



                return Ok();
                //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + client.Id, client);

            }
            return BadRequest();

        }

        // PUT api/<ShipmentAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipmentAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
