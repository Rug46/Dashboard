using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Data;

namespace Dashboard.Controllers
{
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
        public string SetBudgetAmount(int monthHours, int monthMinutes, int dayHours, int dayMinutes)
        {
            using (var db = new Database())
            {
                var monthTotalMinutes = (monthHours * 60) + monthMinutes;

                var monthRecords = db.Budgets
                    .Where(bm => bm.Name == "Month")
                    .OrderBy(bm => bm.Id)
                    .ToList();

                monthRecords.ElementAt(0).Minutes = monthTotalMinutes;

                var dayTotalMinutes = (dayHours * 60) + dayMinutes;

                var dayRecords = db.Budgets
                    .Where(bm => bm.Name == "Day")
                    .OrderBy(bm => bm.Id)
                    .ToList();

                dayRecords.ElementAt(0).Minutes = dayTotalMinutes;
                    
                db.SaveChanges();

                return "Month: " + monthTotalMinutes + ", Day: " + dayTotalMinutes;
            }
        }

        public static void SetBudgetAmountToday(int hours, int minutes)
        {
            using (var db = new Database())
            {
                var totalMinutes = (hours * 60) + minutes;

                db.Budgets.Where(bm => bm.Name == "Day")
                    .ElementAt(0).Minutes = totalMinutes;

                db.SaveChanges();
            }
        }
    }
}