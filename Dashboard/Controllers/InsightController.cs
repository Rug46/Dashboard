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
                    .Where(bm => bm.UserId == Dashboard.Helpers.Account.GetUserId(User.Identity.Name))
                    .OrderBy(bm => bm.id)
                    .ToList();

                records.ElementAt(0).Monthly = monthTotalMinutes;
                records.ElementAt(0).Daily = dayTotalMinutes;

                db.SaveChanges();

                return RedirectToAction("Budget");
            }
        }

        [HttpPost]
        public string SetBudgetAmount(int monthHours, int monthMinutes, int dayHours, int dayMinutes)
        {
            using (var db = new Database())
            {
                var monthTotalMinutes = (monthHours * 60) + monthMinutes;
                var dayTotalMinutes = (dayHours * 60) + dayMinutes;

                var records = db.UserBudgets
                    .Where(bm => bm.UserId == Helpers.Account.GetUserId(User.Identity.Name))
                    .OrderBy(bm => bm.id)
                    .ToList();

                records.ElementAt(0).Monthly = monthTotalMinutes;
                records.ElementAt(0).Daily = dayTotalMinutes;
                    
                db.SaveChanges();

                return "Month: " + monthTotalMinutes + ", Day: " + dayTotalMinutes;
            }
        }
    }
}