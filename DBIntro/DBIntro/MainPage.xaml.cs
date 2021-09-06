using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Xamarin.Essentials;

namespace DBIntro
{
    public partial class MainPage : ContentPage
    {
        SQLiteConnection conn;
        public MainPage()
        {
            InitializeComponent();

            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, "Personnel.db");
            conn = new SQLiteConnection(fname);
            conn.CreateTable<User>();
            lv.ItemsSource = conn.Table<User>().ToList();

            conn.CreateTable<Person>();
            lv2.ItemsSource = conn.Table<Person>().ToList();

        }

        void addUser_Clicked(System.Object sender, System.EventArgs e)
        {
            User newUser = new User { Username = name.Text };
            conn.Insert(newUser);
            lv.ItemsSource = conn.Table<User>().ToList();
        }

        void addPerson_Clicked(System.Object sender, System.EventArgs e)
        {
            Person newPerson = new Person
            {
                Name = personNameEntry.Text,
                Gender = isFemale.IsChecked,
                DOB = dateBirth.Date,
                SSN = socialEntry.Text,
                Income = Int32.Parse(incomeEntry.Text)
            };
            conn.Insert(newPerson);
            lv2.ItemsSource = conn.Table<Person>().ToList();
        }
    }
}
