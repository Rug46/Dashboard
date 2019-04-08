using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Models;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class GameMode
    {
        public static bool NewGameMode(string name, int user)
        {
            using (var db = new Database())
            {
                var records = db.Modes
                    .Where(mm => mm.UserId == user)
                    .OrderBy(mm => mm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Name.ToLower() == name.ToLower())
                    {
                        return false;
                    }
                }

                if (name.Length <= 0 || name.Length > 32)
                {
                    return false;
                }

                ModeModel single = new ModeModel
                {
                    Name = name
                };

                db.Modes.Add(single);
                db.SaveChanges();

                return true;
            }
        }

        public static void RemoveGameMode(int id)
        {
            using (var db = new Database())
            {
                db.Modes.Remove(GetModel(id));
                db.SaveChanges();
            }
        }

        public static ModeModel GetModel(int id)
        {
            using (var db = new Database())
            {
                return db.Modes
                    .Where(mm => mm.Id == id)
                    .ToList()
                    .ElementAt(0);
            }
        }

        public static int GetID(string name, int user)
        {
            using (var db = new Database())
            {
                return db.Modes
                    .Where(mm => mm.UserId == user)
                    .Where(mm => mm.Name == name)
                    .ToList()
                    .ElementAt(0).Id;
            }
        }

        public static List<ModeModel> GetList(int user)
        {
            using (var db = new Database())
            {
                return db.Modes
                    .Where(mm => mm.UserId == user)
                    .ToList();
            }
        }

        public static int GetCount(int user)
        {
            using (var db = new Database())
            {
                return db.Modes
                    .Where(mm => mm.UserId == user)
                    .ToList()
                    .Count();
            }
        }

        public static string GetMode(int id)
        {
            using (var db = new Database())
            {
                var records = db.Modes
                    .Where(mm => mm.Id == id)
                    .OrderBy(mm => mm.Id)
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
