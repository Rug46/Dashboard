using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class Backlog
    {
        public static List<string> GetSystems(int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bl => bl.UserId == user)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                var list = new List<string>();

                for (int i = 0; i < records.Count; i++)
                {

                    if (!list.Contains(records.ElementAt(i).System))
                    {
                        list.Add(records.ElementAt(i).System);
                    }
                }

                list.Sort();

                return list;
            }
        }

        public static int GetFromStatus(int status, int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bl => bl.UserId == user)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Status == status)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public static int GetFromStatus(int status, string system, int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .Where(bm => bm.System == system)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Status == status)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public static double GetFromStatusPercentage(int status, int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                int count = 0;
                int total = records.Count;

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Status == status)
                    {
                        count++;
                    }
                }

                if (total == 0)
                {
                    return 0;
                }

                return (double) count / (double) total * (double) 100;
            }
        }

        public static int GetFromStatusPercentage(int status, string system, int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .Where(bm => bm.System == system)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                var count = 0;
                var total = records.Count;

                for (int i = 0; i < records.Count; i++)
                {
                    if (records.ElementAt(i).Status == status)
                    {
                        count++;
                    }
                }

                if (total == 0)
                {
                    return 0;
                }

                return (count / total) * 100;
            }
        }

        public static bool New(string Name, string Compilation, string System, int Status, string Progress, bool NowPlaying, int user)
        {
            using (var db = new Database())
            {
                var NowPlayingInt = 0;

                if (NowPlaying) NowPlayingInt = 1;

                if (Name == null || System == null)
                {
                    return false;
                }

                var single = new BacklogModel
                {
                    Name = Name,
                    System = System,
                    Status = Status,
                    Progress = Progress,
                    NowPlaying = NowPlayingInt,
                    UserId = user
                };

                db.Backlog.Add(single);
                db.SaveChanges();

                return true;
            }
        }

        public static int GetSystemTotal(string system, int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .Where(bm => bm.System == system)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                return records.Count;
            }
        }

        public static int GetTotal(int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                return records.Count;
            }
        }

        public static BacklogModel Get(int id)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.Id == id)
                    .ToList();

                if (records.Count != 1)
                {
                    return null;
                }

                return records.ElementAt(0);
            }
        }

        public static bool Edit(int id, string Name, string Compilation, string System, int Status, string Progress, int Rating, bool NowPlaying)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.Id == id)
                    .ToList();

                var NowPlayingInt = 0;

                if (NowPlaying) NowPlayingInt = 1;

                if (records.Count != 1)
                {
                    return false;
                }

                if (Name == null || System == null)
                {
                    return false;
                }

                if (Rating > 5 || Rating < 0)
                {
                    return false;
                }

                records.ElementAt(0).Name = Name;
                records.ElementAt(0).System = System;
                records.ElementAt(0).Status = Status;
                records.ElementAt(0).Progress = Progress;
                records.ElementAt(0).Rating = Rating;
                records.ElementAt(0).NowPlaying = NowPlayingInt;

                db.SaveChanges();

                return true;
            }
        }

        public static void Delete(int id)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.Id == id)
                    .ToList();

                db.Backlog.Remove(records.ElementAt(0));
                db.SaveChanges();
            }
        }

        public static List<BacklogModel> GetBacklogModelsFromSystem(string System, int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .Where(bm => bm.System == System)
                    .OrderBy(bm => bm.Id)
                    .ToList();

                if (records.Count == 0)
                {
                    return null;
                }

                return records;
            }
        }

        public static List<BacklogModel> GetAllGamesBySystem(int user)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .Where(bm => bm.UserId == user)
                    .OrderBy(bm => bm.System)
                    .ToList();

                var list = new List<List<BacklogModel>>();
                var result = new List<BacklogModel>();
                var systems = new List<string>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!systems.Contains(records.ElementAt(i).System))
                    {
                        systems.Add(records.ElementAt(i).System);

                        var systemList = records
                            .Where(bm => bm.System == records.ElementAt(i).System)
                            .OrderBy(bm => bm.Name)
                            .ToList();

                        list.Add(systemList);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list.ElementAt(i).Count; j++)
                    {
                        result.Add(list.ElementAt(i).ElementAt(j));
                    }
                }

                return result;
            }
        }
    }
}
