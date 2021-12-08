using Microsoft.AspNetCore.Mvc;
using Equipment_Rental_Application.Data;
using Equipment_Rental_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Equipment_Rental_Application.Helpers;

namespace Equipment_Rental_Application.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View("Index", objList);
        }

        // Create a value of the rental enquiry
        // GET-Create
        public IActionResult Create()
        {
            Item item = new Item();
            item.Products = _db.Equipments.ToList<Equipment>();

            return View("Create", item);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {

            if (ModelState.IsValid)
            {
                // Get equipment name and type based on id
                Equipment equipment = _db.Equipments.Find(obj.DropDownId);
                obj.EquipmentType = equipment.EquipmentType;
                obj.EquipmentName = equipment.EquipmentName;

                // Calculate price
                Calculations priceCaclulation = new Calculations();
                obj.Price = priceCaclulation.RentalPrice(obj.EquipmentType, obj.Duration);

                // Add to database
                _db.Items.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Delete a value from the rental enquiry
        // GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Items.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View("Delete", obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update a value of the rental enquiry
        // GET-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Items.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            Item item = new Item();
            item.Products = _db.Equipments.ToList<Equipment>();

            return View("Update", item);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            // Get equipment name and type based on id
            Equipment equipment = _db.Equipments.Find(obj.DropDownId);
            obj.EquipmentType = equipment.EquipmentType;
            obj.EquipmentName = equipment.EquipmentName;

            // Calculate price
            Calculations priceCaclulation = new Calculations();
            obj.Price = priceCaclulation.RentalPrice(obj.EquipmentType, obj.Duration);

            // Update database
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Update", obj);
        }

        // GET-Success
        public IActionResult Success()
        {
            // Add orders to history
            IEnumerable<Item> itemList = _db.Items;
            List<History> orderHistory = new List<History>();
            History order = new History();
            
            foreach (var item in itemList)
            {
                orderHistory.Add(new History
                { 
                    EquipmentName = item.EquipmentName,
                    EquipmentType = item.EquipmentType,
                    Duration = item.Duration,
                    OrderTime = DateTime.Now
                });
            }
            _db.History.AddRange(orderHistory);
            _db.SaveChanges();

            // Clear order list
            _db.Items.RemoveRange(_db.Items.ToList());
            _db.SaveChanges();

            return View("Success");
        }
    }
}