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

        public static bool IsFavourite(int id)
        {
            using (var db = new Database())
            {
                var records = db.Favourites
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
            using (var db = new Database())
            {
                FavouriteModel single = new FavouriteModel
                {
                    GameID = id
                };

                db.Favourites.Add(single);
                db.SaveChanges();
            }
        }

        public static void RemoveFavourite(int id)
        {
            using (var db = new Database())
            {
                var records = db.Favourites
                    .Where(fm => fm.GameID == id)
                    .OrderBy(fm => fm.Id)
                    .ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    var single = records.ElementAt(i);
                    db.Favourites.Remove(single);
                }

                db.SaveChanges();
            }
        }

        public static List<FavouriteModel> GetFavourites()
        {
            using (var db = new Database())
            {
                var records = db.Favourites
                    .OrderBy(gm => gm.Id)
                    .ToList();

                return records;
            }
        }
    }
}
