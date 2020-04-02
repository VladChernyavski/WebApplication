using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.Controllers {
    public class ItemController : Controller{


        private UserContext db;

        public ItemController(UserContext context) {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            if (id != null) {
                Item item = await db.Items.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Item item) {
            db.Items.Update(item);
            await db.SaveChangesAsync();
            return RedirectToAction("ItemsList", "Collection", new { id = item.CollectionId });
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id) {
            if (id != null) {
                Item item = await db.Items.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            if (id != null) {
                Item item = await db.Items.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null) {
                    db.Items.Remove(item);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ItemsList", "Collection", new { id = item.CollectionId });
                }
            }
            return NotFound();
        }

    }
}
