using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class SetBudgetToday
    {
        public static int GetBudgetHours()
        {
            var totalMinutes = BudgetToday.GetBudgetAmount();
            var hours = (int)Math.Floor(totalMinutes / 60);

            return hours;
        }

        public static int GetBudgetMinutes()
        {
            var totalMinutes = BudgetToday.GetBudgetAmount();
            var minutes = (int)Math.Floor(totalMinutes % 60);

            return minutes;
        }

        public static void SetBudgetAmount(int hours, int minutes)
        {
            using (var db = new BudgetContext())
            {
                var totalMinutes = (hours * 60) + minutes;

                db.BudgetRecords.Where(bm => bm.Name == "Day")
                    .ElementAt(0).Minutes = totalMinutes;

                db.SaveChanges();
            }
        }
    }
}
