using MobileClient.Services.Auth;
using MobileClient.Services.Settings;
using MobileClient.Views;
using MobileClient.Views.Auth;
using MobileClient.Views.Electives;
using MobileClient.Views.Materials;
using MobileClient.Views.Medals;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(MaterialsList), typeof(MaterialsList));
            Routing.RegisterRoute(nameof(MedalsList), typeof(MedalsList));
            Routing.RegisterRoute(nameof(AddEditMedal), typeof(AddEditMedal));
            Routing.RegisterRoute(nameof(AddEditMaterial), typeof(AddEditMaterial));
            Routing.RegisterRoute(nameof(AddEditElective), typeof(AddEditElective));
        }

        public async Task InitLocationAsync(string authToken)
        {
            if (authToken.Equals(string.Empty) ||
                !LocalPropsProviderService.Login)
            {
                await Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }

        private async void OnLogOutItemClicked(object sender, EventArgs e)
        {
            await AuthService.Logout();

            await Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
