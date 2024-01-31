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
    public class ProductAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //Get =>  /api/ProductAPI/
        public IActionResult GetProducts()
        {

            var myProducts = _context.Products.Include(e => e.Shipment_Products).ToList();

            return Ok(myProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Include(e=>e.Shipment_Products).SingleOrDefault(c => c.Id == id);
            if (product != null)
            {
                return Ok(product);
              
            }
            return NotFound();
        }



        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                
                Console.WriteLine(product);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + product.Id, product);
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public void UpdateClient(int id, Product product)
        {

            if (ModelState.IsValid)
            {
                var productObj = _context.Products.SingleOrDefault(c => c.Id == id);
                if (productObj != null)
                {
                    productObj.Id = product.Id;
                    productObj.Name = product.Name;
                    productObj.Price = product.Price;
                  

                    _context.Products.Update(productObj);
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
        // Delete => /api/ProductAPI/id
        public void DeleteProduct(int id)
        {

            var productObj = _context.Products.SingleOrDefault(c => c.Id == id);
            if (productObj != null)
            {
                _context.Products.Remove(productObj);
                _context.SaveChanges();
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);

            }


        }

    }
}
