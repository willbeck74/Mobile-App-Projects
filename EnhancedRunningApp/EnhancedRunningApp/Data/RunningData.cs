using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Essentials;

namespace EnhancedRunningApp.Data
{
    public class RunningData
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime DateRun { get; set; }
        public TimeSpan Dur { get; set; }
        public float Dist { get; set; }

        public string GetDate { get { return DateRun.ToString("yy/mm/dd"); } }
        public string GetWeek { get { return DateRun.ToString("ddd"); } }
        public string GetDur { get { return Dur.ToString(@"hh\:mm"); } }
        public string GetDist { get {
                if (Preferences.Get("MilesPref", true))
                    return Dist.ToString("f2") + " miles";
                else
                    return MtoK(Dist).ToString("f2") + " km";
            }
        }

        public override string ToString() { return string.Format("Week:{0} Dist:{1} Dur:{2}", GetWeek, GetDist, GetDur); }
        public static float MtoK(float m) { return m / 0.6213f; }
        public static float KtoM (float k) { return k * 0.6213f; }

        public class DayRunData : ObservableCollection<RunningData>
        {
            public int WeekNum { get; set; }
            public float Dist { get; set; }
            public string weekDay { get; set; }
            public TimeSpan Dur { get; set; }
            public DayRunData(IEnumerable<RunningData> collection, int weekDay) : base(collection) { WeekNum = weekDay; }

            public void SetWeek()
            {
                Dist = 0f;
                Dur = TimeSpan.Zero;
                foreach (RunningData temp in Items)
                {
                    Dist += temp.Dist;
                    Dur = Dur.Add(temp.Dur);
                }
            }

            public float getMaxDist()
            {
                float max = 0;
                foreach (var temp in Items)
                {
                    if (temp.Dist >= max)
                    {
                        max = temp.Dist;
                    }
                }
                return max;
            }

            public string GetDist
            {
                get
                {
                    if (Preferences.Get("MilesPref", true))
                        return Dist.ToString("f2") + " miles";
                    else
                        return MtoK(Dist).ToString("f2") + " km";
                }
            }

            public float getMinDist()
            {
                float min = getMaxDist();
                foreach (var temp in Items)
                {
                    if (temp.Dist <= min)
                    {
                        min = temp.Dist;
                    }
                }
                return min;
            }

            public override string ToString() { return string.Format("Day {0} - {1}", weekDay, GetDist); }
        }





        //------------------------------------------------------------ Week Data Formation

        public class WeekRunData : ObservableCollection<RunningData>
        {
            public int WeekNum { get; set; }
            public float Dist{ get; set; }
            public TimeSpan Dur { get; set; }
            public WeekRunData(IEnumerable<RunningData> collection, int weekDay) : base(collection) { WeekNum = weekDay; }

            public void SetWeek()
            {
                Dist = 0f;
                Dur = TimeSpan.Zero;
                foreach (RunningData temp in Items) {
                    Dist += temp.Dist;
                    Dur = Dur.Add(temp.Dur);
                }
            }

            public float getMaxDist()
            {
                float max = 0;
                foreach (var temp in Items) {
                    if (temp.Dist >= max) {
                        max = temp.Dist;
                    }
                }
                return max;
            }

            public string GetDist
            {
                get
                {
                    if (Preferences.Get("MilesPref", true))
                        return Dist.ToString("f2") + " miles";
                    else
                        return MtoK(Dist).ToString("f2") + " km";
                }
            }

            public float getMinDist()
            {
                float min = getMaxDist();
                foreach (var temp in Items) {
                    if (temp.Dist <= min) {
                        min = temp.Dist;
                    }
                }
                return min;
            }

            public override string ToString() { return string.Format("week {0} - {1}", WeekNum, GetDist); }
        }

        //------------------------------------------------------------ Month Data Formation

        public class MonthRunData : ObservableCollection<WeekRunData>
        {
            string[] monthTitles = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            public int MonthNum { get; set; }
            public float Dist { get; set; }
            public TimeSpan Dur { get; set; }

            public void SetMonth()
            {
                Dist = 0f;
                Dur = TimeSpan.Zero;
                foreach (WeekRunData temp in Items) {
                    Dist += temp.Dist;
                    Dur = Dur.Add(temp.Dur);
                }
            }

            public string GetDist
            {
                get
                {
                    if (Preferences.Get("MilesPref", true))
                        return Dist.ToString("f2") + " miles";
                    else
                        return MtoK(Dist).ToString("f2") + " km";
                }
            }

            public float getMaxDist()
            {
                float max = 0;
                foreach (var temp in Items) {
                    if (temp.Dist >= max) {
                        max = temp.Dist;
                    }
                }
                return max;
            }

            public float getMinDist()
            {
                float min = getMaxDist();
                foreach (var temp in Items) {
                    if (temp.Dist <= min) {
                        min = temp.Dist;
                    }
                }
                return min;
            }

            public override string ToString() { return string.Format("{0} - {1}", monthTitles[MonthNum - 1], GetDist); }
        }

        //------------------------------------------------------------ Year Data Formation

        public class YearRunData : ObservableCollection<MonthRunData>
        {
            public int Year { get; set; }
            public float Dist { get; set; }
            public TimeSpan Dur { get; set; }
            public void SetYear()
            {
                Dist = 0f;
                Dur = TimeSpan.Zero;
                foreach (MonthRunData temp in Items)
                {
                    Dist += temp.Dist;
                    Dur = Dur.Add(temp.Dur);
                }
            }

            public string GetDist
            {
                get {
                    if (Preferences.Get("MilesPref", true))
                        return Dist.ToString("f2") + " miles";
                    else
                        return MtoK(Dist).ToString("f2") + " km";
                }
            }

            public float getMaxDist()
            {
                float max = 0;
                foreach (var temp in Items) {
                    if (temp.Dist >= max) {
                        max = temp.Dist;
                    }
                }
                return max;
            }

            public float getMinDist()
            {
                float min = getMaxDist();
                foreach (var temp in Items) {
                    if (temp.Dist <= min) {
                        min = temp.Dist;
                    }
                }
                return min;
            }

            public override string ToString() { return string.Format("{0} - {1}", Year, GetDist); }
        }
    }

}
