using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class DbInitialiser
    {
        public static void InitialiseBudget(Database context)
        {
            context.Database.EnsureCreated();

            if (context.Budgets.Any())
            {
                return;
            }

            var records = new BudgetModel[]
            {
                // Default Values
                new BudgetModel{Name="Day",Minutes=120 },
                new BudgetModel{Name="Month",Minutes=1440 }
            };

            foreach (BudgetModel bm in records)
            {
                context.Budgets.Add(bm);
            }

            context.SaveChanges();
        }
    }
}
