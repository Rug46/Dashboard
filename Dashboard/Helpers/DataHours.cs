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
        public JsonResult GetRecordsHours1(int hoursAgo, int index, int col)
        {
            var result = new List<PlaytimeModel>();

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddHours(-hoursAgo).Date)
                    .Where(ptm => ptm.Date.Hour == DateTime.Now.AddHours(-hoursAgo).Hour)
                    .OrderBy(ptm => ptm.Id)
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

            if (col == 4) {
                return Json(new { result = result.ElementAt(index).Mode });
            } 

            return Json(new { });
        }

        public static string GetRecordsDays(int daysAgo, int index, int col)
        {
            var result = new List<PlaytimeModel>();

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddDays(-daysAgo))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                result = records;
            }

            if (index < 0 || index >= result.Count) return "";
            if (col == 0) return result.ElementAt(index).Id.ToString();
            if (col == 1) return result.ElementAt(index).Date.ToString();
            if (col == 2) return result.ElementAt(index).Game.ToString();
            if (col == 3) return result.ElementAt(index).Finish.ToString();
            if (col == 4) return result.ElementAt(index).Mode.ToString();
            return "";
        }

        public static int GetRecordsHoursCount(int hoursAgo)
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddHours(-hoursAgo))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                result = records.Count;
            }

            return result;
        }

        public static int GetRecordsDaysCount(int daysAgo)
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date == DateTime.Now.AddDays(-daysAgo))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                result = records.Count;
            }

            return result;
        }
    }
}
