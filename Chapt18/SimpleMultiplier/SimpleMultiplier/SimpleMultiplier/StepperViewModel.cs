using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleMultiplier
{
    class StepperViewModel : INotifyPropertyChanged
    {

        double addend1, addend2, sum;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Addend1
        {
            set
            {
                if (addend1 != value)
                {
                    addend1 = value;
                    OnPropertyChanged("Addend1");
                    UpdateSum();
                }
            }
            get
            {
                return addend1;
            }
        }

        public double Addend2
        {
            set
            {
                if (addend2 != value)
                {
                    addend2 = value;
                    OnPropertyChanged("Addend2");
                    UpdateSum();
                }
            }
            get
            {
                return addend2;
            }
        }

        public double Sum
        {
            set
            {
                if (sum != value)
                {
                    sum = value;
                    OnPropertyChanged("Sum");
                }
            }
            get
            {
                return sum;
            }
        }


        private void UpdateSum()
        {
            Sum = Addend1 + Addend2;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
