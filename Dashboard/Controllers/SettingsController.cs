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
            var ModeTrim = Mode.Trim();
            GameMode.NewGameMode(ModeTrim);

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
            var GameTrim = Game.Trim();
            Games.NewGame(GameTrim);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveGame(int id)
        {
            Games.RemoveGame(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult NewConsole(string ConsoleName)
        {
            var ConsoleNameTrim = ConsoleName.Trim();
            Consoles.NewConsole(ConsoleNameTrim);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveConsole(int id)
        {
            Consoles.RemoveConsole(id);
            return RedirectToAction("Index");
        }
    }
}