using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstXAML
{
    public partial class MyXAMLPage : ContentPage
    {
        public MyXAMLPage()
        {
            InitializeComponent();
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkBox.Equals("True"))
                theLabel.Text = "Adult";
            else
            {
                theLabel.Text = "";
            }
        }
    }
}
