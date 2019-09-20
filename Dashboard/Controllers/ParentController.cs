using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dashboard.Helpers;

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var currentUser = Account.GetUserId(User.Identity.Name);

            if (!Account.IsChildOf(currentUser, id))
            {
                return RedirectToAction("ChildAccounts");
            }

            TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(id, Setting.GetSettingId("enableLinks"));
            TempData["private"] = UserSetting.GetSettingValueOrDefault(id, Setting.GetSettingId("private"));

            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, string enableLinks, string privateProfile)
        {
            UserSetting.SetSettingValue(id, Setting.GetSettingId("enableLinks"), enableLinks);
            UserSetting.SetSettingValue(id, Setting.GetSettingId("private"), privateProfile);

            TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(id, Setting.GetSettingId("enableLinks"));
            TempData["private"] = UserSetting.GetSettingValueOrDefault(id, Setting.GetSettingId("private"));

            TempData["id"] = id;
            return View();
        }
    }
}