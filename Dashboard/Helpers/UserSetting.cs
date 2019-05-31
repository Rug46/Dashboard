using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class UserSetting
    {
        public static string GetSettingValue(int userid, int setting)
        {
            using (var db = new Database())
            {
                var records = db.UserSettings
                    .Where(us => us.UserId == userid)
                    .Where(us => us.SettingId == setting)
                    .ToList();

                if (records.Count != 1)
                {
                    return null;
                }

                return records.ElementAt(0).Value;
            }
        }

        public static string GetSettingValueOrDefault(int userid, int setting)
        {
            var value = GetSettingValue(userid, setting);

            if (value == null)
            {
                return Setting.GetDefault(setting);
            }
            else
            {
                return value;
            }
        }

        public static void SetSettingValue(int userid, int setting, string value)
        {
            using (var db = new Database())
            {
                var records = db.UserSettings
                    .Where(us => us.UserId == userid)
                    .Where(us => us.SettingId == setting)
                    .ToList();

                if (records.Count == 0)
                {
                    var single = new UserSettingModel
                    {
                        UserId = userid,
                        SettingId = setting,
                        Value = value
                    };

                    db.UserSettings.Add(single);
                }
                else
                {
                    records.ElementAt(0).Value = value;
                }

                db.SaveChanges();
            }
        }
    }
}
