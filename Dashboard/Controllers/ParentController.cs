using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Dashboard.Controllers
{
    [Authorize]
    public class ParentController : Controller
    {
        public IActionResult ChildAccounts()
        {
            if (!Helpers.Account.IsParent(Helpers.Account.GetUserId(User.Identity.Name)))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult NewChild()
        {
            if (!Helpers.Account.IsParent(Helpers.Account.GetUserId(User.Identity.Name)))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult NewChild(string Username, string Password, string Email, int ParentAccountId)
        {
            if (!Helpers.Account.IsParent(Helpers.Account.GetUserId(User.Identity.Name)))
            {
                return RedirectToAction("Index", "Home");
            }

            Helpers.Account.RegisterChild(Username, Password, Email, ParentAccountId);

            return RedirectToAction("ChildAccounts");
        }

        public IActionResult View(int id)
        {
            if(!Helpers.Account.IsChildOf(Helpers.Account.GetUserId(User.Identity.Name), id))
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["Username"] = Helpers.Account.GetUsername(id);
            TempData["Activity"] = Helpers.Activity.GetByUser(id);

            return View();
        }
    }
}