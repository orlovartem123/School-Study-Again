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

            if (!Current.Properties.ContainsKey("login"))
            {
                Current.Properties.Add("authToken", string.Empty);
                Current.Properties.Add("login", false);
            }

            var shell = new AppShell();
            MainPage = shell;

            shell.InitLocation();
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
