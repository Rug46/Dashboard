using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Controllers;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class Activity
    {
        public static int GetLastPage()
        {
            var recordsPerPage = ActivityController.recordsPerPage;
            var count = ActivityController.count;

            var LastPage = (decimal) count / recordsPerPage;
            var LastPageRounded = Math.Ceiling(LastPage);

            return (int) LastPageRounded;
        }

        public static int GetCurrentPage()
        {
            return ActivityController.s_Page + 1;
        }

        public static bool IsSinglePage()
        {
            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count <= ActivityController.recordsPerPage)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsSinglePage24H()
        {
            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .Where(ptm => ptm.Date >= DateTime.Now.AddHours(-24))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count <= ActivityController.recordsPerPage)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsSinglePage7D()
        {
            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .Where(ptm => ptm.Date >= DateTime.Now.AddDays(-7))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count <= ActivityController.recordsPerPage)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsSinglePage28D()
        {
            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .Where(ptm => ptm.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count <= ActivityController.recordsPerPage)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void AddNew(ActivityModel model)
        {
            using (var db = new ActivityContext())
            {
                db.ActivityRecords.Add(model);
                db.SaveChanges();
            }
        }
    }
}
