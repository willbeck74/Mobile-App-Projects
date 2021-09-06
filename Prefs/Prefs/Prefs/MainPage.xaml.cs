﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Prefs {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();

			if (!Preferences.ContainsKey("MetricMode"))
				Preferences.Set("MetricMode", false);
			metricSwitch.IsToggled = Preferences.Get("MetricMode", false);

			if (!Preferences.ContainsKey("Birth"))
				Preferences.Set("Birth", new DateTime(2000, 1, 1, 1, 0, 0));
            DOB.Date = Preferences.Get("Birth", new DateTime(2000, 1, 1, 1, 0, 0));

			if (!Preferences.ContainsKey("Experience"))
				Preferences.Set("Experience", 0.5);
			Experience.Value = Preferences.Get("Experience", Experience.Value);
		}
		private void MetricSwitchToggled(object sender, ToggledEventArgs e) {
			Preferences.Set("MetricMode", metricSwitch.IsToggled);
		}
		private void DOBToggled(object sender, DateChangedEventArgs e)
        {
			Preferences.Set("Birth", DOB.Date);
        }

        void Experience_ValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
			Preferences.Set("Experience", Experience.Value);
        }
    }
}
