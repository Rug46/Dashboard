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
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var currentUser = Account.GetUserId(User.Identity.Name);

            TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("enableLinks"));
            TempData["private"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("private"));

            return View();
        }

        [HttpPost]
        public IActionResult Index(string enableLinks, string privateProfile)
        {
            var currentUser = Account.GetUserId(User.Identity.Name);

            UserSetting.SetSettingValue(currentUser, Setting.GetSettingId("enableLinks"), enableLinks);
            UserSetting.SetSettingValue(currentUser, Setting.GetSettingId("private"), privateProfile);

            TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("enableLinks"));
            TempData["private"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("private"));

            return View();
        }
    }
}