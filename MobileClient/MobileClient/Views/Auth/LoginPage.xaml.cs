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

            entryLogin.Text = "admin@gmail.com";
            entryPassword.Text = "Aa123!";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var errors = new StringBuilder();

            var model = new Models.Auth.SignInModel
            {
                Login = entryLogin.Text,
                Password = entryPassword.Text
            };

            errors.Append(model.Validate());

            if (string.IsNullOrEmpty(errors.ToString()))
            {
                errors.Append(await AuthService.TrySignInAsync(model));
                if (string.IsNullOrEmpty(errors.ToString()))
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }

            errorField.IsVisible = true;
            errorField.Text = errors.ToString();
        }
    }
}