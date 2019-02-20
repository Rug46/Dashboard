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
            TempData["id"] = Dashboard.Helpers.Games.SearchGame(game);

            return View();
        }

        [HttpPost]
        public IActionResult Rate(int gameID, int score)
        {
            if (score <= 0 || score > 100)
            {
                TempData["Error"] = "Score must be between 1 and 100";
                return RedirectToAction("Index");
            }

            Helpers.Games.SetRating(gameID, score);
            return RedirectToAction("Index");
        }
    }
}