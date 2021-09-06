using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class DateTimeViewModel : INotifyPropertyChanged
    {
        DateTime dateTime = DateTime.Now;
        DateTime startTime = DateTime.Now;
        string elapsedTime = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTimeViewModel()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
            StartTime = DateTime.Now;
        }

        bool OnTimerTick()
        {
            DateTime = DateTime.Now;
            StartTime = DateTime.Now;
            ElapsedTime = dateTime.Second % 2 == 1 ? "Odd" : "Even";
			return true;
        }

        public DateTime StartTime
        {
            private set
            {
                if (startTime != value)
                {
                    startTime = value;

                    // Fire the event.
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartTime"));
                }
            }

            get
            {
                return startTime;
            }
        }

        public String ElapsedTime
        {
            get
            {
                return elapsedTime;
            }
            set
            {
                elapsedTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElapsedTime"));
            }
        }

        public DateTime DateTime
        {
            private set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    // Fire the event.
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
                }
            }

            get
            {
                return dateTime;
            }
		}


    }
}
