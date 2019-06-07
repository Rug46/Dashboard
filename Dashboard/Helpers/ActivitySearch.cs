using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class ActivitySearch
    {
        public static int GetGameTimeHour(DateTime hour, int user)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.UserId == user)
                    .Where(ptm => ptm.Date.Date == hour.Date)
                    .Where(ptm => ptm.Date.Hour == hour.Hour)
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    var id = records.ElementAt(i).Id;
                    count += Data.GetTimeDifference(id);
                }

                return count;
            }
        }
    }
}