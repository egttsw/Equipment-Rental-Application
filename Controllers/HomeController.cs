using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Equipment_Rental_Application.Data;
using Equipment_Rental_Application.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using Equipment_Rental_Application.Helpers;

namespace Equipment_Rental_Application.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Show a list of equipment available for loan
        public IActionResult Index()
        {
            IEnumerable<Equipment> objList = _db.Equipments;
            return View("Index", objList);

        }

        // Show rental history
        public IActionResult History()
        {
            IEnumerable<History> objList = _db.History;
            return View("History", objList);
        }

        // Fill invoice and return it in PDF format
        public IActionResult InvoiceAsPDF()
        {
            IEnumerable<History> objList = _db.History;
            Calculations priceCaclulation = new Calculations();
            int total = 0;

            // Calculate prices and total price
            foreach(var obj in objList)
            {
                obj.Price = priceCaclulation.RentalPrice(obj.EquipmentType, obj.Duration);
                total += obj.Price;
            }
            objList.ElementAt(0).Total = total;

            return new ViewAsPdf("Invoice", objList);
        }

        // GET-ClearItems
        public IActionResult ClearItems()
        {
            // Clear order list - purely for testing purposes
            IEnumerable<Item> itemList = _db.Items;

            _db.Items.RemoveRange(_db.Items.ToList());
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET-ClearHistory
        public IActionResult ClearHistory()
        {
            // Clear history list - purely for testing purposes
            IEnumerable<History> itemList = _db.History;

            _db.History.RemoveRange(_db.History.ToList());
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
