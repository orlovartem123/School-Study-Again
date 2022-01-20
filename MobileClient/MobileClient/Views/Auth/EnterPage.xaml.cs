using MobileClient.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterPage : ContentPage
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        private async void ToLoginPage(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            await Navigation.PushAsync(new LoginPage());
        }

        private async void ToRegisterPage(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}