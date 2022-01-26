using MobileClient.Services.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await AuthService.TrySignIn(new Models.Auth.SignInModel
            {
                Login = entryLogin.Text,
                Password = entryPassword.Text
            });

            if (result.Equals(string.Empty))
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

            errorField.IsVisible = true;
            errorField.Text = result;
        }
    }
}