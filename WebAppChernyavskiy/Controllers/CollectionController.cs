using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.Models.Collections;
using WebAppChernyavskiy.ViewModels.Collections;
using WebAppChernyavskiy.ViewModels.Items;

namespace WebAppChernyavskiy.Controllers {
    public class CollectionController : Controller {

        private UserContext db;

        public CollectionController(UserContext context) {
            db = context;
        }

        public IActionResult CollectionsList(int? topic, string name) {
            //        return View(db.Collections.Include(u => u.Topic).Where(p => p.UserId == User.Identity.Name).ToList());
            IQueryable<Collection> collections = db.Collections.Include(p => p.Topic);
            if (topic != null && topic != 0) {
                collections = collections.Where(p => p.TopicId == topic);
            }
            if (!String.IsNullOrEmpty(name)) {
                collections = collections.Where(p => p.Name.Contains(name));
            }

            List<Topic> topics = db.Topics.ToList();

            topics.Insert(0, new Topic { Name = "Все", Id = 0 });

            CollectionListViewModel viewModel = new CollectionListViewModel {
                Collections = collections.ToList(),
                Topics = new SelectList(topics, "Id", "Name"),
                Name = name
            };
            return View(viewModel);
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
        public IActionResult AddItem(int collectionId) {
            ViewBag.Col = collectionId;
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(Item item) {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("ItemsList", new { id = item.CollectionId });
        }

        [HttpPost]
        public async Task<IActionResult> SaveText(Collection collection) {
            db.Collections.Update(collection);
            await db.SaveChangesAsync();
            return RedirectToAction("CollectionInfo", new { collection.Id });
        }

        public async Task<IActionResult> ItemsList(int? id, SortState sortOrder, int page = 1) {
            int pageSize = 5;
            ViewBag.Id = id;

            IQueryable<Item> item = db.Items.Include(x => x.Collection);

            switch (sortOrder) {
                case SortState.NameAsc:
                    item = item.OrderBy(s => s.Name);
                    break;
                case SortState.NameDesc:
                    item = item.OrderByDescending(s => s.Name);
                    break;
            }

            var count = await item.CountAsync();
            var items = await item.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageAndSortViewModel viewModel = new PageAndSortViewModel {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                Items = items
            };

            if (viewModel.SortViewModel.UpName) {
                ViewBag.UpName = "glyphicon glyphicon-chevron-up";
            } else {
                ViewBag.UpName = "glyphicon glyphicon-chevron-down";
            }

            return View(viewModel);
        }
    }
}
