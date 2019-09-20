using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Budget
    {
        public static float GetBudgetAmount(int UserId)
        {
            using (var db = new Database())
            {
                var records = db.UserBudgets
                    .Where(bm => bm.UserId == UserId)
                    .OrderBy(bm => bm.id)
                    .ToList();

                return records.ElementAt(0).Monthly;
            }
        }

        public static string GetBudgetAmountFormatted(int UserId)
        {
            if(GetBudgetAmount(UserId) < 60)
            {
                return GetBudgetAmount(UserId) + " minutes";
            }
            else
            {
                return Math.Floor(GetBudgetAmount(UserId) / 60) + " hours";
            }
        }

        public static float GetUsedAmount()
        {
            using (var db = new Database())
            {
                var records = db.Activity
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

        public static string GetUsedAmountFormatted()
        {
            if(GetUsedAmount() < 60)
            {
                return GetUsedAmount() + " minutes";
            } else
            {
                return Math.Round(GetUsedAmount() / 60, 1) + " hours";
            }
        }

        public static float GetLeftAmount(int UserId)
        {
            return GetBudgetAmount(UserId) - GetUsedAmount();
        }

        public static string GetLeftAmountFormatted(int UserId)
        {
            if(GetLeftAmount(UserId) < 60)
            {
                return GetLeftAmount(UserId) + " minutes";
            } else
            {
                return Math.Round(GetLeftAmount(UserId) / 60, 1) + " hours";
            }
        }

        public static float GetPercentage(int UserId)
        {
            var budget = GetBudgetAmount(UserId);
            var used = GetUsedAmount();
            var left = GetLeftAmount(UserId);

            var percentage = (used / budget) * 100;

            return percentage;
        }

        public static string GetPercentageFormatted(int UserId)
        {
            return Math.Floor(GetPercentage(UserId)) + "% Used";
        }

        public static bool IsOverBudget(int UserId)
        {
            if(GetUsedAmount() >= GetBudgetAmount(UserId))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool IsOverBudgetAny(int UserId)
        {
            if(IsOverBudget(UserId) || BudgetToday.IsOverBudget(UserId))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static string IsOverBudgetFormatted(int UserId)
        {
            if (BudgetToday.IsOverBudget(UserId))
            {
                return "Over Budget Today!";
            } else if(IsOverBudget(UserId))
            {
                return "Over Budget!";
            } else
            {
                return "";
            }
        }
    }
}
