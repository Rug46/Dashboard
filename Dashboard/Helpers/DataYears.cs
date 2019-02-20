using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class DataYears
    {
        public static int GetGameTime(DateTime day)
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .Where(ptm => ptm.Date.Date == day.Date)
                    .Where(ptm => ptm.Date.Day == day.Day)
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var count = 0;

                for (int i = 0; i < records.Count; i++)
                {
                    var id = records.ElementAt(i).Id;
                    count += Data.GetTimeDifference(id);
                }

                return count;
            }
        }

        public static DateTime GetFirstRecordDate()
        {
            using (var db = new Database())
            {
                var records = db.Activity
                    .OrderBy(ptm => ptm.Date)
                    .ToList();

                var single = records.ElementAt(0);

                return single.Date;
            }
        }

        public static int GetMonths(DateTime date1, DateTime date2)
        {
            return ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
        }

        public static string GetMonthID(DateTime month)
        {
            var monthNum = month.Month;
            var yearNum = month.Year;

            string monthS = "";

            if (monthNum == 1) monthS = "Jan";
            if (monthNum == 2) monthS = "Feb";
            if (monthNum == 3) monthS = "Mar";
            if (monthNum == 4) monthS = "Apr";
            if (monthNum == 5) monthS = "May";
            if (monthNum == 6) monthS = "Jun";
            if (monthNum == 7) monthS = "Jul";
            if (monthNum == 8) monthS = "Aug";
            if (monthNum == 9) monthS = "Sep";
            if (monthNum == 10) monthS = "Oct";
            if (monthNum == 11) monthS = "Nov";
            if (monthNum == 12) monthS = "Dec";

            return monthS + yearNum;
        }

        public static DateTime parseMonthID(string monthID, string day)
        {
            string month = monthID.Substring(0, 3);
            string year = month.Substring(3, 4);

            string yearS = "";
            string monthS = "";
            string dayS = day;

            yearS = year;

            if (month == "Jan") monthS = "01";
            if (month == "Feb") monthS = "02";
            if (month == "Mar") monthS = "03";
            if (month == "Apr") monthS = "04";
            if (month == "May") monthS = "05";
            if (month == "Jun") monthS = "06";
            if (month == "Jul") monthS = "07";
            if (month == "Aug") monthS = "08";
            if (month == "Sep") monthS = "09";
            if (month == "Oct") monthS = "10";
            if (month == "Nov") monthS = "11";
            if (month == "Dec") monthS = "12";

            if (month == "Feb" && int.Parse(day) > 28) dayS = "28";

            if (month == "Apr" && int.Parse(day) > 30) dayS = "30";
            if (month == "Jun" && int.Parse(day) > 30) dayS = "30";
            if (month == "Sep" && int.Parse(day) > 30) dayS = "30";
            if (month == "Nov" && int.Parse(day) > 30) dayS = "30";

            return DateTime.Parse(yearS + "-" + monthS + "-" + dayS + " 00:00");
        }

        public static string GetMonthName(DateTime month)
        {
            var monthNum = month.Month;
            var yearNum = month.Year;

            string monthS = "";

            if (monthNum == 1) monthS = "January";
            if (monthNum == 2) monthS = "February";
            if (monthNum == 3) monthS = "March";
            if (monthNum == 4) monthS = "April";
            if (monthNum == 5) monthS = "May";
            if (monthNum == 6) monthS = "June";
            if (monthNum == 7) monthS = "July";
            if (monthNum == 8) monthS = "August";
            if (monthNum == 9) monthS = "September";
            if (monthNum == 10) monthS = "October";
            if (monthNum == 11) monthS = "November";
            if (monthNum == 12) monthS = "December";

            return monthS + " " + yearNum;
        }
    }
}
