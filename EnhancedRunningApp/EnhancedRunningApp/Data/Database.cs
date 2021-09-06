using System;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Xamarin.Essentials;

namespace EnhancedRunningApp.Data
{
    class Database
    {
        public static SQLiteConnection conn;
        public static string DataBaseName = "RunningData1.db";
        public static Collection<RunningData.YearRunData> yearDataList;

        //Open connection from file to database
        public static void DataConnection()
        {
            string lib = FileSystem.AppDataDirectory;
            string fileName = System.IO.Path.Combine(lib, DataBaseName);
            conn = new SQLiteConnection(fileName);
            conn.CreateTable<RunningData>();
        }

        public static void LoadData()
        {
            //Initialization of data objects -- ooof
            yearDataList = new Collection<RunningData.YearRunData>();
            var theData = conn.Table<RunningData>().ToList().OrderBy(i => i.DateRun);
            var startData = theData.First();
            var endData = theData.Last();

            for (var curYear = startData.DateRun.Year; curYear < endData.DateRun.Year; curYear++)
            {
                var currentYearRun = new RunningData.YearRunData() { Year = curYear, Dist = 0, Dur = TimeSpan.Zero };

                for (var curMonth = 1; curMonth <= 12; curMonth++)
                {
                    var currentMonthRun = new RunningData.MonthRunData() { MonthNum = curMonth, Dist = 0, Dur = TimeSpan.Zero };

                    var weekDay = 1;
                    for (var curWeek = getRunWeek(new DateTime(curYear, curMonth, 1));
                        curWeek <= new DateTime(curYear, curMonth, 1).AddMonths(1).AddDays(-1);
                        curWeek = curWeek.AddDays(7))
                    {
                        var temp = theData.Where(i => SameRunWeek(i.DateRun, curWeek));
                        var currentWeekRun = new RunningData.WeekRunData(temp, weekDay);
                        currentWeekRun.SetWeek();
                        currentMonthRun.Add(currentWeekRun);
                        weekDay++;
                    }
                    currentMonthRun.SetMonth();
                    currentYearRun.Add(currentMonthRun);
                }

                currentYearRun.SetYear();
                yearDataList.Add(currentYearRun);

            }
        }

        public static bool SameRunWeek(DateTime a, DateTime b) {
            var calendar = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar; //keep note of this for future. Forever to find on xamarin forms
            var firstDate = a.Date.AddDays((int)calendar.GetDayOfWeek(a) * (-1));
            var secondDate = b.Date.AddDays((int)calendar.GetDayOfWeek(b) * (-1));

            if (firstDate == secondDate) return true;
            return false;
            }

        public static DateTime getRunWeek(DateTime d) { return d.AddDays((int)d.DayOfWeek * (-1)); }
        

    }
}
