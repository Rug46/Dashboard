using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class SetUserBudgetToday
    {
        public static int GetBudgetHours(int user)
        {
            var totalMinutes = UserBudgetToday.GetBudgetAmount(user);
            var hours = (int)Math.Floor(totalMinutes / 60);

            return hours;
        }

        public static int GetBudgetMinutes(int user)
        {
            var totalMinutes = UserBudgetToday.GetBudgetAmount(user);
            var minutes = (int)Math.Floor(totalMinutes % 60);

            return minutes;
        }

        public static void SetBudgetAmount(int hours, int minutes, int user)
        {
            using (var db = new Database())
            {
                var totalMinutes = (hours * 60) + minutes;

                var records = db.UserBudgets
                    .Where(bm => bm.UserId == user)
                    .ToList();

                if (records.Count == 0)
                {
                    UserBudgetModel budget = new UserBudgetModel
                    {
                        UserId = user,
                        Monthly = 24 * 60,
                        Daily = totalMinutes
                    };

                    db.UserBudgets.Add(budget);
                }
                else
                {
                    records.ElementAt(0).Daily = totalMinutes;
                }

                db.SaveChanges();
            }
        }
    }
}
