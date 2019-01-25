using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Data
{
    public class SetBudget
    {
        public static int GetBudgetHours()
        {
            var totalMinutes = Budget.GetBudgetAmount();
            var hours = (int) Math.Floor(totalMinutes / 60);

            return hours;
        }

        public static int GetBudgetMinutes()
        {
            var totalMinutes = Budget.GetBudgetAmount();
            var minutes = (int)Math.Floor(totalMinutes % 60);

            return minutes;
        }

        public static void SetBudgetAmount(int hours, int minutes)
        {
            using (var db = new BudgetContext())
            {
                var totalMinutes = (hours * 60) + minutes;

                db.BudgetRecords.Where(bm => bm.Name == "Month")
                    .ElementAt(0).Minutes = totalMinutes;

                db.SaveChanges();
            }
        }

        public static void Save(int bmHours, int bmMinutes, int bdHours, int bdMinutes)
        {
            Dashboard.Data.SetBudget.SetBudgetAmount(bmHours, bmMinutes);
            Dashboard.Data.SetBudgetToday.SetBudgetAmount(bdHours, bdMinutes);
        }
    }
}
