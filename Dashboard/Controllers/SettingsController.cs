using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Dashboard.Helpers;

namespace Dashboard.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewGameMode(string Mode)
        {
            GameMode.NewGameMode(Mode);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveGameMode(int id)
        {
            GameMode.RemoveGameMode(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult NewGame(string Game)
        {
            Games.NewGame(Game);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveGame(int id)
        {
            Games.RemoveGame(id);
            return RedirectToAction("Index");
        }
    }
}