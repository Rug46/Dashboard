using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Models;
using Dashboard.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Dashboard.Controllers
{
    [Authorize]
    public class BacklogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult New(string Name, string Compilation, string System, int Status, string Progress, bool NowPlaying)
        {
            if (!Backlog.New(Name, Compilation, System, Status, Progress, NowPlaying, Account.GetUserId(User.Identity.Name)))
            {
                TempData["Error"] = "Please fill in the required fields (marked with a *)";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var BacklogEntry = Backlog.Get(id);

            if (BacklogEntry == null)
            {
                TempData["Error"] = "This entry doesn't exist";
            }
            else
            {
                TempData["Backlog"] = BacklogEntry;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name, string Compilation, string System, int Status, string Progress, bool NowPlaying)
        {
            if (!Backlog.Edit(Id, Name, Compilation, System, Status, Progress, NowPlaying))
            {
                TempData["Error"] = "Please fill in the required fields (marked with a *)";
                return RedirectToAction("Index");
            }

            TempData["Success"] = "Successfully Edited";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            Backlog.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult System(string Id)
        {
            TempData["System"] = Id;

            return View();
        }

        public IActionResult Status(int id)
        {
            if (id == (int)BacklogModel.STATUS.UNPLAYED) { TempData["Status"] = "Unplayed"; }
            if (id == (int)BacklogModel.STATUS.UNFINISHED) { TempData["Status"] = "Unfinished"; }
            if (id == (int)BacklogModel.STATUS.BEAT) { TempData["Status"] = "Beat"; }
            if (id == (int)BacklogModel.STATUS.COMPLETED) { TempData["Status"] = "Completed"; }
            if (id > 3) { return RedirectToAction("Index"); }

            return View();
        }
    }
}