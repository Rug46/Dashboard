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
        public static void NewGameMode(string name)
        {
            using (var db = new ModeContext())
            {
                var records = db.ModeRecords
                    .OrderBy(mm => mm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Mode.ToLower() == name.ToLower())
                    {
                        return;
                    }
                }

                ModeModel single = new ModeModel
                {
                    Mode = name
                };

                db.ModeRecords.Add(single);
                db.SaveChanges();
            }
        }

        public static void RemoveGameMode(int id)
        {
            using (var db = new ModeContext())
            {
                db.ModeRecords.Remove(GetModel(id));
                db.SaveChanges();
            }
        }

        public static ModeModel GetModel(int id)
        {
            using (var db = new ModeContext())
            {
                return db.ModeRecords
                    .Where(mm => mm.Id == id)
                    .ToList()
                    .ElementAt(0);
            }
        }

        public static int GetID(string name)
        {
            using (var db = new ModeContext())
            {
                return db.ModeRecords
                    .Where(mm => mm.Mode == name)
                    .ToList()
                    .ElementAt(0).Id;
            }
        }

        public static List<ModeModel> GetList()
        {
            using (var db = new ModeContext())
            {
                return db.ModeRecords.ToList();
            }
        }

        public static int GetCount()
        {
            using (var db = new ModeContext())
            {
                return db.ModeRecords.ToList().Count();
            }
        }

        public static string GetMode(int id)
        {
            using (var db = new ModeContext())
            {
                var records = db.ModeRecords
                    .Where(mm => mm.Id == id)
                    .OrderBy(mm => mm.Id)
                    .ToList();

                if (records.Count <= 0)
                {
                    return null;
                }

                return records.ElementAt(0).Mode;
            }
        }
    }
}
