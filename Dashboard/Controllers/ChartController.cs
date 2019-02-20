using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Year");
        }

        public IActionResult Year()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Month()
        {
            return RedirectToAction("Year");
        }

        [HttpPost]
        public IActionResult Month(DateTime month)
        {
            if (month == null)
            {
                TempData["Error"] = "Please select a month";
                return RedirectToAction("Year");
            }

            TempData["Month"] = month;
            TempData["MonthNum"] = month.Month;

            if (month.Month == 1) TempData["MonthName"] = "January";
            if (month.Month == 2) TempData["MonthName"] = "February";
            if (month.Month == 3) TempData["MonthName"] = "March";
            if (month.Month == 4) TempData["MonthName"] = "April";
            if (month.Month == 5) TempData["MonthName"] = "May";
            if (month.Month == 6) TempData["MonthName"] = "June";
            if (month.Month == 7) TempData["MonthName"] = "July";
            if (month.Month == 8) TempData["MonthName"] = "August";
            if (month.Month == 9) TempData["MonthName"] = "September";
            if (month.Month == 10) TempData["MonthName"] = "October";
            if (month.Month == 11) TempData["MonthName"] = "November";
            if (month.Month == 12) TempData["MonthName"] = "December";

            return View();
        }
    }
}