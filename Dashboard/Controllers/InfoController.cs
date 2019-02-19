using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string platform, string game)
        {
            if (platform == null || platform == "" || game == null || game == "")
            {
                return RedirectToAction("Index");
            }

            TempData["platform"] = platform;
            TempData["game"] = game;

            return View();
        }
    }
}