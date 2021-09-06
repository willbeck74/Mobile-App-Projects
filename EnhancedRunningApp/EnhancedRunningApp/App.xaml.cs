using System;
using EnhancedRunningApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnhancedRunningApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database.DataConnection();
            RunLoadData.LoadData();
            Database.LoadData();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
