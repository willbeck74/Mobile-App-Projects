using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SimpleMultiplier
{
    public partial class SimpleMultiplierPage : ContentPage
    {
        public SimpleMultiplierPage()
        {
            InitializeComponent();

            var a1 = addend1.Value;
            var a2 = addend2.Value;
            var sum = a1 + a2;

            addend1Lable.Text = a1 + "";

            addend2Lable.Text = " + " + a2;

            sumLabe.Text = " = " + sum;
        }

        private void addends_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var a1 = addend1.Value;
            var a2 = addend2.Value;
            var sum = a1 + a2;

            addend1Lable.Text = a1 + "";

            addend2Lable.Text = " + " + a2;

            sumLabe.Text = " = " + sum;

        }

    }
}
