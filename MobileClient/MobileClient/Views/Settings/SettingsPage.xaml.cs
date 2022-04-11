using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            entryIp.Text = GlobalSettings.ServerIp;
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryIp.Text))
                GlobalSettings.ServerIp = entryIp.Text;

            await Navigation.PopAsync();
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}