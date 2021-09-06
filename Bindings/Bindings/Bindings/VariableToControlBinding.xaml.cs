using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bindings {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MyData : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private int data;
        public int Value {
            get {
                return data;
            }
            set {
                if (data != value) {
                    data = value;
                    RaisePropertyChanged();
                }
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private float point1;
        private float point2;

        public float RetPoint1
        {
            get { return point1; }
            set { if (point1 != value) { point1 = value; RaisePropertyChanged(); } }
        }
        public float RetPoint2
        {
            get { return point2; }
            set { if (point2 != value) { point2 = value; RaisePropertyChanged(); } }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class VariableToControlBinding : ContentPage {
        MyData myData = new MyData { Value = 0 };
        MyPoint myPoint = new MyPoint { RetPoint1 = 0.0f, RetPoint2 = 0.0f };
        public VariableToControlBinding() {
            InitializeComponent();
            varValue.SetBinding(Label.TextProperty, new Binding { Source = myData, Path = "Value" });

            point1.SetBinding(Label.TextProperty, new Binding { Source = myPoint, Path = "RetPoint1" });
            point2.SetBinding(Label.TextProperty, new Binding { Source = myPoint, Path = "RetPoint2" });

            BindingContext = this;

            Device.StartTimer(new TimeSpan(0, 0, 1), () => { myPoint.RetPoint1 = RandomNumber(); return true; });
            Device.StartTimer(new TimeSpan(0, 0, 1), () => { myPoint.RetPoint2 = RandomNumber(); return true; });

            Device.StartTimer(new TimeSpan(0, 0, 1), () => { myData.Value += 1; return true; });
        }
        Random random = new Random();
        public float RandomNumber()
        {
            return (float)random.NextDouble();
        }
    }

    
}
