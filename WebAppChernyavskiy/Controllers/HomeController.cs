﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAppChernyavskiy.Models;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.Models.Collections;
using WebAppChernyavskiy.ViewModels.Collections;
using WebAppChernyavskiy.ViewModels.Items;

namespace WebAppChernyavskiy.Controllers {
    public class HomeController : Controller {

        UserContext db;
        public HomeController(UserContext context) {
            db = context;
        }

        public IActionResult Index(int? topic, string name) {
            IQueryable<Collection> collections = db.Collections.Include(p => p.Topic).
                OrderByDescending(o => o.Id).Take(10);
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

        public async Task<IActionResult> CollectionInfo(int? id, int page = 1) {
            int pageSize = 4;
            ViewBag.Id = id;

            IQueryable<Item> item = db.Items.Include(x => x.Collection).Where(p => p.CollectionId == id);

            var count = await item.CountAsync();
            var items = await item.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageAndSortViewModel viewModel = new PageAndSortViewModel {
                PageViewModel = new PageViewModel(count, page, pageSize),
                Items = items
            };

            return View(viewModel);
        }

    }
}
