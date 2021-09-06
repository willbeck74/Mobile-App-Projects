using EnhancedRunningApp.Pages;
using Xamarin.Forms;

namespace EnhancedRunningApp
{
    public partial class MainPage : TabbedPage
    {
        [System.Obsolete]
        public MainPage()
        {
            InitializeComponent();

            //Declaration of navigations
            NavigationPage navPage1 = new NavigationPage(new LogPage());
           

            NavigationPage navPage2 = new NavigationPage(new SummaryPage());
            

            NavigationPage navPage3 = new NavigationPage(new SettingPage());

            navPage1.IconImageSource = "log.png";
            navPage2.IconImageSource = "summary.png";
            navPage3.IconImageSource = "settings.png";
            
            navPage1.Title = "Log";
            navPage2.Title = "Summary";
            navPage3.Title = "Settings";

            Children.Add(navPage1);
            Children.Add(navPage2);
            Children.Add(navPage3);



        }
    }
}
