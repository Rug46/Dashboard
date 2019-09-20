using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dashboard.Helpers;
using Dashboard.Data;

namespace Dashboard.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var currentUser = Account.GetUserId(User.Identity.Name);

            if (!Account.IsParent(currentUser))
            {
                TempData["ErrorStop"] = "Child accounts are not allowed to change settings";

                TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("enableLinks"));
                TempData["private"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("private"));

                return View();
            }

            TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("enableLinks"));
            TempData["private"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("private"));

            return View();
        }

        [HttpPost]
        public IActionResult Index(string enableLinks, string privateProfile)
        {
            var currentUser = Account.GetUserId(User.Identity.Name);

            if (!Account.IsParent(currentUser))
            {
                TempData["ErrorStop"] = "Child accounts are not allowed to change settings";

                TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("enableLinks"));
                TempData["private"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("private"));

                return View();
            }

            UserSetting.SetSettingValue(currentUser, Setting.GetSettingId("enableLinks"), enableLinks);
            UserSetting.SetSettingValue(currentUser, Setting.GetSettingId("private"), privateProfile);

            TempData["enableLinks"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("enableLinks"));
            TempData["private"] = UserSetting.GetSettingValueOrDefault(currentUser, Setting.GetSettingId("private"));

            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword, string repeatPassword)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Username == User.Identity.Name)
                    .ToList();

                if (currentPassword != null)
                {
                    if (Passwords.PasswordCorrect(User.Identity.Name, currentPassword))
                    {
                        if (newPassword == repeatPassword)
                        {
                            if (newPassword == null || newPassword.Length < 6)
                            {
                                TempData["Error"] = "Password must be at least 6 characters long";
                                return View();
                            }
                            else
                            {
                                var newPasswordHash = Passwords.Hash(newPassword);

                                records.ElementAt(0).Password = newPasswordHash;
                                db.SaveChanges();

                                TempData["Success"] = "Password changed successfully";
                                return View();
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Passwords do not match";
                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Current password is incorrect";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "Current password can't be empty";
                    return View();
                }
            }
        }
    }
}