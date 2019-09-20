using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class UserBudget
    {
        public static float GetBudgetAmount(int user)
        {
            using (var db = new Database())
            {
                var records = db.UserBudgets
                    .Where(bm => bm.UserId == user)
                    .OrderBy(bm => bm.id)
                    .ToList();

                return records.ElementAt(0).Monthly;
            }
        }

        public static string GetBudgetAmountFormatted(int user)
        {
            if(GetBudgetAmount(user) < 60)
            {
                return GetBudgetAmount(user) + " minutes";
            }
            else
            {
                return Math.Floor(GetBudgetAmount(user) / 60) + " hours";
            }
        }

        public static float GetUsedAmount(int user)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.UserId == user)
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                var count = 0;

                for(int i = 0; i < records.Count; i++)
                {
                    count += ActivityData.GetTimeDifference(records.ElementAt(i).Id);
                }

                return count;
            }
        }

        public static string GetUsedAmountFormatted(int user)
        {
            if(GetUsedAmount(user) < 60)
            {
                return GetUsedAmount(user) + " minutes";
            } else
            {
                return Math.Round(GetUsedAmount(user) / 60, 1) + " hours";
            }
        }

        public static float GetLeftAmount(int user)
        {
            return GetBudgetAmount(user) - GetUsedAmount(user);
        }

        public static string GetLeftAmountFormatted(int user)
        {
            if(GetLeftAmount(user) < 60)
            {
                return GetLeftAmount(user) + " minutes";
            } else
            {
                return Math.Round(GetLeftAmount(user) / 60, 1) + " hours";
            }
        }

        public static float GetPercentage(int user)
        {
            var budget = GetBudgetAmount(user);
            var used = GetUsedAmount(user);
            var left = GetLeftAmount(user);

            var percentage = (used / budget) * 100;

            return percentage;
        }

        public static string GetPercentageFormatted(int user)
        {
            return Math.Floor(GetPercentage(user)) + "% Used";
        }

        public static bool IsOverBudget(int user)
        {
            if(GetUsedAmount(user) >= GetBudgetAmount(user))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool IsOverBudgetAny(int user)
        {
            if(IsOverBudget(user) || UserBudgetToday.IsOverBudget(user))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static string IsOverBudgetFormatted(int user)
        {
            if (UserBudgetToday.IsOverBudget(user))
            {
                return "Over Budget Today!";
            } else if(IsOverBudget(user))
            {
                return "Over Budget!";
            } else
            {
                return "";
            }
        }
    }
}
