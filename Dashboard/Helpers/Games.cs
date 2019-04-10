using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Models;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Games
    {
        public static bool NewGame(string name)
        {
            using (var db = new Database())
            {
                var records = db.Games
                    .OrderBy(gm => gm.Id)
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

                GameModel single = new GameModel
                {
                    Name = name
                };

                db.Games.Add(single);
                db.SaveChanges();

                return true;
            }
        }

        public static void RemoveGame(int id)
        {
            using (var db = new Database())
            {
                db.Games.Remove(GetModel(id));
                db.SaveChanges();
            }
        }

        public static GameModel GetModel(int id)
        {
            using (var db = new Database())
            {
                return db.Games
                    .Where(gm => gm.Id == id)
                    .ToList()
                    .ElementAt(0);
            }
        }

        public static int GetID(string name)
        {
            using (var db = new Database())
            {
                return db.Games
                    .Where(gm => gm.Name == name)
                    .ToList()
                    .ElementAt(0).Id;
            }
        }

        public static int SearchGame(string name)
        {
            using (var db = new Database())
            {
                var records = db.Games
                    .Where(gm => gm.Name == name)
                    .OrderBy(gm => gm.Id)
                    .ToList();

                if (records.Count == 0)
                {
                    return 0;
                }

                return records.ElementAt(0).Id;
            }
        }

        public static List<GameModel> GetList()
        {
            using (var db = new Database())
            {
                return db.Games.ToList();
            }
        }

        public static int GetCount()
        {
            using (var db = new Database())
            {
                return db.Games.ToList().Count();
            }
        }

        public static string GetGame(int id)
        {
            using (var db = new Database())
            {
                var records = db.Games
                    .Where(gm => gm.Id == id)
                    .OrderBy(gm => gm.Id)
                    .ToList();

                return records.ElementAt(0).Name;
            }
        }

        public static List<string> GetGamesInActivity(int daysAgo)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date >= DateTime.Now.AddDays(-daysAgo))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var result = new List<string>();

                foreach (var record in records)
                {
                    if (!result.Contains(record.Game))
                    {
                        result.Add(record.Game);
                    }
                }

                return result;
            }
        }
    }
}
