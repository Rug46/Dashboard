using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class SetBudgetToday
    {
        public static int GetBudgetHours(int UserId)
        {
            var totalMinutes = BudgetToday.GetBudgetAmount(UserId);
            var hours = (int)Math.Floor(totalMinutes / 60);

            return hours;
        }

        public static int GetBudgetMinutes(int UserId)
        {
            var totalMinutes = BudgetToday.GetBudgetAmount(UserId);
            var minutes = (int)Math.Floor(totalMinutes % 60);

            return minutes;
        }

        public static void SetBudgetAmount(int hours, int minutes)
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
