using MobileClient.Services;
using MobileClient.Views;
using MobileClient.Views.Auth;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            ApiClient.Connect();

            if (!Application.Current.Properties.ContainsKey("login"))
            {
                Application.Current.Properties.Add("authToken", string.Empty);
                Application.Current.Properties.Add("login", false);
                MainPage = new NavigationPage(new EnterPage());
            }
            else
            {
                if ((bool)Application.Current.Properties["login"])
                {
                    MainPage = new AppShell();
                }
                else
                {
                    MainPage = new NavigationPage(new EnterPage());
                }
            }
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
