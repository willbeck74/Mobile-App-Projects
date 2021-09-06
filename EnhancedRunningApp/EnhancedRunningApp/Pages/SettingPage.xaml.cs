using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace EnhancedRunningApp.Pages
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

            genderPicker.Items.Add("Male");
            genderPicker.Items.Add("Female");

            if (!Preferences.ContainsKey("Gender"))
                Preferences.Set("Gender", 1);
            genderPicker.SelectedIndex = Preferences.Get("Gender", 1);


            if (!Preferences.ContainsKey("MilesPref"))
                Preferences.Set("MilesPref", true);
            distSwitch.IsToggled = Preferences.Get("MilesPref", true);

            if (!Preferences.ContainsKey("DOB"))
                Preferences.Set("DOB", new DateTime(1995, 1, 1, 1, 0, 0));
            DOBpicker.Date = Preferences.Get("DOB", new DateTime(1995, 1, 1, 1, 0, 0));
        }

        private void distSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Preferences.Set("MilesPref", distSwitch.IsToggled);
        }

        private void DOBpicker_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Preferences.Set("DOB", DOBpicker.Date);
        }

        private async void Button_ClickedAsync(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync("https://miamioh.edu/", BrowserLaunchMode.SystemPreferred);
        }

        private void genderChanged(System.Object sender, EventArgs e)
        {
            Preferences.Set("Gender", genderPicker.SelectedIndex);
        }
    }
}
