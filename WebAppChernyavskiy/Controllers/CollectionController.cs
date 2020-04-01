using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.Controllers {
    public class CollectionController : Controller {

        private CollectionContext db;

        public CollectionController(CollectionContext context) {
            db = context;
        }

        public IActionResult CollectionsList() {
            return View(db.Collections.Include(u => u.Topic).Where(p => p.UserId == User.Identity.Name).ToList());
        }

        public IActionResult CreateCollection() {
            ViewBag.Topics = new SelectList(db.Topics, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateCollection(Collection collection) {

            db.Collections.Add(collection);
            db.SaveChanges();
            return RedirectToAction("CollectionsList");
        }

        public IActionResult Item(int? id) {
            if (id != null) {
                Collection col = db.Collections.FirstOrDefault(p => p.Id == id);
                if (col != null)
                    return View(col);
            }
            return NotFound();
        }

        public IActionResult AddItem(int CollectionId) {
            ViewBag.Col = CollectionId;
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(Item item) {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("ItemsList", new { id = item.CollectionId });
        }

        public IActionResult ItemsList(int? id) {
            return View(db.Items.Include(u => u.Collection).Where(p => p.CollectionId == id).ToList());
        }

    }
}
