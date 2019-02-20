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
            using (var db = new GameContext())
            {
                var records = db.GameRecords
                    .OrderBy(gm => gm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Game.ToLower() == name.ToLower())
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
                    Game = name
                };

                db.GameRecords.Add(single);
                db.SaveChanges();

                return true;
            }
        }

        public static void RemoveGame(int id)
        {
            using (var db = new GameContext())
            {
                db.GameRecords.Remove(GetModel(id));
                db.SaveChanges();
            }
        }

        public static GameModel GetModel(int id)
        {
            using (var db = new GameContext())
            {
                return db.GameRecords
                    .Where(gm => gm.Id == id)
                    .ToList()
                    .ElementAt(0);
            }
        }

        public static int GetID(string name)
        {
            using (var db = new GameContext())
            {
                return db.GameRecords
                    .Where(gm => gm.Game == name)
                    .ToList()
                    .ElementAt(0).Id;
            }
        }

        public static List<GameModel> GetList()
        {
            using (var db = new GameContext())
            {
                return db.GameRecords.ToList();
            }
        }

        public static int GetCount()
        {
            using (var db = new GameContext())
            {
                return db.GameRecords.ToList().Count();
            }
        }

        public static string GetGame(int id)
        {
            using (var db = new GameContext())
            {
                var records = db.GameRecords
                    .Where(gm => gm.Id == id)
                    .OrderBy(gm => gm.Id)
                    .ToList();

                return records.ElementAt(0).Game;
            }
        }

        public static bool IsFavourite(int id)
        {
            using (var db = new FavouriteContext())
            {
                var records = db.FavouriteRecords
                    .OrderBy(gm => gm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).GameID == id)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static void AddFavourite(int id)
        {
            using (var db = new FavouriteContext())
            {
                FavouriteModel single = new FavouriteModel
                {
                    GameID = id
                };

                db.FavouriteRecords.Add(single);
                db.SaveChanges();
            }
        }

        public static void RemoveFavourite(int id)
        {
            using (var db = new FavouriteContext())
            {
                var records = db.FavouriteRecords
                    .Where(fm => fm.GameID == id)
                    .OrderBy(fm => fm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    var single = records.ElementAt(i);
                    db.FavouriteRecords.Remove(single);
                }

                db.SaveChanges();
            }
        }

        public static List<FavouriteModel> GetFavourites()
        {
            using (var db = new FavouriteContext())
            {
                var records = db.FavouriteRecords
                    .OrderBy(gm => gm.Id)
                    .ToList();

                return records;
            }
        }
    }
}
