using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shipping_Company.Data;
using Shipping_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping_Company.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShipmentsController/Create
        public ActionResult Create()
        {
            ViewBag.selectClient = new SelectList(_context.Clients,"Id","Name");
            ViewBag.selectProduct = new SelectList(_context.Products, "Id", "Name");

            return View();
        }

        // POST: ShipmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shipment shipment)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipmentsController/Edit/5
        public ActionResult Edit(int? id)
        {
            var myObj = _context.Shipments.Single(e => e.GUID == id);
            return View(myObj);
        }

        // POST: ShipmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Shipment shipment)
        {
            if (shipment.GUID != 0)
            {

                if (ModelState.IsValid)
                {
                    _context.Shipments.Update(shipment);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(shipment);
            }
            return NotFound();
        }



    }
}
