using MobileClient.Views;
using MobileClient.Views.Auth;
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
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        public void InitLocation()
        {
            if ((bool)Application.Current.Properties["login"])
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
