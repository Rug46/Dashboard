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

            var BacklogEntryUser = BacklogEntry.UserId;
            var CurrentUser = Account.GetUserId(User.Identity.Name);

            if (BacklogEntry == null || BacklogEntryUser != CurrentUser)
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
        public IActionResult Edit(int Id, string Name, string Compilation, string System, int Status, string Progress, int Rating, bool NowPlaying)
        {
            if (!Backlog.Edit(Id, Name, Compilation, System, Status, Progress, Rating, NowPlaying))
            {
                TempData["Error"] = "Please fill in the required fields (marked with a *). Make sure rating is a whole number between 1 and 5";
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
            if (id == (int)BacklogModel.STATUS.ENDLESS) { TempData["Status"] = "Endless"; }
            if (id == (int)BacklogModel.STATUS.RETIRED) { TempData["Status"] = "Retired"; }
            if (id > 5) { return RedirectToAction("Index"); }

            return View();
        }

        public IActionResult Wishlist(int id)
        {
            TempData["UserId"] = id;

            return View();
        }

        [HttpPost]
        public IActionResult Wishlist(string gameName, string consoleName)
        {
            Helpers.Wishlist.AddWishlist(Account.GetUserId(User.Identity.Name), gameName, consoleName);

            return RedirectToAction("Wishlist", new { id = Account.GetUserId(User.Identity.Name) });
        }

        public IActionResult WishlistDelete(int id)
        {
            Helpers.Wishlist.RemoveWishlist(id, Account.GetUserId(User.Identity.Name));

            return RedirectToAction("Wishlist", new { id = Account.GetUserId(User.Identity.Name) });
        }

        public IActionResult WishlistArchive(int id, int userid)
        {
            Helpers.Wishlist.ArchiveWishlist(id, Account.GetUserId(User.Identity.Name));

            return RedirectToAction("Wishlist", new { id = userid });
        }
    }
}