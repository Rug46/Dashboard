using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Backlog
    {
        public static List<string> GetSystems()
        {
            using (var db = new Database())
            {
                var records = db.Backlog
                    .OrderBy(bm => bm.Id)
                    .ToList();

                var list = new List<string>();

                for (int i = 0; i < records.Count; i++)
                {
                    var val = list
                        .Where(s => s.Contains(records.ElementAt(i).System));

                    if (val != null)
                    {
                        list.Add(records.ElementAt(i).System);
                    }
                }

                return list;
            }
        }

        public static int GetFromStatus(int status)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
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

        public static int GetFromStatus(int status, string system)
        {
            using (var db = new Database())
            {
                var records = db.Backlog
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
    }
}
