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
            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .Where(am => am.Date.Date == DateTime.Now.AddHours(-hoursAgo).Date)
                    .Where(am => am.Date.Hour == DateTime.Now.AddHours(-hoursAgo).Hour)
                    .OrderBy(am => am.Id)
                    .ToList();

                if (index < 0 || index >= records.Count)
                {
                    return Json(new { });
                }

                if (col == 0)
                {
                    return Json(new { result = records.ElementAt(index).Id });
                }

                if (col == 1)
                {
                    return Json(new { result = records.ElementAt(index).Date });
                }

                if (col == 2)
                {
                    return Json(new { result = records.ElementAt(index).Game });
                }

                if (col == 3)
                {
                    return Json(new { result = records.ElementAt(index).Finish });
                }

                if (col == 4)
                {
                    return Json(new { result = records.ElementAt(index).Mode });
                }

                return Json(new { });
            }
        }
    }
}