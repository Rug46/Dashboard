using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Data
    {

        public static int GetTimeDifference(int id)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Id == id)
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                var recordStart = records.ElementAt(0).Date;
                var recordEnd = records.ElementAt(0).Finish;

                var duration = (recordEnd - recordStart).TotalMinutes;

                return (int)Math.Floor(duration);
            }
        }

        public static int GetGameTimeHour(DateTime hour)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date == hour.Date)
                    .Where(ptm => ptm.Date.Hour == hour.Hour)
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    var id = records.ElementAt(i).Id;
                    count += GetTimeDifference(id);
                }

                return count;
            }
        }

        public static int GetGameTimeDay(DateTime day)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date == day.Date)
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    var id = records.ElementAt(i).Id;
                    count += GetTimeDifference(id);
                }

                return count;
            }
        }

        public static int GetGameTimeGame(DateTime day, int GameID)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date == day.Date)
                    .Where(ptm => ptm.Game == Games.GetGame(GameID))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    var id = records.ElementAt(i).Id;
                    count += GetTimeDifference(id);
                }

                return count;
            }
        }

        public static String GetPlayTimeLast24H()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    count += GetTimeDifference(records.ElementAt(i).Id);
                }

                if (count < 60)
                {
                    return count + "m";
                }
                else
                {
                    return count / 60 + "h";
                }
            }
        }

        public static String GetPlayTimeLast7D()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    count += GetTimeDifference(records.ElementAt(i).Id);
                }

                if (count < 60)
                {
                    return count + "m";
                }
                else
                {
                    return count / 60 + "h";
                }
            }
        }

        public static String GetPlayTimeLast28D()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    count += GetTimeDifference(records.ElementAt(i).Id);
                }

                if (count < 60)
                {
                    return count + "m";
                }
                else
                {
                    return count / 60 + "h";
                }
            }
        }

        public static int GetMostPlayedTime(int place)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var gameNames = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!gameNames.Contains(records.ElementAt(i).Game))
                    {
                        gameNames.Add(records.ElementAt(i).Game);
                    }
                }

                var gameMinutes = new List<int>();

                for (int i = 0; i < gameNames.Count; i++)
                {
                    var gameRecords = records.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsCount = 0;

                    for (int j = 0; j < gameRecords.Count; j++)
                    {
                        gameRecordsCount += int.Parse((gameRecords.ElementAt(j).Finish - gameRecords.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    gameMinutes.Add(gameRecordsCount);
                }

                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();


                if (place - 1 >= gameMinutesOrdered.Count)
                {
                    return 0;
                }

                return gameMinutesOrdered.ElementAt(place - 1);
            }
        }

        public static String GetMostPlayedName(int place)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var gameNames = new List<String>();
                var gameNamesOrdered = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!gameNames.Contains(records.ElementAt(i).Game))
                    {
                        // count++;
                        gameNames.Add(records.ElementAt(i).Game);
                    }
                }

                var gameMinutes = new List<int>();

                for (int i = 0; i < gameNames.Count; i++)
                {
                    var gameRecords = records.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsCount = 0;

                    for (int j = 0; j < gameRecords.Count; j++)
                    {
                        gameRecordsCount += int.Parse((gameRecords.ElementAt(j).Finish - gameRecords.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    gameMinutes.Add(gameRecordsCount);
                }

                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();

                gameNamesOrdered = gameNames.Zip(gameMinutes, Tuple.Create).OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();

                if (place - 1 >= gameMinutesOrdered.Count)
                {
                    return "";
                }

                return gameNamesOrdered.ElementAt(place - 1).Trim();
            }
        }

        public static int GetMostPlayedTimeToday(int place)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var gameNames = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!gameNames.Contains(records.ElementAt(i).Game))
                    {
                        gameNames.Add(records.ElementAt(i).Game);
                    }
                }

                var gameMinutes = new List<int>();

                for (int i = 0; i < gameNames.Count; i++)
                {
                    var gameRecords = records.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsCount = 0;

                    for (int j = 0; j < gameRecords.Count; j++)
                    {
                        gameRecordsCount += int.Parse((gameRecords.ElementAt(j).Finish - gameRecords.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    gameMinutes.Add(gameRecordsCount);
                }

                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();

                if (place - 1 >= gameMinutesOrdered.Count)
                {
                    return 0;
                }

                return gameMinutesOrdered.ElementAt(place - 1);
            }
        }

        public static String GetMostPlayedTimeFormatted(int place)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var gameNames = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!gameNames.Contains(records.ElementAt(i).Game))
                    {
                        gameNames.Add(records.ElementAt(i).Game);
                    }
                }

                var gameMinutes = new List<int>();

                for (int i = 0; i < gameNames.Count; i++)
                {
                    var gameRecords = records.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsCount = 0;

                    for (int j = 0; j < gameRecords.Count; j++)
                    {
                        gameRecordsCount += int.Parse((gameRecords.ElementAt(j).Finish - gameRecords.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    gameMinutes.Add(gameRecordsCount);
                }

                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();

                if (place - 1 >= gameMinutesOrdered.Count)
                {
                    return "";
                }

                var placeMinutes = gameMinutesOrdered.ElementAt(place - 1);

                if (placeMinutes < 60)
                {
                    return placeMinutes + " Minutes";
                }
                else
                {
                    return placeMinutes / 60 + " Hours";
                }
            }
        }

        public static String GetMostPlayedTimeTodayFormatted(int place)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var recordsToday = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var gameNames = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!gameNames.Contains(records.ElementAt(i).Game))
                    {
                        gameNames.Add(records.ElementAt(i).Game);
                    }
                }

                var gameMinutes = new List<int>();
                var gameMinutesToday = new List<int>();

                for (int i = 0; i < gameNames.Count; i++)
                {
                    var gameRecords = records.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsCount = 0;

                    var gameRecordsToday = recordsToday.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsTodayCount = 0;

                    for (int j = 0; j < gameRecords.Count; j++)
                    {
                        gameRecordsCount += int.Parse((gameRecords.ElementAt(j).Finish - gameRecords.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    for (int j = 0; j < gameRecordsToday.Count; j++)
                    {
                        gameRecordsTodayCount += int.Parse((gameRecordsToday.ElementAt(j).Finish - gameRecordsToday.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    gameMinutes.Add(gameRecordsCount);
                    gameMinutesToday.Add(gameRecordsTodayCount);
                }

                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();
                var gameMinutesTodayOrdered = gameMinutesToday.Zip(gameMinutes, Tuple.Create).OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();

                if (place - 1 >= gameMinutesTodayOrdered.Count || place - 1 >= gameMinutesOrdered.Count)
                {
                    return "0 Minutes";
                }

                var placeMinutes = gameMinutesTodayOrdered.ElementAt(place - 1);

                if (placeMinutes < 60)
                {
                    return placeMinutes + " Minutes";
                }
                else
                {
                    return placeMinutes / 60 + " Hours";
                }
            }
        }

        public static List<String> GetGames()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Game)
                    .ToList();

                var gameNames = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!gameNames.Contains(records.ElementAt(i).Game))
                    {
                        gameNames.Add(records.ElementAt(i).Game);
                    }
                }

                return gameNames;
            }
        }

        public static List<String> GetModes()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Mode)
                    .ToList();

                var modeNames = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if (!modeNames.Contains(records.ElementAt(i).Mode))
                    {
                        modeNames.Add(records.ElementAt(i).Mode);
                    }
                }

                return modeNames;
            }
        }

        public static String GetGameLast(int item)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .OrderByDescending(ptm => ptm.Id)
                    .ToList();

                var recordsSorted = new List<String>();

                for (int i = 0; i < records.Count; i++)
                {
                    if(!recordsSorted.Contains(records.ElementAt(i).Game)) {
                        recordsSorted.Add(records.ElementAt(i).Game);
                    }
                }

                recordsSorted.Reverse();

                if(recordsSorted.Count - item < 0)
                {
                    return "";
                }

                return recordsSorted.ElementAt(recordsSorted.Count - item);
            }
        }

        public static String GetModeLast(int item)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .OrderByDescending(ptm => ptm.Id)
                    .ToList();

                var recordsSorted = new List<String>();

                for(int i = 0; i < records.Count; i++)
                {
                    if(!recordsSorted.Contains(records.ElementAt(i).Mode))
                    {
                        recordsSorted.Add(records.ElementAt(i).Mode);
                    }
                }

                recordsSorted.Reverse();

                if(records.Count - item < 0)
                {
                    return "";
                }

                return recordsSorted.ElementAt(recordsSorted.Count - item);
            }
        }

        public static bool Any24H()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool Any7D()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool Any28D()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                if (records.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
