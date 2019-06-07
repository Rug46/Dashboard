using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class DataHours : Controller
    {
        public JsonResult GetRecordsHours1(int hoursAgo, int index, int col, int user)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.UserId == user)
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddHours(-hoursAgo).Date)
                    .Where(ptm => ptm.Date.Hour == DateTime.Now.AddHours(-hoursAgo).Hour)
                    .OrderBy(ptm => ptm.Id)
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

        public static string GetRecordsDays(int daysAgo, int index, int col, int user)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.UserId == user)
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddDays(-daysAgo))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (index < 0 || index >= records.Count) return "";
                if (col == 0) return records.ElementAt(index).Id.ToString();
                if (col == 1) return records.ElementAt(index).Date.ToString();
                if (col == 2) return records.ElementAt(index).Game.ToString();
                if (col == 3) return records.ElementAt(index).Finish.ToString();
                if (col == 4) return records.ElementAt(index).Mode.ToString();
                return "";
            }
        }

        public static int GetRecordsHoursCount(int hoursAgo, int user)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.UserId == user)
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddHours(-hoursAgo))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                return records.Count;
            }
        }

        public static int GetRecordsDaysCount(int daysAgo, int user)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.UserId == user)
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddDays(-daysAgo))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                return records.Count;
            }
        }
    }
}
