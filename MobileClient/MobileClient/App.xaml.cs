using MobileClient.Repos;
using MobileClient.Services.Auth;
using MobileClient.Services.Settings;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class App : Application
    {
        private static AppLocalPropsRepository database;

        public static AppLocalPropsRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppLocalPropsRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), GlobalSettings.DATABASE_NAME));

                    database.InitDb();
                }
                return database;
            }

        }
        public App()
        {
            InitializeComponent();

            var authToken = /*LocalPropsProviderService.AuthToken ??*/ GlobalSettings.ExampleBearer;
            LocalPropsProviderService.Login = AuthService.IsAuthenticatedAsync(authToken).Result;
            var shell = new AppShell();
            MainPage = shell;

            Task.Run(() => shell.InitLocationAsync(authToken));
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
