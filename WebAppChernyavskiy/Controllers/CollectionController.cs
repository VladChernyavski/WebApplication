using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.Controllers {
    public class CollectionController : Controller {

        private UserContext db;

        public CollectionController(UserContext context) {
            db = context;
        }

        public IActionResult CollectionsList() {
            return View(db.Collections.Include(u => u.Topic).Where(p => p.UserId == User.Identity.Name).ToList());
        }

        [HttpGet]
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

        public IActionResult CollectionInfo(int? id) {
            if (id != null) {
                Collection col = db.Collections.FirstOrDefault(p => p.Id == id);
                if (col != null)
                    return View(col);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id != null) {
                var collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                    return View(collection);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Collection collection) {
            db.Collections.Update(collection);
            await db.SaveChangesAsync();
            return RedirectToAction("CollectionInfo", new { collection.Id });
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id) {
            if (id != null) {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                    return View(collection);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            if (id != null) {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null) {
                    db.Collections.Remove(collection);
                    await db.SaveChangesAsync();
                    return RedirectToAction("CollectionsList");
                }
            }
            return NotFound();
        }

        [HttpGet]
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
