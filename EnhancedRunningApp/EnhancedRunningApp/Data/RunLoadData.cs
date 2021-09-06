using System;
namespace EnhancedRunningApp.Data
{
    public class RunLoadData
    {

        static Random rand = new Random();
        static DateTime start = new DateTime(2020, 1, 1);
        static DateTime end = new DateTime(2024, 12, 31);
        static float randMile()
        {
            return (float)Math.Round(rand.NextDouble() * 15, 2);
        }

        static TimeSpan GetTimeSpan(float mile)
        {
            int speed = rand.Next(3, 7);

            return TimeSpan.FromHours(mile / speed);
        }

        public static void LoadData()
        {
            for (DateTime date = start; date < end; date = date.AddDays(2))
            {
                var m = randMile();

                var newRun = new RunningData
                {
                    DateRun = date,
                    Dur = GetTimeSpan(m),
                    Dist = m
                };
                Database.conn.Insert(newRun);
            }
        }
  //      public static void GenerateRunData(int startYear, int numYears)
		//{
  //          const double baseMileage = 3.0;
  //          for (int dy = 0; dy < numYears; dy++)
  //          {
  //              int year = startYear + dy;
  //              double yearAdjustment = 1.0 + dy * 0.01;
  //              for (int month = 1; month <= 12; month++)
  //              {
  //                  double monthAdjustment = 1.0 + month * 0.02;
  //                  for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
  //                  {
  //                      DateTime date = new DateTime(year, month, day);
  //                      double length = 0;
  //                      switch (date.DayOfWeek)
  //                      {
  //                          case DayOfWeek.Monday:
  //                              continue;
  //                              break;
  //                          case DayOfWeek.Tuesday:
  //                              length = baseMileage;
  //                              break;
  //                          case DayOfWeek.Wednesday:
  //                              length = 1.5 * baseMileage;
  //                              break;
  //                          case DayOfWeek.Thursday:
  //                              length = 2 * baseMileage;
  //                              break;
  //                          case DayOfWeek.Friday:
  //                              length = 2 * baseMileage;
  //                              break;
  //                          case DayOfWeek.Saturday:
  //                              length = baseMileage;
  //                              break;
  //                          case DayOfWeek.Sunday:
  //                              length = 4 * baseMileage;
  //                              break;
  //                      }
  //                      int runLengthInMiles = (int)Math.Round(yearAdjustment * monthAdjustment * length);
  //                      int secondsToCompleteRun = runLengthInMiles * 480;      // 8 minutes per mile
  //                                                                              // Instead of printing, you should insert the run into your database.
  //                      var addRun = new RunningData
  //                      {
  //                          DateRun = date.Date,
  //                          Dur = new TimeSpan(date.Hour, date.Minute, secondsToCompleteRun),
  //                          Dist = runLengthInMiles
  //                      };


  //                      var run1 = new RunningData { DateRun = new DateTime(2020, 1, 12), Dur = new TimeSpan(5, 45, 10), Dist = 2 }; 
		//				Database.conn.Insert(run1);
		//			}
		//		}
		//	}
		//}
		//public static void Main(string[] args)
		//{
		//	GenerateRunData(2020, 1);   // 2020, 2021, 2022, 2023, 2024
		//}
	}
}
