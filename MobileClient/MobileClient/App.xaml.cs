using MobileClient.Services;
using MobileClient.Views;
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

            MainPage=new AppShell();
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
