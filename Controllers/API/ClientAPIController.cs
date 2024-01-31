using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping_Company.Data;
using Shipping_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shipping_Company.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClientAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //Get =>  /api/ClientAPI/
        public IActionResult GetClients()
        {
            var myClients = _context.Clients.ToList();

            return Ok(myClients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.Clients.Include(e=>e.Shipments).ThenInclude(e=>e.Client).SingleOrDefault(c => c.Id == id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound();
        }



        [HttpPost]
        public IActionResult PostClient(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();


                Console.WriteLine(client);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + client.Id, client);
              
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public void UpdateClient(int id , Client client)
        {

            if (ModelState.IsValid)
            {
                var clientObj = _context.Clients.SingleOrDefault(c => c.Id == id);
                if (clientObj != null)
                {
                    clientObj.Id = client.Id;
                    clientObj.Name = client.Name;
                    clientObj.Phone = client.Phone;
                    clientObj.Email = client.Email;

                    _context.Clients.Update(clientObj);
                    _context.SaveChanges();

                }
                else
                {
                    throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
                }

            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }

        }


        [HttpDelete("{id}")]
        // Delete => /api/ClientAPI/id
        public void DeleteClient(int id)
        {

            var clientObj = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (clientObj != null)
            {
                _context.Clients.Remove(clientObj);
                _context.SaveChanges();
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);

            }


        }



    }
}
