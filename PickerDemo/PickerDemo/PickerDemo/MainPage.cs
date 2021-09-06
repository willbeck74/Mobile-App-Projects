using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PickerDemo {
	public class School {
		public String name;
		public int grade;
		public School(String n, int g) {
			name = n;
			grade = g;
		}
		public override string ToString() {
			return String.Format("{0} ({1})", name, grade);
		}
	}
	public class MainPage : ContentPage {

		Label sizeLabel = new Label { Text = "Univ of Texas" };
		Picker schoolPicker;
		WebView webview;
		public MainPage() {
			StackLayout panel = new StackLayout();

			schoolPicker = new Picker();
			schoolPicker.Items.Add("Miami Uni");
			schoolPicker.Items.Add("Kansas Uni");
			schoolPicker.Items.Add("Univ of Texas");
			schoolPicker.Items.Add("SMU");
			schoolPicker.SelectedIndex = 2;
			schoolPicker.SelectedIndexChanged += schoolPicker_SelectedIndexChanged;
			schoolPicker.SelectedIndexChanged += ConfigureWebsiteView;

			StackLayout sizePanel = new StackLayout();
			sizePanel.Children.Add(sizeLabel);
			sizePanel.Children.Add(schoolPicker);

			webview = new WebView
			{
				Source = new UrlWebViewSource { Url = "https://www.utexas.edu/" },
				VerticalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 200
			};


			Frame sizeFrame = new Frame();
			sizeFrame.Content = sizePanel;
			sizeFrame.BorderColor = Color.Black;

			panel.Children.Add(sizeFrame);
			panel.Children.Add(webview);
			Content = panel;
		}

		private void schoolPicker_SelectedIndexChanged(object sender, EventArgs e) {
			sizeLabel.Text = (String)schoolPicker.SelectedItem;
		}

		private void ConfigureWebsiteView(object sender, EventArgs e)
		{
			String[] webLinks = { "https://www.miamioh.edu", "https://ku.edu/", "https://www.utexas.edu/", "https://www.smu.edu/" };

			webview.Source = new UrlWebViewSource { Url = webLinks[schoolPicker.SelectedIndex] };
		}

	}
}
