using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Setting
    {
        public static int GetSettingId(string key)
        {
            using (var db = new Database())
            {
                var records = db.Settings
                    .Where(s => s.SettingName == key)
                    .ToList();

                if (records.Count != 1)
                {
                    return -1;
                }
                else
                {
                    return records.ElementAt(0).SettingId;
                }
            }
        }

        public static string GetDefault(int id)
        {
            using (var db = new Database())
            {
                var records = db.Settings
                    .Where(s => s.SettingId == id)
                    .ToList();

                if (records.Count != 1)
                {
                    return null;
                }
                else
                {
                    return records.ElementAt(0).SettingDefault;
                }
            }
        }
    }
}
