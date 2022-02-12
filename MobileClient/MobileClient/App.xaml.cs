using MobileClient.Repos;
using MobileClient.Services;
using MobileClient.Services.Auth;
using MobileClient.Services.Settings;
using MobileClient.Views;
using MobileClient.Views.Auth;
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
            DependencyService.Register<MockDataStore>();

            var authToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"; //LocalPropsProviderService.AuthToken;
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
