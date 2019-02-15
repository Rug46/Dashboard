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
        public static void Initialise(ActivityContext context)
        {
            context.Database.EnsureCreated();

            if (context.ActivityRecords.Any())
            {
                return;
            }

            var records = new ActivityModel[]
            {
                // TODO: Remove these after testing
                new ActivityModel{Date=DateTime.Parse("2018-10-24 10:00"), Game="Splatoon 2", Finish=DateTime.Parse("2018-10-24 11:36"), Mode="Online"},
                new ActivityModel{Date=DateTime.Parse("2018-10-24 11:45"), Game="Mario Kart 8 Deluxe", Finish=DateTime.Parse("2018-10-24 12:03"), Mode="Friends"}
            };

            foreach (ActivityModel am in records)
            {
                context.ActivityRecords.Add(am);
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
                // Default Values
                new BudgetModel{Name="Day",Minutes=120 },
                new BudgetModel{Name="Month",Minutes=1440 }
            };

            foreach (BudgetModel bm in records)
            {
                context.BudgetRecords.Add(bm);
            }

            context.SaveChanges();
        }

        public static void InitialiseMode(ModeContext context)
        {
            context.Database.EnsureCreated();

            if (context.ModeRecords.Any())
            {
                return;
            }

            var records = new ModeModel[]
            {

            };

            foreach (ModeModel mm in records)
            {
                context.ModeRecords.Add(mm);
            }

            context.SaveChanges();
        }

        public static void InitialiseGame(GameContext context)
        {
            context.Database.EnsureCreated();
                
            if (context.GameRecords.Any())
            {
                return;
            }

            var records = new GameModel[]
            {

            };

            foreach (GameModel gm in records)
            {
                context.GameRecords.Add(gm);
            }

            context.SaveChanges();
        }
    }
}
