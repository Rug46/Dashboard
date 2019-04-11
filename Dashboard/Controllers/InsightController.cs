using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Data;
using Microsoft.AspNetCore.Authorization;

namespace Dashboard.Controllers
{
    [Authorize]
    public class InsightController : Controller
    {
        private static int _monthHours, _monthMinutes, _dayHours, _dayMinutes;

        public IActionResult Index()
        {
            return RedirectToAction("Budget");
        }

        public IActionResult Budget()
        {
            return View();
        }

        public IActionResult SetBudget()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetBudget(int monthHours, int monthMinutes, int dayHours, int dayMinutes)
        {
            using (var db = new Database())
            {
                var monthTotalMinutes = (monthHours * 60) + monthMinutes;
                var dayTotalMinutes = (dayHours * 60) + dayMinutes;

                var records = db.UserBudgets
                    .Where(bm => bm.UserId == Helpers.Account.GetUserId(User.Identity.Name))
                    .OrderBy(bm => bm.id)
                    .ToList();

                var userRecords = db.Users
                    .Where(um => um.Id == Helpers.Account.GetUserId(User.Identity.Name))
                    .OrderBy(um => um.Id)
                    .ToList();

                if (userRecords.ElementAt(0).Admin == 0) // Not an admin
                {
                    _monthHours = monthHours;
                    _monthMinutes = monthMinutes;
                    _dayHours = dayHours;
                    _dayMinutes = dayMinutes;

                    return RedirectToAction("Authorise");
                }

                records.ElementAt(0).Monthly = monthTotalMinutes;
                records.ElementAt(0).Daily = dayTotalMinutes;

                db.SaveChanges();

                return RedirectToAction("Budget");
            }
        }

        [HttpGet]
        public IActionResult Authorise()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorise(string password)
        {
            using (var db = new Database())
            {
                var userRecords = db.Users
                    .Where(um => um.Id == Helpers.Account.GetUserId(User.Identity.Name))
                    .OrderBy(um => um.Id)
                    .ToList();

                var parentRecords = db.Users
                    .Where(um => um.Id == userRecords.ElementAt(0).ParentAccountId)
                    .OrderBy(um => um.Id)
                    .ToList();

                if (password == null || password == "")
                {
                    return View();
                }

                if (Helpers.Passwords.PasswordCorrect(parentRecords.ElementAt(0).Username, password))
                {
                    var records = db.UserBudgets
                    .Where(bm => bm.UserId == Helpers.Account.GetUserId(User.Identity.Name))
                    .OrderBy(bm => bm.id)
                    .ToList();

                    var monthTotalMinutes = (_monthHours * 60) + _monthMinutes;
                    var dayTotalMinutes = (_dayHours * 60) + _dayMinutes;

                    records.ElementAt(0).Monthly = monthTotalMinutes;
                    records.ElementAt(0).Daily = dayTotalMinutes;

                    db.SaveChanges();

                    return RedirectToAction("Budget");
                }

                return View();
            }
        }
    }
}