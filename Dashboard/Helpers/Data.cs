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
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Id == id)
                    .OrderBy(ptm => ptm.Id)
                    .ToList();

                var recordStart = records.ElementAt(0).Date;
                var recordEnd = records.ElementAt(0).Finish;

                var duration = (recordEnd - recordStart).TotalMinutes;

                result = (int)Math.Floor(duration);
            }

            return result;
        }

        public static int GetGameTimeHour(DateTime hour)
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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

                result = count;
            }

            return result;
        }

        public static int GetGameTimeDay(DateTime day)
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date == day.Date)
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    var id = records.ElementAt(i).Id;
                    count += GetTimeDifference(id);
                }

                result = count;
            }

            return result;
        }

        public static String GetPlayTimeLast24H()
        {
            var result = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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
                    result = count + "m";
                }
                else
                {
                    result = count / 60 + "h";
                }
            }

            return result;
        }

        public static String GetPlayTimeLast7D()
        {
            var result = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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
                    result = count + "m";
                }
                else
                {
                    result = count / 60 + "h";
                }
            }

            return result;
        }

        public static String GetPlayTimeLast28D()
        {
            var result = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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
                    result = count + "m";
                }
                else
                {
                    result = count / 60 + "h";
                }
            }

            return result;
        }

        public static int GetMostPlayedTime(int place)
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                // var count = 0;
                var gameNames = new List<String>();

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

                //var gameMinutesOrdered = gameMinutes.OrderBy(x => x).ToList();
                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();


                if (place - 1 >= gameMinutesOrdered.Count)
                {
                    return 0;
                }

                result = gameMinutesOrdered.ElementAt(place - 1);
            }

            return result;
        }

        public static String GetMostPlayedName(int place)
        {
            var result = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                // var count = 0;
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

                //for(int i = 0; i < gameNames.Count; i++)
                //{
                //    gameNamesOrdered.Add("");
                //}

                for (int i = 0; i < gameNames.Count; i++)
                {
                    var gameRecords = records.FindAll(ptm => ptm.Game == gameNames.ElementAt(i));
                    var gameRecordsCount = 0;

                    for (int j = 0; j < gameRecords.Count; j++)
                    {
                        gameRecordsCount += int.Parse((gameRecords.ElementAt(j).Finish - gameRecords.ElementAt(j).Date).TotalMinutes.ToString());
                    }

                    gameMinutes.Add(gameRecordsCount);
                    //gameNamesOrdered.Add(gameNames.ElementAt(i));
                }

                //var gameMinutesOrdered = gameMinutes.OrderBy(x => x).ToList();
                var gameMinutesOrdered = gameMinutes.OrderByDescending(x => x).ToList();

                //gameNamesOrdered = gameNames.Zip(gameMinutes, Tuple.Create).OrderBy(x => x.Item2).Select(x => x.Item1).ToList();
                gameNamesOrdered = gameNames.Zip(gameMinutes, Tuple.Create).OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();

                if (place - 1 >= gameMinutesOrdered.Count)
                {
                    return "";
                }

                result = gameNamesOrdered.ElementAt(place - 1);
            }

            return result;
        }

        public static int GetMostPlayedTimeToday(int place)
        {
            var result = 0;

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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

                result = gameMinutesOrdered.ElementAt(place - 1);
            }

            return result;
        }

        public static String GetMostPlayedTimeFormatted(int place)
        {
            var result = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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
                    result = placeMinutes + " Minutes";
                }
                else
                {
                    result = placeMinutes / 60 + " Hours";
                }
            }

            return result;
        }

        public static String GetMostPlayedTimeTodayFormatted(int place)
        {
            var result = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var recordsToday = db.PlaytimeRecords
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
                //var gameMinutesTodayOrdered = gameMinutesToday.OrderByDescending(x => x).ToList();
                var gameMinutesTodayOrdered = gameMinutesToday.Zip(gameMinutes, Tuple.Create).OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();

                if (place - 1 >= gameMinutesTodayOrdered.Count || place - 1 >= gameMinutesOrdered.Count)
                {
                    return "0 Minutes";
                }

                //var placeMinutes = gameMinutesOrdered.ElementAt(place - 1);
                var placeMinutes = gameMinutesTodayOrdered.ElementAt(place - 1);

                if (placeMinutes < 60)
                {
                    result = placeMinutes + " Minutes";
                }
                else
                {
                    result = placeMinutes / 60 + " Hours";
                }
            }

            return result;
        }

        public static List<String> GetGames()
        {
            var games = new List<String>();

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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

                games = gameNames;
            }

            return games;
        }

        public static List<String> GetModes()
        {
            var modes = new List<String>();

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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

                modes = modeNames;
            }

            return modes;
        }

        public static String GetGameLast(int item)
        {
            var game = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .OrderByDescending(ptm => ptm.Id)
                    .ToList();

                //var recordsSorted = new List<PlaytimeModel>();
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

                game = recordsSorted.ElementAt(recordsSorted.Count - item);
            }

            return game;
        }

        public static String GetModeLast(int item)
        {
            var mode = "";

            using (var db = new PlaytimeContext())
            {
                var records = db.PlaytimeRecords
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

                mode = recordsSorted.ElementAt(recordsSorted.Count - item);
            }

            return mode;
        }
    }
}
