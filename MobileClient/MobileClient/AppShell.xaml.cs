using MobileClient.Views;
using System;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            if (!Application.Current.Properties.ContainsKey("login"))
            {
                Application.Current.Properties.Add("authToken", string.Empty);
                Application.Current.Properties.Add("login", false);
                await Shell.Current.GoToAsync("//EnterPage");
            }
            else
            {
                if ((bool)Application.Current.Properties["login"])
                {
                    await Shell.Current.GoToAsync("//AboutPage");
                }
                else
                {
                    await Shell.Current.GoToAsync("//EnterPage");
                }
            }
        }
    }
}
