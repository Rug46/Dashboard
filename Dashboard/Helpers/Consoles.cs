using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Models;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Consoles
    {
        public static void NewConsole(string name)
        {
            using (var db = new ConsoleContext())
            {
                var records = db.ConsoleRecords
                    .OrderBy(cm => cm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Console.ToLower() == name.ToLower())
                    {
                        return;
                    }
                }

                ConsoleModel single = new ConsoleModel
                {
                    Console = name
                };

                db.ConsoleRecords.Add(single);
                db.SaveChanges();
            }
        }

        public static void RemoveConsole(int id)
        {
            using (var db = new ConsoleContext())
            {
                db.ConsoleRecords.Remove(GetModel(id));
                db.SaveChanges();
            }
        }

        public static ConsoleModel GetModel(int id)
        {
            using (var db = new ConsoleContext())
            {
                return db.ConsoleRecords
                    .Where(cm => cm.Id == id)
                    .ToList()
                    .ElementAt(0);
            }
        }

        public static int GetID(string name)
        {
            using (var db = new ConsoleContext())
            {
                return db.ConsoleRecords
                    .Where(cm => cm.Console == name)
                    .ToList()
                    .ElementAt(0).Id;
            }
        }

        public static List<ConsoleModel> GetList()
        {
            using (var db = new ConsoleContext())
            {
                return db.ConsoleRecords.ToList();
            }
        }

        public static int GetCount()
        {
            using (var db = new ConsoleContext())
            {
                return db.ConsoleRecords.ToList().Count();
            }
        }

        public static string GetConsole(int id)
        {
            using (var db = new ConsoleContext())
            {
                var records = db.ConsoleRecords
                    .Where(cm => cm.Id == id)
                    .OrderBy(cm => cm.Id)
                    .ToList();

                if (records.Count <= 0)
                {
                    return null;
                }

                return records.ElementAt(0).Console;
            }
        }
    }
}
