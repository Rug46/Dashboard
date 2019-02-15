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
        public static void NewGame(string name)
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
                        return;
                    }
                }

                GameModel single = new GameModel
                {
                    Game = name
                };

                db.GameRecords.Add(single);
                db.SaveChanges();
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
                return db.GameRecords.ToList().ElementAt(id).Game;
            }
        }
    }
}
