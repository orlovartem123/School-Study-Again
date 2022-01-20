using MobileClient.Views;
using MobileClient.Views.Auth;
using System;
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
            Routing.RegisterRoute(nameof(EnterPage), typeof(EnterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //if (!Application.Current.Properties.ContainsKey("login"))
            //{
            //    Application.Current.Properties.Add("authToken", string.Empty);
            //    Application.Current.Properties.Add("login", false);
                await Current.GoToAsync($"//{nameof(EnterPage)}");
            //}
            //else
            //{
            //    if ((bool)Application.Current.Properties["login"])
            //    {
            //        await Current.GoToAsync("//AboutPage");
            //    }
            //    else
            //    {
            //        await Current.GoToAsync($"//{nameof(EnterPage)}");
            //    }
            //}
        }
    }
}
