using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppChernyavskiy.Models;

namespace WebAppChernyavskiy.Controllers {
    public class HomeController : Controller {

        public HomeController() {
        }

        public IActionResult Index() {
            return View();
        }

    }
}
