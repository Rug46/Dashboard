using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class DataYears
    {
        public static int GetGameTime(DateTime day)
        {
            using (var db = new ActivityContext())
            {
                var records = db.ActivityRecords
                    .Where(ptm => ptm.Date.Date == day.Date)
                    .Where(ptm => ptm.Date.Day == day.Day)
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
