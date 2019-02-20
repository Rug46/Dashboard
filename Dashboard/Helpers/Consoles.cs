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
            using (var db = new Database())
            {
                var records = db.Consoles
                    .OrderBy(cm => cm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Name.ToLower() == name.ToLower())
                    {
                        return;
                    }
                }

                ConsoleModel single = new ConsoleModel
                {
                    Name = name
                };

                db.Consoles.Add(single);
                db.SaveChanges();
            }
        }

        public static void RemoveConsole(int id)
        {
            using (var db = new Database())
            {
                db.Consoles.Remove(GetModel(id));
                db.SaveChanges();
            }
        }

        public static ConsoleModel GetModel(int id)
        {
            using (var db = new Database())
            {
                return db.Consoles
                    .Where(cm => cm.Id == id)
                    .ToList()
                    .ElementAt(0);
            }
        }

        public static int GetID(string name)
        {
            using (var db = new Database())
            {
                return db.Consoles
                    .Where(cm => cm.Name == name)
                    .ToList()
                    .ElementAt(0).Id;
            }
        }

        public static List<ConsoleModel> GetList()
        {
            using (var db = new Database())
            {
                return db.Consoles.ToList();
            }
        }

        public static int GetCount()
        {
            using (var db = new Database())
            {
                return db.Consoles.ToList().Count();
            }
        }

        public static string GetConsole(int id)
        {
            using (var db = new Database())
            {
                var records = db.Consoles
                    .Where(cm => cm.Id == id)
                    .OrderBy(cm => cm.Id)
                    .ToList();

                if (records.Count <= 0)
                {
                    return null;
                }

                return records.ElementAt(0).Name;
            }
        }
    }
}
