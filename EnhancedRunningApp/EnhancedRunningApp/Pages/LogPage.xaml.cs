using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using EnhancedRunningApp.Data;
using Xamarin.Essentials;

namespace EnhancedRunningApp
{
    public partial class LogPage : ContentPage
    {
        public LogPage()
        {
            InitializeComponent();
            RefreshLV();

            //Populate Pickers
            for(int i = 0; i<12; i++) {
                HourEntry.Items.Add(i.ToString());
            }
            for(int i = 0; i<60; i++) {
                MinEntry.Items.Add(i.ToString());
            }
            HourEntry.SelectedIndex = 0;
            MinEntry.SelectedIndex = 0;
        }

        void lv_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedItem = lv.SelectedItem as RunningData;
            if(selectedItem != null) {
                RunDate.Date = selectedItem.DateRun;
                HourEntry.SelectedItem = selectedItem.Dur.Hours.ToString();
                MinEntry.SelectedItem = selectedItem.Dur.Minutes.ToString();
                RunDist.Text = Preferences.Get("MilesPref", true) ? selectedItem.Dist.ToString("Miles") : RunningData.MtoK(selectedItem.Dist).ToString("Km");
            }
        }

        void ButtonAdd_Clicked(System.Object sender, System.EventArgs e)
        {
            var addRun = new RunningData { DateRun = RunDate.Date,
                Dur = new TimeSpan(Int32.Parse((string)HourEntry.SelectedItem), Int32.Parse((string)MinEntry.SelectedItem), 0),
                Dist = DistEntry.Text == "" ? 0 : getConvertedDist(float.Parse((string)DistEntry.Text)) };
            Database.conn.Insert(addRun);
            RefreshLV();
        }

        void ButtonUpdate_Clicked(System.Object sender, System.EventArgs e)
        {
            var originalRun = lv.SelectedItem as RunningData;
            var overrideRun = new RunningData { DateRun = RunDate.Date,
                                                Dur = new TimeSpan(Int32.Parse((string)HourEntry.SelectedItem), Int32.Parse((string)MinEntry.SelectedItem), 0),
                                                Dist = DistEntry.Text == "" ? 0 : getConvertedDist(float.Parse((string)DistEntry.Text)) };
            overrideRun.ID = originalRun.ID;
            Database.conn.Update(originalRun);
            RefreshLV();
        }
        

        void ButtonDelete_Clicked(System.Object sender, System.EventArgs e)
        {
            var selectedItem = lv.SelectedItem as RunningData;
            if(selectedItem != null) {
                int temp = Database.conn.Delete(selectedItem);
                if (temp > 0) { lv.SelectedItem = null; RefreshLV(); }
            }
        }

        // Refresh/Reload ListView on LogPage
        private void RefreshLV() {
            lv.ItemsSource = Database.conn.Table<RunningData>().ToList().OrderBy(i => i.DateRun);
        }

        // Refreshes LogPage
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshLV();
            RunDist.Text = Preferences.Get("MilesPref", true) ? "Dist. Miles" : "Dist. Km";
        }

        private static float getConvertedDist(float d)
        {
            if (Preferences.Get("MilesPref", true)) return d;
            return RunningData.KtoM(d);
        }

    }
}
