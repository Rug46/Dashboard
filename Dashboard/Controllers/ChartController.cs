using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hours()
        {
            return View();
        }

        public IActionResult Games()
        {
            return View();
        }

        public JsonResult GetRecordsHours(int hoursAgo, int index, int col)
        {
            var result = new List<ActivityModel>();

            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .Where(am => am.Date.Date == DateTime.Now.AddHours(-hoursAgo).Date)
                    .Where(am => am.Date.Hour == DateTime.Now.AddHours(-hoursAgo).Hour)
                    .OrderBy(am => am.Id)
                    .ToList();

                result = records;
            }

            if (index < 0 || index >= result.Count)
            {
                return Json(new { });
            }

            if (col == 0)
            {
                return Json(new { result = result.ElementAt(index).Id });
            }

            if (col == 1)
            {
                return Json(new { result = result.ElementAt(index).Date });
            }

            if (col == 2)
            {
                return Json(new { result = result.ElementAt(index).Game });
            }

            if (col == 3)
            {
                return Json(new { result = result.ElementAt(index).Finish });
            }

            if (col == 4)
            {
                return Json(new { result = result.ElementAt(index).Mode });
            }

            return Json(new { });
        }
    }
}