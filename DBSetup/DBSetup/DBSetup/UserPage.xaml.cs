using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSetup {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPage : ContentPage {
		public UserPage() {
			InitializeComponent();
		}

		private void OnQueryClicked(object sender, EventArgs e) {
			Button b = (Button)sender;
			var theTable = MainPage.conn.Table<CreateDB.User>();
			switch (b.Text) {
				case "Q1":
					lv.ItemsSource = theTable.ToList();
					break;
				case "Q2":
                    lv.ItemsSource = theTable.AsEnumerable().Where(s => s.DateCreated.Year >= 2010).ToList();
					break;
				case "Q3":
					// SQLite has limitations in what can be put into "where". To overcome these limitations,
					// convert, using AsEnumerable(), so that the basic C# methods work.
					//lv.ItemsSource = theTable.Where(s => s.Username[0] == 'j').ToList();
					lv.ItemsSource = theTable.AsEnumerable().Where(s => s.Username[0] == 'j').ToList();
					break;
				case "Q4":
					break;
				case "Q5":
					break;
			}

		}
	}
}