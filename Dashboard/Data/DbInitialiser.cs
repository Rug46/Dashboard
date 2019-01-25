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
        public static void Initialise(PlaytimeContext context)
        {
            context.Database.EnsureCreated();

            if (context.PlaytimeRecords.Any())
            {
                return;
            }

            var records = new PlaytimeModel[]
            {
                // TODO: Remove these after testing
                //new PlaytimeModel{Date=DateTime.Parse("2018-10-24 10:00"), Game="Splatoon 2", Finish=DateTime.Parse("2018-10-24 11:36"), Mode="Online"},
                //new PlaytimeModel{Date=DateTime.Parse("2018-10-24 11:45"), Game="Mario Kart 8 Deluxe", Finish=DateTime.Parse("2018-10-24 12:03"), Mode="Friends"}
            };

            foreach (PlaytimeModel ptm in records)
            {
                context.PlaytimeRecords.Add(ptm);
            }

            context.SaveChanges();
        }

        public static void InitialiseBudget(BudgetContext context)
        {
            context.Database.EnsureCreated();

            if (context.BudgetRecords.Any())
            {
                return;
            }

            var records = new BudgetModel[]
            {
                new BudgetModel{Name="Day",Minutes=120 },
                new BudgetModel{Name="Month",Minutes=1440 }
            };

            foreach (BudgetModel bm in records)
            {
                context.BudgetRecords.Add(bm);
            }

            context.SaveChanges();
        }
    }
}
