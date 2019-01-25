using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Data
{
    public class Budget
    {
        public static float GetBudgetAmount()
        {
            using (var db = new BudgetContext())
            {
                var records = db.BudgetRecords
                    .Where(bm => bm.Name == "Month")
                    .OrderBy(bm => bm.Id)
                    .ToList();

                return records.ElementAt(0).Minutes;
            }
        }

        public static string GetBudgetAmountFormatted()
        {
            if(GetBudgetAmount() < 60)
            {
                return GetBudgetAmount() + " minutes";
            } else
            {
                return Math.Floor(GetBudgetAmount() / 60) + " hours";
            }
        }

        public static float GetUsedAmount()
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                var count = 0;

                for(int i = 0; i < records.Count; i++)
                {
                    count += Data.GetTimeDifference(records.ElementAt(i).Id);
                }

                result = count;
            }

            return result;
        }

        public static string GetUsedAmountFormatted()
        {
            if(GetUsedAmount() < 60)
            {
                return GetUsedAmount() + " minutes";
            } else
            {
                return Math.Floor(GetUsedAmount() / 60) + " hours";
            }
        }

        public static float GetLeftAmount()
        {
            return GetBudgetAmount() - GetUsedAmount();
        }

        public static string GetLeftAmountFormatted()
        {
            if(GetLeftAmount() < 60)
            {
                return GetLeftAmount() + " minutes";
            } else
            {
                return Math.Floor(GetLeftAmount() / 60) + " hours";
            }
        }

        public static float GetPercentage()
        {
            var budget = GetBudgetAmount();
            var used = GetUsedAmount();
            var left = GetLeftAmount();

            var percentage = (left / budget) * 100;

            return percentage;
        }

        public static string GetPercentageFormatted()
        {
            return Math.Floor(GetPercentage()) + "%";
        }

        public static bool IsOverBudget()
        {
            if(GetUsedAmount() >= GetBudgetAmount())
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool IsOverBudgetAny()
        {
            if(IsOverBudget() || BudgetToday.IsOverBudget())
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static string IsOverBudgetFormatted()
        {
            if (BudgetToday.IsOverBudget())
            {
                return "Over Budget Today!";
            } else if(IsOverBudget())
            {
                return "Over Budget!";
            } else
            {
                return "";
            }
        }
    }
}
