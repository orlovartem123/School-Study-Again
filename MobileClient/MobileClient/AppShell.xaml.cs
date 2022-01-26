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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(MaterialsList), typeof(MaterialsList));
            Routing.RegisterRoute(nameof(MedalsList), typeof(MedalsList));
            Routing.RegisterRoute(nameof(AddEditMedal), typeof(AddEditMedal));
            Routing.RegisterRoute(nameof(AddEditMaterial), typeof(AddEditMaterial));
            Routing.RegisterRoute(nameof(AddEditElective), typeof(AddEditElective));
            Routing.RegisterRoute(nameof(BindActivityWithElectives), typeof(BindActivityWithElectives));
        }

        public void InitLocation()
        {
            if (!(bool)Application.Current.Properties["login"])
                Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnLogOutItemClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["login"] = false;
            Application.Current.Properties["authToken"] = string.Empty;

            await Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
